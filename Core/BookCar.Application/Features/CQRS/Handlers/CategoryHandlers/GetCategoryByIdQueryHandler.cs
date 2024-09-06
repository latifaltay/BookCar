using BookCar.Application.Features.CQRS.Queries.CategoryQueries;
using BookCar.Application.Features.CQRS.Results.CategoryResults;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler(IRepository<Category> _repository)
    {
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query) 
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetCategoryByIdQueryResult 
            {
                CategoryId = value.CategoryId,
                Name = value.Name,
            };
        }
    }
}
