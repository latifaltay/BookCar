using BookCar.Application.Features.Mediator.Commands.AuthorCommands;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class CreateAuthorCommandHandler(IRepository<Author> _repository) : IRequestHandler<CreateAuthorCommand>
    {
        public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Author
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
            });
        }
    }
}
