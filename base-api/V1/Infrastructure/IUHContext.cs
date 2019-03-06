using Microsoft.EntityFrameworkCore;
using base_api.V1.Domain;

namespace base_api.V1.Infrastructure
{
    public interface IUHContext
    {
        DbSet<UhTransaction> UTransactions { get; set; }
    }
}
