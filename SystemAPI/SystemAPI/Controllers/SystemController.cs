using Microsoft.AspNetCore.Mvc;
using SystemAPI.Repository.IRepository;

namespace SystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private static ISystemRepository _systemRepository;

        public SystemController(ISystemRepository systemRepository)
        {
            _systemRepository = systemRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Entities.System>> GetAllAsync()
        {
            var systems = await _systemRepository.GetAllAsync();
            return systems;
        }

        [HttpGet("{id}")]
        public async Task<Entities.System> GetAsync(int id)
        {
            var system = await _systemRepository.GetAsync(id);
            return system;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Entities.System model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _systemRepository.CreateAsync(model);

            return Ok();
        }
    }
}
