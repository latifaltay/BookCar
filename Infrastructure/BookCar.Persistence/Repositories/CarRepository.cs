using BookCar.Application.Interfaces.CarInterfaces;
using BookCar.Domain.Entities;
using BookCar.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Persistence.Repositories
{
    public class CarRepository(BookCarContext _context) : ICarRepository
    {
        //private readonly BookCarContext _context;
        public List<Car> GetCarsListWithBrands()
        {
            var valeus = _context.Cars.Include(c => c.Brand).ToList();  
            return valeus;
        }
    }
}
