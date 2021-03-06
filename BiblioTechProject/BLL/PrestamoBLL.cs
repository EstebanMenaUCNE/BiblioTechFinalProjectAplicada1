﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BiblioTechProject.BLL
{
    public class PrestamoBLL
    {
        public static bool Guardar(Entidades.Prestamo prestamo, List<Entidades.PrestamoLibro> listaRelaciones)
        {
            using (var repositorio = new DAL.Repositorio<Entidades.Prestamo>())
            {
                bool prestamoGuardado;
                bool relacionesGuardadas = false;
                if (Buscar(P => P.PrestamoId == prestamo.PrestamoId) == null)
                {
                    prestamoGuardado = repositorio.Guardar(prestamo);
                }
                else
                {
                    prestamoGuardado = repositorio.Modificar(prestamo);
                }
                if (prestamoGuardado)
                {
                    relacionesGuardadas = true;
                    foreach (var relacion in listaRelaciones)
                    {
                        relacion.PrestamoId = prestamo.PrestamoId;
                        if (!PrestamoLibroBLL.Guardar(relacion))
                        {
                            relacionesGuardadas = false;
                        }
                    }
                }
                return relacionesGuardadas;
            }
        }

        public static Entidades.Prestamo Buscar(Expression<Func<Entidades.Prestamo, bool>> criterioBusqueda)
        {
            using (var repositorio = new DAL.Repositorio<Entidades.Prestamo>())
            {
                return repositorio.Buscar(criterioBusqueda);
            }
        }

        public static bool Eliminar(Entidades.Prestamo prestamo)
        {
            using (var repositorio = new DAL.Repositorio<Entidades.Prestamo>())
            {
                bool relacionesEliminadas = true;
                List<Entidades.PrestamoLibro> listaRelaciones = PrestamoLibroBLL.GetList(R => R.PrestamoId == prestamo.PrestamoId);
                foreach (var relacion in listaRelaciones)
                {
                    if (!PrestamoLibroBLL.Eliminar(relacion))
                    {
                        relacionesEliminadas = false;
                    }
                }
                if (relacionesEliminadas)
                {
                    return repositorio.Eliminar(prestamo);
                }
                return false;
            }
        }

        public static List<Entidades.Prestamo> GetList(Expression<Func<Entidades.Prestamo, bool>> criterioBusqueda)
        {
            using (var repositorio = new DAL.Repositorio<Entidades.Prestamo>())
            {
                return repositorio.GetList(criterioBusqueda);
            }
        }
        
        /*
        public static List<Entidades.Prestamo> GetListId(int id)
        {
            using (var repositorio = new DAL.Repositorio<Entidades.Prestamo>())
            {
                return repositorio.GetList(P => P.PrestamoId == id);
            }
        }
        */

        public static List<Entidades.Prestamo> GetListCliente(string nombreCliente)
        {
            Entidades.Cliente cliente = null;
            List<Entidades.Cliente> lista = ClienteBLL.GetList(C => C.Nombre == nombreCliente);
            if (lista.Count > 0)
            {
                cliente = lista.ElementAt(0);
            }
            if (cliente != null)
            {
                using (var repositorio = new DAL.Repositorio<Entidades.Prestamo>())
                {
                    return repositorio.GetList(P => P.ClienteId == cliente.ClienteId);
                }
            }
            else
            {
                return new List<Entidades.Prestamo>();
            }

        }

    }
}
