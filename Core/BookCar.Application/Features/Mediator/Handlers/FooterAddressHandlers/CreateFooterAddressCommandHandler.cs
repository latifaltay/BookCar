using BookCar.Application.Features.Mediator.Commands.FooterAddressCommands;
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
    public class CreateFooterAddressCommandHandler(IRepository<FooterAddress> _repository) : IRequestHandler<CreateFooterAddressCommand>
    {
        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new FooterAddress 
            {
                Address = request.Address,
                Description = request.Description,
                Email = request.Email,
                Phone = request.Phone,
            });
        }
    }
}
