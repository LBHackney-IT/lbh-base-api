using Microsoft.EntityFrameworkCore;
using BaseApi.V1.Domain;

namespace BaseApi.V1.Infrastructure
{
    public interface IDatabaseContext
    {
        DbSet<DatabaseEntity> DatabaseEntities { get; set; }
    }
}
