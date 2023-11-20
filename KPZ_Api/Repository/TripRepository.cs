using KPZ_Api.Data;
using KPZ_Api.Interfaces;
using KPZ_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace KPZ_Api.Repository
{
    public class TripRepository : ITripInterface
    {
        private readonly DataContext _context;
        public TripRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<ICollection<Trip>> GetTrips()
        {
            //return await _context.Trips.ToListAsync();
            return await _context.Trips
                .Include(t => t.Customer)
                    .Include(t => t.Driver)
                        .ToListAsync();
        }
        public async Task<Trip> GetTrip(int id)
        {
            return await _context.Trips
                .Include(t => t.Customer)
                    .Include(t => t.Driver)
                        .FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<bool> TripExists(int id)
        {
            return await _context.Trips.AnyAsync(t => t.Id == id);
        }
        public async Task<bool> CreateTrip(Trip trip)
        {
            _context.Add(trip);
            return await Save();
        }
        public async Task<bool> UpdateTrip(Trip trip)
        {
            _context.Update(trip);
            return await Save();
        }
        public async Task<bool> DeleteTrip(Trip trip)
        {
            _context.Remove(trip);
            return await Save();
        }
        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}
