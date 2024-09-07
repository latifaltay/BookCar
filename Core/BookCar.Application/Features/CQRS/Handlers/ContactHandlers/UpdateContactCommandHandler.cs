using BookCar.Application.Features.CQRS.Commands.ContactCommands;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler(IRepository<Contact> _repository)
    {

        public async Task Handle(UpdateContactCommand command) 
        {
            var value = await _repository.GetByIdAsync(command.ContactId);
            value.Name = command.Name;
            value.Email = command.Email;    
            value.SendDate = command.SendDate;
            value.Subject = command.Subject;
            value.Message = command.Message;
            await _repository.UpdateAsync(value);
        } 

    }
}
