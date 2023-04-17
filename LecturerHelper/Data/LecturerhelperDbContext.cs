using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LecturerHelper.Data;

public partial class LecturerhelperDbContext : DbContext
{
    public LecturerhelperDbContext()
    {
    }

    public LecturerhelperDbContext(DbContextOptions<LecturerhelperDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AutoHosqNumber> AutoHosqNumbers { get; set; }

    public virtual DbSet<Fakultet> Fakultets { get; set; }

    public virtual DbSet<Kaefic> Kaefics { get; set; }

    public virtual DbSet<Nagruzka> Nagruzkas { get; set; }

    public virtual DbSet<Patok1> Patok1s { get; set; }

    public virtual DbSet<PatokNara> PatokNaras { get; set; }

    public virtual DbSet<Xmber> Xmbers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=ALLENYOPC;Database=lecturerhelperDb;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AutoHosqNumber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("AutoHosqNumbers$PrimaryKey");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AutoHosqDas).HasDefaultValueSql("((0))");
            entity.Property(e => e.AutoHosqGorc).HasDefaultValueSql("((0))");
            entity.Property(e => e.AutoHosqGorc16).HasDefaultValueSql("((0))");
            entity.Property(e => e.AutoHosqGorc8).HasDefaultValueSql("((0))");
            entity.Property(e => e.AutoHosqLab).HasDefaultValueSql("((0))");
            entity.Property(e => e.AutoHosqLab8).HasDefaultValueSql("((0))");
            entity.Property(e => e.Fakultet)
                .HasMaxLength(255)
                .HasColumnName("fakultet");
            entity.Property(e => e.Kurs).HasColumnName("kurs");
            entity.Property(e => e.StudKanak).HasColumnName("stud_kanak");
            entity.Property(e => e.Xumb)
                .HasMaxLength(255)
                .HasColumnName("xumb");
        });

        modelBuilder.Entity<Fakultet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Fakultet$PrimaryKey");

            entity.ToTable("Fakultet");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FakKod).HasMaxLength(255);
            entity.Property(e => e.FakName).HasMaxLength(255);
        });

        modelBuilder.Entity<Kaefic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("kaefic$PrimaryKey");

            entity.ToTable("kaefic");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Atestavorum).HasColumnName("atestavorum");
            entity.Property(e => e.Avart).HasColumnName("avart");
            entity.Property(e => e.AvartCons).HasColumnName("avart_cons");
            entity.Property(e => e.Axrana).HasColumnName("axrana");
            entity.Property(e => e.Cons).HasColumnName("cons");
            entity.Property(e => e.ConsSt).HasColumnName("cons_st");
            entity.Property(e => e.Das).HasColumnName("das");
            entity.Property(e => e.Diplom).HasColumnName("diplom");
            entity.Property(e => e.Ekanomika).HasColumnName("ekanomika");
            entity.Property(e => e.Gorc).HasColumnName("gorc");
            entity.Property(e => e.Graf).HasColumnName("graf");
            entity.Property(e => e.Grax).HasColumnName("grax");
            entity.Property(e => e.Hashvet).HasColumnName("hashvet");
            entity.Property(e => e.Infor).HasColumnName("infor");
            entity.Property(e => e.KursN).HasColumnName("kursN");
            entity.Property(e => e.KursNM).HasColumnName("kursN_M");
            entity.Property(e => e.Lab).HasColumnName("lab");
            entity.Property(e => e.Otar).HasColumnName("otar");
            entity.Property(e => e.Prakt).HasColumnName("prakt");
            entity.Property(e => e.Prakt1).HasColumnName("prakt1");
            entity.Property(e => e.Prakt2).HasColumnName("prakt2");
            entity.Property(e => e.Qnut).HasColumnName("qnut");
            entity.Property(e => e.Rus).HasColumnName("rus");
            entity.Property(e => e.Stug).HasColumnName("stug");
        });

        modelBuilder.Entity<Nagruzka>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Nagruzka");

            entity.Property(e => e.Ambion)
                .HasMaxLength(255)
                .HasColumnName("ambion");
            entity.Property(e => e.Ararka)
                .HasMaxLength(255)
                .HasColumnName("ararka");
            entity.Property(e => e.Atestavorum).HasColumnName("atestavorum");
            entity.Property(e => e.Avart).HasColumnName("avart");
            entity.Property(e => e.AvartCons).HasColumnName("avart_cons");
            entity.Property(e => e.ConsSt1).HasColumnName("cons_st_1");
            entity.Property(e => e.ConsSt2).HasColumnName("cons_st_2");
            entity.Property(e => e.D1).HasColumnName("D_1");
            entity.Property(e => e.Das1).HasColumnName("das_1");
            entity.Property(e => e.Das1Sum).HasColumnName("das_1_sum");
            entity.Property(e => e.Das2).HasColumnName("das_2");
            entity.Property(e => e.Das2Sum).HasColumnName("das_2_sum");
            entity.Property(e => e.Diplom1).HasColumnName("diplom1");
            entity.Property(e => e.Diplom2).HasColumnName("diplom2");
            entity.Property(e => e.Fakultet)
                .HasMaxLength(255)
                .HasColumnName("fakultet");
            entity.Property(e => e.G1).HasColumnName("G_1");
            entity.Property(e => e.Gorc1).HasColumnName("gorc_1");
            entity.Property(e => e.Gorc11).HasColumnName("gorc_1_1");
            entity.Property(e => e.Gorc1Sum).HasColumnName("gorc_1_sum");
            entity.Property(e => e.Gorc2).HasColumnName("gorc_2");
            entity.Property(e => e.Gorc22).HasColumnName("gorc_2_2");
            entity.Property(e => e.Gorc2Sum).HasColumnName("gorc_2_sum");
            entity.Property(e => e.Grax).HasColumnName("grax");
            entity.Property(e => e.Gum1).HasColumnName("gum1");
            entity.Property(e => e.Gum2).HasColumnName("gum2");
            entity.Property(e => e.Kurs).HasColumnName("kurs");
            entity.Property(e => e.Kurs1).HasColumnName("kurs_1");
            entity.Property(e => e.Kurs2).HasColumnName("kurs_2");
            entity.Property(e => e.Kursain1)
                .HasMaxLength(255)
                .HasColumnName("kursain_1");
            entity.Property(e => e.Kursain2)
                .HasMaxLength(255)
                .HasColumnName("kursain_2");
            entity.Property(e => e.L1).HasColumnName("L_1");
            entity.Property(e => e.Lab1).HasColumnName("lab_1");
            entity.Property(e => e.Lab11).HasColumnName("lab_1_1");
            entity.Property(e => e.Lab1A).HasColumnName("lab_1_a");
            entity.Property(e => e.Lab2).HasColumnName("lab_2");
            entity.Property(e => e.Lab22).HasColumnName("lab_2_2");
            entity.Property(e => e.Lab2A).HasColumnName("lab_2_a");
            entity.Property(e => e.Prakt1).HasColumnName("prakt_1");
            entity.Property(e => e.Prakt2).HasColumnName("prakt_2");
            entity.Property(e => e.Qnut1).HasColumnName("qnut_1");
            entity.Property(e => e.Qnut2).HasColumnName("qnut_2");
            entity.Property(e => e.QnutCons1).HasColumnName("qnut_cons_1");
            entity.Property(e => e.QnutCons2).HasColumnName("qnut_cons_2");
            entity.Property(e => e.Qnutun1)
                .HasMaxLength(255)
                .HasColumnName("qnutun_1");
            entity.Property(e => e.Qnutun2)
                .HasMaxLength(255)
                .HasColumnName("qnutun_2");
            entity.Property(e => e.Sem1).HasColumnName("sem1");
            entity.Property(e => e.Sem2).HasColumnName("sem2");
            entity.Property(e => e.StudKanak).HasColumnName("stud_kanak");
            entity.Property(e => e.Stug1).HasColumnName("stug_1");
            entity.Property(e => e.Stug2).HasColumnName("stug_2");
            entity.Property(e => e.Stugark1)
                .HasMaxLength(255)
                .HasColumnName("stugark_1");
            entity.Property(e => e.Stugark2)
                .HasMaxLength(255)
                .HasColumnName("stugark_2");
            entity.Property(e => e.Texn1).HasColumnName("texn1");
            entity.Property(e => e.Texn2).HasColumnName("texn2");
            entity.Property(e => e.Xumb)
                .HasMaxLength(255)
                .HasColumnName("xumb");
        });

        modelBuilder.Entity<Patok1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Patok_1$PrimaryKey");

            entity.ToTable("Patok_1");

            entity.HasIndex(e => e.Id, "Patok_1$ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AmbionKod)
                .HasMaxLength(255)
                .HasColumnName("ambionKod");
            entity.Property(e => e.Ararka).HasMaxLength(255);
            entity.Property(e => e.Hosq).HasColumnName("hosq");
            entity.Property(e => e.Kanak).HasColumnName("kanak");
            entity.Property(e => e.Kurs).HasColumnName("kurs");
            entity.Property(e => e.Lek)
                .HasMaxLength(255)
                .HasColumnName("lek");
            entity.Property(e => e.PUsQan).HasColumnName("pUsQan");
            entity.Property(e => e.QnnutyunStugarq)
                .HasMaxLength(255)
                .HasColumnName("qnnutyunStugarq");
            entity.Property(e => e.XUsQan).HasColumnName("xUsQan");
            entity.Property(e => e.Xumb).HasMaxLength(255);
        });

        modelBuilder.Entity<PatokNara>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Patok_Nara$PrimaryKey");

            entity.ToTable("Patok_Nara");

            entity.HasIndex(e => e.Id, "Patok_Nara$ID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AmbionKod)
                .HasMaxLength(255)
                .HasColumnName("ambionKod");
            entity.Property(e => e.Ararka).HasMaxLength(255);
            entity.Property(e => e.Hosq).HasColumnName("hosq");
            entity.Property(e => e.Kanak).HasColumnName("kanak");
            entity.Property(e => e.Kurs).HasColumnName("kurs");
            entity.Property(e => e.Lek)
                .HasMaxLength(255)
                .HasColumnName("lek");
            entity.Property(e => e.PUsQan).HasColumnName("pUsQan");
            entity.Property(e => e.QnnutyunStugarq)
                .HasMaxLength(255)
                .HasColumnName("qnnutyunStugarq");
            entity.Property(e => e.Xmber).HasMaxLength(255);
        });

        modelBuilder.Entity<Xmber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Xmber$PrimaryKey");

            entity.ToTable("Xmber");

            entity.HasIndex(e => e.Dh2q, "Xmber$DH2");

            entity.HasIndex(e => e.Dh2, "Xmber$D_2");

            entity.HasIndex(e => e.Gh1q, "Xmber$GH1");

            entity.HasIndex(e => e.Gh2q, "Xmber$GH2");

            entity.HasIndex(e => e.Gh1, "Xmber$G_1");

            entity.HasIndex(e => e.Gh2, "Xmber$G_2");

            entity.HasIndex(e => e.L11, "Xmber$ID_X");

            entity.HasIndex(e => e.Lh1q, "Xmber$LH1");

            entity.HasIndex(e => e.Lh2q, "Xmber$LH2");

            entity.HasIndex(e => e.Lh1, "Xmber$L_1");

            entity.HasIndex(e => e.Lh2, "Xmber$L_2");

            entity.HasIndex(e => e.Id, "Xmber$id");

            entity.HasIndex(e => e.D2, "Xmber$id1");

            entity.HasIndex(e => e.G2, "Xmber$id11");

            entity.HasIndex(e => e.G1, "Xmber$id_1");

            entity.HasIndex(e => e.L21, "Xmber$id_11");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ambion)
                .HasMaxLength(255)
                .HasColumnName("ambion");
            entity.Property(e => e.Ararka)
                .HasMaxLength(255)
                .HasColumnName("ararka");
            entity.Property(e => e.ArginKis)
                .HasDefaultValueSql("((0))")
                .HasColumnName("argin_kis");
            entity.Property(e => e.D1)
                .HasDefaultValueSql("((-1))")
                .HasColumnName("D_1");
            entity.Property(e => e.D2)
                .HasDefaultValueSql("((-1))")
                .HasColumnName("D_2");
            entity.Property(e => e.Das1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("das_1");
            entity.Property(e => e.Das2)
                .HasDefaultValueSql("((0))")
                .HasColumnName("das_2");
            entity.Property(e => e.Dasich)
                .HasMaxLength(255)
                .HasColumnName("dasich");
            entity.Property(e => e.Dh1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DH1");
            entity.Property(e => e.Dh1q)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DH1q");
            entity.Property(e => e.Dh2)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DH2");
            entity.Property(e => e.Dh2q)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DH2q");
            entity.Property(e => e.ErkKis)
                .HasDefaultValueSql("((0))")
                .HasColumnName("erk_kis");
            entity.Property(e => e.Fakultet)
                .HasMaxLength(255)
                .HasColumnName("fakultet");
            entity.Property(e => e.G1)
                .HasDefaultValueSql("((-1))")
                .HasColumnName("G_1");
            entity.Property(e => e.G2)
                .HasDefaultValueSql("((-1))")
                .HasColumnName("G_2");
            entity.Property(e => e.Gh1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("GH1");
            entity.Property(e => e.Gh1q)
                .HasDefaultValueSql("((0))")
                .HasColumnName("GH1q");
            entity.Property(e => e.Gh2)
                .HasDefaultValueSql("((0))")
                .HasColumnName("GH2");
            entity.Property(e => e.Gh2q)
                .HasDefaultValueSql("((0))")
                .HasColumnName("GH2q");
            entity.Property(e => e.Gorc1).HasDefaultValueSql("((1))");
            entity.Property(e => e.Gorc11)
                .HasDefaultValueSql("((0))")
                .HasColumnName("gorc_1");
            entity.Property(e => e.Gorc2).HasDefaultValueSql("((1))");
            entity.Property(e => e.Gorc21)
                .HasDefaultValueSql("((0))")
                .HasColumnName("gorc_2");
            entity.Property(e => e.Graxos).HasColumnName("graxos");
            entity.Property(e => e.Hosq).HasDefaultValueSql("((0))");
            entity.Property(e => e.Kurs).HasColumnName("kurs");
            entity.Property(e => e.Kursain1)
                .HasMaxLength(255)
                .HasColumnName("kursain_1");
            entity.Property(e => e.Kursain2)
                .HasMaxLength(255)
                .HasColumnName("kursain_2");
            entity.Property(e => e.L1).HasDefaultValueSql("((1))");
            entity.Property(e => e.L11)
                .HasDefaultValueSql("((-1))")
                .HasColumnName("L_1");
            entity.Property(e => e.L2).HasDefaultValueSql("((1))");
            entity.Property(e => e.L21)
                .HasDefaultValueSql("((-1))")
                .HasColumnName("L_2");
            entity.Property(e => e.Lab1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("lab_1");
            entity.Property(e => e.Lab2)
                .HasDefaultValueSql("((0))")
                .HasColumnName("lab_2");
            entity.Property(e => e.Lh1)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LH1");
            entity.Property(e => e.Lh1q)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LH1q");
            entity.Property(e => e.Lh2)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LH2");
            entity.Property(e => e.Lh2q)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LH2q");
            entity.Property(e => e.Masnagit)
                .HasMaxLength(255)
                .HasColumnName("masnagit");
            entity.Property(e => e.Qnutun1)
                .HasMaxLength(255)
                .HasColumnName("qnutun_1");
            entity.Property(e => e.Qnutun2)
                .HasMaxLength(255)
                .HasColumnName("qnutun_2");
            entity.Property(e => e.Sem1)
                .HasDefaultValueSql("((1))")
                .HasColumnName("sem1");
            entity.Property(e => e.Sem2)
                .HasDefaultValueSql("((1))")
                .HasColumnName("sem2");
            entity.Property(e => e.ShabJam1).HasColumnName("shab_jam_1");
            entity.Property(e => e.ShabJam2).HasColumnName("shab_jam_2");
            entity.Property(e => e.Sharunak)
                .HasMaxLength(255)
                .HasColumnName("sharunak");
            entity.Property(e => e.StudKanak).HasColumnName("stud_kanak");
            entity.Property(e => e.Stugark1)
                .HasMaxLength(255)
                .HasColumnName("stugark_1");
            entity.Property(e => e.Stugark2)
                .HasMaxLength(255)
                .HasColumnName("stugark_2");
            entity.Property(e => e.Tarekan).HasColumnName("tarekan");
            entity.Property(e => e.Xumb)
                .HasMaxLength(255)
                .HasColumnName("xumb");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
