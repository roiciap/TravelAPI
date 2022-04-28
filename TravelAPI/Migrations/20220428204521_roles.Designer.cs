﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAPI.Entities;

namespace TravelAPI.Migrations
{
    [DbContext(typeof(DataBase))]
    [Migration("20220428204521_roles")]
    partial class roles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("TravelAPI.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IloscGwiazdek")
                        .HasColumnType("int");

                    b.Property<int>("LokalizacjaId")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LokalizacjaId");

                    b.ToTable("Hotele");
                });

            modelBuilder.Entity("TravelAPI.Entities.Klient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("passwordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Klienci");
                });

            modelBuilder.Entity("TravelAPI.Entities.Lokalizacja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Kraj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Miasto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lokalizacje");
                });

            modelBuilder.Entity("TravelAPI.Entities.Pokoj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("koszt")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Pokoje");
                });

            modelBuilder.Entity("TravelAPI.Entities.Rezerwacja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KlientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KlientId");

                    b.ToTable("Rezerwacje");
                });

            modelBuilder.Entity("TravelAPI.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("TravelAPI.Entities.Wycieczka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PokojId")
                        .HasColumnType("int");

                    b.Property<int>("RezerwacjaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PokojId");

                    b.HasIndex("RezerwacjaId");

                    b.ToTable("Wycieczki");
                });

            modelBuilder.Entity("TravelAPI.Entities.Hotel", b =>
                {
                    b.HasOne("TravelAPI.Entities.Lokalizacja", "Lokalizacja")
                        .WithMany()
                        .HasForeignKey("LokalizacjaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lokalizacja");
                });

            modelBuilder.Entity("TravelAPI.Entities.Klient", b =>
                {
                    b.HasOne("TravelAPI.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TravelAPI.Entities.Pokoj", b =>
                {
                    b.HasOne("TravelAPI.Entities.Hotel", "Hotel")
                        .WithMany("Pokoje")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("TravelAPI.Entities.Rezerwacja", b =>
                {
                    b.HasOne("TravelAPI.Entities.Klient", "Klient")
                        .WithMany("Rezerwacje")
                        .HasForeignKey("KlientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klient");
                });

            modelBuilder.Entity("TravelAPI.Entities.Wycieczka", b =>
                {
                    b.HasOne("TravelAPI.Entities.Pokoj", "Pokoj")
                        .WithMany("Wycieczki")
                        .HasForeignKey("PokojId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAPI.Entities.Rezerwacja", "Rezerwacja")
                        .WithMany("Wycieczki")
                        .HasForeignKey("RezerwacjaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokoj");

                    b.Navigation("Rezerwacja");
                });

            modelBuilder.Entity("TravelAPI.Entities.Hotel", b =>
                {
                    b.Navigation("Pokoje");
                });

            modelBuilder.Entity("TravelAPI.Entities.Klient", b =>
                {
                    b.Navigation("Rezerwacje");
                });

            modelBuilder.Entity("TravelAPI.Entities.Pokoj", b =>
                {
                    b.Navigation("Wycieczki");
                });

            modelBuilder.Entity("TravelAPI.Entities.Rezerwacja", b =>
                {
                    b.Navigation("Wycieczki");
                });
#pragma warning restore 612, 618
        }
    }
}
