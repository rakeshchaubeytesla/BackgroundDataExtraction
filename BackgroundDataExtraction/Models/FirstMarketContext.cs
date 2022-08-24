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
