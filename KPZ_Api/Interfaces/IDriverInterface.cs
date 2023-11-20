using KPZ_Api.Models;

namespace KPZ_Api.Interfaces
{
    public interface IDriverInterface
    {
        public Task<ICollection<Driver>> GetDrivers();
        public Task<Driver> GetDriver(int id);
        public Task<bool> DriverExists(int id);
        public Task<bool> CreateDriver(Driver driver);
        public Task<bool> UpdateDriver(Driver driver);
        public Task<bool> DeleteDriver(Driver driver);
        public Task<bool> Save();
    }
}
