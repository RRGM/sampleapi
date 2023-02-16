using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sampleapi.Models;

namespace sampleapi.Interfaces
{
    public interface IPeopleService
    {
        Task<PeopleResponse> GetByLimit(int Limit);
        Task<PeopleResponse> GetById(int Id);
    }
}