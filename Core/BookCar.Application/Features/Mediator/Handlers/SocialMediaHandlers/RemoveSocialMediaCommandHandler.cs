using BookCar.Application.Features.Mediator.Commands.ServiceCommands;
using BookCar.Application.Features.Mediator.Commands.SocialMediaCommands;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class RemoveSocialMediaCommandHandler(IRepository<SocialMedia> _repository) : IRequestHandler<RemoveSocialMediaCommand>
    {
        public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
