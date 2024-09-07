﻿using BookCar.Application.Features.CQRS.Commands.ContactCommands;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler(IRepository<Contact> _repository)
    {
        public async Task Handle(RemoveContactCommand command) 
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
