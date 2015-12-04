using System.Data;
using System.Linq;
using Business.Interfaces;
using Models;

namespace Data.Repositories
{
    public class SqlServerCustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly DataContext _context;

        public SqlServerCustomerRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Customer GetByCustomerName(string customerName)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerName == customerName);
        }

        public int GetCustomerDuration(string customerName)
        {
            var connection = _context.Database.Connection;
            if(connection.State == ConnectionState.Closed)
                connection.Open();
            object returnValue;
            using (var command = _context.Database.Connection.CreateCommand())
            {
                command.CommandText = "uspGetCustomerDuration " + customerName;
                returnValue  =  command.ExecuteScalar();
            }
            return (int) returnValue;
        }
    }
}