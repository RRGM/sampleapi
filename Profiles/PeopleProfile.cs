using AutoMapper;
using sampleapi.Models;
using sampleapi.Models.Swapi;

namespace sampleapi.Profiles
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            CreateMap<SwapiPeople, People>();
        }
    }
}