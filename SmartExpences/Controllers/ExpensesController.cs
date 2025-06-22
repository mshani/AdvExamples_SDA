using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartExpenses.Models;
using SmartExpenses.Services.Infrastucture;
using System.Collections.Generic;

namespace SmartExpenses.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly ICategoryService _categoryService;
        public ExpensesController(
            IExpenseService expenseService, 
            ICategoryService categoryService)
        {
            _expenseService = expenseService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Overview()
        {
            var expenses = await _expenseService.GetAllExpensesAsync();
            return View(expenses);
        }

        public async Task<IActionResult> Upsert(int? id)
        {

            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = categories;

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
