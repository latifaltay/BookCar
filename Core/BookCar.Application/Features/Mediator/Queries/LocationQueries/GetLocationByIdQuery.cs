using BookCar.Application.Features.Mediator.Results.LocationResults;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationByIdQuery(int id) : IRequest<GetLocationByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
