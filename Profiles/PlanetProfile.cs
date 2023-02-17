using AutoMapper;
using sampleapi.Models;
using sampleapi.Models.Swapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sampleapi.Profiles
{
    public class PlanetProfile: Profile
    {
        public PlanetProfile()
        {
            CreateMap<SwapiPlanet, Planet>();
        }
    }
}