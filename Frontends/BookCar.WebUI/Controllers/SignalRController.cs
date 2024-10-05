using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebUI.Controllers
{
    public class SignalRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
