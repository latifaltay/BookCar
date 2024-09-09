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
    public class GetServiceByIdQueryHandler(IRepository<Service> _repository) : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetServiceByIdQueryResult
            {
                ServiceId = value.ServiceId,
                Description = value.Description,
                IconUrl = value.IconUrl,
                Title = value.Title,
            };
        }
    }
}
