using BookCar.Application.Interfaces.ReviewInterfaces;
using BookCar.Domain.Entities;
using BookCar.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Persistence.Repositories.ReviewRepositories
{
	public class ReviewRepository(BookCarContext _context) : IReviewRepository
	{
		public List<Review> GetReviewsByCarId(int carId)
		{
			var values = _context.Reviews.Where(x => x.CarId == carId).ToList();
			return values;
		}
	}
}
