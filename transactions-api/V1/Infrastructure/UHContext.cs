using Microsoft.EntityFrameworkCore;
using transactions_api.V1.Domain;

namespace UnitTests.V1.Infrastructure
{
    public class UhContext : DbContext, IUHContext
    {
        public DbSet<Transaction> UTransactions { get; set; }
    }
}
