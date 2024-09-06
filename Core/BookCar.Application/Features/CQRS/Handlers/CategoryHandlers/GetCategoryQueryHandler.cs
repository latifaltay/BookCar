using BookCar.Application.Features.CQRS.Results.CategoryResults;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace BookCar.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler(IRepository<Category> _repository)
    {
        public async Task<List<GetCategoryQueryResult>> Handle() 
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCategoryQueryResult 
            {
                CategoryId = x.CategoryId,
                Name= x.Name,
            }).ToList();
        }
    }
}
