using Microsoft.EntityFrameworkCore;
using SystemAPI.Data;
using SystemAPI.Entities;
using SystemAPI.Repository.IRepository;

namespace SystemAPI.Repository
{
    public class SystemRepository : ISystemRepository
    {
        private readonly DatabaseContext _context;

        public SystemRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entities.System>> GetAllAsync()
        {
            return await _context.Systems.ToListAsync();
        }

        public async Task<Entities.System> GetAsync(int systemId)
        {
            return await _context.Systems.FirstOrDefaultAsync(s => s.Id == systemId);
        }

        public async Task<Entities.System> GetAsync(string name)
        {
            return await _context.Systems.FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task CreateAsync(Entities.System system)
        {
            if (await _context.Systems.AnyAsync(d => d.Name == system.Name))
            {
                throw new Exception("Name already in use.");
            }

            await _context.Systems.AddAsync(system);
        }

        public async Task UpdateAsync(Entities.System system, int id)
        {
            _context.Systems.Update(system);
        }

        public async Task RemoveAsync(Entities.System system)
        {
            _context.Systems.Remove(system);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
