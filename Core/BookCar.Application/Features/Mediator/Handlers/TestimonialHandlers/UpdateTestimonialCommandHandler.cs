using BookCar.Application.Features.Mediator.Commands.TestimonialCommands;
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
    public class UpdateTestimonialCommandHandler(IRepository<Testimonial> _repository) : IRequestHandler<UpdateTestimonialCommand>
    {
        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TestimonialId);
            value.Title = request.Title;
            value.Comment = request.Comment;
            value.Name = request.Name;
            value.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
