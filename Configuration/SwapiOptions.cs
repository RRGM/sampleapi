using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sampleapi.Configuration
{
    public class SwapiOptions
    {
        public Planet Planet { get; set; } = new Planet();
        public People People { get; set; } = new People();

    }
    public class Planet
    {
        public string BaseUrl { get; set; } = string.Empty;
    }
    public class People
    {
        public string BaseUrl { get; set; } = string.Empty;
    }
}