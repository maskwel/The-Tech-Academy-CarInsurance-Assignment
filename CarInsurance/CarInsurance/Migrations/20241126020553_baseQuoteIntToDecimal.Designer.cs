﻿// <auto-generated />
using System;
using CarInsurance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarInsurance.Migrations
{
    [DbContext(typeof(CarInsuranceDbContext))]
    [Migration("20241126020553_baseQuoteIntToDecimal")]
    partial class baseQuoteIntToDecimal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarInsurance.Models.Insuree", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CarMake")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CarYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("CoverageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DUI")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Quote")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SpeedingTickets")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Insurees");
                });
#pragma warning restore 612, 618
        }
    }
}
