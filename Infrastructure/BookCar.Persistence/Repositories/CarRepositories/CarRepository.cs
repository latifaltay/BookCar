using BookCar.Application.Interfaces.CarInterfaces;
using BookCar.Domain.Entities;
using BookCar.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Persistence.Repositories.CarRepositories
{
    public class CarRepository(BookCarContext _context) : ICarRepository
    {
        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        //private readonly BookCarContext _context;
        public List<Car> GetCarsListWithBrands()
        {
            var valeus = _context.Cars.Include(c => c.Brand).ToList();
            return valeus;
        }

        //public List<CarPricing> GetCarsWithPricings()
        //{
        //    var values = _context.CarPricings.Include(x => x.Car).ThenInclude(x => x.Brand).Include(x => x.Pricing).ToList();
        //    return values;
        //}

        public List<Car> GetLast5CarsWithBrands()
        {
            var values = _context.Cars.Include(c => c.Brand).OrderByDescending(x => x.CarId).Take(5).ToList();
            return values;
        }
    }
}
