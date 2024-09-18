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
    public class GetTagCloudQueryHandler(IRepository<TagCloud> _repository) : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select( x => new GetTagCloudQueryResult 
            {
                TagCloudId = x.TagCloudId,
                Title = x.Title,
                BlogId = x.BlogId,
            }).ToList();
        }
    }
}
