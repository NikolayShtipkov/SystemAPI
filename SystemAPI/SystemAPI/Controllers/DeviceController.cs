using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SystemAPI.Entities;
using SystemAPI.Models;
using SystemAPI.Repository.IRepository;

namespace SystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private static IDeviceRepository _deviceRepository;
        private static IMapper _mapper;

        public DeviceController(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DeviceDto>> GetAllAsync()
        {
            var devices = await _deviceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DeviceDto>>(devices);
        }

        [HttpGet("{id}")]
        public async Task<DeviceDto> GetAsync(int id)
        {
            var device = await _deviceRepository.GetAsync(id);
            return _mapper.Map<DeviceDto>(device);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(DeviceDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _deviceRepository.CreateAsync(_mapper.Map<Device>(model));

            return Ok();
        }
    }
}
