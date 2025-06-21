using Microsoft.AspNetCore.Mvc;
using SmartExpenses.Models;
using SmartExpenses.Services;
using SmartExpenses.Services.Infrastucture;

namespace SmartExpenses.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseService _expenseService;
        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        public async Task<IActionResult> Overview()
        {
            var expenses = await _expenseService.GetAllExpensesAsync();
            return View(expenses);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            if (id != null)
            {
                var expense = await _expenseService.GetExpenseByIdAsync(id.Value);
                return View(expense);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Expense payload)
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var data = await _expenseService.GetExpenseByIdAsync(id.Value);
                return View(data);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Expense payload)
        {
            if (payload != null && payload.Id > 0)
            {
                await _expenseService.DeleteExpenseAsync(payload.Id);
                return RedirectToAction("Overview");
            }
            return View();
        }
    }
}
