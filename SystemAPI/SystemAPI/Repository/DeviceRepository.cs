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
            return await _context.Devices.FirstOrDefaultAsync(d => d.DeviceId == deviceId);
        }

        public async Task<Device> GetAsync(string name)
        {
            return await _context.Devices.FirstOrDefaultAsync(d => d.Name == name);
        }

        public async Task CreateAsync(Device device)
        {
            await _context.Devices.AddAsync(device);
        }

        public async Task UpdateAsync(Device device)
        {
            _context.Devices.Update(device);
        }

        public async Task RemoveAsync(Device device)
        {
            _context.Devices.Remove(device);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
