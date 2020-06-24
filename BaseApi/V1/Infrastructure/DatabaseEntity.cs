using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseApi.V1.Infrastructure
{
    //TODO: rename table and add needed fields relating to the table columns.
    // There's an example of this in the wiki https://github.com/LBHackney-IT/lbh-base-api/wiki/DatabaseContext
    [Table("example_entities")]
    public class DatabaseEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

    }
}
