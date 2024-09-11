using BookCar.Application.Features.Mediator.Queries.TestimonialQueries;
using BookCar.Application.Features.Mediator.Results.TestimonialResults;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler(IRepository<Testimonial> _repository) : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTestimonialQueryResult 
            {
                TestimonialId = x.TestimonialId,
                Name = x.Name,
                Title = x.Title,
                Comment = x.Comment,
                ImageUrl = x.ImageUrl,
            }).ToList();
        }
    }
}
