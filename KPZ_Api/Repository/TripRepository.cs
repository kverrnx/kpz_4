using KPZ_Api.Data;
using KPZ_Api.Interfaces;
using KPZ_Api.Models;

namespace KPZ_Api.Repository
{
    public class TripRepository : ITripInterface
    {
        private readonly DataContext _context;
        public TripRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public ICollection<Trip> GetTrips()
        {
            return _context.Trips.OrderBy(t => t.Id).ToList();
        }
        public Trip GetTrip(int id)
        {
            return _context.Trips.Where(t => t.Id == id).FirstOrDefault();
        }
        public bool TripExists(int id)
        {
            return _context.Trips.Any(t => t.Id == id);
        }
        //public bool CreateTrip(int customerId, int driverId)
        //{
        //    var tripCustomerEntity = _context.Customers.Where(c => c.Id == customerId).FirstOrDefault();
        //    var tripDriverEntity = _context.Drivers.Where(d => d.Id == driverId).FirstOrDefault();


        //}
        public bool CreateTrip(int customerId, int driverId)
        {
            throw new NotImplementedException();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
