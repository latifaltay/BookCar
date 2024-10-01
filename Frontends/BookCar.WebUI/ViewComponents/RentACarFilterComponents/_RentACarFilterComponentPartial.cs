using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(string v)
        {
            v = "test";
            TempData["value"] = v;
            return View();
        }
    }
}
