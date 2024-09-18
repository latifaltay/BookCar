using BookCar.Application.Features.Mediator.Queries.TagCloudQueries;
using BookCar.Application.Features.Mediator.Results.TagCloudResults;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByIdQueryHandler(IRepository<TagCloud> _repository) : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetTagCloudByIdQueryResult 
            {
                BlogId = value.BlogId,
                TagCloudId = value.TagCloudId,
                Title = value.Title,
            };
        }
    }
}
