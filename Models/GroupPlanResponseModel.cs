namespace Models
{
    public class GroupPlanResponseModel
    {

        public List<GroupPlan>? GroupPlans { get; set; }
    }


    public class GroupPlan
    {
        public string? FacultyName { get; set; }
        public string? Dasich { get; set; }
        public string? GroupName { get; set; }
        public int StudCount { get; set; }
        public string? Profession { get; set; }
        public int Course { get; set; }
        public List<Ararkap>? Ararkaps { get; set; }

    }

    public class Ararkap
    {
        public string? Ararka { get; set; }
        public string? Cursayin1 { get; set; }
        public string? Shab_jam1 { get; set; }
        public string? Das1 { get; set; }
        public string? Gorc1 { get; set; }
        public string? Lab1 { get; set; }
        public string? Qnnutyun1 { get; set; }
        public string? Stugark_1 { get; set; }
        public string? Pr1 { get; set; }

        public string? Shab_jam2 { get; set; }
        public string? Das2 { get; set; }
        public string? Gorc2 { get; set; }
        public string? Lab2 { get; set; }
        public string? Cursayin2 { get; set; }
        public string? Qnnutyun2 { get; set; }
        public string? Stugark_2 { get; set; }
        public string? Pr2 { get; set; }
        public string? Sharunak { get; set; }
        public string? Ambion { get; set; }
    }

}
