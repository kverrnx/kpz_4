using KPZ_Api.Models;

namespace KPZ_Api.Interfaces
{
    public interface IDriverInterface
    {
        public ICollection<Driver> GetDrivers();
        public Driver GetDriver(int id);
        public bool DriverExists(int id);
    }
}
