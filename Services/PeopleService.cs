using AutoMapper;
using Newtonsoft.Json;
using sampleapi.Models;
using sampleapi.Models.Swapi;
using sampleapi.Repositories;

namespace sampleapi.Services
{
    public interface IPeopleService
    {
        Task<List<People>> GetByLimit(int Limit);
        Task<People> GetById(int Id);
    }

    public class PeopleService : IPeopleService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly IDbTestRespositorty _repo;

        public PeopleService(HttpClient httpClient, IMapper mapper, IDbTestRespositorty repo)
        {
            _httpClient = httpClient;
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<People> GetById(int Id)
        {
            //var responseFromRepo = await _repo.GetPeopleAsync(Id);
            
            //if(responseFromRepo is not null)
            //{
            //    return responseFromRepo;
            //}

            var response = await _httpClient.GetAsync($"{Id}");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var apiresponse = JsonConvert.DeserializeObject<SwapiPeople>(content);

            var people = _mapper.Map<People>(apiresponse);

            //await _repo.CreatePeopleAsync(people);

            return people;
        }

        public async Task<List<People>> GetByLimit(int Limit)
        {
            return await FetchPeopleByLimit(Limit);
        }

        private async Task<List<People>> FetchPeopleByLimit(int Limit)
        {
            var response = await _httpClient.GetAsync(string.Empty);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var apiresponse = JsonConvert.DeserializeObject<SwapiPeoplePaginated>(content);

            if (Limit <= apiresponse.Results.Count)
            {
                return _mapper.Map<List<People>>(apiresponse.Results).GetRange(0, Limit);
            }
            else
            {
                double elemenCount = Convert.ToDouble(apiresponse.Count);

                double maxPages = Math.Ceiling(elemenCount / apiresponse.Results.Count);

                double pages = (Limit <= elemenCount) ? Math.Ceiling(Limit / (double)apiresponse.Results.Count) : maxPages;

                var planetList = new List<People>();

                for (int i = 1; i <= pages; i++)
                {
                    var pageresponse = await _httpClient.GetAsync(i == 1 ? string.Empty : $"?page={i}");
                    pageresponse.EnsureSuccessStatusCode();

                    var mappedResponse = _mapper.Map<List<People>>(
                                                JsonConvert.DeserializeObject<SwapiPeoplePaginated>(
                                                await pageresponse.Content.ReadAsStringAsync())
                                                .Results);

                    if (mappedResponse.Count + planetList.Count > Limit)
                    {
                        planetList.AddRange(mappedResponse.GetRange(0, Limit - planetList.Count));
                    }
                    else
                    {
                        planetList.AddRange(mappedResponse);
                    }

                }

                return planetList;

            }
        }
    }
}