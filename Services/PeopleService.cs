using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sampleapi.Interfaces;
using sampleapi.Models;

namespace sampleapi.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly HttpClient _httpClient;
        public PeopleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PeopleResponse> GetById(int Id)
        {
           var response = await _httpClient.GetAsync($"/{Id}");

            return new PeopleResponse();
        }

        public async Task<PeopleResponse> GetByLimit(int Limit)
        {
            throw new NotImplementedException();
        }
    }
}