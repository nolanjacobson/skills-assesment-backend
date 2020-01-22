﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using capstone_backend.Models;

namespace capstonebackend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200110210336_SectionClassImmutable1")]
    partial class SectionClassImmutable1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("capstone_backend.Models.Nurse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("NurseEmail")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("RecruiterEmail")
                        .HasColumnType("text");

                    b.Property<string>("SignatureCanvas")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Nurse");
                });

            modelBuilder.Entity("capstone_backend.Models.TestData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TestData");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TestData");
                });

            modelBuilder.Entity("capstone_backend.Models.Section", b =>
                {
                    b.HasBaseType("capstone_backend.Models.TestData");

                    b.Property<List<int>>("FrequencyRating")
                        .HasColumnType("integer[]");

                    b.Property<string>("Header")
                        .HasColumnType("text");

                    b.Property<List<int>>("ProficiencyRating")
                        .HasColumnType("integer[]");

                    b.Property<List<string>>("Questions")
                        .HasColumnType("text[]");

                    b.Property<int?>("TestDataId")
                        .HasColumnType("integer");

                    b.HasIndex("TestDataId");

                    b.HasDiscriminator().HasValue("Section");
                });

            modelBuilder.Entity("capstone_backend.Models.Section", b =>
                {
                    b.HasOne("capstone_backend.Models.TestData", null)
                        .WithMany("sections")
                        .HasForeignKey("TestDataId");
                });
#pragma warning restore 612, 618
        }
    }
}