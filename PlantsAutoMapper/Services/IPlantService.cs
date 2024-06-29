using Microsoft.AspNetCore.Mvc;
using PlantsAutoMapper.Models;

namespace PlantsAutoMapper.Services
{
    public interface IPlantService
    {
        ActionResult<List<PlantDto>> GetAllPlants();
        ActionResult<PlantDto> GetPlantById(int id);
        ActionResult<List<PlantDto>> AddPlant(PlantDto newPlantDto);
        ActionResult UpdatePlant(int id, PlantDto plantDto);
        ActionResult DeletePlant(int id);
    }
}
