using Microsoft.AspNetCore.Mvc;
using SmartExpenses.Models;
using SmartExpenses.Services.Infrastucture;
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
            var expenses = await _expenseService.GetAllExpensesAsync();
            var incomings = await _incomingService.GetAllIncomingsAsync();
            ViewData["Expenses"] = expenses.Sum(x => x.Value);
            ViewData["Incomings"] = incomings.Sum(x => x.Value);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
