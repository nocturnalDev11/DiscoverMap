using DiscoverMap.Server.DTOs;
using DiscoverMap.Server.Models;
using DiscoverMap.Server.Services;
using DiscoverMap.Server.Services.DiscoverMap.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiscoverMap.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PinController : ControllerBase
    {
        private readonly PinService _service;

        public PinController(PinService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetPins()
        {
            var pins = _service.GetAllPins();
            return Ok(pins);
        }

        [HttpPost]
        public IActionResult CreatePin(CreatePinDTO dto)
        {
            var pin = new Pin
            {
                Title = dto.Title,
                Description = dto.Description,
                Category = dto.Category,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                ImageUrl = dto.ImageUrl
            };

            _service.CreatePin(pin);

            return Ok(pin);
        }
    }
}