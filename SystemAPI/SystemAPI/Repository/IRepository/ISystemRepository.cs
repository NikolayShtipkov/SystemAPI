namespace SystemAPI.Repository.IRepository
{
    public interface ISystemRepository
    {
        Task CreateAsync(Entities.System system);
        Task<IEnumerable<Entities.System>> GetAllAsync();
        Task<Entities.System> GetAsync(int systemId);
        Task<Entities.System> GetAsync(string name);
        Task RemoveAsync(Entities.System system);
        Task SaveAsync();
        Task UpdateAsync(Entities.System system, int id);
    }
}