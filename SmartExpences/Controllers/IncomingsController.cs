using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartExpenses.Models;
using SmartExpenses.Models.Enums;
using SmartExpenses.Services;
using SmartExpenses.Services.Infrastucture;

namespace SmartExpenses.Controllers
{
    public class IncomingsController : Controller
    {
        private readonly IIncomingService _incomingService;
        private readonly ICategoryService _categoryService;

        public IncomingsController(IIncomingService incomingService, ICategoryService categoryService)
        {
            _incomingService = incomingService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Overview(int? categoryId)
        {
            var categories = await _categoryService.GetAllAsync(CategoryTypeEnum.Incoming);
            ViewData["Categories"] = new SelectList(categories, "Id", "Name");
            var data = await _incomingService.GetAllIncomingsAsync(categoryId);
            return View(data);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            var categories = await _categoryService.GetAllAsync(CategoryTypeEnum.Incoming, true);
            ViewData["Categories"] = new SelectList(categories, "Id", "Name");
            if (id != null)
            {
                var data = await _incomingService.GetIncomingByIdAsync(id.Value);
                return View(data);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Incoming payload)
        {
            if (payload != null)
            {
                if (payload?.Id > 0)
                {
                    await _incomingService.UpdateIncomingAsync(payload);
                }
                else
                {
                    await _incomingService.CreateIncomingAsync(payload);
                }
            }
            return RedirectToAction("Overview");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var data = await _incomingService.GetIncomingByIdAsync(id.Value);
                return View(data);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Incoming payload)
        {
            if (payload != null && payload.Id > 0)
            {
                await _incomingService.DeleteIncomingAsync(payload.Id);
                return RedirectToAction("Overview");
            }
            return View();
        }
    }
}
