using Microsoft.EntityFrameworkCore;
using base_api.V1.Domain;

namespace base_api.V1.Infrastructure
{
    public class UhContext : DbContext, IUHContext
    {
        public UhContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UhTransaction> UTransactions { get; set; }
    }
}
