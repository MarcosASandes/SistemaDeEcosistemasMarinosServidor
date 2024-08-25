using EcoMarino.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.AccesoDatos.EntityFramework
{
    public class EcoMarinoContext : DbContext
    {
        public DbSet<Amenaza> Amenazas { get; set; }
        public DbSet<ControlCambios> ControlCambios { get; set; }
        public DbSet<Ecosistema> Ecosistemas { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<EstadoConservacion> EstadosDeConservacion { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<EcosistemaAmenaza> EcosistemaAmenaza { get; set; }
        public DbSet<EspecieAmenaza> EspecieAmenaza { get; set; }
        public DbSet<EcosistemaEspecie> EcosistemaEspecie { get; set; }
        public DbSet<EcosistemaImagen> EcosistemaImagen { get; set; }
        public DbSet<EspecieImagen> EspecieImagen { get; set; }
        public DbSet<Configuracion> Configuraciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cadenaConexion =
                @"SERVER=(localdb)\MSsqlLocaldb;
                DATABASE=MundoMarinoDB;
                INTEGRATED SECURITY=TRUE;
                ENCRYPT=False";

            optionsBuilder.UseSqlServer(cadenaConexion).EnableDetailedErrors();
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Conf. de EcosistemaAmenaza
            modelBuilder.Entity<EcosistemaAmenaza>()
                .HasKey(ea => new { ea.EcosistemaId, ea.AmenazaId });

            modelBuilder.Entity<EcosistemaAmenaza>()
                .HasOne(ea => ea.Ecosistema)
                .WithMany(e => e._amenazas)
                .HasForeignKey(ea => ea.EcosistemaId);

            modelBuilder.Entity<EcosistemaAmenaza>()
                .HasOne(ea => ea.Amenaza)
                .WithMany(a => a.ecosistemas)
                .HasForeignKey(ea => ea.AmenazaId);
            #endregion

            #region Conf. de EspecieAmenaza
            modelBuilder.Entity<EspecieAmenaza>()
                .HasKey(ea => new { ea.idEspecie, ea.idAmenaza });

            modelBuilder.Entity<EspecieAmenaza>()
                .HasOne(ea => ea.Especie)
                .WithMany(e => e._amenazas)
                .HasForeignKey(ea => ea.idEspecie);

            modelBuilder.Entity<EspecieAmenaza>()
                .HasOne(ea => ea.Amenaza)
                .WithMany(a => a.especies)
                .HasForeignKey(ea => ea.idAmenaza);
            #endregion

            #region Conf. de EcosistemaEspecie
            modelBuilder.Entity<EcosistemaEspecie>()
            .HasKey(ea => new { ea.idEcosistema, ea.idEspecie, ea.LoHabita });

            modelBuilder.Entity<EcosistemaEspecie>()
                .HasOne(ea => ea.Especie)
                .WithMany(e => e._ecosistemas)
                .HasForeignKey(ea => ea.idEspecie)
                .OnDelete(DeleteBehavior.Restrict); // Cambia a restrict en lugar de cascade

            modelBuilder.Entity<EcosistemaEspecie>()
                .HasOne(ea => ea.Ecosistema)
                .WithMany(a => a._especies)
                .HasForeignKey(ea => ea.idEcosistema)
                .OnDelete(DeleteBehavior.Restrict); // Cambia a restrict en lugar de cascade
            #endregion

            #region Conf. de EcosistemaImagen
            modelBuilder.Entity<EcosistemaImagen>()
                .HasOne(ea => ea.Eco)
                .WithMany(e => e._imagenes)
                .HasForeignKey(ea => ea.IdEcosistema)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Conf. de EspecieImagen
            modelBuilder.Entity<EspecieImagen>()
                .HasOne(ea => ea.Esp)
                .WithMany(e => e._imagenes)
                .HasForeignKey(ea => ea.IdEspecie)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }


    }
}
