﻿// <auto-generated />
using System;
using AngularApp1.Server.infraestructure.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AngularApp1.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240402225438_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AngularApp1.Server.Domain.Entities.Campionato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Campionatos");
                });

            modelBuilder.Entity("AngularApp1.Server.Domain.Entities.Clasificacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Derrotas")
                        .HasColumnType("int");

                    b.Property<int>("Empatados")
                        .HasColumnType("int");

                    b.Property<Guid>("EquipoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GolesAF")
                        .HasColumnType("int");

                    b.Property<int>("GolesEC")
                        .HasColumnType("int");

                    b.Property<int>("PartidosJugados")
                        .HasColumnType("int");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int>("Posicion")
                        .HasColumnType("int");

                    b.Property<Guid?>("TablaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Victorias")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipoId");

                    b.HasIndex("TablaId");

                    b.ToTable("Clasificacions");
                });

            modelBuilder.Entity("AngularApp1.Server.Domain.Entities.Equipo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<Guid?>("CampionatoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PartidoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CampionatoId");

                    b.HasIndex("PartidoId");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("AngularApp1.Server.Domain.Entities.Partido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GolLocal")
                        .HasColumnType("int");

                    b.Property<int>("GolVisitante")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("AngularApp1.Server.Domain.Entities.Tabla", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CampionatoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CampionatoId");

                    b.ToTable("Tablas");
                });

            modelBuilder.Entity("AngularApp1.Server.Domain.Entities.Clasificacion", b =>
                {
                    b.HasOne("AngularApp1.Server.Domain.Entities.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AngularApp1.Server.Domain.Entities.Tabla", null)
                        .WithMany("Clasificaciones")
                        .HasForeignKey("TablaId");

                    b.Navigation("Equipo");
                });

            modelBuilder.Entity("AngularApp1.Server.Domain.Entities.Equipo", b =>
                {
                    b.HasOne("AngularApp1.Server.Domain.Entities.Campionato", null)
                        .WithMany("Equipos")
                        .HasForeignKey("CampionatoId");

                    b.HasOne("AngularApp1.Server.Domain.Entities.Partido", null)
                        .WithMany("Equipos")
                        .HasForeignKey("PartidoId");
                });

            modelBuilder.Entity("AngularApp1.Server.Domain.Entities.Tabla", b =>
                {
                    b.HasOne("AngularApp1.Server.Domain.Entities.Campionato", "Campionato")
                        .WithMany()
                        .HasForeignKey("CampionatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campionato");
                });

            modelBuilder.Entity("AngularApp1.Server.Domain.Entities.Campionato", b =>
                {
                    b.Navigation("Equipos");
                });

            modelBuilder.Entity("AngularApp1.Server.Domain.Entities.Partido", b =>
                {
                    b.Navigation("Equipos");
                });

            modelBuilder.Entity("AngularApp1.Server.Domain.Entities.Tabla", b =>
                {
                    b.Navigation("Clasificaciones");
                });
#pragma warning restore 612, 618
        }
    }
}