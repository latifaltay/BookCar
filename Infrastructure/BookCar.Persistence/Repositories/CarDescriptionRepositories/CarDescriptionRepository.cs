using BookCar.Application.Interfaces.CarDescriptionInterfaces;
using BookCar.Domain.Entities;
using BookCar.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Persistence.Repositories.CarDescriptionRepositories
{
	public class CarDescriptionRepository(BookCarContext _context) : ICarDescriptionRepository
	{
		public async Task<CarDescription> GetCarDescription(int carId)
		{
			var values = await _context.CarDescriptions.Where(x => x.CarId == carId).FirstOrDefaultAsync();
			return values;
		}
	}
}
