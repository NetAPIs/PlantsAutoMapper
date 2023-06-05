using AutoMapper;
using PlantsAutoMapper.Models;

namespace PlantsAutoMapper.Maps
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile() 
        { 
            CreateMap<Plant, PlantDto>();
            CreateMap<PlantDto, Plant>();
        }
    }
}
