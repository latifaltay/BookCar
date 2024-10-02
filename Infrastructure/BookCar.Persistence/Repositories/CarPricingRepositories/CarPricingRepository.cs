using BookCar.Application.Interfaces.CarPricingInterfaces;
using BookCar.Application.ViewModels;
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

        public List<CarPricing> GetCarPricingWithTimePeriod()
        {
            throw new NotImplementedException();
        }


        public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
        {
            var result = from carPricing in _context.CarPricings
                         join car in _context.Cars on carPricing.CarId equals car.CarId
                         join brand in _context.Brands on car.BrandId equals brand.BrandId
                         group new { carPricing, car, brand } by new { car.Model, brand.Name, car.CoverImageUrl } into grouped
                         select new CarPricingViewModel
                         {
                             Brand = grouped.Key.Name,
                             Model = grouped.Key.Model,
                             CoverImageUrl = grouped.Key.CoverImageUrl,
                             DailyAmount = grouped.Where(x => x.carPricing.PricingId == 1).Sum(x => (decimal?)x.carPricing.Amount) ?? 0,
                             WeeklyAmount = grouped.Where(x => x.carPricing.PricingId == 2).Sum(x => (decimal?)x.carPricing.Amount) ?? 0,
                             MonthlyAmount = grouped.Where(x => x.carPricing.PricingId == 3).Sum(x => (decimal?)x.carPricing.Amount) ?? 0
                         };

            return result.ToList();
        }
    }
}
