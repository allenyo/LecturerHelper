namespace Models
{
    public class Patok1ResponseModel
    {
        public List<Patok1>? Patok1s { get; set; }
    }
    public class Patok1
    {
        public int Id { get; set; }
        public string? Group { get; set; }
        public string? Ararka { get; set; }
        public double Semestr { get; set; }
        public double Hosq { get; set; }
        public int Count { get; set; }
        public string? Lek { get; set; }
        public int PUsQan { get; set; }
        public int XUsQan { get; set; }
        public string? AmbionCode { get; set; }
        public int Course { get; set; }
        public string? QnnutyunStugarq { get; set; }
    }

}
