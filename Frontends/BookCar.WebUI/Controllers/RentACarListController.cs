﻿using Microsoft.AspNetCore.Mvc;

namespace BookCar.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
