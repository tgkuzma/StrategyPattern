using System.Data.Entity;
using Models;

namespace Data
{
    public class TestContext : DbContext
    {
        public TestContext() : base("MyContext")
        {
            Database.SetInitializer(new TestContextInitializer());
        }

        public DbSet<Customer> Customers { get; set; }

    }
}
