using BookCar.Application.Features.Mediator.Queries.ServiceQueries;
using BookCar.Application.Features.Mediator.Results.ServiceResults;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler(IRepository<Service> _repository) : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetServiceQueryResult 
            {
                ServiceId = x.ServiceId,
                Description = x.Description,
                IconUrl = x.IconUrl,
                Title = x.Title,
            }).ToList();
        }
    }
}
