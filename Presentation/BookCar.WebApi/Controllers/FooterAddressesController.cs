using BookCar.Application.Features.Mediator.Commands.FeatureCommands;
using BookCar.Application.Features.Mediator.Commands.FooterAddressCommands;
using BookCar.Application.Features.Mediator.Queries.FeatureQueries;
using BookCar.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Altbilgi Başarıyla Eklendi!");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(RemoveFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Altbilgi Başarıyla Silindi!");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Altbilgi Başarıyla Güncellendi!");
        }
    }
}
