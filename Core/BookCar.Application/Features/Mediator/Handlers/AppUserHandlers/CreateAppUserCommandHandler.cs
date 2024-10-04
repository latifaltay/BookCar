using BookCar.Application.Features.Mediator.Commands.AppUserCommands;
using BookCar.Application.Interfaces;
using BookCar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Application.Features.Mediator.Handlers.AppUserHandlers
{
	public class CreateAppUserCommandHandler(IRepository<AppUser> _repository) : IRequestHandler<CreateAppUserCommand>
	{
		public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new AppUser 
			{
				Username = request.Username,
				Password = request.Password,
				Name = request.Name,
				Surname = request.Surname,
				Email = request.Email,
				//AppRoleId = (int)RolesType.Member,
			});
		}
	}
}
