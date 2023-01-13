﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_Selin_Robert_Cristian.Data;

#nullable disable

namespace Proiect_Selin_Robert_Cristian.Migrations
{
    [DbContext(typeof(Proiect_Selin_Robert_CristianContext))]
    [Migration("20230113142308_Mem")]
    partial class Mem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.Booking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.Property<int?>("SportsFieldID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MemberID");

                    b.HasIndex("SportsFieldID");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.SportsFacility", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SportsFacilityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("SportsFacility");
                });

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.SportsField", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Field_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price_Per_Hour")
                        .HasColumnType("decimal(7,2)");

                    b.Property<int?>("SportsFacilityID")
                        .HasColumnType("int");

                    b.Property<string>("Surface")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("SportsFacilityID");

                    b.ToTable("SportsField");
                });

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.SportsFieldCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("SportsFieldID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SportsFieldID");

                    b.ToTable("SportsFieldCategory");
                });

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.Booking", b =>
                {
                    b.HasOne("Proiect_Selin_Robert_Cristian.Models.Member", "Member")
                        .WithMany("Bookings")
                        .HasForeignKey("MemberID");

                    b.HasOne("Proiect_Selin_Robert_Cristian.Models.SportsField", "SportsField")
                        .WithMany()
                        .HasForeignKey("SportsFieldID");

                    b.Navigation("Member");

                    b.Navigation("SportsField");
                });

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.SportsFacility", b =>
                {
                    b.HasOne("Proiect_Selin_Robert_Cristian.Models.City", "City")
                        .WithMany("SportsFacilities")
                        .HasForeignKey("CityID");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.SportsField", b =>
                {
                    b.HasOne("Proiect_Selin_Robert_Cristian.Models.SportsFacility", "SportsFacility")
                        .WithMany("SportsFields")
                        .HasForeignKey("SportsFacilityID");

                    b.Navigation("SportsFacility");
                });

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.SportsFieldCategory", b =>
                {
                    b.HasOne("Proiect_Selin_Robert_Cristian.Models.Category", "Category")
                        .WithMany("SportsFieldCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_Selin_Robert_Cristian.Models.SportsField", "SportsField")
                        .WithMany("SportsFieldCategories")
                        .HasForeignKey("SportsFieldID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("SportsField");
                });

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.Category", b =>
                {
                    b.Navigation("SportsFieldCategories");
                });

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.City", b =>
                {
                    b.Navigation("SportsFacilities");
                });

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.Member", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.SportsFacility", b =>
                {
                    b.Navigation("SportsFields");
                });

            modelBuilder.Entity("Proiect_Selin_Robert_Cristian.Models.SportsField", b =>
                {
                    b.Navigation("SportsFieldCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
