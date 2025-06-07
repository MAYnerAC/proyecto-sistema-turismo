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
    /// Servicio para operaciones CRUD sobre etiquetas.
    /// </summary>
    public class EtiquetaService
    {

        private readonly IModeloSistema _db;

        public EtiquetaService(IModeloSistema db)
        {
            _db = db;
        }


        /// <summary>
        /// Lista todas las etiquetas registradas.
        /// </summary>
        public List<Etiqueta> ObtenerTodos()
        {
            return _db.Etiqueta.ToList();
        }

        /// <summary>
        /// Lista solo las etiquetas activas.
        /// </summary>
        public List<Etiqueta> ObtenerTodosActivos()
        {
            return _db.Etiqueta
                      .Where(e => e.estado == "A") // Filtrar solo los activos
                      .ToList();
        }

        /// <summary>
        /// Busca una etiqueta por su ID.
        /// </summary>
        public Etiqueta ObtenerPorId(int id)
        {
            return _db.Etiqueta
                      .SingleOrDefault(e => e.id_etiqueta == id);
        }

        /// <summary>
        /// Agrega una nueva etiqueta, siempre como activa.
        /// </summary>
        public void Agregar(Etiqueta etiqueta)
        {
            etiqueta.estado = "A"; // Siempre activo por defecto
            _db.Etiqueta.Add(etiqueta);
            _db.SaveChanges();
        }

        /// <summary>
        /// Actualiza los datos de una etiqueta.
        /// </summary>
        public void Actualizar(Etiqueta etiqueta)
        {
            _db.Entry(etiqueta).State = EntityState.Modified;
            _db.SaveChanges();
        }

        /// <summary>
        /// Elimina lógicamente una etiqueta (cambia estado a inactivo).
        /// </summary>
        public void Eliminar(int id)
        {
            var etiqueta = _db.Etiqueta.Find(id);
            if (etiqueta != null)
            {
                etiqueta.estado = "I"; // Marcar como inactivo
                _db.SaveChanges();
            }
        }

        /*--------------------------------------------*/







        //
    }
}