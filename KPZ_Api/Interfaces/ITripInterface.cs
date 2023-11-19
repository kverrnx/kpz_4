using KPZ_Api.Models;

namespace KPZ_Api.Interfaces
{
    public interface ITripInterface
    {
        public ICollection<Trip> GetTrips();
        public Trip GetTrip(int id);
        public bool TripExists(int id);
        public bool CreateTrip(int customerId, int driverId);
        public bool Save();
    }
}
