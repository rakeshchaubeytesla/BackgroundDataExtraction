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
                    .HasColumnType("datetime")
                    .HasColumnName("BC_END_DT");

                entity.Property(e => e.BcStrtDt)
                    .HasColumnType("datetime")
                    .HasColumnName("BC_STRT_DT");

                entity.Property(e => e.CorporateActionSecurityDate).HasColumnType("datetime");

                entity.Property(e => e.ExDt)
                    .HasColumnType("datetime")
                    .HasColumnName("EX_DT");

                entity.Property(e => e.NdEndDt)
                    .HasColumnType("datetime")
                    .HasColumnName("ND_END_DT");

                entity.Property(e => e.NdStrtDt)
                    .HasColumnType("datetime")
                    .HasColumnName("ND_STRT_DT");

                entity.Property(e => e.Purpose)
                    .HasColumnType("datetime")
                    .HasColumnName("PURPOSE");

                entity.Property(e => e.RecordDt)
                    .HasColumnType("datetime")
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
