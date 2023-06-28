using ApiShoes.Dtos;
using ApiShoes.Models;
using AutoMapper;

namespace ApiShoes
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ShoesDto, Shoes>();
                config.CreateMap<Shoes, ShoesDto>();
            });
            return mappingConfig;
        }
    }
}
