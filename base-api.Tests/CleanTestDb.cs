using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using base_api.V1.Infrastructure;

namespace UnitTests
{
    public class DbTest
    {
        protected DatabaseContext _databaseContext;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var builder = new DbContextOptionsBuilder();

            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                            @"Host=test-database;Port=5432;Database=entitycorex;Username=postgres;Password=mypassword";

            builder.UseNpgsql(connectionString);

            _databaseContext = new DatabaseContext(builder.Options);

            _databaseContext.Database.EnsureCreated();

            _databaseContext.Database.BeginTransaction();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            _databaseContext.Database.RollbackTransaction();
        }
    }
}
