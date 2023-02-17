using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sampleapi.Models.Swapi
{
    public class BasePagination
    {
        public string Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
    }
}