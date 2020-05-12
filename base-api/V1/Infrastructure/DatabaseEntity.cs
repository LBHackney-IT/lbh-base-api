using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace base_api.V1.Domain
{
    [Table("example_entities")]
    public class DatabaseEntity
    {
        [Column("id")] public int Id { get; set; }

        [Column("created_at")] public DateTime CreatedAt { get; set; }

    }
}
