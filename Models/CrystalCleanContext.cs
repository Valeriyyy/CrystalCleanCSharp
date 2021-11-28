using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace crystalClean.Models
{
    public partial class CrystalCleanContext : DbContext
    {

        // public CrystalCleanContext()
        // {
        // }

        public CrystalCleanContext(DbContextOptions<CrystalCleanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<LineItem> LineItems { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     Console.WriteLine("WHEN DOES THIS RUN??" + optionsBuilder.IsConfigured);
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         // #warning To protect potentially sensitive information in your connection string, 
        //         // you should move it out of source code. You can avoid scaffolding 
        //         // the connection string by using the Name= syntax to read it from 
        //         // configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. 
        //         // For more guidance on storing connection strings, 
        //         // see http://go.microsoft.com/fwlink/?LinkId=723263.
        //         optionsBuilder.UseNpgsql("CrystalCleanContext");
        //     }
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Client).HasColumnName("client");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .HasColumnName("last_name");

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.ClientNavigation)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.Client)
                    .HasConstraintName("contact_client_foreign");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.DefaultPrice)
                    .HasPrecision(6, 2)
                    .HasColumnName("default_price");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("job");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Client).HasColumnName("client");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.EndAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("end_at");

                entity.Property(e => e.EstimatedPrice)
                    .HasPrecision(6, 2)
                    .HasColumnName("estimated_price");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.OrderNumber)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("order_number");

                entity.Property(e => e.PaidAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("paid_at");

                entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");

                entity.Property(e => e.StartAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("start_at");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'scheduled'::text");

                entity.Property(e => e.Tip)
                    .HasPrecision(6, 2)
                    .HasColumnName("tip");

                entity.Property(e => e.TotalPrice)
                    .HasPrecision(6, 2)
                    .HasColumnName("total_price");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.ClientNavigation)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.Client)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_client_foreign");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.Location)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("job_location_foreign");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.ToTable("line_item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Item).HasColumnName("item");

                entity.Property(e => e.Job).HasColumnName("job");

                entity.Property(e => e.Price)
                    .HasPrecision(6, 2)
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("line_item_item_foreign");

                entity.HasOne(d => d.JobNavigation)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.Job)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("line_item_job_foreign");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .HasColumnName("city");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.GateCode)
                    .HasMaxLength(255)
                    .HasColumnName("gate_code");

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .HasColumnName("notes");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .HasColumnName("state");

                entity.Property(e => e.Unit)
                    .HasMaxLength(7)
                    .HasColumnName("unit");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Zip)
                    .HasMaxLength(5)
                    .HasColumnName("zip");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.HasIndex(e => e.Email, "person_email_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
