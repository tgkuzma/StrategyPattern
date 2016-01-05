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

        public virtual Customer GetByCustomerName(string customerName)
        {
            if (string.IsNullOrEmpty(customerName))
            {
                throw new ArgumentException("A customerName is required.");
            }

            return _context.Customers.FirstOrDefault(c => c.CustomerName == customerName);
        }

        public virtual int GetCustomerDuration(string customerName)
        {
            var customer = GetByCustomerName(customerName);

            if (customer == null)
            {
                throw new ApplicationException(string.Format("No customer could be found with name, '{0}'", customerName));
            }
            return (DateTime.Now - customer.DateActive).Days / 365;
        }
    }
}