using BookCar.Application.Features.CQRS.Commands.CategoryCommands;
using BookCar.Application.Features.CQRS.Handlers.BrandHandlers;
using BookCar.Application.Features.CQRS.Handlers.CategoryHandlers;
using BookCar.Application.Features.CQRS.Queries.BrandQueries;
using BookCar.Application.Features.CQRS.Queries.CategoryQueries;
using BookCar.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(
        GetCategoryQueryHandler _getCategoryQueryHandler,
        GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler,
        CreateCategoryCommandHandler _createCategoryCommandHandler,
        UpdateCategoryCommandHandler _updateCategoryCommandHandler,
        RemoveCategoryCommandHandler _removeCategoryCommandHandler
        ) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id) 
        {
            var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command) 
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok();
        }

        
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(RemoveCategoryCommand command) 
        {
            await _removeCategoryCommandHandler.Handle(command);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command) 
        {
            await _updateCategoryCommandHandler.Handle(command);
            return Ok();
        }

}
}
