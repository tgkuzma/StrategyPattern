using System.Data;

namespace Data.Repositories
{
    public class SqlServerCustomerRepository : CustomerRepositoryBase
    {
        private readonly DataContext _context;

        public SqlServerCustomerRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override int GetCustomerDuration(string customerName)
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