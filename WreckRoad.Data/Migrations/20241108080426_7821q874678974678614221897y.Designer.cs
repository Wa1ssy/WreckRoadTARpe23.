﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WreckRoad.Data;

#nullable disable

namespace WreckRoad.Data.Migrations
{
    [DbContext(typeof(WreckRoadContext))]
    [Migration("20241108080426_7821q874678974678614221897y")]
    partial class _7821q874678974678614221897y
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WreckRoad.Core.Domain.Car", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BuiltAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CarCrashed")
                        .HasColumnType("datetime2");

                    b.Property<int>("CarLevel")
                        .HasColumnType("int");

                    b.Property<string>("CarName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarStatus")
                        .HasColumnType("int");

                    b.Property<int>("CarType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CarWasBuilt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CarXP")
                        .HasColumnType("int");

                    b.Property<int>("CarXPNextLevel")
                        .HasColumnType("int");

                    b.Property<string>("TurnName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TurnSpeed")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("WreckRoad.Core.Domain.FileToDatabase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CarID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("FilesToDatabase");
                });
#pragma warning restore 612, 618
        }
    }
}
