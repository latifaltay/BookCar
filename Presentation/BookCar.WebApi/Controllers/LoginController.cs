using BookCar.Application.Features.Mediator.Queries.AppUserQueries;
using BookCar.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController(IMediator _mediator) : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> Index(GetCheckAppUserQuery query)
		{
			var values = await _mediator.Send(query);
			if (values.IsExist)
			{
				return Created("", JwtTokenGenerator.GenerateToken(values));
			}
			else 
			{
				return BadRequest("Kullanıcı adı ya da parola hatalı!");
			}


		}
	}
}
