namespace Models.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerByName(string customerName);
        int GetCustomerDuration(string customerName);
    }
}