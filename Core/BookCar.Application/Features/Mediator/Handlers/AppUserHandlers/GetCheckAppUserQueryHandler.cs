using BookCar.Application.Features.Mediator.Queries.AppUserQueries;
using BookCar.Application.Features.Mediator.Results.AppUserResults;
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
	public class GetCheckAppUserQueryHandler(IRepository<AppUser> _appUserRepository, IRepository<AppRole> _appRoleRepository) : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
	{
		public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
		{
			var values = new GetCheckAppUserQueryResult();
			var user = await _appUserRepository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);
			if (user == null)
			{
				values.IsExist = false;
			}
			else 
			{
				values.IsExist = true;
				values.UserName = user.Username;
				values.Role = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId)).AppRoleName;
				values.Id = user.AppUserId;
			}
			return values;
		}
	}
}
