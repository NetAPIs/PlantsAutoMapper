namespace PlantsAutoMapper.Models
{
    public class PlantDto
    {
        public string Name { get; set; } = string.Empty;
        public string LatinName { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public int Height { get; set; }
    }
}
