using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AssetManagement.Models
{
    public partial class AssetManagementContext : DbContext
    {
        public AssetManagementContext()
        {
        }

        public AssetManagementContext(DbContextOptions<AssetManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetMaster> AssetMaster { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<UserRegistration> UserRegistration { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SARITHPSAJEEV\\SQLEXPRESS; Initial Catalog=AssetManagement; Integrated security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetMaster>(entity =>
            {
                entity.HasKey(e => e.AmId)
                    .HasName("PK__AssetMas__B95A8ED07EC2D22B");

                entity.Property(e => e.AmId).HasColumnName("am_id");

                entity.Property(e => e.AmAdId).HasColumnName("am_ad_id");

                entity.Property(e => e.AmAtypeId).HasColumnName("am_atype_id");

                entity.Property(e => e.AmFrom)
                    .HasColumnName("am_from")
                    .HasColumnType("date");

                entity.Property(e => e.AmMakeId).HasColumnName("am_make_id");

                entity.Property(e => e.AmModel)
                    .HasColumnName("am_model")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AmMyYear)
                    .HasColumnName("am_myYear")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AmPdate)
                    .HasColumnName("am_pdate")
                    .HasColumnType("date");

                entity.Property(e => e.AmSNumber)
                    .HasColumnName("am_sNumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AmTo)
                    .HasColumnName("am_to")
                    .HasColumnType("date");

                entity.Property(e => e.AmWarranty)
                    .HasColumnName("am_warranty")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__login__DE11596F8DB6945C");

                entity.ToTable("login");

                entity.Property(e => e.LId).HasColumnName("lId");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasColumnName("userType")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__UserRegi__B51D3DEA8E8E40DB");

                entity.Property(e => e.UId).HasColumnName("u_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LId).HasColumnName("lId");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.UserRegistration)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK__UserRegistr__lId__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
