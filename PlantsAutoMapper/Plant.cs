namespace PlantsAutoMapper
{
    public class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LatinName { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty; 
        public int Height { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateModified { get; set;}

    }
}
