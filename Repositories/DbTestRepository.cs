using Microsoft.EntityFrameworkCore;
using sampleapi.Data;
using sampleapi.Models;
using System.Numerics;

namespace sampleapi.Repositories
{
    public interface IDbTestRespositorty
    {
        Task<Planet> GetPlanetAsync(int id);
        Task<Planet> CreatePlanetAsync(Planet Planet);
        Task<People> GetPeopleAsync(int id);
        Task<People> CreatePeopleAsync(People Pleople);
    }
    public class DbTestRepository : IDbTestRespositorty
    {
        public async Task<People> CreatePeopleAsync(People people)
        {
            using (var context = new SampleApiDbContext())
            {
                context.People.Add(people);
                await context.SaveChangesAsync();
            }
            return people;
        }

        public async Task<Planet> CreatePlanetAsync(Planet planet)
        {
            using (var context = new SampleApiDbContext())
            {
                context.Planets.Add(planet);
                await context.SaveChangesAsync();
            }
            return planet;
        }

        public async Task<People> GetPeopleAsync(int id)
        {
            using (var context = new SampleApiDbContext())
            {
                return await context.People.FirstOrDefaultAsync(p => p.Id == id);
            }
        }

        public async Task<Planet> GetPlanetAsync(int id)
        {
            using (var context = new SampleApiDbContext())
            {
                return await context.Planets.FirstOrDefaultAsync(p => p.Id == id);
            }
        }
    }
}