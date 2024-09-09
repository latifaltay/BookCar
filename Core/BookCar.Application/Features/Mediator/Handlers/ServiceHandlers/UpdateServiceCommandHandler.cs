using BookCar.Application.Features.Mediator.Commands.ServiceCommands;
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
    public class UpdateServiceCommandHandler(IRepository<Service> _repository) : IRequestHandler<UpdateServiceCommand>
    {
        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ServiceId);
            value.Title = request.Title;
            value.Description = request.Description;
            value.IconUrl = request.IconUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
