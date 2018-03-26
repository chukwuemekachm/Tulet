using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tulet.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Tulet.Models.Entities;

namespace Tulet.Models.Entities
{
    public partial class tuletContext : DbContext
    {
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Verification> Verification { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;userid=root;pwd=St.gerrard343;port=3306;database=tulet;sslmode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("post");

                entity.HasIndex(e => e.Category)
                    .HasName("post_category_idx");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Type)
                    .HasName("post_type_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("post_user_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Negotiable).HasColumnType("boolean");

                entity.Property(e => e.Photo1)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Photo2).HasMaxLength(45);

                entity.Property(e => e.Photo3).HasMaxLength(45);

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("User_ID")
                    .HasMaxLength(100);

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Post)
                    .HasPrincipalKey(p => p.Name)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("post_category");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Post)
                    .HasPrincipalKey(p => p.Name)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("post_type");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("post_user");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("subscription");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("subscription_user_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnName("Expiry_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubscriptionDate)
                    .HasColumnName("Subscription_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubscriptionType)
                    .IsRequired()
                    .HasColumnName("Subscription_Type")
                    .HasMaxLength(45);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("User_ID")
                    .HasMaxLength(45);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Subscription)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subscription_user");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("type");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("Name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("user");

                entity.HasIndex(e => e.Email)
                    .HasName("Email_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.Active).HasColumnType("boolean");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("Birth_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasMaxLength(45);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(45);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.RegDate)
                    .HasColumnName("Reg_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("User_ID")
                    .HasMaxLength(100);

                entity.Property(e => e.Verified).HasColumnType("boolean");
            });

            modelBuilder.Entity<Verification>(entity =>
            {
                entity.ToTable("verification");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("verification_user_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BusinessAddress)
                    .IsRequired()
                    .HasColumnName("Business_Address")
                    .HasMaxLength(45);

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasColumnName("Business_Name")
                    .HasMaxLength(45);

                entity.Property(e => e.CaCNo)
                    .HasColumnName("CaC_No")
                    .HasMaxLength(45);

                entity.Property(e => e.IdentificationExpiry)
                    .HasColumnName("Identification_Expiry")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdentificationNo)
                    .IsRequired()
                    .HasColumnName("Identification_No")
                    .HasMaxLength(45);

                entity.Property(e => e.IdentificationType)
                    .IsRequired()
                    .HasColumnName("Identification_Type")
                    .HasMaxLength(45);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("User_ID")
                    .HasMaxLength(45);

                entity.Property(e => e.VerDate)
                    .HasColumnName("Ver_Date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Verification)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("verification_user");
            });
        }
    }
}
