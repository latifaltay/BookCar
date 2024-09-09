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
    public class GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> _repository) : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetSocialMediaByIdQueryResult 
            {
                Name = value.Name,
                Url = value.Url,
                Icon = value.Icon,
            };
        }
    }
}
