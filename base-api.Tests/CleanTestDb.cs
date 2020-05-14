using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using BaseApi.V1.Infrastructure;

namespace UnitTests
{
    [TestFixture]
    public class DbTest
    {
        protected DatabaseContext DatabaseContext { get; set; }

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var builder = new DbContextOptionsBuilder();

            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                            @"Host=test-database;Port=5432;Database=entitycorex;Username=postgres;Password=mypassword";

            builder.UseNpgsql(connectionString);

            DatabaseContext = new DatabaseContext(builder.Options);

            DatabaseContext.Database.EnsureCreated();

            DatabaseContext.Database.BeginTransaction();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            DatabaseContext.Database.RollbackTransaction();
        }
    }
}
