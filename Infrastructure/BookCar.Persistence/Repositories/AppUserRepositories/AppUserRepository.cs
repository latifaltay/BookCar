using BookCar.Application.Interfaces.AppUserInterfaces;
using BookCar.Domain.Entities;
using BookCar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Persistence.Repositories.AppUserRepositories
{
	public class AppUserRepository(BookCarContext _context) : IAppUserRepository
	{
		public async Task<List<AppUser>> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
		{
			throw new NotImplementedException();
		}
	}
}
