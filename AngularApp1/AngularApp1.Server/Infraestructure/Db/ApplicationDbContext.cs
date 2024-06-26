﻿using AngularApp1.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace AngularApp1.Server.infraestructure.db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Equipo> Equipos { get; set; }

        public DbSet<Partido> Partidos { get; set; }

        public DbSet<Campionato> Campionatos { get; set; }
        public DbSet<Tabla> Tablas { get; set; }
        public DbSet<Clasificacion> Clasificacions { get; set; }

    }
}
