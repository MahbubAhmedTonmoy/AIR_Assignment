using Application.Response;
using Core.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command
{
    public class FlightCreateCommand : IRequest<CommandResponse>
    {
        public string AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string FromLocation { get; set; }
        public string TOLocation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Duration { get; set; }
        public int TotalSeats { get; set; }

        //
        public DateTime FlightDate { get; set; }
        public double Price { get; set; }
        public int AvailableSeats { get; set; }
    }
}
