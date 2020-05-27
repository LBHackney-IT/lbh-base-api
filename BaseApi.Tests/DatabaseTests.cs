using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using BaseApi.V1.Infrastructure;
using BaseApi.Tests;
using Microsoft.EntityFrameworkCore.Storage;

namespace UnitTests
{
    [TestFixture]
    public class DatabaseTests
    {
        private IDbContextTransaction _transaction;
        protected DatabaseContext DatabaseContext { get; set; }

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseNpgsql(ConnectionString.TestDatabase());
            DatabaseContext = new DatabaseContext(builder.Options);

            DatabaseContext.Database.EnsureCreated();
            _transaction = DatabaseContext.Database.BeginTransaction();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }
    }
}
