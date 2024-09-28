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
    public class GetCarCountByKmSmallerThen1000QueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetCarCountByKmSmallerThen1000Query, GetCarCountByKmSmallerThen1000QueryResult>
    {
        public async Task<GetCarCountByKmSmallerThen1000QueryResult> Handle(GetCarCountByKmSmallerThen1000Query request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByKmSmallerThen1000();
            return new GetCarCountByKmSmallerThen1000QueryResult
            {
                CarCountByKmSmallerThen1000 = value
            };
        }
    }
}
