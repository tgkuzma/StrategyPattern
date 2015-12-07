using System.Data.Entity;
using Models;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("MyContext")
        {
            Database.SetInitializer(new DataContextInitializer());
        }

        //public DataContext(string connectionStringName) : base(connectionStringName)
        //{
        //    Database.SetInitializer(new DataContextInitializer());
        //}

        public DbSet<Customer> Customers { get; set; }

    }
}
