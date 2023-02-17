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
        public async Task<People> GetById(int Id)
        {
           var response = await _httpClient.GetAsync($"/{Id}");

            return new People();
        }

        public async Task<People> GetByLimit(int Limit)
        {
            throw new NotImplementedException();
        }
    }
}