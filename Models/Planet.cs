namespace sampleapi.Models
{
    public class Planet
    {
        public string Climate { get; set; }
        public string Diameter { get; set; }
        public string Name { get; set; }
        public string Population { get; set; }
        public ICollection<string> Residents { get; set; }
        public string Terrain { get; set; }
        public string Url { get; set; }
    }
}