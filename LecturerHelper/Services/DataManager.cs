using LecturerHelper.Core;
using Models;
using System.Data.OleDb;


namespace LecturerHelper.Services
{
    public class DataManager : IDataManager
    {
        readonly OleDbConnection connection;

        public DataManager()
        {
            OleDbConnectionStringBuilder builder = new()
            {
                Provider = Constants.Provider,
                DataSource = Constants.DatSource,
                PersistSecurityInfo = true,
            };

            connection = new(builder.ConnectionString);
        }

        public FacultyResponseModel Faculties()
        {

            var grups = AllGroups().Groups;


            connection.Open();
            var command = new OleDbCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.TableDirect,
                CommandText = "Fakultet"
            };

            var fakulties = new List<Faculty>();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                fakulties.Add(new Faculty() { Id = reader.GetInt32(0), Name = reader.GetString(1), Code = reader.GetString(2) });
            }


            foreach (var faculty in fakulties)
                faculty.Groupes = grups.Where(a => a.Fakulty == faculty.Name).ToList().DistinctBy(a => a.Group).ToList();


            var hs = fakulties.FirstOrDefault(n => n.Name.Equals("Հոսքային", StringComparison.InvariantCultureIgnoreCase));
            if (hs != null)
                fakulties.Remove(hs);

