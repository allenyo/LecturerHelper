using AutoMapper;
using Models;

namespace LecturerHelper.Mapping
{
    public class Mapper : Profile
    {
        public MapperConfiguration Config { get; set; }

        public Mapper()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Data.Xmber, Groupe>()
                .ForMember(p => p.Argin_kis, p => p.MapFrom(a => a.ArginKis))
                .ForMember(p => p.Shab_jam_1, p => p.MapFrom(a => a.ShabJam1))
                .ForMember(p => p.Shab_jam_2, p => p.MapFrom(a => a.ShabJam2))
                .ForMember(p => p.Das_1, p => p.MapFrom(a => a.Das1))
                .ForMember(p => p.Gorc_1, p => p.MapFrom(a => a.Gorc1))
                .ForMember(p => p.Gorc_2, p => p.MapFrom(a => a.Gorc2))
                .ForMember(p => p.Gorc_1, p => p.MapFrom(a => a.Gorc11))
                .ForMember(p => p.Gorc_2, p => p.MapFrom(a => a.Gorc21))
                .ForMember(p => p.Das_2, p => p.MapFrom(a => a.Das2))
                .ForMember(p => p.Kursayin_1, p => p.MapFrom(a => a.Kursain1))
                .ForMember(p => p.Kursain_2, p => p.MapFrom(a => a.Kursain2))
                .ForMember(p => p.Qnutun_1, p => p.MapFrom(a => a.Qnutun1))
                .ForMember(p => p.Stugark_1, p => p.MapFrom(a => a.Stugark1))
                .ForMember(p => p.Qnutun_2, p => p.MapFrom(a => a.Qnutun2))
                .ForMember(p => p.Stugark_2, p => p.MapFrom(a => a.Stugark2))
                .ForMember(p => p.Erk_kis, p => p.MapFrom(a => a.ErkKis))
                .ForMember(p => p.StudCount, p => p.MapFrom(a => a.StudKanak))
                .ForMember(p => p.Course, p => p.MapFrom(a => a.Kurs))
                .ForMember(p => p.Group, p => p.MapFrom(a => a.Xumb))
                .ForMember(p => p.LH1, p => p.MapFrom(a => a.Lh1))
                .ForMember(p => p.LH2, p => p.MapFrom(a => a.Lh2))
                .ForMember(p => p.LH2q, p => p.MapFrom(a => a.Lh2q))
                .ForMember(p => p.LH1q, p => p.MapFrom(a => a.Lh1q))
                .ForMember(p => p.DH1, p => p.MapFrom(a => a.Dh1))
                .ForMember(p => p.DH1q, p => p.MapFrom(a => a.Dh1q))
                .ForMember(p => p.GH1, p => p.MapFrom(a => a.Gh1))
                .ForMember(p => p.GH1q, p => p.MapFrom(a => a.Gh1q))
                .ForMember(p => p.D_1, p => p.MapFrom(a => a.D1))
                .ForMember(p => p.D_2, p => p.MapFrom(a => a.D2))
                .ForMember(p => p.G_1, p => p.MapFrom(a => a.G1))
                .ForMember(p => p.G_2, p => p.MapFrom(a => a.G2))
                .ForMember(p => p.L_1, p => p.MapFrom(a => a.L11))
                .ForMember(p => p.L_2, p => p.MapFrom(a => a.L21))
                .ForMember(p => p.DH2, p => p.MapFrom(a => a.Dh2))
                .ForMember(p => p.GH2, p => p.MapFrom(a => a.Gh2))
                .ForMember(p => p.GH2q, p => p.MapFrom(a => a.Gh2q))
                .ForMember(p => p.DH2q, p => p.MapFrom(a => a.Dh2q))
                .ForMember(p => p.G_2, p => p.MapFrom(a => a.G2))
                .ForMember(p => p.G_1, p => p.MapFrom(a => a.G1))
                .ForMember(p => p.D_1, p => p.MapFrom(a => a.D1))
                .ForMember(p => p.D_2, p => p.MapFrom(a => a.D2))
                .ForMember(p => p.Fakulty, p => p.MapFrom(a => a.Fakultet))
                .ForMember(p => p.Graxos, p => p.MapFrom(a => a.Graxos.ToString() ?? string.Empty))
                .ForMember(p => p.Tarekan, p => p.MapFrom(a => a.Tarekan.ToString() ?? string.Empty))
                ;
                cfg.CreateMap<Data.PatokNara, Models.PatokNara>()
                .ForMember(p => p.Groups, p => p.MapFrom(a => a.Xmber))
                .ForMember(p => p.Count, p => p.MapFrom(a => a.Kanak))
                .ForMember(p => p.Course, p => p.MapFrom(a => a.Kurs))
                .ForMember(p => p.AmbionCode, p => p.MapFrom(p => p.AmbionKod));
                ;
                cfg.CreateMap<Data.Fakultet, Models.Faculty>()
                .ForMember(p => p.Name, p => p.MapFrom(a => a.FakName))
                .ForMember(p => p.Code, p => p.MapFrom(a => a.FakKod));
                cfg.CreateMap<Data.AutoHosqNumber, Models.AutoHosqNumbers>()
                .ForMember(p => p.Course, p => p.MapFrom(a => a.Kurs))
                .ForMember(p => p.Group, p => p.MapFrom(a => a.Xumb))
                ;
                cfg.CreateMap<Data.Patok1, Models.Patok1>()
                .ForMember(p => p.Group, p => p.MapFrom(a => a.Xumb))
                .ForMember(p => p.Course, p => p.MapFrom(a => a.Kurs))
                .ForMember(p => p.Count, p => p.MapFrom(a => a.Kanak))
                .ForMember(p => p.AmbionCode, p => p.MapFrom(a => a.AmbionKod))
                ;
                cfg.CreateMap<Data.Nagruzka, Models.Load>()
                .ForMember(p => p.Fakulty, p => p.MapFrom(a => a.Fakultet))
                .ForMember(p => p.D_1, p => p.MapFrom(a => a.D1))
                .ForMember(p => p.G_1, p => p.MapFrom(a => a.G1))
                .ForMember(p => p.L_1, p => p.MapFrom(a => a.L1))
                .ForMember(p => p.Group, p => p.MapFrom(a => a.Xumb))
                .ForMember(p => p.Course, p => p.MapFrom(a => a.Kurs))
                .ForMember(p => p.StudCount, p => p.MapFrom(a => a.StudKanak))
                .ForMember(p => p.Das_1, p => p.MapFrom(a => a.Das1))
                .ForMember(p => p.Das_1_sum, p => p.MapFrom(a => a.Das1Sum))
                .ForMember(p => p.Gorc_1_1, p => p.MapFrom(a => a.Gorc11))
                .ForMember(p => p.Gorc_1, p => p.MapFrom(a => a.Gorc1))
                .ForMember(p => p.Gorc_1_sum, p => p.MapFrom(a => a.Gorc1Sum))
                .ForMember(p => p.Lab_1_1, p => p.MapFrom(a => a.Lab11))
                .ForMember(p => p.Lab_1_a, p => p.MapFrom(a => a.Lab1A))
                .ForMember(p => p.Lab_1, p => p.MapFrom(a => a.Lab1))
                .ForMember(p => p.Kursain_1, p => p.MapFrom(a => a.Kursain1))
                .ForMember(p => p.Kursain_2, p => p.MapFrom(a => a.Kursain2))
                .ForMember(p => p.Kurs_1, p => p.MapFrom(a => a.Kurs1))
                .ForMember(p => p.Kurs_2, p => p.MapFrom(a => a.Kurs2))
                .ForMember(p => p.Qnut_1, p => p.MapFrom(a => a.Qnut1))
                .ForMember(p => p.Qnut_2, p => p.MapFrom(a => a.Qnut2))
                .ForMember(p => p.Qnutun_1, p => p.MapFrom(a => a.Qnutun1))
                .ForMember(p => p.Qnutun_2, p => p.MapFrom(a => a.Qnutun2))
                .ForMember(p => p.Cons_st_1, p => p.MapFrom(a => a.ConsSt1))
                .ForMember(p => p.Cons_st_2, p => p.MapFrom(a => a.ConsSt2))
                .ForMember(p => p.Qnut_cons_1, p => p.MapFrom(a => a.QnutCons1))
                .ForMember(p => p.Qnut_cons_2, p => p.MapFrom(a => a.QnutCons2))
                .ForMember(p => p.Stugark_1, p => p.MapFrom(a => a.Stugark1))
                .ForMember(p => p.Stugark_2, p => p.MapFrom(a => a.Stugark2))
                .ForMember(p => p.Stug_1, p => p.MapFrom(a => a.Stug1))
                .ForMember(p => p.Stug_2, p => p.MapFrom(a => a.Stug2))
                .ForMember(p => p.Prakt_1, p => p.MapFrom(a => a.Prakt1))
                .ForMember(p => p.Prakt_2, p => p.MapFrom(a => a.Prakt2))
                .ForMember(p => p.Das_2, p => p.MapFrom(a => a.Das2))
                .ForMember(p => p.Das_2_sum, p => p.MapFrom(a => a.Das2Sum))
                .ForMember(p => p.Gorc_2, p => p.MapFrom(a => a.Gorc2))
                .ForMember(p => p.Gorc_2_2, p => p.MapFrom(a => a.Gorc22))
                .ForMember(p => p.Gorc_2_sum, p => p.MapFrom(a => a.Gorc2Sum))
                .ForMember(p => p.Avart_cons, p => p.MapFrom(a => a.AvartCons))
                .ForMember(p => p.Lab_2, p => p.MapFrom(a => a.Lab2))
                .ForMember(p => p.Lab_2_2, p => p.MapFrom(a => a.Lab22))
                .ForMember(p => p.Lab_2_a, p => p.MapFrom(a => a.Lab2A))
                ;
            });



        }

    }


}
