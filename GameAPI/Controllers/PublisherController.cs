using GameAPI.BusinessLayer.Infrastructure;
using GameAPI.DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PublisherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = _publisherService.GetAll();
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
                var data = _publisherService.GetById(id);
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Publisher publisher)
        {
            try
            {
                var data = _publisherService.Create(publisher);
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Publisher publisher)
        {
            try
            {
                var data = _publisherService.Update(publisher);
                return new OkObjectResult(data);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
