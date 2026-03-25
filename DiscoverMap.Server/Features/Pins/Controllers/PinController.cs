using DiscoverMap.Server.Features.Pins.Services;
using DiscoverMap.Server.Features.Pins.Models;
using DiscoverMap.Server.Features.Pins.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DiscoverMap.Server.Features.Pins.Controllers
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
        public async Task<IActionResult> GetPins()
        {
            var pins = await _service.GetAllPinsAsync();
            return Ok(pins);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePin(CreatePinDTO dto)
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

            await _service.CreatePinAsync(pin);

            return Ok(pin);
        }
    }
}
