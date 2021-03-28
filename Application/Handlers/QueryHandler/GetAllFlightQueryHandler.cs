using Application.Queries;
using Application.Response;
using Core.Entity;
using Core.Repository.Base;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers.QueryHandler
{
    public class GetAllFlightQueryHandler : IRequestHandler<GetAllFlightQuery, QueryResponse<object>>
    {
        private readonly IRepository<Flight> _repository;

        public GetAllFlightQueryHandler(IRepository<Flight> repository)
        {
            _repository = repository;
        }

        public Task<QueryResponse<object>> Handle(GetAllFlightQuery query, CancellationToken cancellationToken)
        {
            var response = new QueryResponse<object>();

            try
            {
                var flight = this._repository.GetAsync(x => x.AirlineName.StartsWith("s"), x => x.OrderBy(y => y.AirlineName), "FlightDetails")
                    .Result
                    .Skip(query.PageSize * query.PageNumber)
                    .Take(query.PageSize);
                response.Success = true;
                response.Data = flight;
                response.TotalCount = flight.Count();
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Success = false;
                return Task.FromResult(response);
            }
        }
    }
    public class GetAllFlightQueryValidator : AbstractValidator<GetAllFlightQueryHandler>
    {
        public GetAllFlightQueryValidator()
        {
            //RuleFor(m => m.UserName).NotEmpty();
        }
    }
}
