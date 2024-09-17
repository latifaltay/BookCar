using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCategoryComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        }
    }
}
