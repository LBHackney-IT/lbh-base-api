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
            builder.UseSqlServer(@"Server=localhost;Database=uhsimulator;User Id='sa';Password='Rooty-Tooty';");
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
