using BookCar.Application.Features.Mediator.Commands.CommentCommands;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class CreateCommentHandler(IRepository<Comment> _repository) : IRequestHandler<CreateCommentCommand>
    {
        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Comment
            {
                Description = request.Description,
                BlogId = request.BlogId,
                CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
                Name = request.Name,
                Email = request.Email
            });
        }
    }
}
