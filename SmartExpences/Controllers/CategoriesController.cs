using Microsoft.AspNetCore.Mvc;
using SmartExpenses.Models;
using SmartExpenses.Services.Infrastucture;

namespace SmartExpenses.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Overview()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            if (id != null)
            {
                var category = await _categoryService.GetByIdAsync(id.Value);
                return View(category);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Category payload)
        {
            if (payload != null)
            {
                if (payload?.Id > 0)
                {
                    await _categoryService.UpdateAsync(payload);
                }
                else
                {
                    await _categoryService.CreateAsync(payload);
                }
            }
            return RedirectToAction("Overview");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var data = await _categoryService.GetByIdAsync(id.Value);
                return View(data);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Category payload)
        {
            if (payload != null && payload.Id > 0)
            {
                await _categoryService.DeleteAsync(payload.Id);
                return RedirectToAction("Overview");
            }
            return View();
        }
    }
}
