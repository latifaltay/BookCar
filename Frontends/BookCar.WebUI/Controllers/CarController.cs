using BookCar.Dto.CarDtos;
using BookCar.Dto.CarPricingDtos;
using BookCar.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace BookCar.WebUI.Controllers
{
    public class CarController(IHttpClientFactory _httpClientFactory) : Controller
    {
		public async Task<IActionResult> Index()
		{
			ViewBag.v1 = "Araçlarımız";
			ViewBag.v2 = "Aracınızı seçiniz";


			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7028/api/CarPricings");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
