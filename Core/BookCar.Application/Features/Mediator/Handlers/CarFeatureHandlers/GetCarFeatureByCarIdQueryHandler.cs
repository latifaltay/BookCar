using BookCar.Application.Features.Mediator.Queries.CarFeatureQueries;
using BookCar.Application.Features.Mediator.Results.CarFeatureResults;
using BookCar.Application.Interfaces;
using BookCar.Application.Interfaces.CarFeatureInterfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository _repository) : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarFeaturesByCarId(request.Id);
            return values.Select(x => new GetCarFeatureByCarIdQueryResult
            {
                Available = x.Available,
                CarFeatureId = x.CarFeatureId,
                FeatureId = x.FeatureId,
                FeatureName = x.Feature.Name
            }).ToList();
        }
    }
}
