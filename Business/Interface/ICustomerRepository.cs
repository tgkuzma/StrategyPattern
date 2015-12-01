using Models;

namespace Business.Interface
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByCustomerName(string customerName);
        int GetCustomerDuration(string customerName);
    }
}