using KPZ_Api.Data;
using KPZ_Api.Interfaces;
using KPZ_Api.Models;

namespace KPZ_Api.Repository
{
    public class DriverRepository : IDriverInterface
    {
        private readonly DataContext _context;
        public DriverRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public ICollection<Driver> GetDrivers()
        {
            return _context.Drivers.OrderBy(d => d.Id).ToList();
        }
        public Driver GetDriver(int id)
        {
            return _context.Drivers.Where(d => d.Id == id).FirstOrDefault();
        }
        public bool DriverExists(int id)
        {
            return _context.Drivers.Any(d => d.Id == id);
        }    
    }
}
