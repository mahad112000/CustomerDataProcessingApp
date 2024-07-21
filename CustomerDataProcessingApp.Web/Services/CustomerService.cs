using CustomerDataProcessingApp.Web.Helpers;
using CustomerDataProcessingApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CustomerDataProcessingApp.Web.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _client;
        public const string baseUrl = "/api/Customers";
        public CustomerService(HttpClient httpClient)
        {
                _client = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var response = await _client.GetAsync(baseUrl);

            return await response.ReadContentAsync<List<Customer>>();
        }

        public async Task<Customer> GetCustomer(string id)
        {
            var dbId = int.Parse(id);
            var response = await _client.GetAsync($"{baseUrl}/{dbId}");

            return await response.ReadContentAsync<Customer>();
        }

        public async Task<bool> CreateCustomer(Customer customer)
        {
            // Serialize the object to JSON
            var json = JsonConvert.SerializeObject(customer);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send the POST request
            var response = await _client.PostAsync(baseUrl, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            // Serialize the object to JSON

            var json = JsonConvert.SerializeObject(customer);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send the POST request
            var response = await _client.PutAsync(baseUrl, content);
            return response.IsSuccessStatusCode;
        }

        public async Task DeleteCustomer(string id)
        {
            var url = $"{baseUrl}/{id}";
            await _client.DeleteAsync(url);
        }
    }
}
