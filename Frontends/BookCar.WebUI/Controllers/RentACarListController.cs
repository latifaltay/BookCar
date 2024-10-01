﻿using BookCar.Dto.BrandDtos;
using BookCar.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace BookCar.WebUI.Controllers
{
    public class RentACarListController(IHttpClientFactory _httpClientFactory) : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            var locationId = TempData["locationId"];

            //filterRentACarDto.LocationId = int.Parse(locationId.ToString());
            //filterRentACarDto.Available = true;

            id = int.Parse(locationId.ToString());

            ViewBag.locationId = locationId;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7028/api/RentACars?locationId={id}&available=true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);

            }
            return View();
        }
    }
}
