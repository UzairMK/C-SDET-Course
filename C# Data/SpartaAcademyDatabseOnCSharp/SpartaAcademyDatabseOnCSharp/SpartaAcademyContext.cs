﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SpartaAcademyDatabseOnCSharp
{
    public partial class SpartaAcademyContext : DbContext
    {
        public SpartaAcademyContext()
        {
        }

        public SpartaAcademyContext(DbContextOptions<SpartaAcademyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Stream> Streams { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<TrainersCoursesLink> TrainersCoursesLinks { get; set; }
        public virtual DbSet<TrainersStreamsLink> TrainersStreamsLinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SpartaAcademy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Course1)
                    .HasName("PK__Courses__1241F7F709AF292B");

                entity.Property(e => e.Course1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("course");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.Stream)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("stream");

                entity.HasOne(d => d.StreamNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Stream)
                    .HasConstraintName("FK__Courses__stream__5D95E53A");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.City)
                    .HasName("PK__Location__23BEBA6BFBCF12A4");

                entity.Property(e => e.City)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Postcode)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("postcode");
            });

            modelBuilder.Entity<Stream>(entity =>
            {
                entity.HasKey(e => e.Stream1)
                    .HasName("PK__Streams__3F189F46E89B1DF3");

                entity.Property(e => e.Stream1)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("stream");

                entity.Property(e => e.YearsRun).HasColumnName("years_run");
            });

            modelBuilder.Entity<Trainee>(entity =>
            {
                entity.Property(e => e.TraineeId).HasColumnName("trainee_id");

                entity.Property(e => e.Course)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("course");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Location)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.Stream)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("stream");

                entity.Property(e => e.TrainerId).HasColumnName("trainer_id");

                entity.HasOne(d => d.CourseNavigation)
                    .WithMany(p => p.Trainees)
                    .HasForeignKey(d => d.Course)
                    .HasConstraintName("FK__Trainees__course__65370702");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Trainees)
                    .HasForeignKey(d => d.Location)
                    .HasConstraintName("FK__Trainees__locati__662B2B3B");

                entity.HasOne(d => d.StreamNavigation)
                    .WithMany(p => p.Trainees)
                    .HasForeignKey(d => d.Stream)
                    .HasConstraintName("FK__Trainees__stream__6442E2C9");

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.Trainees)
                    .HasForeignKey(d => d.TrainerId)
                    .HasConstraintName("FK__Trainees__traine__634EBE90");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.Property(e => e.TrainerId).HasColumnName("trainer_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Location)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.YearsOfExperience).HasColumnName("years_of_experience");

                entity.HasOne(d => d.LocationNavigation)
                    .WithMany(p => p.Trainers)
                    .HasForeignKey(d => d.Location)
                    .HasConstraintName("FK__Trainers__locati__607251E5");
            });

            modelBuilder.Entity<TrainersCoursesLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TrainersCoursesLink");

                entity.Property(e => e.Course)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("course");

                entity.Property(e => e.TrainerId).HasColumnName("trainer_id");

                entity.HasOne(d => d.CourseNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Course)
                    .HasConstraintName("FK__TrainersC__cours__6BE40491");

                entity.HasOne(d => d.Trainer)
                    .WithMany()
                    .HasForeignKey(d => d.TrainerId)
                    .HasConstraintName("FK__TrainersC__train__6AEFE058");
            });

            modelBuilder.Entity<TrainersStreamsLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TrainersStreamsLink");

                entity.Property(e => e.Stream)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("stream");

                entity.Property(e => e.TrainerId).HasColumnName("trainer_id");

                entity.HasOne(d => d.StreamNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Stream)
                    .HasConstraintName("FK__TrainersS__strea__690797E6");

                entity.HasOne(d => d.Trainer)
                    .WithMany()
                    .HasForeignKey(d => d.TrainerId)
                    .HasConstraintName("FK__TrainersS__train__681373AD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
