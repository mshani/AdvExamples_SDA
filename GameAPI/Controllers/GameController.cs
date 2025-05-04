using GameAPI.BusinessLayer.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace GameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IVideoGameService _videoGameService;
        public GameController(IVideoGameService videoGameService) { 
            _videoGameService = videoGameService;
        }

        [HttpGet("Welcome")]
        public IActionResult Welcome([FromQuery] string? name, [FromQuery] string? lastName)
        {
            var message = $"Welcome back {name} {lastName} to Game API";
            return new OkObjectResult(message);
        }

        [HttpGet("GetAll")]
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
    }
}
