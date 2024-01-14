using Microsoft.EntityFrameworkCore;
using SystemAPI.Entities;

namespace SystemAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Entities.System> Systems { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}
