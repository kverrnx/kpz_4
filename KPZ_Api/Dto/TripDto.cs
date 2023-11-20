using KPZ_Api.Models;

namespace KPZ_Api.Dto
{
    public class TripDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public CustomerDto Customer { get; set; }
        public DriverDto Driver { get; set; }
    }
}
