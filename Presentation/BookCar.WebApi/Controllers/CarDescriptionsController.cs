using BookCar.Application.Features.Mediator.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarDescriptionsController(IMediator _mediator) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> CarDescriptionByCarId(int id)
		{
			var values = await _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
			return Ok(values);
		}
	}
}
