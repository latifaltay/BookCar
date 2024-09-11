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
    public class RemoveTestimonialCommandHandler(IRepository<Testimonial> _repository) : IRequestHandler<RemoveTestimonialCommand>
    {
        public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
