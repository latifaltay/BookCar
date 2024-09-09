using BookCar.Application.Features.Mediator.Queries.ServiceQueries;
using BookCar.Application.Features.Mediator.Queries.SocialMediaQueries;
using BookCar.Application.Features.Mediator.Results.ServiceResults;
using BookCar.Application.Features.Mediator.Results.SocialMediaResults;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    internal class GetSocialMediaQueryHandler(IRepository<SocialMedia> _repository) : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetSocialMediaQueryResult 
            {
                SocialMediaId = x.SocialMediaId,
                Name = x.Name,
                Icon = x.Icon,
                Url = x.Url,
            }).ToList();

        }
    }
}
