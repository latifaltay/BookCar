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
    public class GetAllBlogsWithAuthorQueryHandler(IBlogRepository _repository) : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetBlogsWithAuthors();
            return values.Select(x => new GetAllBlogsWithAuthorQueryResult 
            {
                AuthorId = x.AuthorId,
                AuthorName = x.Author.Name,
                BlogId = x.BlogId,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                Title = x.Title,
                BlogDescription = x.BlogDescription,
            }).ToList();
        }
    }
}
