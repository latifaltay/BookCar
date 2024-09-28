using BookCar.Application.Features.Mediator.Results.StatisticsResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetCarCountByFuelElectricQuery : IRequest<GetCarCountByFuelElectricQueryResult>
    {
    }
}
