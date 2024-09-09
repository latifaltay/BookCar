using BookCar.Application.Features.Mediator.Queries.FeatureQueries;
using BookCar.Application.Features.Mediator.Queries.FooterAddressQueries;
using BookCar.Application.Features.Mediator.Results.FeatureResults;
using BookCar.Application.Features.Mediator.Results.FooterAddressResult;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler(IRepository<FooterAddress> _repository) : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult 
            {
                Address = x.Address,
                Description = x.Description,
                Email = x.Email,
                FooterAddressId = x.FooterAddressId,
                Phone = x.Phone,
            }).ToList();
        }
    }
}
