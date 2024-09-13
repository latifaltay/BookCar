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
    public class GetAuthorQueryHandler(IRepository<Location> _repository) : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select( x => new GetLocationQueryResult 
            {
                LocationId = x.LocationId,
                Name = x.Name,
            }).ToList();
        }
    }
}
