using BookCar.Application.Features.Mediator.Queries.StatisticsQueries;
using BookCar.Application.Features.Mediator.Results.StatisticsResult;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetCarCountQueryHandler(IRepository<Car> _repository) : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
    {
        public Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
