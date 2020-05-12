using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using base_api.V1.Infrastructure;

namespace UnitTests
{
    public class DbTest
    {
        protected ExampleContext _exampleContext;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var builder = new DbContextOptionsBuilder();

            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                            @"Host=test-database;Port=5432;Database=entitycorex;Username=postgres;Password=mypassword";

            builder.UseNpgsql(connectionString);

            _exampleContext = new ExampleContext(builder.Options);

            _exampleContext.Database.EnsureCreated();

            _exampleContext.Database.BeginTransaction();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            _exampleContext.Database.RollbackTransaction();
        }
    }
}
