using BookCar.Application.Interfaces.CarFeatureInterfaces;
using BookCar.Domain.Entities;
using BookCar.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Persistence.Repositories.CarFeatureRepositories
{
	public class CarFeatureRepository(BookCarContext _context) : ICarFeatureRepository
    {
		public void AddNewFeatureToAllCars(Feature feature)
		{
			var cars = _context.Cars.ToList();

			foreach (var car in cars)
			{
				var carFeature = new CarFeature
				{
					CarId = car.CarId,
					FeatureId = feature.FeatureId,
					Available = false
				};
				_context.CarFeatures.Add(carFeature);
			}

			_context.SaveChanges();
		}

		public void ChangeCarFeatureAvailableToFalse(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureId == id).FirstOrDefault();
            values.Available = false;
            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureId == id).FirstOrDefault();
            values.Available = true;
            _context.SaveChanges();
        }



        public List<CarFeature> GetCarFeaturesByCarId(int carId)
        {
            var values = _context.CarFeatures.Include(x => x.Feature).Where(x => x.CarId == carId).ToList();
            return values;
        }
    }
}
