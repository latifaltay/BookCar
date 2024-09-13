using BookCar.Application.Features.Mediator.Commands.BlogCommands;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler(IRepository<Blog> _repository) : IRequestHandler<UpdateBlogCommand>
    {
        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BlogId);
            values.AuthorId = request.AuthorId;
            values.CreatedDate = request.CreatedDate;
            values.CategoryId = request.CategoryId;
            values.CoverImageUrl = request.CoverImageUrl;
            values.Title = request.Title;
            await _repository.UpdateAsync(values);
        }
    }
}
