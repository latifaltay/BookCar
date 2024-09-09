﻿using BookCar.Application.Features.Mediator.Results.FooterAddressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressByIdQuery(int id) : IRequest<GetFooterAddressByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
