namespace Models
{
    public class HosqResponse
    {
        public List<Hosqe>? Hosqs { get; set; }
    }

    public class Hosqe
    {
        public List<GroupHosq>? Groups { get; set; }
        public double Hosq { get; set; }
        public int GroupCount { get; set; }
        public int PUsQan { get; set; }
        public int XUsQan { get; set; }
        public string? AmbionCode { get; set; }
        public int Course { get; set; }
        public double Semestr { get; set; }
    }

    public class GroupHosq
    {
        public string? GroupName { get; set; }
        public List<Ararkan>? Ararkans { get; set; }

    }

    public class Ararkan
    {
        public string? Ararka { get; set; }
        public string? Lek { get; set; }
        public string? QnnutyunStugarq { get; set; }
    }
}
