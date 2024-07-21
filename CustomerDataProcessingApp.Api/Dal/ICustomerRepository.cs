using CustomerDataProcessingApp.Api.Models;

namespace CustomerDataProcessingApp.Api.Dal
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        void InsertCustomer(Customer customer);
        void DeleteCustomer(int CustomerId);
        void UpdateCustomer(Customer customer);
        void Save();
    }
}
