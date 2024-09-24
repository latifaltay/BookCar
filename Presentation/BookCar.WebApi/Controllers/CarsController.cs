﻿using BookCar.Application.Features.CQRS.Commands.BrandCommands;
using BookCar.Application.Features.CQRS.Commands.CarCommands;
using BookCar.Application.Features.CQRS.Handlers.BrandHandlers;
using BookCar.Application.Features.CQRS.Handlers.CarHandlers;
using BookCar.Application.Features.CQRS.Queries.BrandQueries;
using BookCar.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetLast5CarsWithBrandQueryHandler _getLast5CarsWithBrandQueryHandler;


        public CarsController(
            GetCarQueryHandler getCarQueryHandler, 
            GetCarByIdQueryHandler getCarByIdQueryHandler, 
            CreateCarCommandHandler createCarCommandHandler, 
            UpdateCarCommandHandler updateCarCommandHandler, 
            RemoveCarCommandHandler removeCarCommandHandler,
            GetCarWithBrandQueryHandler getCarWithBrandQueryHandler,
            GetLast5CarsWithBrandQueryHandler getLast5CarsWithBrandQueryHandler)
        {
            _getCarQueryHandler = getCarQueryHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLast5CarsWithBrandQueryHandler = getLast5CarsWithBrandQueryHandler;
        }




        [HttpGet]
        public async Task<IActionResult> CarList() 
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CarById(int id) 
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Brand Bilgisi Eklendi!");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id) 
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Car Bilgisi Silindi!");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command) 
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Car Bilgisi Güncellendi!");
        }


        [HttpGet("GetCarWithBrand")]
        public IActionResult GetCarWithBrand() 
        {
            var values =  _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetLast5CarsWithBrandQueryHandler")]
        public IActionResult GetLast5CarsWithBrandQueryHandler()
        {
            var values = _getLast5CarsWithBrandQueryHandler.Handle();
            return Ok(values);
        }

    }
}
