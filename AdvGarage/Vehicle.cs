using System.ComponentModel.DataAnnotations;

namespace AdvGarage
{   
    internal class Vehicle
    {
        [Required]
        public string Model { get; set; }
        [MaxLength(100)]
        public string Plate { get; set; }
        public DateTime CheckinTime { get; set; }
        public DateTime? CheckoutTime { get; set; }
        public int GetHours()
        {
            DateTime checkoutTime = CheckoutTime ?? DateTime.Now;
            TimeSpan timeSpan = checkoutTime - CheckinTime;
            double hours = timeSpan.TotalHours;
            if (hours % 1 != 0)
            {
                hours = hours + 1;
            }
            int result = Convert.ToInt32(Math.Floor(hours));
            return result;
        }
    }
}
