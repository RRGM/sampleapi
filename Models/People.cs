using Newtonsoft.Json;
using sampleapi.Models.Swapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sampleapi.Models
{
    public class People
    {
        public string Name { get; set; }
        public string BirthYear { get; set; }
        public string EyeColor { get; set; }
        public string Gender { get; set; }
        public string HairColor { get; set; }
        public string Height { get; set; }
        public string HomeWolrd { get; set; }
        public string Mass { get; set; }
        public string SkinColor { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string Url { get; set; }
    }
}