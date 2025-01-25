// See https://aka.ms/new-console-template for more information
using AdvGarage;


//ParkigGarage
//ParkingSpots
//BasePrice
//MaxPrice
//List<Vehicles>
//Vehical 
//Model
//Plate
//CheckinTime
//CheckOutTime
//--GetHours()
//--Checkin(Vehicle vehical)
//--Checkout(string plate)
//GetPresentVehicleList
//GetAvailableParkingSpots
//--CheckIfPresent (string plate)
//--GetSummary()
//GetInvoice(string plate)
try
{
    Vehicle vehicle = new Vehicle()
    {
        Model = "Audi A6",
        Plate = "AA123BB",
        CheckinTime = new DateTime(2025, 01, 19, 13, 00, 00)
    };

    Vehicle vehicle2 = new Vehicle()
    {
        Model = "Audi A4",
        Plate = "AA345BB",
        CheckinTime = new DateTime(2025, 01, 19, 12, 00, 00)
    };

    Vehicle vehicle3 = new Vehicle()
    {
        Model = "Audi A6",
        Plate = "AA567BB",
        CheckinTime = new DateTime(2025, 01, 19, 6, 00, 00)
    };
    Vehicle vehicle4 = new Vehicle()
    {
        Model = "Audi Q5",
        Plate = "AA890BB",
        CheckinTime = new DateTime(2025, 01, 19, 9, 45, 00)
    };

    ParkingGarage parkingGarage = new ParkingGarage();
    parkingGarage.Checkin(vehicle);
    parkingGarage.Checkin(vehicle2);
    parkingGarage.Checkin(vehicle3);
    parkingGarage.GetInvoice(vehicle.Plate);
    parkingGarage.GetInvoice(vehicle2.Plate);
    parkingGarage.GetInvoice(vehicle3.Plate);
    parkingGarage.Checkout("AA123BB");

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
