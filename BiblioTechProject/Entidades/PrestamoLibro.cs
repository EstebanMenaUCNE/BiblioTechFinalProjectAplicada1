﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BiblioTechProject.Entidades
{
    public class PrestamoLibro
    {
        [Key]
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public int LibroId { get; set; }

        /*public virtual Libro Libro { get; set; }
        public virtual Usuario Usuario { get; set; }
        */
        public PrestamoLibro(int libroId)
        {
            LibroId = libroId;
        }

        public PrestamoLibro()
        {

        }

        public PrestamoLibro(int id, int prestamoId, int libroId)
        {
            Id = id;
            PrestamoId = prestamoId;
            LibroId = libroId;
        }
    }

}
