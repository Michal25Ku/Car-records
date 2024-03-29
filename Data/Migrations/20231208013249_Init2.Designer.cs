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
    [Migration("20231208013249_Init2")]
    partial class Init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("Data.Entities.CarEntity", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("EngineCapacity")
                        .HasColumnType("TEXT");

                    b.Property<int>("EnginePower")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EngineType")
                        .HasColumnType("TEXT");

                    b.Property<string>("LicensePlateNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Producer")
                        .HasColumnType("TEXT");

                    b.HasKey("CarId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Data.Entities.CarEntity", b =>
                {
                    b.OwnsOne("Data.Entities.CarContactDetailsEntity", "ContactDetails", b1 =>
                        {
                            b1.Property<int>("CarEntityCarId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("CarId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Email")
                                .HasColumnType("TEXT");

                            b1.Property<string>("FirstName")
                                .HasColumnType("TEXT");

                            b1.Property<string>("LastName")
                                .HasColumnType("TEXT");

                            b1.Property<string>("PhoneNumber")
                                .HasColumnType("TEXT");

                            b1.HasKey("CarEntityCarId");

                            b1.ToTable("Cars");

                            b1.WithOwner()
                                .HasForeignKey("CarEntityCarId");
                        });

                    b.Navigation("ContactDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
