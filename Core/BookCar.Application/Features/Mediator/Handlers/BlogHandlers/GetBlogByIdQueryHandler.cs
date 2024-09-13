using BookCar.Application.Features.Mediator.Queries.BlogQueries;
using BookCar.Application.Features.Mediator.Results.BlogResults;
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
    public class GetBlogByIdQueryHandler(IRepository<Blog> _repository) : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult 
            {
                AuthorId = value.AuthorId,
                BlogId = value.BlogId,
                CategoryId = value.CategoryId,
                CoverImageUrl = value.CoverImageUrl,
                CreatedDate = value.CreatedDate,
                Title = value.Title,
            };
        }
    }
}
