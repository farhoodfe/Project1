using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Data
{
    public class ApiDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<WeatherInfo> WeatherInfos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectModels; Database=Project1;");
        }
    }
}
