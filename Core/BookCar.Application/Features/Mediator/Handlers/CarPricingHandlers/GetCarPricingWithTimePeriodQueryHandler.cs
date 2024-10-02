using BookCar.Application.Features.Mediator.Queries.CarPricingQueries;
using BookCar.Application.Features.Mediator.Results.CarPricingResults;
using BookCar.Application.Interfaces;
using BookCar.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository _repository) : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
    {
        public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithTimePeriod1();
            return values.Select(x => new GetCarPricingWithTimePeriodQueryResult
            {
                Brand = x.Brand,
                Model = x.Model,
                CoverImageUrl = x.CoverImageUrl,
                DailyAmount = x.DailyAmount,    
                WeeklyAmount = x.WeeklyAmount,  
                MonthlyAmount = x.MonthlyAmount 
            }).ToList();
        }
    }
}
