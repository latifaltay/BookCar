using BookCar.Application.Features.Mediator.Results.AuthorResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Queries.AuthorQueries
{
    public class GetAuthorByIdQuery(int id) : IRequest<GetAuthorByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
