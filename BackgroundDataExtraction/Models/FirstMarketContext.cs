using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackgroundDataExtraction.Models
{
    public partial class FirstMarketContext : DbContext
    {
        public FirstMarketContext()
        {
        }

        public FirstMarketContext(DbContextOptions<FirstMarketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnAnnouncement> AnAnnouncements { get; set; }
        public virtual DbSet<BcCorporateActionSecurity> BcCorporateActionSecurities { get; set; }
        public virtual DbSet<DailyBhav> DailyBhavs { get; set; }
        public virtual DbSet<DailyBhavTemp> DailyBhavTemps { get; set; }
        public virtual DbSet<DailyCalculationBhavTable> DailyCalculationBhavTables { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=RAKESHCHAUBEY;Database=FirstMarket;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnAnnouncement>(entity =>
            {
                entity.ToTable("AnAnnouncement");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Announcement).IsUnicode(false);

                entity.Property(e => e.AnnouncementDate).HasColumnType("datetime");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Symbol)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BcCorporateActionSecurity>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BcEndDt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BC_END_DT");

                entity.Property(e => e.BcStrtDt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BC_STRT_DT");

                entity.Property(e => e.CorporateActionSecurityDate).HasColumnType("datetime");

                entity.Property(e => e.ExDt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EX_DT");

                entity.Property(e => e.NdEndDt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ND_END_DT");

                entity.Property(e => e.NdStrtDt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ND_STRT_DT");

                entity.Property(e => e.Purpose)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PURPOSE");

                entity.Property(e => e.RecordDt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RECORD_DT");

                entity.Property(e => e.Security)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("SECURITY");

                entity.Property(e => e.Series)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SERIES");

                entity.Property(e => e.Symbol)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SYMBOL");
            });

            modelBuilder.Entity<DailyBhav>(entity =>
            {
                entity.ToTable("DailyBhav");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Close)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("CLOSE");

                entity.Property(e => e.GeneratedDate).HasColumnType("datetime");

                entity.Property(e => e.High)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("HIGH");

                entity.Property(e => e.Isin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ISIN");

                entity.Property(e => e.Last)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("LAST");

                entity.Property(e => e.Low)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("LOW");

                entity.Property(e => e.Open)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("OPEN");

                entity.Property(e => e.Prevclose)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("PREVCLOSE");

                entity.Property(e => e.Series)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SERIES");

                entity.Property(e => e.Symbol)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SYMBOL");

                entity.Property(e => e.Timestamp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TIMESTAMP");

                entity.Property(e => e.Totaltrades).HasColumnName("TOTALTRADES");

                entity.Property(e => e.Tottrdqty).HasColumnName("TOTTRDQTY");

                entity.Property(e => e.Tottrdval)
                    .HasColumnType("numeric(14, 2)")
                    .HasColumnName("TOTTRDVAL");
            });

            modelBuilder.Entity<DailyBhavTemp>(entity =>
            {
                entity.ToTable("DailyBhavTemp");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Close)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("CLOSE");

                entity.Property(e => e.GeneratedDate).HasColumnType("datetime");

                entity.Property(e => e.High)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("HIGH");

                entity.Property(e => e.Isin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ISIN");

                entity.Property(e => e.Last)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("LAST");

                entity.Property(e => e.Low)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("LOW");

                entity.Property(e => e.Open)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("OPEN");

                entity.Property(e => e.Prevclose)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("PREVCLOSE");

                entity.Property(e => e.Series)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SERIES");

                entity.Property(e => e.Symbol)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SYMBOL");

                entity.Property(e => e.Timestamp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TIMESTAMP");

                entity.Property(e => e.Totaltrades).HasColumnName("TOTALTRADES");

                entity.Property(e => e.Tottrdqty).HasColumnName("TOTTRDQTY");

                entity.Property(e => e.Tottrdval)
                    .HasColumnType("numeric(14, 2)")
                    .HasColumnName("TOTTRDVAL");
            });

            modelBuilder.Entity<DailyCalculationBhavTable>(entity =>
            {
                entity.ToTable("DailyCalculationBhavTable");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Symbol)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e._1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("1");

                entity.Property(e => e._10)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("10");

                entity.Property(e => e._11)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("11");

                entity.Property(e => e._12)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("12");

                entity.Property(e => e._13)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("13");

                entity.Property(e => e._14)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("14");

                entity.Property(e => e._15)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("15");

                entity.Property(e => e._16)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("16");

                entity.Property(e => e._17)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("17");

                entity.Property(e => e._18)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("18");

                entity.Property(e => e._19)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("19");

                entity.Property(e => e._2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("2");

                entity.Property(e => e._20)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("20");

                entity.Property(e => e._21)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("21");

                entity.Property(e => e._22)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("22");

                entity.Property(e => e._23)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("23");

                entity.Property(e => e._24)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("24");

                entity.Property(e => e._25)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("25");

                entity.Property(e => e._26)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("26");

                entity.Property(e => e._27)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("27");

                entity.Property(e => e._28)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("28");

                entity.Property(e => e._29)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("29");

                entity.Property(e => e._3)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("3");

                entity.Property(e => e._30)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("30");

                entity.Property(e => e._31)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("31");

                entity.Property(e => e._4)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("4");

                entity.Property(e => e._5)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("5");

                entity.Property(e => e._6)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("6");

                entity.Property(e => e._7)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("7");

                entity.Property(e => e._8)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("8");

                entity.Property(e => e._9)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("9");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
