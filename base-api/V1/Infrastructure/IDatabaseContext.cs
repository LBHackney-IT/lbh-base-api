using Microsoft.EntityFrameworkCore;
using base_api.V1.Domain;

namespace base_api.V1.Infrastructure
{
    public interface IDatabaseContext
    {
        DbSet<DatabaseEntity> DatabaseEntities { get; set; }
    }
}
