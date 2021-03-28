using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entity
{
    public class FlightDetails
    {
        [Key]
        //public int FlightId { get; set; }
        public Guid FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public double Price { get; set; }
        public int AvailableSeats { get; set; }
    }
}
