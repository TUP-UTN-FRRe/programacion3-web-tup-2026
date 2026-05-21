using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TUP.Mundial.Entidades;

namespace TUP.Mundial.DatosEF
{
    internal class MundialFIFA2026Context : DbContext
    {

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Partido> Partidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = "Server=localhost;Database=MundialFIFA2026;Integrated Security=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connection);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
