using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SystemAPI.Models;
using SystemAPI.Repository.IRepository;

namespace SystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private static ISystemRepository _systemRepository;
        private static IMapper _mapper;

        public SystemController(ISystemRepository systemRepository, IMapper mapper)
        {
            _systemRepository = systemRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SystemDto>> GetAllAsync()
        {
            var systems = await _systemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SystemDto>>(systems);
        }

        [HttpGet("{id}")]
        public async Task<SystemDto> GetAsync(int id)
        {
            var system = await _systemRepository.GetAsync(id);
            return _mapper.Map<SystemDto>(system);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(SystemDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _systemRepository.CreateAsync(_mapper.Map<Entities.System>(model));
            await _systemRepository.SaveAsync();

            return Ok();
        }
    }
}
