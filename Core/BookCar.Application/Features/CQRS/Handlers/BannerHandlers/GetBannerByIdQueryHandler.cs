using BookCar.Application.Features.CQRS.Queries.AboutQueries;
using BookCar.Application.Features.CQRS.Queries.BannerQueries;
using BookCar.Application.Features.CQRS.Results.BannerResults;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }


        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query) 
        {
            var valeus = await _repository.GetByIdAsync(query.id);
            return new GetBannerByIdQueryResult 
            {
                BannerId = valeus.BannerId,
                Description = valeus.Description,
                Title = valeus.Title,
                VideoDescription = valeus.VideoDescription,
                VideoUrl = valeus.VideoUrl
            };
        }

    }
}
