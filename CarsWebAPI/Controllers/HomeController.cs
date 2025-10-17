using CarsWebAPI.Data;
using CarsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace CarsWebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarsCoreMvcIdentityContext? _context;

        public HomeController(ILogger<HomeController> logger, CarsCoreMvcIdentityContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
                id = "555";

            var car = (from c in _context.MyCars
                      where c.Id.ToString() == id
                      select c).FirstOrDefault();

            if (car == null)
                return RedirectToAction("Index", "Car");

            return View("EditCar", car);
        }

        public ActionResult MyCars()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
