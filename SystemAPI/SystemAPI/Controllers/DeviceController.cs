﻿using AutoMapper;
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
            await _deviceRepository.SaveAsync();

            return Ok();
        }

        [HttpPut("{deviceId}/Assign/{systemId}")]
        public async Task<IActionResult> AssignDeviceToSystem(int deviceId, int systemId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _deviceRepository.AssignDeviceToSystem(deviceId, systemId);
            await _deviceRepository.SaveAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(DeviceDto model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _deviceRepository.UpdateAsync(_mapper.Map<Device>(model), id);
            await _deviceRepository.SaveAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _deviceRepository.RemoveAsync(id);
            await _deviceRepository.SaveAsync();

            return Ok();
        }
    }
}
