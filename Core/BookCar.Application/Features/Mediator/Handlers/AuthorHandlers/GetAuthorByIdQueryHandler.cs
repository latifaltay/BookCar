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
    public class GetAuthorByIdQueryHandler(IRepository<Author> _repository) : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetAuthorByIdQueryResult
            {
                AuthorId = value.AuthorId,
                Name = value.Name,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
            };
        }
    }
}
