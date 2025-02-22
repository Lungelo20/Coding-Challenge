﻿// <auto-generated />
using System;
using Coding_Challenge.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Coding_Challenge.Migrations
{
    [DbContext(typeof(TaskDbContext))]
    partial class TaskDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Coding_Challenge.Models.TaskItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Initialize Git repo, configure project folders, and set up CI/CD.",
                            DueDate = new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Set up project structure"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Create wireframes and UI designs for the application screens.",
                            DueDate = new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Design UI mockups"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Implement user login and registration with JWT authentication.",
                            DueDate = new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Develop authentication system"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Create RESTful API endpoints for user and task management.",
                            DueDate = new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Build API endpoints"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Ensure high code quality with unit and integration tests.",
                            DueDate = new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Write unit tests"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
