using BookCar.Application.Features.CQRS.Commands.CategoryCommands;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler(IRepository<Category> _repository)
    {
        public async Task Handle(UpdateCategoryCommand command) 
        {
            var value = await _repository.GetByIdAsync(command.CategoryId);
            value.Name = command.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
