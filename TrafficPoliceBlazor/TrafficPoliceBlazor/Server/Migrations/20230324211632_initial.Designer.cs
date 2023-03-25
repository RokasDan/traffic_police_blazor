﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrafficPoliceBlazor.Server.Dal;

#nullable disable

namespace TrafficPoliceBlazor.Server.Migrations
{
    [DbContext(typeof(adminDbContext))]
    [Migration("20230324211632_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TrafficPoliceBlazor.Shared.admins", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Username");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Password");

                    b.HasKey("username");

                    b.ToTable("loginDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
