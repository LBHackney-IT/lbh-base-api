using BaseApi.V1.Domain;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.V1.Infrastructure
{
    public interface IDatabaseContext
    {
        DbSet<DatabaseEntity> DatabaseEntities { get; set; }
    }
}
