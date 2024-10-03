using BookCar.Application.Features.Mediator.Commands.ReviewCommands;
using BookCar.Application.Features.Mediator.Queries.ReviewQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController(IMediator _mediator) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> ReviewListByCarId(int id)
		{
			var values = await _mediator.Send(new GetReviewByCarIdQuery(id));
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateReview(CreateReviewCommand command)
		{
			await _mediator.Send(command);
			return Ok("Ekleme işlemi gerçekleşti");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
		{
			await _mediator.Send(command);
			return Ok("Güncelleme işlemi gerçekleşti");
		}
	}
}
