using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebUI.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
