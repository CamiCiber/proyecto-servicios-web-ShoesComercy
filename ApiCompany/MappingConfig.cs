using AutoMapper;
using ApiCompany.Dtos;
using ApiCompany.Models;


namespace ApiCompany
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CompanyDto, Company>();
                config.CreateMap<Company, CompanyDto>();
            });
            return mappingConfig;
        }
    }
}
