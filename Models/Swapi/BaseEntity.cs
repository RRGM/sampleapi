using Newtonsoft.Json;

namespace sampleapi.Models.Swapi
{
    public abstract class BaseEntity
    {
    [JsonProperty]
    public string Url { get; set; }
    [JsonProperty]
    public DateTime Created { get; set; }
    [JsonProperty]
    public DateTime Edited { get; set; }

    }
}
