﻿using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsParagraphComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        }
    }
}
