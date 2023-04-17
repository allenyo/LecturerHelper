
using AutoMapper;
using LecturerHelper.Data;
using LecturerHelper.Mapping;
using Models;
using System.Data;
using System.Data.OleDb;


namespace LecturerHelper.Services
{
    public class DataManager : IDataManager
    {
        private readonly LecturerhelperDbContext dbContext;
        private readonly Mapping.Mapper mapperconf;
        private readonly IMapper mapper;    
        public DataManager(LecturerhelperDbContext dbContext, Mapping.Mapper mapperconf)
        {
            this.dbContext = dbContext;
            this.mapperconf = mapperconf;  
            mapper = mapperconf.Config.CreateMapper();
        }

        public FacultyResponseModel Faculties()
        {

            var grups = AllGroups().Groups;

            var fakulties = mapper.Map<List<Fakultet>, List<Faculty>>(  dbContext.Fakultets.ToList());


            foreach (var faculty in fakulties)
                faculty.Groupes = grups.Where(a => a.Fakulty == faculty.Name).ToList().DistinctBy(a => a.Group).ToList();


            var hs = fakulties.FirstOrDefault(n => n.Name.Equals("Հոսքային", StringComparison.InvariantCultureIgnoreCase));
            if (hs != null)
                fakulties.Remove(hs);

            return new FacultyResponseModel { Faculties = fakulties };
        }

        public List<AutoHosqNumbers> AutoHosqNumbers()
        {
         
            var AutoHosqNumbers = dbContext.AutoHosqNumbers.ToList();

            return mapper.Map<List<Data.AutoHosqNumber>,List<Models.AutoHosqNumbers>>( AutoHosqNumbers);
        }
        public LoadResponseModel Loads()
        {      
            var Loads =  dbContext.Nagruzkas.ToList();

            return new LoadResponseModel
            {
                Loads = mapper.Map<List<Nagruzka>, List<Load>>(Loads)
            };
        }
        public List<Data.Kaefic> Kaefics()
        {
            var kaefics = dbContext.Kaefics.ToList();
            return kaefics;

        }

        public Patok1ResponseModel Patok1s()
        {
            var patok1s = mapper.Map<List<Data.Patok1>, List<Models.Patok1>>(  dbContext.Patok1s.ToList());       

            return new Patok1ResponseModel
            {
                Patok1s = patok1s.OrderBy(x => x.Hosq).ToList(),

            };
        }
        public PatokNaraResponseModel PatokNaras()
        {
           

            var patokNaras = dbContext.PatokNaras.ToList();        

            return new PatokNaraResponseModel
            {
                PatokNaras = mapper.Map<List<Data.PatokNara>, List<Models.PatokNara>>(patokNaras)
            };

        }

        public GroupsResponseModel AllGroups()
        {
            var groupes = dbContext.Xmbers.AsEnumerable().Where(n=> !n.Xumb.Equals("Հոսքային1", StringComparison.InvariantCultureIgnoreCase)).ToList();
    

            return new GroupsResponseModel
            {
                Groups = mapper.Map<List<Xmber>, List<Groupe>>(groupes)
            };
        }

        public GroupsResponseModel Groups()
        {

            var items = dbContext.Xmbers.AsEnumerable().Where(n => !n.Xumb.Equals("Հոսքային1", StringComparison.InvariantCultureIgnoreCase))
                .DistinctBy(p=>p.Xumb).ToList();


            return new GroupsResponseModel
            {
                Groups = mapper.Map<List<Xmber>, List<Groupe>>(items)
            };
        }

        public GroupPlanResponseModel GetGroupPlanByFakName(string fakName)
        {
            var data = AllGroups();
            data.Groups = data.Groups.Where(p => p.Fakulty.Equals(fakName, StringComparison.InvariantCultureIgnoreCase)).OrderBy(p => p.Fakulty).ToList();
            return MapToGroupPlanResponseModel(data);

        }
        public GroupPlanResponseModel GetAllGroupPlan()
        {

            var data = AllGroups();

            return MapToGroupPlanResponseModel(data);
        }

        public GroupPlanResponseModel GetGroupPlanByGroup(string groupname)
        {

            var data = AllGroups();
            data.Groups = data.Groups.Where(p => p.Group.Equals(groupname, StringComparison.InvariantCultureIgnoreCase)).OrderBy(p => p.Group).ToList();
            return MapToGroupPlanResponseModel(data);
        }

