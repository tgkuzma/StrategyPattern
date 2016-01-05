namespace Data.Repositories
{
    public class MySqlCustomerRepository : CustomerRepositoryBase
    {
        public MySqlCustomerRepository(DataContext context) : base(context)
        {
        }
    }
}