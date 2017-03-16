﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BiblioTechProject.Entidades
{
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public List<Libro> Libros { get; set; }

        public Autor()
        {
            Libros = new List<Libro>();
        }
    }

}
