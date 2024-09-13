using BookCar.Application.Features.Mediator.Queries.LocationQueries;
using BookCar.Application.Features.Mediator.Results.LocationResults;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetAuthorByIdQueryHandler(IRepository<Location> _repository) : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetLocationByIdQueryResult 
            {
                LocationId = value.LocationId,
                Name = value.Name,
            };
        }
    }
}
