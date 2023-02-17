using AutoMapper;
using Newtonsoft.Json;
using sampleapi.Interfaces;
using sampleapi.Models;
using sampleapi.Models.Swapi;

namespace sampleapi.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public PeopleService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;

        }
        public async Task<People> GetById(int Id)
        {
            var response = await _httpClient.GetAsync($"{Id}");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var apiresponse = JsonConvert.DeserializeObject<SwapiPeople>(content);

            return _mapper.Map<People>(apiresponse);
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