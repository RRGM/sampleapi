using sampleapi.Models;

namespace sampleapi.Interfaces
{
    public interface IPlanetService
    {
        Task<List<Planet>> GetByLimit(int Limit);
        Task<Planet> GetById(int Id);
    }
}