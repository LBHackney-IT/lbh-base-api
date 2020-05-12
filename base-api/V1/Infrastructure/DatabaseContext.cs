using Microsoft.EntityFrameworkCore;
using base_api.V1.Domain;

namespace base_api.V1.Infrastructure
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DatabaseEntity> DatabaseEntities { get; set; }
    }
}
