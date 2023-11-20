using KPZ_Api.Data;
using KPZ_Api.Interfaces;
using KPZ_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace KPZ_Api.Repository
{
    public class DriverRepository : IDriverInterface
    {
        private readonly DataContext _context;
        public DriverRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<ICollection<Driver>> GetDrivers()
        {
            return await _context.Drivers.ToListAsync();
        }
        public async Task<Driver> GetDriver(int id)
        {
            return await _context.Drivers.FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task<bool> DriverExists(int id)
        {
            return await _context.Drivers.AnyAsync(d => d.Id == id);
        }
        public async Task<bool> CreateDriver(Driver driver)
        {
            _context.Add(driver);
            return await Save();
        }
        public async Task<bool> UpdateDriver(Driver driver)
        {
            _context.Update(driver);
            return await Save();
        }
        public async Task<bool> DeleteDriver(Driver driver)
        {
            _context.Remove(driver);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
