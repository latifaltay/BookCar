using BookCar.Dto.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BookCar.WebUI.Controllers
{
	public class RegisterController(IHttpClientFactory _httpClientFactory) : Controller
	{
        [HttpGet]
        public IActionResult CreateAppUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateRegisterDto createRegisterDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createRegisterDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7028/api/Registers", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
