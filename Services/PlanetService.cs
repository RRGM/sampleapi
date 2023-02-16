using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sampleapi.Interfaces;
using sampleapi.Models;

namespace sampleapi.Services
{
    public class PlanetService : IPlanetService
    {
        public Task<PlanetResponse> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<PlanetResponse> GetByLimit(int Limit)
        {
            throw new NotImplementedException();
        }
    }
}