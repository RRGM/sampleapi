using Newtonsoft.Json;

namespace sampleapi.Models.Swapi
{
    public class SwapiPlanet : BaseEntity
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Diameter { get; set; }

        [JsonProperty(PropertyName = "rotation_period")]
        public string RotationPeriod { get; set; }

        [JsonProperty(PropertyName = "orbital_period")]
        public string OrbitalPeriod { get; set; }

        [JsonProperty]
        public string Gravity { get; set; }

        [JsonProperty]
        public string Climate { get; set; }

        [JsonProperty]
        public string Terrain { get; set; }
        [JsonProperty]
        public string Population { get; set; }

        [JsonProperty(PropertyName = "surface_water")]
        public string SurfaceWater { get; set; }

        [JsonProperty]
        public ICollection<string> Residents { get; set; }

        [JsonProperty]
        public ICollection<string> Films { get; set; }
    }

    public class SwapiPlanetsPaginated : BasePagination
    {
        public ICollection<SwapiPlanet> Results { get; set; }
    }
}