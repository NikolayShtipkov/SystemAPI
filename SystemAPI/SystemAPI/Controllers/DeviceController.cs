using Microsoft.AspNetCore.Mvc;
using SystemAPI.Entities;
using SystemAPI.Repository.IRepository;

namespace SystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private static IDeviceRepository _deviceRepository;

        public DeviceController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            var device = await _deviceRepository.GetAllAsync();
            return device;
        }

        [HttpGet("{id}")]
        public async Task<Device> GetAsync(int id)
        {
            var device = await _deviceRepository.GetAsync(id);
            return device;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Device model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _deviceRepository.CreateAsync(model);

            return Ok();
        }
    }
}
