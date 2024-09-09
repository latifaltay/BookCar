using BookCar.Application.Features.Mediator.Results.ServiceResults;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceQuery : IRequest<List<GetServiceQueryResult>>
    {

    }
}
