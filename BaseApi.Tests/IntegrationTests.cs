using System.Net.Http;
using BaseApi.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NUnit.Framework;

namespace BaseApi.Tests
{
    public class IntegrationTests<TStartup> where TStartup : class
    {
        protected HttpClient Client { get; private set; }
        protected DatabaseContext DatabaseContext { get; private set; }

        private MockWebApplicationFactory<TStartup> _factory;
        private NpgsqlConnection _connection;
        private NpgsqlTransaction _transaction;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _connection = new NpgsqlConnection(ConnectionString.TestDatabase());
            _connection.Open();
            var npgsqlCommand = _connection.CreateCommand();
            npgsqlCommand.CommandText = "SET deadlock_timeout TO 30";
            npgsqlCommand.ExecuteNonQuery();

            var builder = new DbContextOptionsBuilder();
            builder.UseNpgsql(_connection);
            DatabaseContext = new DatabaseContext(builder.Options);
            DatabaseContext.Database.EnsureCreated();
        }

        [SetUp]
        public void BaseSetup()
        {
            _factory = new MockWebApplicationFactory<TStartup>(_connection);
            Client = _factory.CreateClient();

            _transaction = _connection.BeginTransaction();
        }

        [TearDown]
        public void BaseTearDown()
        {
            Client.Dispose();
            _factory.Dispose();
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
