using GameAPI.BusinessLayer.Infrastructure;
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
        public IActionResult GetAll()
        {
            try
            {
                var data = _videoGameService.GetAll();
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
        public IActionResult Create([FromBody] VideoGame videoGame)
        {
            try
            {
                var data = _videoGameService.Create(videoGame);
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] VideoGame videoGame)
        {
            try
            {
                var data = _videoGameService.Update(videoGame);
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
