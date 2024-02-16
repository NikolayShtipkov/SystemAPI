using Microsoft.EntityFrameworkCore;
using SystemAPI.Data;
using SystemAPI.Entities;
using SystemAPI.Repository.IRepository;

namespace SystemAPI.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DatabaseContext _context;

        public DeviceRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task<Device> GetAsync(int deviceId)
        {
            var device = await _context.Devices.FirstOrDefaultAsync(d => d.Id == deviceId);
            if (device == null)
            {
                throw new Exception(SD.SD.DeviceDoesNotExist);
            }

            return device;
        }

        public async Task<Device> GetAsync(string name)
        {
            var device = await _context.Devices.FirstOrDefaultAsync(d => d.Name == name);
            if (device == null)
            {
                throw new Exception(SD.SD.DeviceDoesNotExist);
            }

            return device;
        }

        public async Task CreateAsync(Device device)
        {
            if (await _context.Devices.AnyAsync(d => d.Name == device.Name))
            {
                throw new Exception(SD.SD.NameAlredyExist);
            }

            await _context.Devices.AddAsync(device);
        }

        public async Task AssignDeviceToSystem(int deviceId, int systemId)
        {
            var device = await GetAsync(deviceId);
            
            var system = await _context.Devices.FirstOrDefaultAsync(s => s.Id == systemId);
            if (system == null)
            {
                throw new Exception(SD.SD.SystemDoesNotExist);
            }

            device.SystemId = systemId;
            _context.Devices.Update(device);
        }

        public async Task UpdateAsync(Device device, int id)
        {
            var deviceToUpdate = await GetAsync(id);
            bool nameExists = await _context.Devices
                .AnyAsync(d => d.Name == device.Name && d.Name != deviceToUpdate.Name);
            if (nameExists)
            {
                throw new Exception(SD.SD.NameAlredyExist);
            }

            if (await _context.Systems.AnyAsync(s => s.Id != device.SystemId))
            {
                throw new Exception(SD.SD.SystemDoesNotExist);
            }

            deviceToUpdate.Name = device.Name;
            deviceToUpdate.Location = device.Location;
            deviceToUpdate.SystemId = device.SystemId;

            _context.Devices.Update(deviceToUpdate);
        }

        public async Task RemoveAsync(int id)
        {
            var device = await GetAsync(id);
            if (device == null)
            {
                throw new Exception(SD.SD.DeviceDoesNotExist);
            }

            _context.Devices.Remove(device);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
