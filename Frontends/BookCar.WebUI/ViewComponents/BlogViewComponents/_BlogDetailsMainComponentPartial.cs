﻿using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        }
    }
}
