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
    public class UpdateSocialMediaCommandHandler(IRepository<SocialMedia> _repository) : IRequestHandler<UpdateSocialMediaCommand>
    {
        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.SocialMediaId);
            values.SocialMediaId = request.SocialMediaId;
            values.Name = request.Name;
            values.Url = request.Url;
            values.Icon = request.Icon;
            await _repository.UpdateAsync(values);
        }
    }
}
