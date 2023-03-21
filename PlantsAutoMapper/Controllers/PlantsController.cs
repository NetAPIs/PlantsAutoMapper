using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PlantsAutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private static List<Plant> plants = new List<Plant>
        {
            new Plant{
                Id = 1,
                Name = "Vánoční Kaktus",
                LatinName = "Schlumbergera",
                Destination = "Brazil",
                Height = 25,
                DateAdded = new DateTime(2023, 03, 21),
                DateModified= null
            },

            new Plant{
                Id = 2,
                Name = "Orchidej",
                LatinName = "Orchidaceae",
                Destination = "South America",
                Height = 45,
                DateAdded = new DateTime(2023, 03, 21),
                DateModified= null
            },
        };

        private readonly IMapper _mapper;

        public PlantsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Plant>> GetAllPlans()
        {     

            return Ok(plants.Select(plant => _mapper.Map<PlantDto>(plant)));
        }

        [HttpGet("{id}")]
        public ActionResult<PlantDto> GetPlantById(int id)
        {
            Plant plant = plants.FirstOrDefault(p => p.Id == id);
            if (plant == null)
            {
                return NotFound();
            }
            PlantDto plantDto = _mapper.Map<PlantDto>(plant);
            return Ok(plantDto);
        }


        [HttpPost]
        public ActionResult<List<Plant>> AddPlan(PlantDto newPlant)
        {
            var plant = _mapper.Map<Plant>(newPlant);
            plants.Add(plant);
            return Ok(plants.Select(plant => _mapper.Map<PlantDto>(plant)));
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePlant(int id, PlantDto plantDto)
        {
            Plant plant = plants.FirstOrDefault(p => p.Id == id);
            if (plant == null)
            {
                return NotFound();
            }
            _mapper.Map(plantDto, plant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlant(int id)
        {
            Plant plant = plants.FirstOrDefault(p => p.Id == id);
            if (plant == null)
            {
                return NotFound();
            }
            plants.Remove(plant);
            return NoContent();
        }

    }
}
