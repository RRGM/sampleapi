using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sampleapi.Models;

namespace sampleapi.Interfaces
{
    public interface IPeopleService
    {
        Task<People> GetByLimit(int Limit);
        Task<People> GetById(int Id);
    }
}