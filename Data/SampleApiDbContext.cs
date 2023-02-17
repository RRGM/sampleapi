using Microsoft.EntityFrameworkCore;
using sampleapi.Models;

namespace sampleapi.Data
{
    public class SampleApiDbContext : DbContext
    {
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "dbTest");
        }
        public DbSet<People> People { get; set; }
        public DbSet<Planet> Planets { get; set; }
    }
}