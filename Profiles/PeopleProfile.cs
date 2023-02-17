using AutoMapper;
using sampleapi.Models;
using sampleapi.Models.Swapi;
using System.Text.RegularExpressions;

namespace sampleapi.Profiles
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            CreateMap<SwapiPeople, People>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => Convert.ToInt32(Regex.Match(src.Url, @"\d+").Value))
                    );
        }
    }
}