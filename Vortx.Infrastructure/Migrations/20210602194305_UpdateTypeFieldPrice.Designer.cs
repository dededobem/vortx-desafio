﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vortx.Infrastructure.Data;

namespace Vortx.Infrastructure.Migrations
{
    [DbContext(typeof(VortxContext))]
    [Migration("20210602194305_UpdateTypeFieldPrice")]
    partial class UpdateTypeFieldPrice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Vortx.Domain.Entities.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("TimeMinutes")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("Vortx.Domain.Entities.Price", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("DddDestination")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar");

                    b.Property<string>("DddOrigin")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar");

                    b.Property<double>("Minute")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Prices");
                });
#pragma warning restore 612, 618
        }
    }
}
