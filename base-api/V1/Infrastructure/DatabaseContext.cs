using Microsoft.EntityFrameworkCore;
using BaseApi.V1.Domain;
using BaseApi.V1.Infrastructure;

namespace BaseApi.V1.Infrastructure
{

    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DatabaseEntity> DatabaseEntities { get; set; }
    }
}
