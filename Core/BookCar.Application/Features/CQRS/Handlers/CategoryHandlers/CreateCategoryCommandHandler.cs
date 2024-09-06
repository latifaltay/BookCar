﻿using BookCar.Application.Features.CQRS.Commands.AboutCommands;
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
    public class CreateCategoryCommandHandler(IRepository<Category> _repository)
    {
        public async Task Handle(CreateCategoryCommand command) 
        {
            await _repository.CreateAsync(new Category 
            {
                Name = command.Name,
            });
        }
    }
}
