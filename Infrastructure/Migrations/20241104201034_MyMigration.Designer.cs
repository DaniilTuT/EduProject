﻿// <auto-generated />
using System;
using Infrastructure.Dal.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20241104201034_MyMigration")]
    partial class MyMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("SheduleId")
                        .HasColumnType("uuid");

                    b.Property<int>("TypeOfLesson")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1)
                        .HasColumnName("type_of_lesson");

                    b.HasKey("Id");

                    b.HasIndex("SheduleId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Domain.Entities.Shedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<bool>("IsOddWeek")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Shedules");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VerificationCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("VerificationCode");
                });

            modelBuilder.Entity("Domain.Entities.Lesson", b =>
                {
                    b.HasOne("Domain.Entities.Shedule", null)
                        .WithMany("Lessons")
                        .HasForeignKey("SheduleId");

                    b.OwnsOne("Domain.ValueObjects.DateRange", "DateRange", b1 =>
                        {
                            b1.Property<Guid>("LessonId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("EndDate")
                                .HasColumnType("timestamp")
                                .HasColumnName("end_date");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("timestamp")
                                .HasColumnName("start_date");

                            b1.HasKey("LessonId");

                            b1.ToTable("Lessons");

                            b1.WithOwner()
                                .HasForeignKey("LessonId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Subject", "Subject", b1 =>
                        {
                            b1.Property<Guid>("LessonId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("subject_name");

                            b1.HasKey("LessonId");

                            b1.ToTable("Lessons");

                            b1.WithOwner()
                                .HasForeignKey("LessonId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Teacher", "Teacher", b1 =>
                        {
                            b1.Property<Guid>("LessonId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("teacher_name");

                            b1.HasKey("LessonId");

                            b1.ToTable("Lessons");

                            b1.WithOwner()
                                .HasForeignKey("LessonId");
                        });

                    b.Navigation("DateRange")
                        .IsRequired();

                    b.Navigation("Subject")
                        .IsRequired();

                    b.Navigation("Teacher")
                        .IsRequired();
                });

            modelBuilder.Entity("VerificationCode", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("VerificationCodes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Shedule", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("VerificationCodes");
                });
#pragma warning restore 612, 618
        }
    }
}
