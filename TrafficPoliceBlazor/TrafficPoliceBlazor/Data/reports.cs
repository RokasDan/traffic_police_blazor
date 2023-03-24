namespace TrafficPoliceBlazor.Data
{
    public class reports
    {
        public long ReportId { get; set; }
        public string Author { get; set; }
        public long CarId { get; set; }
        public long OffenceId { get; set; }
        public int FineIssued { get; set; }
        public int PointsIssued { get; set; }
        public DateTime ReportDate { get; set; }
        public string Details { get; set; }
    }
}
