using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuickCutsUI.Models
{
    public partial class QuickCutsContext : DbContext
    {
        public QuickCutsContext()
        {
        }

        public QuickCutsContext(DbContextOptions<QuickCutsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Barber> Barber { get; set; }
        public virtual DbSet<Favorites> Favorites { get; set; }
        public virtual DbSet<Pictures> Pictures { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Zip> Zip { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=QuickCuts;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Barber>(entity =>
            {
                entity.Property(e => e.BarberId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BusinessHours)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PolicyInfo)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.BarberNavigation)
                    .WithOne(p => p.Barber)
                    .HasForeignKey<Barber>(d => d.BarberId)
                    .HasConstraintName("FK_Barber_AspNetUsers_Id");
            });

            modelBuilder.Entity<Favorites>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Favorite__1788CC4C498D4EFB");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.BarberId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Barber)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.BarberId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Favorites)
                    .HasForeignKey<Favorites>(d => d.UserId)
                    .HasConstraintName("FK_Favorites_AspNetUsers_Id");
            });

            modelBuilder.Entity<Pictures>(entity =>
            {
                entity.HasKey(e => e.PictureId)
                    .HasName("PK__Pictures__8C2866D87B85B62D");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImageData).IsRequired();

                entity.Property(e => e.ImageMimeType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OwnerId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Pictures)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Pictures_AspNetUsers_Id");
            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("PK__Ratings__FCCDF87C9FF332C3");

                entity.Property(e => e.BarberId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Comment).HasMaxLength(300);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Barber)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.BarberId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ratings_AspNetUsers_Id");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.BarberId)
                    .HasName("PK__Services__BE22A8AED1D42E74");

                entity.Property(e => e.BarberId).ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Barber)
                    .WithOne(p => p.Services)
                    .HasForeignKey<Services>(d => d.BarberId);
            });

            modelBuilder.Entity<Zip>(entity =>
            {
                entity.HasKey(e => e.ZipCode);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
