using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantsAutoMapper.Data;
using PlantsAutoMapper.Models;

namespace PlantsAutoMapper.Services
{
    public class PlantService : IPlantService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public PlantService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public ActionResult<List<PlantDto>> AddPlant(PlantDto newPlantDto)
        {
            var newPlant = _mapper.Map<Plant>(newPlantDto);
            _context.Plants.Add(newPlant);
            _context.SaveChanges();

            var plants = _context.Plants.ToList();
            var plantDtos = _mapper.Map<List<PlantDto>>(plants);
            return plantDtos;
        }

        public ActionResult DeletePlant(int id)
        {
            var plant = _context.Plants.FirstOrDefault(p => p.Id == id);
            if (plant == null)
            {
                throw new Exception("Plant not found!");
            }
            _context.Plants.Remove(plant);
            _context.SaveChanges();
            throw new Exception("");
        }

        public ActionResult<List<PlantDto>> GetAllPlans()
        {
            var plants = _context.Plants.ToList();
            var plantDtos = _mapper.Map<List<PlantDto>>(plants);

            return plantDtos;
        }

        public ActionResult<PlantDto> GetPlantById(int id)
        {
            var plant = _context.Plants.FirstOrDefault(p => p.Id == id);
            if (plant == null)
            {
                throw new Exception("Plant not found!");
            }
            var plantDto = _mapper.Map<PlantDto>(plant);
            return plantDto;
        }

        public ActionResult UpdatePlant(int id, PlantDto plantDto)
        {
            var plant = _context.Plants.FirstOrDefault(p => p.Id == id);
            if (plant == null)
            {
                throw new Exception("Plant not found!");
            }
            _mapper.Map(plantDto, plant);
            _context.SaveChanges();
            throw new Exception("");
        }
    }
}
