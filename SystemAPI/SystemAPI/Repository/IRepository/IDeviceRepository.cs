using SystemAPI.Entities;

namespace SystemAPI.Repository.IRepository
{
    public interface IDeviceRepository
    {
        Task CreateAsync(Device device);
        Task<IEnumerable<Device>> GetAllAsync();
        Task<Device> GetAsync(int deviceId);
        Task<Device> GetAsync(string name);
        Task RemoveAsync(Device device);
        Task SaveAsync();
        Task UpdateAsync(Device device);
    }
}