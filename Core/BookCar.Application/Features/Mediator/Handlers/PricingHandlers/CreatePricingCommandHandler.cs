using BookCar.Application.Features.Mediator.Commands.PricingCommands;
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
    public class CreatePricingCommandHandler(IRepository<Pricing> _repository) : IRequestHandler<CreatePricingCommand>
    {
        public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Pricing 
            {
                Name = request.Name,
            });
        }
    }
}
