using BookCar.Application.Features.Mediator.Queries.CarPricingQueries;
using BookCar.Application.Features.Mediator.Results.CarPricingResults;
using BookCar.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler(ICarPricingRepository _repository) : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values =  _repository.GetCarPricingsWithCars();
            return values.Select(x => new GetCarPricingWithCarQueryResult 
            {
                CarId = x.CarId,
                Amount = x.Amount,
                Brand = x.Car.Brand.Name,
                CarPricingId = x.CarPricingId,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model,
            }).ToList();
        }
    }
}
