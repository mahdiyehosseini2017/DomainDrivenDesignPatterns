﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpecificationPatternLearning.Infra.Data.EfCore.SQL;

namespace SpecificationPatternLearning.Infra.Data.EfCore.SQL.Migrations
{
    [DbContext(typeof(PersonnelDbContext))]
    [Migration("20210920092215_SeedEducationTypes")]
    partial class SeedEducationTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SpecificationPatternLearning.Core.Domain.PersonnelEducations.EducationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("EducationType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "diplom",
                            Title = "Diploma"
                        },
                        new
                        {
                            Id = 2,
                            Code = "lisans",
                            Title = "Bachelor"
                        },
                        new
                        {
                            Id = 3,
                            Code = "foghe-lisance",
                            Title = "Masters"
                        },
                        new
                        {
                            Id = 4,
                            Code = "doktora",
                            Title = "PhD"
                        });
                });

            modelBuilder.Entity("SpecificationPatternLearning.Core.Domain.PersonnelEducations.PersonnelEducation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EducationTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PersonnelId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EducationTypeId");

                    b.HasIndex("PersonnelId");

                    b.ToTable("PersonnelEducations");
                });

            modelBuilder.Entity("SpecificationPatternLearning.Core.Domain.Personnels.Personnel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PersonnelNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength(true);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Personnels");
                });

            modelBuilder.Entity("SpecificationPatternLearning.Core.Domain.PersonnelEducations.PersonnelEducation", b =>
                {
                    b.HasOne("SpecificationPatternLearning.Core.Domain.PersonnelEducations.EducationType", "EducationType")
                        .WithMany()
                        .HasForeignKey("EducationTypeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SpecificationPatternLearning.Core.Domain.Personnels.Personnel", null)
                        .WithMany()
                        .HasForeignKey("PersonnelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EducationType");
                });
#pragma warning restore 612, 618
        }
    }
}
