using System;
using System.Linq;
using Business.Interface;
using Models;

namespace Data.Repositories
{
    public class MySqlCustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly TestContext _context;

        public MySqlCustomerRepository(TestContext context) : base(context)
        {
            _context = context;
        }

        public Customer GetByCustomerName(string customerName)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerName == customerName);
        }

        public int GetCustomerDuration(string customerName)
        {
            var customer = GetByCustomerName(customerName);

            return (DateTime.Now - customer.DateActive).Days/365;
        }
    }
}