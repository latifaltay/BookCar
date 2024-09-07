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
    public class CreateContactCommandHandler(IRepository<Contact> _repository)
    {
        public async Task Handle(CreateContactCommand command) 
        {
            await _repository.CreateAsync(new Contact 
            {
                Email = command.Email,
                Message = command.Message,
                Name = command.Name,
                SendDate = command.SendDate,
                Subject = command.Subject,
            });
        }
    }
}
