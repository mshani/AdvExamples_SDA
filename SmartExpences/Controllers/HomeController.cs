using Microsoft.AspNetCore.Mvc;
using SmartExpenses.Models;
using SmartExpenses.Services.Infrastucture;
using System.Diagnostics;

namespace SmartExpenses.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
