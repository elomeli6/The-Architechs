namespace project_wildfire_web.Models
{
    public class EonetGeometry
    {
        public decimal? MagnitudeValue { get; set; }
        public string MagnitudeUnit { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public List<double> Coordinates { get; set; }

        // convenience props
        public double Longitude => Coordinates?.ElementAtOrDefault(0) ?? 0;
        public double Latitude  => Coordinates?.ElementAtOrDefault(1) ?? 0;
    }
}