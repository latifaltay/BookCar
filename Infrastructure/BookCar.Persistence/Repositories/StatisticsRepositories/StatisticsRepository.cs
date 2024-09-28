using BookCar.Application.Interfaces;
using BookCar.Application.Interfaces.StatisticInterfaces;
using BookCar.Domain.Entities;
using BookCar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCar.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository(BookCarContext _context) : IStatisticsRepository
    {
        public int GetAuthorCount()
        {
            return _context.Authors.Count();
        }

        public decimal GetAvgRentPriceForDaily()
        {
            //var carPriceSum = _context.CarPricings.Where(x => x.CarPricingId == 1).Sum(x => x.Amount);
            //var carCount = _context.Cars.Count();
            //return carPriceSum / carCount;

            var id = _context.pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.CarPricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            //var carPriceSum = _context.CarPricings.Where(x => x.CarPricingId == 2).Sum(x => x.Amount);
            //var carCount = _context.Cars.Count();
            //return carPriceSum / carCount;

            var id = _context.pricings.Where(x => x.Name == "Aylık").Select(x => x.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.CarPricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            //var carPriceSum = _context.CarPricings.Where(x => x.CarPricingId == 4).Sum(x => x.Amount);
            //var carCount = _context.Cars.Count();
            //return carPriceSum / carCount;

            var id = _context.pricings.Where(x => x.Name == "Haftalık").Select(x => x.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.CarPricingId == id).Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            return _context.Blogs.Count();
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            throw new NotImplementedException();
        }

        public int GetBrandCount()
        {
            return _context.Brands.Count();
        }

        public string GetBrandNameByMaxCar()
        {
            var value = _context.Cars.OrderBy(x => x.BrandId).ToString();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            throw new NotImplementedException();
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            throw new NotImplementedException();
        }

        public int GetCarCount()
        {
            return _context.Cars.Count();
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            var value = _context.Cars.Where(x=>x.Km <= 1000).Count();
            return value;
        }

        public int GetCarCountByTranmissionIsAuto()
        {
            var value = _context.Cars.Where(x =>x.Transmission == "Otomatik").Count();
            return value;   
        }

        public int GetLocationCount()
        {
            return _context.Locations.Count();
        }
    }
}
