using Microsoft.EntityFrameworkCore;
using transactions_api.V1.Domain;
using UnitTests.V1.Gateways;

namespace UnitTests.V1.Infrastructure
{
    public class UHContext : DbContext, IUHContext
    {
        public DbSet<Transaction> UTransactions { get; set; }
    }
}
