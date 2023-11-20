using KPZ_Api.Models;

namespace KPZ_Api.Interfaces
{
    public interface ITripInterface
    {
        public Task<ICollection<Trip>> GetTrips();
        public Task<Trip> GetTrip(int id);
        public Task<bool> TripExists(int id);
        public Task<bool> CreateTrip(Trip trip);
        public Task<bool> UpdateTrip(Trip trip);
        public Task<bool> DeleteTrip(Trip trip);
        public Task<bool> Save();
    }
}
