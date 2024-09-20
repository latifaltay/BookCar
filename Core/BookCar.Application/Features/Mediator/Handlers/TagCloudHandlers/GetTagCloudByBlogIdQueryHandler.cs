using BookCar.Application.Features.Mediator.Queries.TagCloudQueries;
using BookCar.Application.Features.Mediator.Results.TagCloudResults;
using BookCar.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler(ITagCloudRepository _repository) : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetTagCloudsByBlogId(request.Id);
            return values.Select(x => new GetTagCloudByBlogIdQueryResult 
            {
                TagCloudId = x.TagCloudId,
                BlogId = x.BlogId,
                Title = x.Title,
            }).ToList(); 
        }
    }
}
