﻿using BiblioTechProject.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace BiblioTechProject.DAL
{
    public class BiblioTechDb : DbContext
    {


        public BiblioTechDb() : base("ConStr")
        {

        }
        
        public DbSet<Autor> Autores { get; set; }
        public DbSet<AutorLibro> AutoresLibros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Devolucion> Devoluciones { get; set; }
        public DbSet<DevolucionLibro> DevolucionesLibros { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<EditorialLibro> EditorialesLibros { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<PrestamoLibro> PrestamosLibros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>()
                .HasMany(Autor => Autor.Libros)
                .WithMany(Libro => Libro.Autores)
                .Map(AutoresLibros =>
                {
                    AutoresLibros.MapLeftKey("AutorId");
                    AutoresLibros.MapRightKey("LibroId");
                    AutoresLibros.ToTable("AutoresLibros");
                }
                );
        }*/
        
    }

}
