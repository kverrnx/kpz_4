namespace KPZ_Api.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }
        public Driver Driver { get; set; }
    }
}
