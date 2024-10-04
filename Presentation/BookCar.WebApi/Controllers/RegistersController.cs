using BookCar.Application.Features.Mediator.Commands.AppUserCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegistersController(IMediator _mediator) : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> CreateUser(CreateAppUserCommand command) 
		{
			await _mediator.Send(command);
			return Ok("Kullanıcı başarıyla oluşturuldu!");
		}
	}
}
