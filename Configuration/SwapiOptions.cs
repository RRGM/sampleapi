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