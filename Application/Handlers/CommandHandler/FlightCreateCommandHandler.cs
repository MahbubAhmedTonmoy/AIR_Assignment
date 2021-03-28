using Application.Command;
using Application.Response;
using AutoMapper;
using Core.Entity;
using Core.Repository.Base;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.CommandHandler
{
    public class FlightCreateCommandHandler : IRequestHandler<FlightCreateCommand, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Flight> _flightrepository;
        private readonly IRepository<FlightDetails> _flightDetailsrepository;
        public FlightCreateCommandHandler(IRepository<Flight> flightrepository, 
            IRepository<FlightDetails> flightDetailsrepository, 
            IMapper mapper)
        {
            _mapper = mapper;
            _flightrepository = flightrepository;
            _flightDetailsrepository = flightDetailsrepository;
        }

        public Task<CommandResponse> Handle(FlightCreateCommand command, CancellationToken cancellationToken)
        {
            var response = new CommandResponse();
            try
            { var itemID = Guid.NewGuid();
                var flightDetails = new FlightDetails
                {
                    FlightId = itemID,
                    FlightDate = command.FlightDate,
                    AvailableSeats = command.AvailableSeats,
                    Price = command.Price
                };

                var entity2 = this._flightDetailsrepository.AddAsync(flightDetails);
                var flight = new Flight
                {
                    Id = Guid.NewGuid(),
                    AirlineId = command.AirlineId,
                    AirlineName = command.AirlineName,
                    FromLocation = command.FromLocation,
                    TOLocation = command.TOLocation,
                    DepartureTime = command.DepartureTime,
                    ArrivalTime = command.ArrivalTime,
                    Duration = command.Duration,
                    TotalSeats = command.TotalSeats,
                    FlightId = itemID
                };
                var entity = this._flightrepository.AddAsync(flight);

                
                response.Success = true;
                return Task.FromResult(response);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                return Task.FromResult(response);
            }
        }
    }
    public class FlightCreateCommandValidator : AbstractValidator<FlightCreateCommand>
    {
        public FlightCreateCommandValidator()
        {
            RuleFor(m => m.AirlineId).NotEmpty();
            RuleFor(m => m.AirlineName).NotEmpty();
        }
    }
}
