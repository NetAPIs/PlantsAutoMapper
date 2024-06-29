using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantsAutoMapper.Data;
using PlantsAutoMapper.Models;
using PlantsAutoMapper.Services;

namespace PlantsAutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantService _service;

        public PlantsController(IPlantService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<PlantDto>> GetAllPlans()
        {
           return _service.GetAllPlans();
        }

        [HttpGet("{id}")]
        public ActionResult<PlantDto> GetPlantById(int id)
        {
            return _service.GetPlantById(id);
        }

        [HttpPost]
        public ActionResult<List<PlantDto>> AddPlant(PlantDto newPlantDto)
        {
            return _service.AddPlant(newPlantDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePlant(int id, PlantDto plantDto)
        {
            return _service.UpdatePlant(id, plantDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlant(int id)
        {
            return _service.DeletePlant(id);
        }
    }
}
