using GameAPI.BusinessLayer.Infrastructure;
using GameAPI.DataLayer.DTOs;
using GameAPI.DataLayer.Filters;
using GameAPI.DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IVideoGameService _videoGameService;
        public GameController(IVideoGameService videoGameService)
        {
            _videoGameService = videoGameService;
        }

        [HttpGet("welcome")]
        public IActionResult Welcome([FromQuery] string? name, [FromQuery] string? lastName)
        {
            var message = $"Welcome back {name} {lastName} to Game API";
            return new OkObjectResult(message);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] VideoGameFilter filter)
        {
            try
            {
                var data = _videoGameService.GetAll(filter);
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet("getById")]
        public IActionResult GetById([FromQuery] int id)
        {
            try
            {
                var data = _videoGameService.GetById(id);
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] VideoGameDTO payload)
        {
            try
            {
                var data = _videoGameService.Create(payload);
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] VideoGameDTO payload)
        {
            try
            {
                var data = _videoGameService.Update(id, payload);
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try
            {
                var data = _videoGameService.Delete(id);
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
