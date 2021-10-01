using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Amazon.XRay.Recorder.Core;
using Amazon.XRay.Recorder.Core.Strategies;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Tests
{
    [TestFixture]
    public class DynamoDbTests
    {

        public IDynamoDBContext DynamoDbContext { get; private set; }
        public AmazonDynamoDBClient DynamoDBClient { get; private set; }
        public List<Action> CleanupActions { get; set; } = new List<Action>();
        private const string ID = "id";

        [SetUp]
        protected void RunBeforeTests()
        {
            AWSXRayRecorder.Instance.ContextMissingStrategy = ContextMissingStrategy.LOG_ERROR;
            var clientConfig = new AmazonDynamoDBConfig { ServiceURL = "http://dynamodb-database:8000" };
            DynamoDBClient = new AmazonDynamoDBClient(clientConfig);
            try
            {
                var request = new CreateTableRequest("TableName",
                new List<KeySchemaElement> { new KeySchemaElement(ID, KeyType.HASH) },
                new List<AttributeDefinition> { new AttributeDefinition(ID, ScalarAttributeType.S) },
                new ProvisionedThroughput(3, 3));
                DynamoDBClient.CreateTableAsync(request).GetAwaiter().GetResult();
            }
            catch (ResourceInUseException)
            {
                // It already exists :-)
            }
            DynamoDbContext = new DynamoDBContext(DynamoDBClient);
        }
        [TearDown]
        protected void RunAfterTests()
        {
            foreach (var action in CleanupActions) action();
            DynamoDBClient.Dispose();

        }
    }
}
