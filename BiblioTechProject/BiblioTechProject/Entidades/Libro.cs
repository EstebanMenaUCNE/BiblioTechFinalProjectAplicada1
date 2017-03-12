﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BiblioTechProject.Entidades
{
    public class Libro
    {
        [Key]
        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public int Edicion { get; set; }
        public string Estado { get; set; }
        public int EditorialId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public List<Autor> Autores { get; set; }
        public virtual ICollection<EditorialLibro> EditorialesLibros { get; set; }
        public virtual ICollection<PrestamoLibro> PrestamosLibros { get; set; }
        public virtual ICollection<DevolucionLibro> DevolucionesLibros { get; set; }
    }

}