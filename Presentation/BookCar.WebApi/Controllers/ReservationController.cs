﻿using BookCar.Application.Features.Mediator.Commands.ReservationCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand createReservationCommand) 
        {
            await _mediator.Send(createReservationCommand);
            return Ok("Rezervasyon başarıyla eklendi.");
        }
    }
}
