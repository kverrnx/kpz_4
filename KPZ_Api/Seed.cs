using KPZ_Api.Data;
using KPZ_Api.Models;

namespace KPZ_Api
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void SeedDataContext()
        {
            if(!dataContext.Trips.Any())
            {
                var trips = new List<Trip>()
                {
                    new Trip()
                    {
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddMinutes(30),
                        StartPoint = "Vashynhtona 17A St.",
                        EndPoint = "Bandery 55 St.",
                        Price = 120.67,
                        Status = "Completed",
                        Description = " - ",
                        Customer = new Customer()
                        {
                            Name = "Pavlo",
                            Surname = "Hertsun",
                            Phone = "+380963528218",
                            Email = "hpavlo140904@gmail.com",
                            Address = "Vashynhtona 17A St.",
                            Rating = 5
                        },
                        Driver = new Driver()
                        {
                            Name = "Ivan",
                            Surname = "Karpinskiy",
                            Phone = "+380972347183",
                            Email = "ivankarpinskiy@gmail.com",
                            Balance = 90.99,
                            Rating = 5
                        }
                    }
                };
                //var customers = new List<Customer>() { 
                //    new Customer()
                //    {
                //        Name = "Pavlo",
                //            Surname = "Hertsun",
                //            Phone = "+380963528218",
                //            Email = "hpavlo140904@gmail.com",
                //            Address = "Vashynhtona 17A St.",
                //            Rating = 5
                //    },
                //    new Customer()
                //    {
                //            Name = "Ivan",
                //            Surname = "Karpinskiy",
                //            Phone = "+380972347183",
                //            Email = "ivankarpinskiy@gmail.com",
                //            Address = "Sichovyh Strilrsiv 15 St.",
                //            Rating = 5
                //    }
                //};
                //dataContext.Customers.AddRange(customers);
                dataContext.Trips.AddRange(trips);
                dataContext.SaveChanges();
            }
        }
    }
}
