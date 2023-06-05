using Microsoft.EntityFrameworkCore;
using PlantsAutoMapper.Models;

namespace PlantsAutoMapper.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Plant> Plants { get; set; }
    }
}
