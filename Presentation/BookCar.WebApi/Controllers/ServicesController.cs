using BookCar.Application.Features.Mediator.Commands.FeatureCommands;
using BookCar.Application.Features.Mediator.Commands.ServiceCommands;
using BookCar.Application.Features.Mediator.Queries.FeatureQueries;
using BookCar.Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _mediator.Send(new GetServiceQuery());
            return Ok(values);
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis Başarıyla Eklendi!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(RemoveServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis Başarıyla Silindi!");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis Başarıyla Güncellendi!");
        }
    }
}
