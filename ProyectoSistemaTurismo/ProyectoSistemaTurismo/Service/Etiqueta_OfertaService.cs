using ProyectoSistemaTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoSistemaTurismo.Service
{
    public class Etiqueta_OfertaService
    {

        public List<Etiqueta_Oferta> ObtenerTodos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Etiqueta_Oferta
                             .Include(e => e.Oferta)
                             .Include(e => e.Etiqueta)
                             .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public List<Etiqueta_Oferta> ObtenerTodosActivos()
        //{
        //    try
        //    {
        //        using (var db = new ModeloSistema())
        //        {
        //            return db.Etiqueta_Oferta
        //                     .Include(e => e.Oferta)
        //                     .Include(e => e.Etiqueta)
        //                     .Where(e => e.Oferta.estado == "A")
        //                     .ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public Etiqueta_Oferta ObtenerPorId(int id)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Etiqueta_Oferta
                             .Include(e => e.Oferta)
                             .Include(e => e.Etiqueta)
                             .SingleOrDefault(e => e.id_etiqueta_oferta == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Agregar(Etiqueta_Oferta etiquetaOferta)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Etiqueta_Oferta.Add(etiquetaOferta);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Actualizar(Etiqueta_Oferta etiquetaOferta)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Entry(etiquetaOferta).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    var etiquetaOferta = db.Etiqueta_Oferta.Find(id);
                    if (etiquetaOferta != null)
                    {
                        db.Etiqueta_Oferta.Remove(etiquetaOferta);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }






        //
    }
}