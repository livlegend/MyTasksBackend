﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyTasksBackend.Models;

#nullable disable

namespace MyTasksBackend.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20241123055008_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyTasksBackend.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategoryItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Travail"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Personnel"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Etudes"
                        });
                });

            modelBuilder.Entity("MyTasksBackend.Models.TheTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateLimit")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("TaskItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            DateLimit = new DateTime(2024, 11, 23, 0, 50, 8, 179, DateTimeKind.Local).AddTicks(9320),
                            Description = "Ma desc1",
                            Status = 0,
                            Title = "Ma tâche 1",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            DateLimit = new DateTime(2024, 11, 23, 0, 50, 8, 179, DateTimeKind.Local).AddTicks(9369),
                            Description = "Ma desc2",
                            Status = 0,
                            Title = "Ma tâche 2",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            DateLimit = new DateTime(2024, 11, 23, 0, 50, 8, 179, DateTimeKind.Local).AddTicks(9371),
                            Description = "Ma desc2",
                            Status = 0,
                            Title = "Ma tâche 2",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("MyTasksBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "test@example.com",
                            Name = "HYAME Lorry",
                            Password = "RqN9ZaTJ6yIJuvPpGthQ/URXwL2AQSoLUPYF/dOmqmFMTAB5gc2lsDWfv/sSxnvL",
                            Role = "Administrator",
                            Status = "Active"
                        });
                });

            modelBuilder.Entity("MyTasksBackend.Models.TheTask", b =>
                {
                    b.HasOne("MyTasksBackend.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyTasksBackend.Models.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyTasksBackend.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("MyTasksBackend.Models.User", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
