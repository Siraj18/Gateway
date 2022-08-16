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
    [Migration("20220518150945_UpdateUserTable")]
    partial class UpdateUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

            modelBuilder.Entity("Gateway.Data.Levels.LevelDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("integer")
                        .HasColumnName("course_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Stars")
                        .HasColumnType("integer")
                        .HasColumnName("stars");

                    b.Property<string>("Tutorial")
                        .HasColumnType("text")
                        .HasColumnName("tutorial");

                    b.HasKey("Id")
                        .HasName("pk_levels");

                    b.HasIndex("CourseId")
                        .HasDatabaseName("ix_levels_course_id");

                    b.ToTable("levels");
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

            modelBuilder.Entity("Gateway.Data.Courses.CourseDbModel", b =>
                {
                    b.Navigation("Levels");
                });
#pragma warning restore 612, 618
        }
    }
}
