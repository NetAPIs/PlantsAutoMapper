using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantsAutoMapper.Data;
using PlantsAutoMapper.Models;

namespace PlantsAutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public PlantsController(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<PlantDto>> GetAllPlans()
        {
            var plants = _context.Plants.ToList();
            var plantDtos = _mapper.Map<List<PlantDto>>(plants);

            return Ok(plantDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<PlantDto> GetPlantById(int id)
        {
            var plant = _context.Plants.FirstOrDefault(p => p.Id == id);
            if (plant == null)
            {
                return NotFound();
            }
            var plantDto = _mapper.Map<PlantDto>(plant);
            return Ok(plantDto);
        }

        [HttpPost]
        public ActionResult<List<PlantDto>> AddPlan(PlantDto newPlantDto)
        {
            var newPlant = _mapper.Map<Plant>(newPlantDto);
            _context.Plants.Add(newPlant);
            _context.SaveChanges();

            var plants = _context.Plants.ToList();
            var plantDtos = _mapper.Map<List<PlantDto>>(plants);
            return Ok(plantDtos);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePlant(int id, PlantDto plantDto)
        {
            var plant = _context.Plants.FirstOrDefault(p => p.Id == id);
            if (plant == null)
            {
                return NotFound();
            }
            _mapper.Map(plantDto, plant);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlant(int id)
        {
            var plant = _context.Plants.FirstOrDefault(p => p.Id == id);
            if (plant == null)
            {
                return NotFound();
            }
            _context.Plants.Remove(plant);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
