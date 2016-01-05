using System;
using System.Linq;
using Models;
using Models.Interfaces;

namespace Data.Repositories
{
    public class MySqlCustomerRepository : CustomerRepositoryBase
    {
        private readonly DataContext _context;

        public MySqlCustomerRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}