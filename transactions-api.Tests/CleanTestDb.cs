using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using UnitTests.V1.Infrastructure;

namespace UnitTests
{
    public class DbTest
    {
        protected UhContext _uhContext;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

            string TEST_UH_URL = Environment.GetEnvironmentVariable("TEST_UH_URL") ??
                                 @"Server=localhost;Database=uhsimulator;User Id='sa';Password='Rooty-Tooty';";

            builder.UseSqlServer(TEST_UH_URL);

            _uhContext = new UhContext(builder.Options);
            _uhContext.Database.BeginTransaction();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            _uhContext.Database.RollbackTransaction();
        }
    }
}
