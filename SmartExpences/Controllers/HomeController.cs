using Microsoft.AspNetCore.Mvc;
using SmartExpenses.Models;
using SmartExpenses.Services.Infrastucture;
using SmartExpenses.ViewModels.Home;
using System.Diagnostics;

namespace SmartExpenses.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IIncomingService _incomingService;

        public HomeController(IExpenseService expenseService, IIncomingService incomingService)
        {
            _expenseService = expenseService;
            _incomingService = incomingService;
        }

        public async Task<IActionResult> Index()
        {
            var expenses = await _expenseService.GetTotalAsync();
            var incomings = await _incomingService.GetTotalAsync();
            var data = new HomeIndexVM
            {
                ExpensesTotal = expenses,
                IncomingsTotal = incomings
            };
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
