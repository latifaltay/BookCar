using BookCar.Application.Features.Mediator.Queries.PricingQueries;
using BookCar.Application.Features.Mediator.Results.PricingResults;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler(IRepository<Pricing> _repository) : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetPricingByIdQueryResult 
            {
                PricingId = request.Id,
                Name = value.Name,
            };
        }
    }
}
