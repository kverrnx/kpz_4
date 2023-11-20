using KPZ_Api.Data;
using KPZ_Api.Interfaces;
using KPZ_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace KPZ_Api.Repository
{
    public class CustomerRepository : ICustomerInterface
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<ICollection<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomer(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<bool> CustomerExists(int id)
        {
            return await _context.Customers.AnyAsync(c => c.Id == id);
        }
        public async Task<bool> CreateCustomer(Customer customer)
        {
            _context.Add(customer);
            return await Save();
        }
        public async Task<bool> UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            return await Save();
        }
        public async Task<bool> DeleteCustomer(Customer customer)
        { 
            _context.Remove(customer);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ;
        }
    }
}
