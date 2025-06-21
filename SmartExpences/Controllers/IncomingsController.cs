using Microsoft.AspNetCore.Mvc;
using SmartExpenses.Models;
using SmartExpenses.Services;
using SmartExpenses.Services.Infrastucture;

namespace SmartExpenses.Controllers
{
    public class IncomingsController : Controller
    {
        private readonly IIncomingService _incomingService;
        public IncomingsController(IIncomingService incomingService)
        {
            _incomingService = incomingService;
        }

        public async Task<IActionResult> Overview()
        {
            var data = await _incomingService.GetAllIncomingsAsync();
            return View(data);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
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
