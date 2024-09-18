using BookCar.Application.Features.Mediator.Commands.TagCloudCommands;
using BookCar.Application.Features.Mediator.Commands.TestimonialCommands;
using BookCar.Application.Features.Mediator.Queries.TagCloudQueries;
using BookCar.Application.Features.Mediator.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TagCloudList()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> GetTagCloud(int id)
        {
            var value = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("TagCloud Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteTagCloud(RemoveTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("TagCloud Başarıyla Silindi!");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("TagCloud Başarıyla Güncellendi!");
        }
    }
}
