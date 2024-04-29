﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Models.NumberVilla", b =>
                {
                    b.Property<int>("VillaNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpecialDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("VillaNumber");

                    b.HasIndex("VillaId");

                    b.ToTable("NumberVillas");
                });

            modelBuilder.Entity("Data.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocuppants")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<double>("SquareMeters")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "",
                            CreationDate = new DateTime(2024, 4, 29, 4, 26, 14, 18, DateTimeKind.Local).AddTicks(2693),
                            Detail = "Detalle de la villa",
                            ImageUrl = "",
                            Name = "Villa Real",
                            Ocuppants = 5,
                            Rate = 200.0,
                            SquareMeters = 50.0,
                            UpdateDate = new DateTime(2024, 4, 29, 4, 26, 14, 18, DateTimeKind.Local).AddTicks(2702)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "",
                            CreationDate = new DateTime(2024, 4, 29, 4, 26, 14, 18, DateTimeKind.Local).AddTicks(2704),
                            Detail = "Detalle de la villa",
                            ImageUrl = "",
                            Name = "Premium Vista al Mar",
                            Ocuppants = 4,
                            Rate = 150.0,
                            SquareMeters = 40.0,
                            UpdateDate = new DateTime(2024, 4, 29, 4, 26, 14, 18, DateTimeKind.Local).AddTicks(2705)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "",
                            CreationDate = new DateTime(2024, 4, 29, 4, 26, 14, 18, DateTimeKind.Local).AddTicks(2706),
                            Detail = "Detalle de la villa",
                            ImageUrl = "",
                            Name = "Premium Vista al Mar",
                            Ocuppants = 4,
                            Rate = 150.0,
                            SquareMeters = 40.0,
                            UpdateDate = new DateTime(2024, 4, 29, 4, 26, 14, 18, DateTimeKind.Local).AddTicks(2707)
                        });
                });

            modelBuilder.Entity("Data.Models.NumberVilla", b =>
                {
                    b.HasOne("Data.Models.Villa", "Villa")
                        .WithMany()
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });
#pragma warning restore 612, 618
        }
    }
}
