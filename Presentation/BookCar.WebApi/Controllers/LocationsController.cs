using BookCar.Application.Features.Mediator.Commands.LocationCommands;
using BookCar.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            var values = await _mediator.Send(new GetLocationQuery());
            return Ok(values);
        }
        

        [HttpPost("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var value = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Lokasyon Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteLocation(RemoveLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Lokasyon Başarıyla Silindi!");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Lokasyon Başarıyla Güncellendi!");
        }
    }
}
