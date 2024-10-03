﻿using BookCar.Application.Features.Mediator.Results.ReviewResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Queries.ReviewQueries
{
	public class GetReviewByCarIdQuery(int id) : IRequest<List<GetReviewByCarIdQueryResult>>
	{
        public int Id { get; set; } = id;
    }
}
