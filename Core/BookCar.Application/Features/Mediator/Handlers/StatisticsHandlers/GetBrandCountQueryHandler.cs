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
    public class GetBrandCountQueryHandler(IStatisticsRepository _repository) : IRequestHandler<GetBrandCountQuery, GetBrandCountQueryResult>
    {
        public async Task<GetBrandCountQueryResult> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBrandCount();
            return new GetBrandCountQueryResult
            {
                BrandCount = value
            };
        }
    }
}
