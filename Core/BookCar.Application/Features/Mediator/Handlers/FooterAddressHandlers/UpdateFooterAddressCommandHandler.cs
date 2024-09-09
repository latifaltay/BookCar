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
    public class UpdateFooterAddressCommandHandler(IRepository<FooterAddress> _repository) : IRequestHandler<UpdateFooterAddressCommand>
    {
        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FooterAddressId);
            value.Description = request.Description;
            value.Address = request.Address;
            value.Phone = request.Phone;
            value.Email = request.Email;
            await _repository.UpdateAsync(value);
        }
    }
}
