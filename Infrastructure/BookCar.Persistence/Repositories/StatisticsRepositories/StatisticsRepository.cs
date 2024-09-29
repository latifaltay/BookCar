using BookCar.Application.Interfaces;
using BookCar.Application.Interfaces.StatisticInterfaces;
using BookCar.Domain.Entities;
using BookCar.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            var value = _context.CarPricings.Where(x => x.PricingId == id).Average(x => x.Amount);
            return value;

        }

        public decimal GetAvgRentPriceForMonthly()
        {
            //var carPriceSum = _context.CarPricings.Where(x => x.CarPricingId == 2).Sum(x => x.Amount);
            //var carCount = _context.Cars.Count();
            //return carPriceSum / carCount;

            var id = _context.pricings.Where(x => x.Name == "Aylık").Select(x => x.PricingId).FirstOrDefault();
            var result = _context.CarPricings.Where(x => x.PricingId == id).Average(x => x.Amount);
            return result;

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
            //select Top(1) BlogId,COUNT(*) as 'sayi' from Comments Group By BlogId order by sayi Desc

            var values = _context.Comments.GroupBy(x => x.BlogId).Select(x => new
            {
                BlogId = x.Key,
                Count = x.Count()
            }).OrderByDescending(x => x.Count).Take(1).FirstOrDefault();

            var blogName = _context.Blogs.Where(x => x.BlogId == values.BlogId).Select(x => x.Title).FirstOrDefault();
            return blogName;


        }

        public int GetBrandCount()
        {
            return _context.Brands.Count();
        }

        public string GetBrandNameByMaxCar()
        {
            /* sql sorgusu
            select top(1) Brands.Name, Count(*) as 'ToplamArac' from Cars 
            inner join Brands
            on
            Cars.BrandId = Brands.BrandId
            group by Brands.Name
            order by ToplamArac desc
            */

            var value = _context.Cars.GroupBy(x => x.BrandId)
                .Select(x => new
                {
                    BrandId = x.Key,
                    Count = x.Count()
                }).OrderByDescending(x => x.Count).Take(1).FirstOrDefault();
            
            var brandName =_context.Brands.Where(x => x.BrandId == value.BrandId).Select(x => x.Name).FirstOrDefault();

            return brandName;


            // yapay zeka yardımıyla en fazla arabaya sahip olan marka listesi sorgusu
            //var topBrand = _context.Cars
            //    .GroupBy(car => car.Brand.Name)
            //    .Select(g => new
            //    {
            //        BrandName = g.Key,
            //        ToplamArac = g.Count()
            //    })
            //    .OrderByDescending(x => x.ToplamArac)
            //    .FirstOrDefault(); 

            //var topBrandName = topBrand?.BrandName; 
            //return topBrandName;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            // select * from CarPricings where Amount = (Select Max(Amount) from CarPricings where PricingId =1)

            var pricingId = _context.pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingId).FirstOrDefault();
            var amount = _context.CarPricings.Where(x => x.PricingId == pricingId).Max(x => x.Amount);
            var carId = _context.CarPricings.Where(x => x.Amount == amount).Select(x => x.CarId).FirstOrDefault();
            var brandModel = _context.Cars.Where(x => x.CarId == carId).Include(x => x.Brand).Select(x => x.Brand.Name + " " + x.Model).FirstOrDefault();
            return brandModel;




            // Eğitimdeki uzun sorgunun tek satır sorgu hali
            //var brandModel = _context.CarPricings
            //    .Where(cp => cp.Pricing.Name == "Günlük")
            //    .OrderByDescending(cp => cp.Amount)
            //    .Select(cp => cp.Car.Brand.Name + " " + cp.Car.Model)
            //    .FirstOrDefault();
            //return brandModel;

        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            //select* from CarPricings where Amount = (select MIN(Amount) from CarPricings where PricingId = 1)

            var pricingId = _context.pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingId).FirstOrDefault();
            var amount = _context.CarPricings.Where(x => x.PricingId == pricingId).Min(x => x.Amount);
            var carId = _context.CarPricings.Where(x => x.Amount == amount).Select(x => x.CarId).FirstOrDefault();
            var brandModel = _context.Cars.Where(x => x.CarId == carId).Include(x => x.Brand).Select(x => x.Brand.Name + " " + x.Model).FirstOrDefault();
            return brandModel;



            // Eğitimdeki uzun sorgunun tek satır sorgu hali
            //var brandModel = _context.CarPricings
            //    .Where(cp => cp.Pricing.Name == "Günlük")
            //    .OrderBy(cp => cp.Amount)
            //    .Select(cp => cp.Car.Brand.Name + " " + cp.Car.Model)
            //    .FirstOrDefault();
            //return brandModel;


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
            var value = _context.Cars.Where(x => x.Km <= 1000).Count();
            return value;
        }

        public int GetCarCountByTranmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            return _context.Locations.Count();
        }
    }
}
