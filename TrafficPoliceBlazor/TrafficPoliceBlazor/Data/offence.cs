namespace TrafficPoliceBlazor.Data
{
    public class offence
    {
        public long OffenceID {  get; set; }
        public string Description { get; set;}
        public int MaxFine { get; set; }
        public int MaxPoints { get; set; }
    }
}
