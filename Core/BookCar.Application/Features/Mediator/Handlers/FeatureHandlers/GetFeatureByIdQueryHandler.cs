﻿using BookCar.Application.Features.Mediator.Queries.FeatureQueries;
using BookCar.Application.Features.Mediator.Results.FeatureResults;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler(IRepository<Feature> _repository) : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetFeatureByIdQueryResult
            {
                FeatureId = value.FeatureId,
                Name = value.Name,
            };
        }
    }
}
