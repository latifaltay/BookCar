using BookCar.Application.Interfaces.CarPricingInterfaces;
using BookCar.Domain.Entities;
using BookCar.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository(BookCarContext _context) : ICarPricingRepository
    {
        public List<CarPricing> GetCarPricingsWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingId == 1);
            // Yukarıdaki ef core sorgusunu sql sorgusuna çeviren bir method
            var test = values.ToQueryString();
            return values.ToList();   
        }
    }
}
