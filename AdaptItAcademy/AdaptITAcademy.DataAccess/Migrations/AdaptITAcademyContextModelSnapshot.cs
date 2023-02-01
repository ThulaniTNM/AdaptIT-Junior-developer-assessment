﻿// <auto-generated />
using System;
using AdaptItAcademy.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdaptITAcademy.DataAccess.Migrations
{
    [DbContext(typeof(AdaptITAcademyContext))]
    partial class AdaptITAcademyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdaptITAcademyAPI.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Course code");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("AdaptITAcademyAPI.Models.PhysicalAddress", b =>
                {
                    b.Property<int>("PhysicalAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhysicalAddressId"));

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suburb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PhysicalAddressId");

                    b.HasIndex("UserId");

                    b.ToTable("PhysicalAddresses", (string)null);
                });

            modelBuilder.Entity("AdaptITAcademyAPI.Models.PostalAddress", b =>
                {
                    b.Property<int>("PostalAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostalAddressId"));

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PostalAddressId");

                    b.HasIndex("UserId");

                    b.ToTable("PostalAddresses", (string)null);
                });

            modelBuilder.Entity("AdaptITAcademyAPI.Models.Training", b =>
                {
                    b.Property<int>("TrainingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainingID"));

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<decimal>("TrainingCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TrainingEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrainingPeriod")
                        .HasColumnType("int");

                    b.Property<DateTime>("TrainingRegistrationClosingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TrainingStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TrainingID");

                    b.HasIndex("CourseId");

                    b.ToTable("Trainings", (string)null);
                });

            modelBuilder.Entity("AdaptITAcademyAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DietaryRequirements")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhonenNumer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("AdaptITAcademyAPI.Models.UserTraining", b =>
                {
                    b.Property<int>("UserTrainingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserTrainingId"));

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserTrainingId");

                    b.HasIndex("TrainingId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTrainings", (string)null);
                });

            modelBuilder.Entity("AdaptITAcademyAPI.Models.PhysicalAddress", b =>
                {
                    b.HasOne("AdaptITAcademyAPI.Models.User", "User")
                        .WithMany("PhysicalAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AdaptITAcademyAPI.Models.PostalAddress", b =>
                {
                    b.HasOne("AdaptITAcademyAPI.Models.User", "User")
                        .WithMany("PostalAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AdaptITAcademyAPI.Models.Training", b =>
                {
                    b.HasOne("AdaptITAcademyAPI.Models.Course", "Course")
                        .WithMany("Trainings")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("AdaptITAcademyAPI.Models.UserTraining", b =>
                {
                    b.HasOne("AdaptITAcademyAPI.Models.Training", "Training")
                        .WithMany("UserTrainings")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdaptITAcademyAPI.Models.User", "User")
                        .WithMany("UserTrainings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AdaptITAcademyAPI.Models.Course", b =>
                {
                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("AdaptITAcademyAPI.Models.Training", b =>
                {
                    b.Navigation("UserTrainings");
                });

            modelBuilder.Entity("AdaptITAcademyAPI.Models.User", b =>
                {
                    b.Navigation("PhysicalAddresses");

                    b.Navigation("PostalAddresses");

                    b.Navigation("UserTrainings");
                });
#pragma warning restore 612, 618
        }
    }
}
