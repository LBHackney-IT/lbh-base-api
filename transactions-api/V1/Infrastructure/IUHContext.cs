using Microsoft.EntityFrameworkCore;
using transactions_api.V1.Domain;

namespace UnitTests.V1.Gateways
{
    public interface IUHContext
    {
        DbSet<Transaction> UTransactions { get; set; }
    }
}
