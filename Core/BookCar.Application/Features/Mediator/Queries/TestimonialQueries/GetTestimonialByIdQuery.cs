using BookCar.Application.Features.Mediator.Results.TestimonialResults;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery(int id) : IRequest<GetTestimonialByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
