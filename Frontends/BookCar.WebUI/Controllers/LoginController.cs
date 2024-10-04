using BookCar.Dto.RegisterDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace BookCar.WebUI.Controllers
{
    public class LoginController(IHttpClientFactory _httpClientFactory) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {
            var client = _httpClientFactory.CreateClient();

            return View();
        }
    }
}
