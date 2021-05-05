﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpartaAcademyDatabseOnCSharp;

namespace SpartaAcademyDatabseOnCSharp.Migrations
{
    [DbContext(typeof(SpartaAcademyContext))]
    [Migration("20210505084130_update")]
    partial class update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.Course", b =>
                {
                    b.Property<string>("Course1")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("course");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.Property<string>("Stream")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("stream");

                    b.HasKey("Course1")
                        .HasName("PK__Courses__1241F7F709AF292B");

                    b.HasIndex("Stream");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.Location", b =>
                {
                    b.Property<string>("City")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("city");

                    b.Property<string>("Postcode")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("postcode");

                    b.HasKey("City")
                        .HasName("PK__Location__23BEBA6BFBCF12A4");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.Stream", b =>
                {
                    b.Property<string>("Stream1")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("stream");

                    b.Property<int?>("YearsRun")
                        .HasColumnType("int")
                        .HasColumnName("years_run");

                    b.HasKey("Stream1")
                        .HasName("PK__Streams__3F189F46E89B1DF3");

                    b.ToTable("Streams");
                });

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.Trainee", b =>
                {
                    b.Property<int>("TraineeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("trainee_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Course")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("course");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("FirstName")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("last_name");

                    b.Property<string>("Location")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("location");

                    b.Property<string>("Stream")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("stream");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("int")
                        .HasColumnName("trainer_id");

                    b.HasKey("TraineeId");

                    b.HasIndex("Course");

                    b.HasIndex("Location");

                    b.HasIndex("Stream");

                    b.HasIndex("TrainerId");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.Trainer", b =>
                {
                    b.Property<int>("TrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("trainer_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("last_name");

                    b.Property<string>("Location")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("location");

                    b.Property<int?>("YearsOfExperience")
                        .HasColumnType("int")
                        .HasColumnName("years_of_experience");

                    b.HasKey("TrainerId");

                    b.HasIndex("Location");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.TrainersCoursesLink", b =>
                {
                    b.Property<string>("Course")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("course");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int")
                        .HasColumnName("trainer_id");

                    b.HasIndex("Course");

                    b.HasIndex("TrainerId");

                    b.ToTable("TrainersCoursesLink");
                });

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.TrainersStreamsLink", b =>
                {
                    b.Property<string>("Stream")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("stream");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("int")
                        .HasColumnName("trainer_id");

                    b.HasIndex("Stream");

                    b.HasIndex("TrainerId");

                    b.ToTable("TrainersStreamsLink");
                });

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.Course", b =>
                {
                    b.HasOne("SpartaAcademyDatabseOnCSharp.Stream", "StreamNavigation")
                        .WithMany("Courses")
                        .HasForeignKey("Stream")
                        .HasConstraintName("FK__Courses__stream__5D95E53A");

                    b.Navigation("StreamNavigation");
                });

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.Trainee", b =>
                {
                    b.HasOne("SpartaAcademyDatabseOnCSharp.Course", "CourseNavigation")
                        .WithMany("Trainees")
                        .HasForeignKey("Course")
                        .HasConstraintName("FK__Trainees__course__65370702");

                    b.HasOne("SpartaAcademyDatabseOnCSharp.Location", "LocationNavigation")
                        .WithMany("Trainees")
                        .HasForeignKey("Location")
                        .HasConstraintName("FK__Trainees__locati__662B2B3B");

                    b.HasOne("SpartaAcademyDatabseOnCSharp.Stream", "StreamNavigation")
                        .WithMany("Trainees")
                        .HasForeignKey("Stream")
                        .HasConstraintName("FK__Trainees__stream__6442E2C9");

                    b.HasOne("SpartaAcademyDatabseOnCSharp.Trainer", "Trainer")
                        .WithMany("Trainees")
                        .HasForeignKey("TrainerId")
                        .HasConstraintName("FK__Trainees__traine__634EBE90");

                    b.Navigation("CourseNavigation");

                    b.Navigation("LocationNavigation");

                    b.Navigation("StreamNavigation");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.Trainer", b =>
                {
                    b.HasOne("SpartaAcademyDatabseOnCSharp.Location", "LocationNavigation")
                        .WithMany("Trainers")
                        .HasForeignKey("Location")
                        .HasConstraintName("FK__Trainers__locati__607251E5");

                    b.Navigation("LocationNavigation");
                });

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.TrainersCoursesLink", b =>
                {
                    b.HasOne("SpartaAcademyDatabseOnCSharp.Course", "CourseNavigation")
                        .WithMany()
                        .HasForeignKey("Course")
                        .HasConstraintName("FK__TrainersC__cours__6BE40491");

                    b.HasOne("SpartaAcademyDatabseOnCSharp.Trainer", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerId")
                        .HasConstraintName("FK__TrainersC__train__6AEFE058")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseNavigation");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.TrainersStreamsLink", b =>
                {
                    b.HasOne("SpartaAcademyDatabseOnCSharp.Stream", "StreamNavigation")
                        .WithMany()
                        .HasForeignKey("Stream")
                        .HasConstraintName("FK__TrainersS__strea__690797E6");

                    b.HasOne("SpartaAcademyDatabseOnCSharp.Trainer", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerId")
                        .HasConstraintName("FK__TrainersS__train__681373AD");

                    b.Navigation("StreamNavigation");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.Course", b =>
                {
                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.Location", b =>
                {
                    b.Navigation("Trainees");

                    b.Navigation("Trainers");
                });

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.Stream", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("SpartaAcademyDatabseOnCSharp.Trainer", b =>
                {
                    b.Navigation("Trainees");
                });
#pragma warning restore 612, 618
        }
    }
}
