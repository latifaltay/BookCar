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
    public class GetPricingQueryHandler(IRepository<Pricing> _repository) : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetPricingQueryResult 
            {
                PricingId = x.PricingId,
                Name = x.Name,
            }).ToList();
        }
    }
}
