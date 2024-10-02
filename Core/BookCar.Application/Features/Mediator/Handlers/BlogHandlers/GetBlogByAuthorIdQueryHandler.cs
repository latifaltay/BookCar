using BookCar.Application.Features.Mediator.Queries.BlogQueries;
using BookCar.Application.Features.Mediator.Results.BlogResults;
using BookCar.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByAuthorIdQueryHandler(IBlogRepository _repository) : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
    {
        public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBlogByAuthorId(request.Id);
            return value.Select(x => new GetBlogByAuthorIdQueryResult 
            {
                AuthorId = x.AuthorId,
                BlogId = x.BlogId,
                AuthorName = x.Author.Name,
                AuthorDescription = x.Author.Description,
                AuthorImageUrl = x.Author.ImageUrl,
            }).ToList();
        }
    }
}
