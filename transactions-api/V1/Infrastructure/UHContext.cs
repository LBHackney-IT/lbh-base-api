using Microsoft.EntityFrameworkCore;
using transactions_api.V1.Domain;

namespace UnitTests.V1.Infrastructure
{
    public class UhContext : DbContext, IUHContext
    {
        public UhContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UhTransaction> UTransactions { get; set; }
    }
}
