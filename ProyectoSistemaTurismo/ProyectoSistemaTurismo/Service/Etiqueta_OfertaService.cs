using ProyectoSistemaTurismo.Interfaces;
using ProyectoSistemaTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoSistemaTurismo.Service
{
    /// <summary>
    /// Servicio para operaciones CRUD sobre la relación Etiqueta_Oferta.
    /// </summary>
    public class Etiqueta_OfertaService
    {
        private readonly IModeloSistema _db;

        public Etiqueta_OfertaService(IModeloSistema db)
        {
            _db = db;
        }

        /// <summary>
        /// Lista todas las relaciones Etiqueta-Oferta, incluyendo datos relacionados.
        /// </summary>
        public List<Etiqueta_Oferta> ObtenerTodos()
        {
            return _db.Etiqueta_Oferta
                      .Include(e => e.Oferta)
                      .Include(e => e.Etiqueta)
                      .ToList();
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

        /// <summary>
        /// Busca una relación Etiqueta-Oferta por su ID, con navegación.
        /// </summary>
        public Etiqueta_Oferta ObtenerPorId(int id)
        {
            return _db.Etiqueta_Oferta
                      .Include(e => e.Oferta)
                      .Include(e => e.Etiqueta)
                      .SingleOrDefault(e => e.id_etiqueta_oferta == id);
        }

        /// <summary>
        /// Agrega una nueva relación Etiqueta-Oferta.
        /// </summary>
        public void Agregar(Etiqueta_Oferta etiquetaOferta)
        {
            _db.Etiqueta_Oferta.Add(etiquetaOferta);
            _db.SaveChanges();
        }

        /// <summary>
        /// Actualiza una relación Etiqueta-Oferta.
        /// </summary>
        public void Actualizar(Etiqueta_Oferta etiquetaOferta)
        {
            _db.Entry(etiquetaOferta).State = EntityState.Modified;
            _db.SaveChanges();
        }

        /// <summary>
        /// Elimina una relación Etiqueta-Oferta de la base de datos.
        /// </summary>
        public void Eliminar(int id)
        {
            var etiquetaOferta = _db.Etiqueta_Oferta.Find(id);
            if (etiquetaOferta != null)
            {
                _db.Etiqueta_Oferta.Remove(etiquetaOferta);
                _db.SaveChanges();
            }
        }


        /*--------------------------------------------*/

        /// <summary>
        /// Lista todas las relaciones Etiqueta-Oferta asociadas a una oferta específica.
        /// </summary>
        public List<Etiqueta_Oferta> ObtenerPorOferta(int idOferta)
        {
            return _db.Etiqueta_Oferta
                      .Include(e => e.Oferta)
                      .Include(e => e.Etiqueta)
                      .Where(e => e.id_oferta == idOferta)
                      .ToList();
        }







        //
    }
}