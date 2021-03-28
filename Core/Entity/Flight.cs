using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class Flight //: BaseEntity
    {
        [Key]
        // public int Id { get; set; }
        public Guid Id { get; set; }
        public string AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string FromLocation { get; set; }
        public string TOLocation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Duration { get; set; }
        public int TotalSeats { get; set; }
        [ForeignKey("FlightDetails")]
        public Guid FlightId { get; set; }
        public FlightDetails FlightDetails { get; set; }
    }

    //public class BaseEntity
    //{
    //    public int ID { get; set; }
    //}
}
