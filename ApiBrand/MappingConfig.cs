using ApiBrand.Models;
using ApiBrand.Dtos;
using AutoMapper;

namespace ApiBrand
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<BrandDto, Brand>();
                config.CreateMap<Brand, BrandDto>();
            });
            return mappingConfig;
        }
    }
}