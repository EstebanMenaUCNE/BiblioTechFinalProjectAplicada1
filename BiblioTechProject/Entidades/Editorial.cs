﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BiblioTechProject.Entidades
{
    public class Editorial
    {
        [Key]
        public int EditorialId { get; set; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string UltimoUsuarioEnModificar { get; set; }
        /*
        public virtual Usuario Usuario { get; set; }
        public ICollection<EditorialLibro> EditorialesLibros { get; set; }
        */
        public Editorial()
        {
            //EditorialesLibros = new HashSet<EditorialLibro>();
        }
        /*
        public void AgregarDetalle(int libroId)
        {
            EditorialesLibros.Add(new EditorialLibro(libroId));
        }
        */
        public Editorial(int editorialId, string nombre, int usuarioId)
        {
            EditorialId = editorialId;
            Nombre = nombre;
            UsuarioId = usuarioId;
        }
    }

}
