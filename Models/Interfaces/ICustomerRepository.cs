namespace Models.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByCustomerName(string customerName);
        int GetCustomerDuration(string customerName);
    }
}