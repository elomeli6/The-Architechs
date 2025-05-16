namespace project_wildfire_web.Models
{
    public class EonetEvent
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime? Closed { get; set; }
        public List<EonetGeometry> Geometry { get; set; }
    }
}