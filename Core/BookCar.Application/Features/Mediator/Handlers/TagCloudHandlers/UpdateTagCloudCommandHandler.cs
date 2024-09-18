using BookCar.Application.Features.Mediator.Commands.TagCloudCommands;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class UpdateAuthorCommandHandler(IRepository<TagCloud> _repository) : IRequestHandler<UpdateTagCloudCommand>
    {
        public async Task Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TagCloudId);
            value.Title = request.Title;
            value.BlogId = request.BlogId;
            await _repository.UpdateAsync(value);
        }
    }
}
