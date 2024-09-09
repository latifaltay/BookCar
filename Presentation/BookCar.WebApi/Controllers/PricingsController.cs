using BookCar.Application.Features.Mediator.Commands.LocationCommands;
using BookCar.Application.Features.Mediator.Commands.PricingCommands;
using BookCar.Application.Features.Mediator.Queries.LocationQueries;
using BookCar.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> GetPricing(int id)
        {
            var value = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Fiyat Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> DeletePricing(RemovePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Fiyat Başarıyla Silindi!");
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Fiyat Başarıyla Güncellendi!");
        }
    }
}
