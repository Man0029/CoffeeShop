using System.Diagnostics;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
