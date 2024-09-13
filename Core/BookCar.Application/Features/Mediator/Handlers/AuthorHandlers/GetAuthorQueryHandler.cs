using BookCar.Application.Features.Mediator.Queries.AuthorQueries;
using BookCar.Application.Features.Mediator.Results.AuthorResults;
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
    public class GetAuthorQueryHandler(IRepository<Author> _repository) : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select( x => new GetAuthorQueryResult
            {
                AuthorId = x.AuthorId,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Description = x.Description,
            }).ToList();
        }
    }
}
