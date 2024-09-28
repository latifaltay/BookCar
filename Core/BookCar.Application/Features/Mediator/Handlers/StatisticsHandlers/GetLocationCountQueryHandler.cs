using BookCar.Application.Features.Mediator.Queries.StatisticsQueries;
using BookCar.Application.Features.Mediator.Results.StatisticsResult;
using BookCar.Application.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetLocationCountQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
    {
        public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetLocationCount();
            return new GetLocationCountQueryResult
            {
                LocationCount = value
            };
        }
    }
}
