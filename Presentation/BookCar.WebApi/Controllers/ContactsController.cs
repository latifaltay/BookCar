using BookCar.Application.Features.CQRS.Commands.ContactCommands;
using BookCar.Application.Features.CQRS.Handlers.AboutHandlers;
using BookCar.Application.Features.CQRS.Handlers.ContactHandlers;
using BookCar.Application.Features.CQRS.Queries.AboutQueries;
using BookCar.Application.Features.CQRS.Queries.Contact;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController
        (
            GetContactQueryHandler _getContactQueryHandler,
            GetContactByIdQueryHandler _getContactByIdQueryHandler,
            CreateContactCommandHandler _createContactCommandHandler,
            RemoveContactCommandHandler _removeContactCommandHandler,
            UpdateContactCommandHandler _updateContactCommandHandler
        ) : ControllerBase
    {


        [HttpGet]
        public async Task<IActionResult> ContactList() 
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id) 
        {
            var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveContact(RemoveContactCommand command) 
        {
            await _removeContactCommandHandler.Handle(command);
            return Ok("İletişim Bilgisi Silindi!");
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command) 
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("İletişim Bilgisi Eklendi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command) 
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("İletişim Bilgisi Güncellendi!");
        }

    }
}
