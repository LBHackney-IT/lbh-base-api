using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using base_api.V1.Infrastructure;

namespace UnitTests
{
    public class DbTest
    {
        protected UhContext _uhContext;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

            // To run database tests locally (eg. via Visual Studio) the TEST_DB_URL environment variable will need to be populated with
            // @"Host=localhost;Database=entitycore;Username=postgres;Password=mypassword";
            string TEST_DB_URL = @"Host=stub-test-db;Database=entitycore;Username=postgres;Password=mypassword";
            // Note: The Host name needs to be the name of the stub database docker-compose service, in order to run tests via Docker

            // Delete as appropriate
            // If using SQL:
            // builder.UseSqlServer(TEST_DB_URL);

            // If using Postgres:
            builder.UseNpgsql(TEST_DB_URL);

            // Do not delete this line:
            _uhContext = new UhContext(builder.Options);

            // If using Postgres:
            _uhContext.Database.EnsureCreated(); 

            // Do not delete this line:
            _uhContext.Database.BeginTransaction();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            _uhContext.Database.RollbackTransaction();
        }
    }
}
