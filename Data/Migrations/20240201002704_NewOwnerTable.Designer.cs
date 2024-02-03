﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(CarDbContext))]
    [Migration("20240201002704_NewOwnerTable")]
    partial class NewOwnerTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("Data.Entities.CarEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT")
                        .HasColumnName("CreateDate");

                    b.Property<string>("EngineCapacity")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("EnginePower")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EngineType")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LicensePlateNumber")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Producer")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 2, 1, 1, 27, 4, 443, DateTimeKind.Local).AddTicks(687),
                            EngineCapacity = "1.3",
                            EnginePower = 60,
                            EngineType = "Benzynowy",
                            LicensePlateNumber = "KR AB12",
                            Model = "Felicia",
                            OwnerId = 1,
                            Producer = "Skoda",
                            State = 1
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 2, 1, 1, 27, 4, 443, DateTimeKind.Local).AddTicks(734),
                            EngineCapacity = "1.6",
                            EnginePower = 50,
                            EngineType = "Benzynowy",
                            LicensePlateNumber = "WI CB21",
                            Model = "Golf 2",
                            OwnerId = 2,
                            Producer = "BMW",
                            State = 1
                        });
                });

            modelBuilder.Entity("Data.Entities.OwnerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jan.nowak@gmail.com",
                            FirstName = "Jan",
                            LastName = "Nowak",
                            Pesel = "95715209461",
                            PhoneNumber = "+48923614982"
                        },
                        new
                        {
                            Id = 2,
                            Email = "piotr.kowalski@wp.pl",
                            FirstName = "Piotr",
                            LastName = "Kowalski",
                            Pesel = "12497432487",
                            PhoneNumber = "+48740981265"
                        });
                });

            modelBuilder.Entity("Data.Entities.CarEntity", b =>
                {
                    b.HasOne("Data.Entities.OwnerEntity", "Owner")
                        .WithMany("Cars")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Data.Entities.OwnerEntity", b =>
                {
                    b.OwnsOne("Data.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OwnerEntityId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .HasColumnType("TEXT");

                            b1.HasKey("OwnerEntityId");

                            b1.ToTable("Owners");

                            b1.WithOwner()
                                .HasForeignKey("OwnerEntityId");

                            b1.HasData(
                                new
                                {
                                    OwnerEntityId = 1,
                                    City = "Kraków",
                                    PostalCode = "12-900",
                                    Region = "Małopolska",
                                    Street = "Krakowska 1"
                                },
                                new
                                {
                                    OwnerEntityId = 2,
                                    City = "Warszawa",
                                    PostalCode = "21-009",
                                    Region = "Mazowsze",
                                    Street = "Warszawska 2"
                                });
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Data.Entities.OwnerEntity", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
