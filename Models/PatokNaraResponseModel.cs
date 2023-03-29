namespace Models
{
    public class PatokNaraResponseModel
    {
        public List<PatokNara>? PatokNaras { get; set; }
    }
    public class PatokNara
    {
        public int Id { get; set; }
        public string? Ararka { get; set; }
        public string? AmbionCode { get; set; }
        public double Hosq { get; set; }
        public string? Groups { get; set; }
        public int PUsQan { get; set; }
        public int Count { get; set; }
        public string? Lek { get; set; }
        public double Semestr { get; set; }
        public int Course { get; set; }
        public string? QnnutyunStugarq { get; set; }
    }
}
