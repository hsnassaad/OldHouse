﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OldHouse.Data;

namespace OldHouse.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OldHouse.Data.Patient", b =>
                {
                    b.Property<string>("PatientId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("BloodType")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(256);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Gender")
                        .HasMaxLength(256);

                    b.Property<bool>("IsAlive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("MachineId")
                        .HasMaxLength(2147483647);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(256);

                    b.Property<int?>("RelativeId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("PatientId");

                    b.HasIndex("RelativeId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("OldHouse.Models.Alert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2147483647);

                    b.Property<string>("PatientId");

                    b.Property<bool>("Seen");

                    b.Property<DateTime>("SeenAt");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("OldHouse.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BloodPressur")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("BloodSugarLevel");

                    b.Property<int>("CholesterolLevel");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2147483647);

                    b.Property<int>("HeartBeatPerSecond");

                    b.Property<string>("PatientId");

                    b.Property<int>("Temperature");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("OldHouse.Models.Relative", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Relation")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Relatives");
                });

            modelBuilder.Entity("OldHouse.Data.Patient", b =>
                {
                    b.HasOne("OldHouse.Models.Relative", "Relative")
                        .WithMany()
                        .HasForeignKey("RelativeId");
                });

            modelBuilder.Entity("OldHouse.Models.Alert", b =>
                {
                    b.HasOne("OldHouse.Data.Patient", "Patient")
                        .WithMany("Alerts")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("OldHouse.Models.Record", b =>
                {
                    b.HasOne("OldHouse.Data.Patient", "Patient")
                        .WithMany("Records")
                        .HasForeignKey("PatientId");
                });
#pragma warning restore 612, 618
        }
    }
}
