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
            //var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingId == 2).ToList();
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingId == 1).ToList();
            // sorulacak
            // Entity ismi değiştirildi bir sıkıntı var mı?
            // yalnızca 5 araç geliyor sonra eklememe rağmen yenisi gelmiyor (çözüldü)
            return values;   
        }
    }
}
