using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sampleapi.Models;

namespace sampleapi.Interfaces
{
    public interface IPlanetService
    {
        Task<PlanetResponse> GetByLimit(int Limit);
        Task<PlanetResponse> GetById(int Id);
    }
}