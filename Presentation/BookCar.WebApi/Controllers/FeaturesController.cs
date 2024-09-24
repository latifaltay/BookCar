using BookCar.Application.Features.Mediator.Commands.FeatureCommands;
using BookCar.Application.Features.Mediator.Handlers.FeatureHandlers;
using BookCar.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _mediator.Send(new GetFeatureQuery());
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var value = await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Özellik Başarıyla Eklendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Özellik Başarıyla Silindi!");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command) 
        {
            await _mediator.Send(command);
            return Ok("Özellik Başarıyla Güncellendi!");
        }

    }
}
