using CustomerDataProcessingApp.Web.Models;

namespace CustomerDataProcessingApp.Web.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<bool> CreateCustomer(Customer customer);
        public Task DeleteCustomer(string id);
        public Task<Customer> GetCustomer(string id);
        public Task<bool> UpdateCustomer(Customer customer);
    }
}
