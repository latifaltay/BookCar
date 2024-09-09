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
    public class CreateServiceCommandHandler(IRepository<Service> _repository) : IRequestHandler<CreateServiceCommand>
    {
        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Service 
            {
                Description = request.Description,
                IconUrl = request.IconUrl,
                Title = request.Title,
            });
        }
    }
}
