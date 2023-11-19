using AutoMapper;
using KPZ_Api.Dto;
using KPZ_Api.Models;

namespace KPZ_Api.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<Driver, DriverDto>();
            CreateMap<DriverDto, DriverDto>();

            CreateMap<Trip, TripDto>();
            CreateMap<TripDto, Trip>();
        }
    }
}
