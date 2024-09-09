using BookCar.Application.Features.Mediator.Queries.FooterAddressQueries;
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
    public class GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> _repository) : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetFooterAddressByIdQueryResult 
            {
                Address = value.Address,
                Phone = value.Phone,
                Description = value.Description,
                Email = value.Email,
                FooterAddressId = value.FooterAddressId,
            };
        }
    }
}