        private static GroupPlanResponseModel MapToGroupPlanResponseModel(GroupsResponseModel groupsResponseModel)
        {
            var groupPlanResponseModel = new GroupPlanResponseModel();
            GroupPlan? groupPlan = null;
            if (groupsResponseModel?.Groups != null)
            {
                groupPlanResponseModel.GroupPlans = new List<GroupPlan>();

                foreach (var group in groupsResponseModel.Groups)
                {
                    groupPlan = new GroupPlan()
                    {
                        FacultyName = group.Fakulty,
                        Dasich = group.Dasich,
                        GroupName = group.Group,
                        StudCount = group.StudCount,
                        Profession = group.Masnagit,
                        Course = group.Course,
                        Ararkaps = new List<Ararkap>()
                    };

                    var ars = groupsResponseModel.Groups.Where(p => p.Group == group.Group);

                    foreach (var ar in ars)
                    {
                        groupPlan.Ararkaps.Add(new Ararkap
                        {
                            Ararka = ar.Ararka,
                            Cursayin1 = ar.Kursayin_1,
                            Shab_jam1 = (int.Parse(ar.Das_1) + ar.Gorc1 + ar.Lab_1).ToString(),
                            Das1 = ar.Das_1,
                            Gorc1 = ar.Gorc_1.ToString(),
                            Lab1 = ar.Lab_1.ToString(),
                            Qnnutyun1 = ar.Qnutun_1,
                            Stugark_1 = ar.Stugark_1,
                            Pr1 = ar.Argin_kis.ToString(),

                            Shab_jam2 = (int.Parse(ar.Das_2) + ar.Gorc2 + ar.Lab_2).ToString(),
                            Das2 = ar.Das_2,
                            Gorc2 = ar.Gorc_2.ToString(),
                            Lab2 = ar.Lab_2.ToString(),
                            Cursayin2 = ar.Kursain_2,
                            Qnnutyun2 = ar.Qnutun_2,
                            Stugark_2 = ar.Stugark_2,
                            Pr2 = ar.Erk_kis.ToString(),
                            Sharunak = ar.Sharunak,
                            Ambion = ar.Ambion
                        });

                    }
                    groupPlanResponseModel.GroupPlans.Add(groupPlan);

                }

                groupPlanResponseModel.GroupPlans = groupPlanResponseModel.GroupPlans.OrderBy(p => p.FacultyName).DistinctBy(g => g.GroupName).ToList();
            }

            return groupPlanResponseModel;
        }

        public HosqResponse Hosq()
        {
            var data = Patok1s().Patok1s;
            var hosq = new Hosqe();
            var hosqResponse = new HosqResponse() { Hosqs = new List<Hosqe>() };

            foreach (var item in data)
            {
                hosq = new Hosqe
                {
                    Hosq = item.Hosq,
                    AmbionCode = item.AmbionCode,
                    GroupCount = item.Count,
                    Course = item.Course,
                    PUsQan = item.PUsQan,
                    XUsQan = item.XUsQan,
                    Semestr = item.Semestr,
                    Groups = new List<GroupHosq>()
                };

                var group = data.Where(p => item.Hosq == p.Hosq);

                foreach (var i in group)
                {
                    var ararkan = data.Where(p => p.Group == i.Group && p.Hosq == i.Hosq);
                    var ararkans = new List<Ararkan>();

                    foreach (var ar in ararkan)
                    {
                        ararkans.Add(new Ararkan()
                        {
                            Ararka = ar.Ararka,
                            Lek = ar.Lek,
                            QnnutyunStugarq = ar.QnnutyunStugarq
                        });
                    }


                    hosq.Groups.Add(new GroupHosq()
                    {
                        GroupName = i.Group,
                        Ararkans = ararkans
                    });

                }

                hosqResponse.Hosqs.Add(hosq);

                hosqResponse.Hosqs = hosqResponse.Hosqs.DistinctBy(p => p.Hosq).ToList();
            }

            return hosqResponse;
        }

        public GroupPlanResponseModel GetHosqPlan()
        {

            var groupes = dbContext.Xmbers.AsEnumerable().Where(p => p.Xumb.Equals("Հոսքային1", StringComparison.InvariantCultureIgnoreCase)).ToList();           

            var gr = new GroupsResponseModel
            {
                Groups = mapper.Map<List<Xmber>, List<Groupe>>(groupes)
            };

            return MapToGroupPlanResponseModel(gr);
        }

        public LoadResponseModel GetLoadByCode(string code)
        {
            var all = Loads().Loads;

            return new LoadResponseModel
            {
                Loads = all.Where(p => p.Ambion.Equals(code)).ToList()
            };
        }
    }
}

