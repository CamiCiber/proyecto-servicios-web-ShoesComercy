using ApiWorker.Dtos;
using ApiWorker.Models;
using AutoMapper;

namespace ApiWorker
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<WorkerDto, Worker>();
                config.CreateMap<Worker, WorkerDto>();
            });
            return mappingConfig;
        }
    }
}
