using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsRecentBlogsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
