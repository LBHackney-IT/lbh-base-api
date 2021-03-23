using Amazon.DynamoDBv2.DataModel;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseApi.V1.Infrastructure
{
    //TODO: rename table and add needed fields relating to the table columns.
    // There's an example of this in the wiki https://github.com/LBHackney-IT/lbh-base-api/wiki/DatabaseContext

    //TODO: Pick the attributes for the required data source, delete the others as appropriate
    // Postgres will use the "Table" and "Column" attributes
    // DynamoDB will use the "DynamoDBTable", "DynamoDBHashKey" and "DynamoDBProperty" attributes

    //TODO: For DynamoDB...
    // * The table name must match that specified in the terraform step that provisions the DynamoDb resource
    // * The name of the hash key property must match that specified in the terraform step that provisions the DynamoDb resource

    [Table("example_table")]
    [DynamoDBTable("example_table", LowerCamelCaseProperties = true)]
    public class DatabaseEntity
    {
        [Column("id")]
        [DynamoDBHashKey]
        public int Id { get; set; }

        [Column("created_at")]
        [DynamoDBProperty]
        public DateTime CreatedAt { get; set; }
    }
}
