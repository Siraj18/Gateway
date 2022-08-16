﻿// <auto-generated />
using System;
using Gateway.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Gateway.Data.Migrations
{
    [DbContext(typeof(GatewayContext))]
    [Migration("20220526154415_AddTypeAndAnswerColumnsToLevel")]
    partial class AddTypeAndAnswerColumnsToLevel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CourseDbModelStatisticDbModel", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("integer")
                        .HasColumnName("courses_id");

                    b.Property<int>("StatisticsId")
                        .HasColumnType("integer")
                        .HasColumnName("statistics_id");

                    b.HasKey("CoursesId", "StatisticsId")
                        .HasName("pk_course_db_model_statistic_db_model");

                    b.HasIndex("StatisticsId")
                        .HasDatabaseName("ix_course_db_model_statistic_db_model_statistics_id");

                    b.ToTable("course_db_model_statistic_db_model");
                });

            modelBuilder.Entity("Gateway.Data.Courses.CourseDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsBonus")
                        .HasColumnType("boolean")
                        .HasColumnName("is_bonus");

                    b.Property<int>("Level")
                        .HasColumnType("integer")
                        .HasColumnName("level");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_courses");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("Gateway.Data.Courses.StatisticCourseDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("integer")
                        .HasColumnName("course_id");

                    b.Property<int>("MaxLevel")
                        .HasColumnType("integer")
                        .HasColumnName("max_level");

                    b.Property<int>("StatisticId")
                        .HasColumnType("integer")
                        .HasColumnName("statistic_id");

                    b.HasKey("Id")
                        .HasName("pk_statistic_course");

                    b.ToTable("statistic_course");
                });

            modelBuilder.Entity("Gateway.Data.Levels.LevelDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Answer")
                        .HasColumnType("text")
                        .HasColumnName("answer");

                    b.Property<int>("Counter")
                        .HasColumnType("integer")
                        .HasColumnName("counter");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer")
                        .HasColumnName("course_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsLast")
                        .HasColumnType("boolean")
                        .HasColumnName("is_last");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Stars")
                        .HasColumnType("integer")
                        .HasColumnName("stars");

                    b.Property<string>("Tutorial")
                        .HasColumnType("text")
                        .HasColumnName("tutorial");

                    b.Property<string>("Type")
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_levels");

                    b.HasIndex("CourseId")
                        .HasDatabaseName("ix_levels_course_id");

                    b.ToTable("levels");
                });

            modelBuilder.Entity("Gateway.Data.Statistics.StatisticDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("MaxCourse")
                        .HasColumnType("integer")
                        .HasColumnName("max_course");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_statistics");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasDatabaseName("ix_statistics_user_id");

                    b.ToTable("statistics");
                });

            modelBuilder.Entity("Gateway.Data.Users.UserDbModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.Property<string>("UserClass")
                        .HasColumnType("text")
                        .HasColumnName("user_class");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users");
                });

            modelBuilder.Entity("CourseDbModelStatisticDbModel", b =>
                {
                    b.HasOne("Gateway.Data.Courses.CourseDbModel", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .HasConstraintName("fk_course_db_model_statistic_db_model_courses_courses_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gateway.Data.Statistics.StatisticDbModel", null)
                        .WithMany()
                        .HasForeignKey("StatisticsId")
                        .HasConstraintName("fk_course_db_model_statistic_db_model_statistics_statistics_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gateway.Data.Levels.LevelDbModel", b =>
                {
                    b.HasOne("Gateway.Data.Courses.CourseDbModel", "Course")
                        .WithMany("Levels")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("fk_levels_courses_course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Gateway.Data.Statistics.StatisticDbModel", b =>
                {
                    b.HasOne("Gateway.Data.Users.UserDbModel", "User")
                        .WithOne("Statistic")
                        .HasForeignKey("Gateway.Data.Statistics.StatisticDbModel", "UserId")
                        .HasConstraintName("fk_statistics_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gateway.Data.Courses.CourseDbModel", b =>
                {
                    b.Navigation("Levels");
                });

            modelBuilder.Entity("Gateway.Data.Users.UserDbModel", b =>
                {
                    b.Navigation("Statistic");
                });
#pragma warning restore 612, 618
        }
    }
}
