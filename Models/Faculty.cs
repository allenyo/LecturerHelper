namespace Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public List<Groupe> Groupes { get; set; }
    }

}
