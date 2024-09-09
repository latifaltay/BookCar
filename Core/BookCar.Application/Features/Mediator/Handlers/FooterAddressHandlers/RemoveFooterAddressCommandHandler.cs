﻿using BookCar.Application.Features.Mediator.Commands.FooterAddressCommands;
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
    public class RemoveFooterAddressCommandHandler(IRepository<FooterAddress> _repository) : IRequestHandler<RemoveFooterAddressCommand>
    {
        public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value =await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
