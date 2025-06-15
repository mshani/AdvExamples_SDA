using Microsoft.AspNetCore.Mvc;
using SmartExpenses.Models;
using SmartExpenses.Services.Infrastucture;
using System.Diagnostics;

namespace SmartExpenses.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExpenseService _expenseService;

        public HomeController(ILogger<HomeController> logger, IExpenseService expenseService)
        {
            _logger = logger;
            _expenseService = expenseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Overview()
        {
            var expenses = await _expenseService.GetAllExpensesAsync(); 
            return View(expenses);
        }

        public async Task<IActionResult> UpsertExpense(int? id)
        {
            if (id != null)
            {
                var expense = await _expenseService.GetExpenseByIdAsync(id.Value);
                return View(expense);
            }
            return View();
        }

        public async Task<IActionResult> DeleteExpense(int? id)
        {
            if (id != null)
            {
                await _expenseService.DeleteExpenseAsync(id.Value);
            }
            return RedirectToAction("Overview");
        }

        public async Task<IActionResult> UpsertForm(Expense payload)
        {
            if (payload != null)
            {
                if (payload?.Id > 0)
                {
                    await _expenseService.UpdateExpenseAsync(payload);
                }
                else
                {
                    await _expenseService.CreateExpenseAsync(payload);
                }
            }          
            return RedirectToAction("Overview");
        }
        public IActionResult Privacy()
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
