using KPZ_Api.Models;

namespace KPZ_Api.Interfaces
{
    public interface ICustomerInterface
    {
        public Task<ICollection<Customer>> GetCustomers();
        public Task<Customer> GetCustomer(int id);
        public Task<bool> CustomerExists(int id);
        public Task<bool> CreateCustomer(Customer customer);
        public Task<bool> UpdateCustomer(Customer customer);
        public Task<bool> DeleteCustomer(Customer customer);
        public Task<bool> Save();
    }
}
