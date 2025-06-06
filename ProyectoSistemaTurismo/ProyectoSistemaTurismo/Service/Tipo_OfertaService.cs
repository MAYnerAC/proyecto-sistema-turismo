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
    /// Servicio para gestionar operaciones sobre tipos de oferta turística.
    /// Incluye métodos CRUD y filtros por estado.
    /// </summary>
    public class Tipo_OfertaService
    {

        private readonly IModeloSistema _db;

        public Tipo_OfertaService(IModeloSistema db)
        {
            _db = db;
        }

        /// <summary>
        /// Obtiene todos los tipos de oferta registrados.
        /// </summary>
        /// <returns>Lista de Tipo_Oferta</returns>
        public List<Tipo_Oferta> ObtenerTodos()
        {
            return _db.Tipo_Oferta.ToList();
        }

        /// <summary>
        /// Obtiene solo los tipos de oferta con estado activo ("A").
        /// </summary>
        /// <returns>Lista de Tipo_Oferta activos</returns>
        public List<Tipo_Oferta> ObtenerTodosActivos()
        {
            return _db.Tipo_Oferta.Where(t => t.estado == "A").ToList();
        }

        /// <summary>
        /// Busca un tipo de oferta por su ID.
        /// </summary>
        /// <param name="id">ID del tipo de oferta</param>
        /// <returns>Tipo_Oferta encontrado o null</returns>
        public Tipo_Oferta ObtenerPorId(int id)
        {
            return _db.Tipo_Oferta.SingleOrDefault(t => t.id_tipo_oferta == id);
        }

        /// <summary>
        /// Agrega un nuevo tipo de oferta con estado activo por defecto.
        /// </summary>
        /// <param name="tipoOferta">Objeto Tipo_Oferta a agregar</param>
        public void Agregar(Tipo_Oferta tipoOferta)
        {
            tipoOferta.estado = "A";
            _db.Tipo_Oferta.Add(tipoOferta);
            _db.SaveChanges();
        }


        /// <summary>
        /// Actualiza los datos de un tipo de oferta existente.
        /// </summary>
        /// <param name="tipoOferta">Objeto actualizado</param>
        public void Actualizar(Tipo_Oferta tipoOferta)
        {
            _db.Entry(tipoOferta).State = EntityState.Modified;
            _db.SaveChanges();
        }

        /// <summary>
        /// Elimina lógicamente un tipo de oferta cambiando su estado a "I".
        /// </summary>
        /// <param name="id">ID del tipo de oferta</param>
        public void Eliminar(int id)
        {
            var tipoOferta = _db.Tipo_Oferta.Find(id);
            if (tipoOferta != null)
            {
                tipoOferta.estado = "I";
                _db.SaveChanges();
            }
        }





        //
    }
}