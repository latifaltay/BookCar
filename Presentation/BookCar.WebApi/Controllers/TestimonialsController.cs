using BookCar.Application.Features.Mediator.Commands.SocialMediaCommands;
using BookCar.Application.Features.Mediator.Commands.TestimonialCommands;
using BookCar.Application.Features.Mediator.Queries.SocialMediaQueries;
using BookCar.Application.Features.Mediator.Queries.TestimonialQueries;
using BookCar.Application.Features.Mediator.Results.TestimonialResults;
using BookCar.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _mediator.Send(new GetTestimonialQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var value = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _mediator.Send(new RemoveTestimonialCommand(id));
            return Ok("Referans Başarıyla Silindi!");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans Başarıyla Güncellendi!");
        }
    }
}
