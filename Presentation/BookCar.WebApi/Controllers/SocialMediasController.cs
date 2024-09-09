using BookCar.Application.Features.Mediator.Commands.LocationCommands;
using BookCar.Application.Features.Mediator.Commands.SocialMediaCommands;
using BookCar.Application.Features.Mediator.Queries.LocationQueries;
using BookCar.Application.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _mediator.Send(new GetSocialMediaQuery());
            return Ok(values);
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var value = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sosyal Medya Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteSocialMedia(RemoveSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sosyal Medya Başarıyla Silindi!");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sosyal Medya Başarıyla Güncellendi!");
        }
    }
}
