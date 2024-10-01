using BookCar.Application.Features.Mediator.Queries.RentACarQueries;
using BookCar.Application.Features.Mediator.Results.RentACarResults;
using BookCar.Application.Interfaces;
using BookCar.Application.Interfaces.RentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler(IRentACarRepository _repository) : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.Available == true);
            return values.Select(x => new GetRentACarQueryResult
            {
                CarId = x.CarId,
                //Brand = x.Car.Brand.Name,
                //Model = x.Car.Model,
                //CoverImageUrl = x.Car.CoverImageUrl
            }).ToList();
        }
    }
}