            connection.Close();
            return new FacultyResponseModel { Faculties = fakulties };
        }

        public List<AutoHosqNumbers> AutoHosqNumbers()
        {
            connection.Open();
            var command = new OleDbCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.TableDirect,
                CommandText = "AutoHosqNumbers"
            };

            var AutoHosqNumbers = new List<AutoHosqNumbers>();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                AutoHosqNumbers.Add(new AutoHosqNumbers()
                {
                    Id = reader.GetInt32(0),
                    Course = reader.GetInt32(1),
                    Group = reader.GetString(2),
                    StudCount = reader.GetInt32(3),
                    Fakulty = reader.GetString(4),
                    AutoHosqDas = reader.GetInt32(5),
                    AutoHosqGorc = reader.GetInt32(6),
                    AutoHosqLab = reader.GetInt32(7),
                    AutoHosqGorc16 = reader.GetInt32(8),
                    AutoHosqGorc8 = reader.GetInt32(9),
                    AutoHosqLab8 = reader.GetInt32(10),
                });
            }

            connection.Close();
            return AutoHosqNumbers;
        }
        public LoadResponseModel Loads()
        {

            connection.Open();
            var command = new OleDbCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.TableDirect,
                CommandText = "Nagruzka"
            };

            var Loads = new List<Load>();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Loads.Add(new Load()
                {
                    Fakulty = reader.GetValue(0).ToString(),
                    Hosq = reader.GetInt32(1),
                    D_1 = reader.GetInt32(2),
                    G_1 = reader.GetInt32(3),
                    L_1 = reader.GetInt32(4),
                    Ararka = reader.GetValue(5).ToString(),
                    Group = reader.GetValue(6).ToString(),
                    Course = reader.GetInt32(7),
                    StudCount = reader.GetInt32(8),
                    Das_1 = reader.GetDouble(9),
                    Sem1 = reader.GetFloat(10),
                    Das_1_sum = reader.GetDouble(11),
                    Gorc_1_1 = reader.GetDouble(12),
                    Gorc_1 = reader.GetDouble(13),
                    Gorc_1_sum = reader.GetDouble(14),
                    Lab_1_1 = reader.GetDouble(15),
                    Lab_1_a = reader.GetDouble(16),
                    Lab_1 = reader.GetDouble(17),
                    Kursain_1 = reader.GetValue(18).ToString(),
                    Kurs_1 = reader.GetDouble(19),
                    Qnutun_1 = reader.GetValue(20).ToString(),
                    Qnut_1 = reader.GetDouble(21),
                    Cons_st_1 = reader.GetDouble(22),
                    Qnut_cons_1 = reader.GetDouble(23),
                    Stugark_1 = reader.GetValue(24).ToString(),
                    Stug_1 = reader.GetDouble(25),
                    Prakt_1 = reader.GetDouble(26),
                    Diplom1 = reader.GetInt32(27),
                    Texn1 = reader.GetDouble(28),
                    Gum1 = reader.GetDouble(29),
                    Das_2 = reader.GetDouble(30),
                    Sem2 = reader.GetFloat(31),
                    Das_2_sum = reader.GetDouble(32),
                    Gorc_2_2 = reader.GetDouble(33),
                    Gorc_2 = reader.GetDouble(34),
                    Gorc_2_sum = reader.GetDouble(35),
                    Lab_2_2 = reader.GetDouble(36),
                    Lab_2_a = reader.GetDouble(37),
                    Lab_2 = reader.GetDouble(38),
                    Kursain_2 = reader.GetValue(39).ToString(),
                    Kurs_2 = reader.GetDouble(40),
                    Qnutun_2 = reader.GetValue(41).ToString(),
                    Qnut_2 = reader.GetDouble(42),
                    Cons_st_2 = reader.GetDouble(43),
                    Qnut_cons_2 = reader.GetDouble(44),
                    Stugark_2 = reader.GetValue(45).ToString(),
                    Stug_2 = reader.GetDouble(46),
                    Prakt_2 = reader.GetDouble(47),
                    Ampkons = reader.GetDouble(48),
                    Avart = reader.GetDouble(49),
                    Grax = reader.GetDouble(50),
                    Avart_cons = reader.GetDouble(51),
                    Pashtpan = reader.GetDouble(52),
                    Texn2 = reader.GetDouble(53),
                    Diplom2 = reader.GetInt32(54),
                    Atestavorum = reader.GetDouble(55),
                    Gum2 = reader.GetDouble(56),
                    Ambion = reader.GetValue(57).ToString(),

                });
            }

            connection.Close();
            return new LoadResponseModel
            {
                Loads = Loads
            };
        }
        public List<Kaefic> Kaefics()
        {
            connection.Open();
            var command = new OleDbCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.TableDirect,
                CommandText = "kaefic"
            };

            var kaefics = new List<Kaefic>();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                kaefics.Add(new Kaefic()
                {
                    Id = reader.GetInt32(0),
                    Das = reader.GetFloat(1),
                    Gorc = reader.GetFloat(2),
                    Lab = reader.GetFloat(3),
                    Otar = reader.GetFloat(4),
                    Rus = reader.GetFloat(5),
                    Graf = reader.GetFloat(6),
                    Stug = reader.GetFloat(7),
                    Cons_st = reader.GetFloat(8),
                    Prakt = reader.GetFloat(9),
                    Qnut = reader.GetFloat(10),
                    Cons = reader.GetFloat(11),
                    Hashvet = reader.GetFloat(12),
                    Grax = reader.GetFloat(13),
                    Ampkons = reader.GetFloat(14),
                    Avart = reader.GetFloat(15),
                    KursN = reader.GetFloat(16),
                    KursN_M = reader.GetFloat(17),
                    KursA = reader.GetFloat(18),
                    Avart_cons = reader.GetFloat(19),
                    Diplom = reader.GetFloat(20),
                    Pashtpan = reader.GetFloat(21),
                    Ekanomika = reader.GetFloat(22),
                    Axrana = reader.GetFloat(23),
                    Prakt1 = reader.GetInt32(24),
                    Prakt2 = reader.GetInt32(25),
                    Infor = reader.GetInt32(26),
                    Atestavorum = reader.GetFloat(27)
                });
            }

            connection.Close();
            return kaefics;

        }

        public Patok1ResponseModel Patok1s()
        {

            connection.Open();
            var command = new OleDbCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.TableDirect,
                CommandText = "Patok_1"
            };

            var patok1s = new List<Patok1>();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                patok1s.Add(new Patok1()
                {
                    Id = reader.GetInt32(0),
                    Group = reader.GetValue(1).ToString(),
                    Ararka = reader.GetValue(2).ToString(),
                    Semestr = reader.GetDouble(3),
                    Hosq = reader.GetDouble(4),
                    Count = reader.GetInt32(5),
                    Lek = reader.GetValue(6).ToString(),
                    PUsQan = reader.GetInt32(7),
                    XUsQan = reader.GetInt32(8),
                    AmbionCode = reader.GetString(9),
                    Course = reader.GetByte(10),
                    QnnutyunStugarq = reader.GetString(11)

                });
            }

            connection.Close();

            return new Patok1ResponseModel
            {
                Patok1s = patok1s

            };
        }
        public PatokNaraResponseModel PatokNaras()
        {
            connection.Open();
            var command = new OleDbCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.TableDirect,
                CommandText = "Patok_Nara"
            };

            var patokNaras = new List<PatokNara>();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                patokNaras.Add(new PatokNara()
                {
                    Id = reader.GetInt32(0),
                    Ararka = reader.GetValue(1).ToString(),
                    AmbionCode = reader.GetValue(2).ToString(),
                    Hosq = reader.GetDouble(3),
                    Groups = reader.GetValue(4).ToString(),
                    PUsQan = reader.GetInt32(5),
                    Count = reader.GetInt32(6),
                    Lek = reader.GetValue(7).ToString(),
                    Semestr = reader.GetDouble(8),
                    Course = reader.GetByte(9),
                    QnnutyunStugarq = reader.GetString(10)

                });
            }

            connection.Close();

            return new PatokNaraResponseModel
            {
                PatokNaras = patokNaras
            };


        }

        public GroupsResponseModel AllGroups()
        {
            connection.Open();
            var command = new OleDbCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.TableDirect,
                CommandText = "Xmber"
            };

            var groupes = new List<Groupe>();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                groupes.Add(new Groupe()
                {
                    Ararka = reader.GetValue(0).ToString(),
                    Sem1 = reader.GetFloat(1),
                    Sem2 = reader.GetFloat(2),
                    Gorc1 = reader.GetInt32(3),
                    Gorc2 = reader.GetInt32(4),
                    Tarekan = reader.GetValue(5).ToString(),
                    Argin_kis = reader.GetInt32(6),
                    Shab_jam_1 = reader.GetFloat(7),
                    Das_1 = reader.GetValue(8).ToString(),
                    Gorc_1 = reader.GetFloat(9),
                    Lab_1 = reader.GetFloat(10),
                    Kursayin_1 = reader.GetValue(11).ToString(),
                    Qnutun_1 = reader.GetValue(12).ToString(),
                    Stugark_1 = reader.GetValue(13).ToString(),
                    Erk_kis = reader.GetInt32(14),
                    Shab_jam_2 = reader.GetInt32(15),
                    Das_2 = reader.GetValue(16).ToString(),
                    Gorc_2 = reader.GetFloat(17),
                    Lab_2 = reader.GetFloat(18),
                    Kursain_2 = reader.GetValue(19).ToString(),
                    Qnutun_2 = reader.GetValue(20).ToString(),
                    Stugark_2 = reader.GetValue(21).ToString(),
                    Sharunak = reader.GetValue(22).ToString(),
                    Ambion = reader.GetValue(23).ToString(),
                    Group = reader.GetValue(24).ToString(),
                    Masnagit = reader.GetValue(25).ToString(),
                    Dasich = reader.GetValue(26).ToString(),
                    StudCount = reader.GetInt32(27),
                    Course = reader.GetInt32(28),
                    Fakulty = reader.GetValue(29).ToString(),
                    Graxos = reader.GetValue(30).ToString(),
                    L1 = reader.GetInt32(31),
                    L2 = reader.GetInt32(32),
                    Id = reader.GetInt32(33),
                    Hosq = reader.GetInt32(34),
                    D_1 = reader.GetInt32(35),
                    D_2 = reader.GetInt32(36),
                    G_1 = reader.GetInt32(37),
                    G_2 = reader.GetInt32(38),
                    L_1 = reader.GetInt32(39),
                    L_2 = reader.GetInt32(40),
                    DH1 = reader.GetInt32(41),
                    DH2 = reader.GetInt32(42),
                    GH1 = reader.GetInt32(43),
                    GH2 = reader.GetInt32(44),
                    LH1 = reader.GetInt32(45),
                    LH2 = reader.GetInt32(46),
                    DH1q = reader.GetInt32(47),
                    DH2q = reader.GetInt32(48),
                    GH1q = reader.GetInt32(49),
                    GH2q = reader.GetInt32(50),
                    LH1q = reader.GetInt32(51),
                    LH2q = reader.GetInt32(52)
                });
            }

            connection.Close();

            var hs = groupes.FirstOrDefault(n => n.Group.Equals("Հոսքային1", StringComparison.InvariantCultureIgnoreCase));
            if (hs != null)
                groupes.Remove(hs);

            return new GroupsResponseModel
            {
                Groups = groupes
            };
        }

        public GroupsResponseModel Groups()
        {
            connection.Open();
            var command = new OleDbCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.TableDirect,
                CommandText = "Xmber"
            };

            var groupes = new List<Groupe>();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                groupes.Add(new Groupe()
                {
                    Ararka = reader.GetValue(0).ToString(),
                    Sem1 = reader.GetFloat(1),
                    Sem2 = reader.GetFloat(2),
                    Gorc1 = reader.GetInt32(3),
                    Gorc2 = reader.GetInt32(4),
                    Tarekan = reader.GetValue(5).ToString(),
                    Argin_kis = reader.GetInt32(6),
                    Shab_jam_1 = reader.GetFloat(7),
                    Das_1 = reader.GetValue(8).ToString(),
                    Gorc_1 = reader.GetFloat(9),
                    Lab_1 = reader.GetFloat(10),
                    Kursayin_1 = reader.GetValue(11).ToString(),
                    Qnutun_1 = reader.GetValue(12).ToString(),
                    Stugark_1 = reader.GetValue(13).ToString(),
                    Erk_kis = reader.GetInt32(14),
                    Shab_jam_2 = reader.GetInt32(15),
                    Das_2 = reader.GetValue(16).ToString(),
                    Gorc_2 = reader.GetFloat(17),
                    Lab_2 = reader.GetFloat(18),
                    Kursain_2 = reader.GetValue(19).ToString(),
                    Qnutun_2 = reader.GetValue(20).ToString(),
                    Stugark_2 = reader.GetValue(21).ToString(),
                    Sharunak = reader.GetValue(22).ToString(),
                    Ambion = reader.GetValue(23).ToString(),
                    Group = reader.GetValue(24).ToString(),
                    Masnagit = reader.GetValue(25).ToString(),
                    Dasich = reader.GetValue(26).ToString(),
                    StudCount = reader.GetInt32(27),
                    Course = reader.GetInt32(28),
                    Fakulty = reader.GetValue(29).ToString(),
                    Graxos = reader.GetValue(30).ToString(),
                    L1 = reader.GetInt32(31),
                    L2 = reader.GetInt32(32),
                    Id = reader.GetInt32(33),
                    Hosq = reader.GetInt32(34),
                    D_1 = reader.GetInt32(35),
                    D_2 = reader.GetInt32(36),
                    G_1 = reader.GetInt32(37),
                    G_2 = reader.GetInt32(38),
                    L_1 = reader.GetInt32(39),
                    L_2 = reader.GetInt32(40),
                    DH1 = reader.GetInt32(41),
                    DH2 = reader.GetInt32(42),
                    GH1 = reader.GetInt32(43),
                    GH2 = reader.GetInt32(44),
                    LH1 = reader.GetInt32(45),
                    LH2 = reader.GetInt32(46),
                    DH1q = reader.GetInt32(47),
                    DH2q = reader.GetInt32(48),
                    GH1q = reader.GetInt32(49),
                    GH2q = reader.GetInt32(50),
                    LH1q = reader.GetInt32(51),
                    LH2q = reader.GetInt32(52)
                });
            }

            connection.Close();
            var items = groupes.GroupBy(p => p.Group).Select(p => p.First()).ToList();
            var hs = items.FirstOrDefault(n => n.Group.Equals("Հոսքային1", StringComparison.InvariantCultureIgnoreCase));
            if (hs != null)
                items.Remove(hs);

            return new GroupsResponseModel
            {
                Groups = items
            };
        }
        /*
                void GetReport()
                {

                    Application access = new Application();

                    // open the Access database
                    Database db = access.OpenDatabase("path/to/your/database.accdb");

                    // get the report that you want to export
                    Report report = db.Reports["NameOfYourReport"];

                    // export the report as an HTML file
                    string outputFile = "path/to/your/output/file.html";
                    report.PublishToHTML(outputFile);

                    // clean up resources
                    report.Close();
                    db.Close();
                    access.Quit();


                }*/
    }
}
