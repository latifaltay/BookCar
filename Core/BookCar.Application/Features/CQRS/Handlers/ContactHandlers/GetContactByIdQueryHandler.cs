using BookCar.Application.Features.CQRS.Queries.Contact;
using BookCar.Application.Features.CQRS.Results.CarResults;
using BookCar.Application.Features.CQRS.Results.ContactResults;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler(IRepository<Contact> _repository)
    {

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query) 
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult 
            {
                ContactId = value.ContactId,
                Name = value.Name,
                Email = value.Email,
                Message = value.Message,
                SendDate = value.SendDate,
                Subject = value.Subject,
            };
        }

    }
}
