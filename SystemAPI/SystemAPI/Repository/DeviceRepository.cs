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
            return await _context.Devices.FirstOrDefaultAsync(d => d.Id == deviceId);
        }

        public async Task<Device> GetAsync(string name)
        {
            return await _context.Devices.FirstOrDefaultAsync(d => d.Name == name);
        }

        public async Task CreateAsync(Device device)
        {
            if (await _context.Devices.AnyAsync(d => d.Name == device.Name))
            {
                throw new Exception("Name already in use.");
            }

            await _context.Devices.AddAsync(device);
        }

        public async Task UpdateAsync(Device device, int id)
        {
            var deviceToUpdate = await GetAsync(id);
            bool nameExists = await _context.Devices
                .AnyAsync(d => d.Name == device.Name && d.Name != deviceToUpdate.Name);
            if (nameExists)
            {
                throw new Exception("Name already in use.");
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
                throw new Exception("Device doesn't exist.");
            }

            _context.Devices.Remove(device);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
