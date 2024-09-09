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
    internal class CreateSocialMediaCommandHandler(IRepository<SocialMedia> _repository) : IRequestHandler<CreateSocialMediaCommand>
    {
        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new SocialMedia
            {
                Name = request.Name,
                Url = request.Url,
               Icon = request.Icon, 
            });
        }
    }
}
