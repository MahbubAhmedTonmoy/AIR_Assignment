using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    public class TicketInfo
    {
        [Key]
        public int TicketId { get; set; }
        public string Status { get; set; }
        [ForeignKey("Flight")]
        public Guid FlightId { get; set; }
        public Flight Flight { get; set; }
        [ForeignKey("PassengerProfile")]
        public string PassengerId { get; set; }
        public PassengerProfile PassengerProfile { get; set; }
    }
}
