using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdvGarage
{
    internal class ParkingGarage
    {
        public int ParkingSpots { get; private set; } = 3;
        public decimal BasePrice { get; private set; } = 100;
        public decimal MaxPrice { get; private set; } = 500;
        public List<Vehicle> Vehicles { get; private set; } = [];
        public void Checkin(Vehicle vehicle)
        {
            if (vehicle == null ||
                vehicle.Model == null ||
                vehicle.Plate == null ||
                vehicle.CheckinTime == null)
            {
                throw new ArgumentNullException("INVALID_ARGUMENTS");
            }
            var foundVehicle = CheckIfPresent(vehicle.Plate);
            if (foundVehicle != null)
            {
                throw new Exception("VEHICLE IS ALREADY PRESENT");
            }
            if (Vehicles.Count() >= ParkingSpots)
            {
                throw new Exception("PARKING LOT IS FULL");
            }

            vehicle.Plate = vehicle.Plate.Replace(" ", "");
            Vehicles.Add(vehicle);
            Console.WriteLine($"Checkin {vehicle.Plate} - {vehicle.Model}");
        }
        public void Checkout(string plate)
        {
            Vehicle? vehicle = CheckIfPresent(plate);           
            if (vehicle != null)
            {
                Vehicles.Remove(vehicle);
                Console.WriteLine($"Checkout {vehicle.Plate} - {vehicle.Model}");
            }
        }

        public Vehicle? CheckIfPresent(string plate)
        {
            Vehicle? vehicle = null;
            var cleanPlate = plate.Replace(" ", "");
            foreach (var item in Vehicles)
            {
                if (string.Equals(cleanPlate, item.Plate, StringComparison.OrdinalIgnoreCase))
                {
                    vehicle = item;
                    break;
                }
            }
            return vehicle;
        }
        public Dictionary<string, int> GetSummary()
        {
            var dictionary = new Dictionary<string, int>();
            foreach (var item in Vehicles)
            {
                if (dictionary.ContainsKey(item.Model))
                {
                    dictionary[item.Model] += 1;
                }
                else
                {
                    dictionary.Add(item.Model, 1);
                }
            }
            return dictionary;
        }
        public decimal GetInvoice(string plate)
        {
            decimal total = 0;
            Vehicle? vehicle = CheckIfPresent(plate);            
            if (vehicle == null)
            {
                throw new Exception("VEHICLE IS NOT PRESENT");
            }
            int hours = vehicle.GetHours();
            total = BasePrice * hours;
            if (total >= MaxPrice)
            {
                total = MaxPrice;
            }
            Console.WriteLine($"Invoice: {hours}: (ALL{total}) {vehicle.Plate} - {vehicle.Model}");
            return total;
        }
    }
}
