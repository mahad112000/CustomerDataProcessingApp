using CustomerDataProcessingApp.Api.Models;

namespace CustomerDataProcessingApp.Api.Dal
{
    public class CustomerRepository : ICustomerRepository
    {
       
        public CustomerRepository()
        {
                
        }
        public void DeleteCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public void InsertCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
