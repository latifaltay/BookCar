using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebUI.ViewComponents.AboutViewComponents
{
    public class _BecomeADriverComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
