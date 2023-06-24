﻿// <auto-generated />
using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(CollegeListContext))]
    [Migration("20230623163918_AddPromejdsv1")]
    partial class AddPromejdsv1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.AttesTut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AttestationId")
                        .HasColumnType("int");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttestationId");

                    b.HasIndex("TutorId");

                    b.ToTable("AttesTuts");
                });

            modelBuilder.Entity("Domain.Models.Attestation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TutorId");

                    b.ToTable("Attestations");
                });

            modelBuilder.Entity("Domain.Models.CourTut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TutorId");

                    b.ToTable("CourTuts");
                });

            modelBuilder.Entity("Domain.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdTutor")
                        .HasColumnType("int");

                    b.Property<int?>("IdTutorNavigationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdTutorNavigationId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Domain.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Domain.Models.TrainingCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TutorId");

                    b.ToTable("TrainingCourses");
                });

            modelBuilder.Entity("Domain.Models.Tutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tutors");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<Guid>("GuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("GuId");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuId");

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Domain.Models.CollegeAdmin", b =>
                {
                    b.HasBaseType("Domain.Models.User");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("CollegeAdmins");
                });

            modelBuilder.Entity("Domain.Models.DbAdmin", b =>
                {
                    b.HasBaseType("Domain.Models.User");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("DbAdmins");
                });

            modelBuilder.Entity("Domain.Models.AttesTut", b =>
                {
                    b.HasOne("Domain.Models.Attestation", "Attestation")
                        .WithMany()
                        .HasForeignKey("AttestationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attestation");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("Domain.Models.Attestation", b =>
                {
                    b.HasOne("Domain.Models.Tutor", null)
                        .WithMany("Attestations")
                        .HasForeignKey("TutorId");
                });

            modelBuilder.Entity("Domain.Models.CourTut", b =>
                {
                    b.HasOne("Domain.Models.TrainingCourse", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("Domain.Models.Group", b =>
                {
                    b.HasOne("Domain.Models.Tutor", "IdTutorNavigation")
                        .WithMany("Groups")
                        .HasForeignKey("IdTutorNavigationId");

                    b.Navigation("IdTutorNavigation");
                });

            modelBuilder.Entity("Domain.Models.Student", b =>
                {
                    b.HasOne("Domain.Models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Domain.Models.TrainingCourse", b =>
                {
                    b.HasOne("Domain.Models.Tutor", null)
                        .WithMany("TrainingCourses")
                        .HasForeignKey("TutorId");
                });

            modelBuilder.Entity("Domain.Models.CollegeAdmin", b =>
                {
                    b.HasOne("Domain.Models.User", null)
                        .WithOne()
                        .HasForeignKey("Domain.Models.CollegeAdmin", "GuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.DbAdmin", b =>
                {
                    b.HasOne("Domain.Models.User", null)
                        .WithOne()
                        .HasForeignKey("Domain.Models.DbAdmin", "GuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Domain.Models.Tutor", b =>
                {
                    b.Navigation("Attestations");

                    b.Navigation("Groups");

                    b.Navigation("TrainingCourses");
                });
#pragma warning restore 612, 618
        }
    }
}