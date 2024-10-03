using BookCar.Application.Features.CQRS.Commands.CarCommands;
using BookCar.Application.Features.CQRS.Queries.CarQueries;
using BookCar.Application.Features.CQRS.Results.CarResults;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler(IRepository<Car> _repository)
    {
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query) 
        {
            var valeus = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult 
            {
                CarId = valeus.CarId,
                BrandId = valeus.BrandId,
                Model = valeus.Model,
                CoverImageUrl = valeus.CoverImageUrl,
                Km = valeus.Km,
                Transmission = valeus.Transmission,
                Seat = valeus.Seat,
                Luggage = valeus.Luggage,
                Fuel = valeus.Fuel,
                BigImageUrl = valeus.BigImageUrl
            };
        }


    }
}
