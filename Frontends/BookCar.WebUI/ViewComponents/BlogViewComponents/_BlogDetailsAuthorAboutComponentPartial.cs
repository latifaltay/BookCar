using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsAuthorAboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        }
    }
}
