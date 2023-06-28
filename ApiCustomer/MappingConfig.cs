using AutoMapper;
using AppCustomer.Models;
using AppCustomer.Dtos;

namespace AppCustomer
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CustomerDto, Customer>();
                config.CreateMap<Customer, CustomerDto>();
            });
            return mappingConfig;
        }
    }
}
