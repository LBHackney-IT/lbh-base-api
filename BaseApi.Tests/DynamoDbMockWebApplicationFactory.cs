using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Hackney.Core.DynamoDb;
using Hackney.Core.Testing.DynamoDb;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace BaseApi.Tests
{
    public class DynamoDbMockWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        private readonly List<TableDef> _tables;

        public IDynamoDbFixture DbFixture { get; private set; }
        public IAmazonDynamoDB DynamoDb => DbFixture?.DynamoDb;
        public IDynamoDBContext DynamoDbContext => DbFixture?.DynamoDbContext;

        public DynamoDbMockWebApplicationFactory(List<TableDef> tables)
        {
            _tables = tables;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(b => b.AddEnvironmentVariables())
                .UseStartup<Startup>();
            builder.ConfigureServices(services =>
            {
                services.ConfigureDynamoDB();
                services.ConfigureDynamoDbFixture();

                var serviceProvider = services.BuildServiceProvider();

                DbFixture = serviceProvider.GetRequiredService<IDynamoDbFixture>();
                DbFixture.EnsureTablesExist(_tables);
            });
        }
    }
}
