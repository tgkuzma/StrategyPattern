using System;
using System.Linq;
using Models;
using Models.Interfaces;

namespace Data.Repositories
{
    public class CustomerRepositoryBase : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly DataContext _context;

        protected CustomerRepositoryBase(DataContext context) : base(context)
        {
            _context = context;
        }

        public virtual Customer GetCustomerByName(string customerName)
        {
            if (string.IsNullOrEmpty(customerName))
            {
                throw new ArgumentException("A customerName is required.");
            }

            return _context.Customers.FirstOrDefault(c => c.CustomerName == customerName);
        }

        public virtual int GetCustomerDuration(string customerName)
        {
            var customer = GetCustomerByName(customerName);

            if (customer == null)
            {
                throw new ApplicationException(string.Format("No customer could be found with name, '{0}'", customerName));
            }
            return (DateTime.Now - customer.DateActive).Days / 365;
        }
    }
}