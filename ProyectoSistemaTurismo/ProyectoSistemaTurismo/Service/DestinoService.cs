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
    /// Servicio para gestionar operaciones CRUD sobre destinos turísticos.
    /// </summary>
    public class DestinoService
    {
        private readonly IModeloSistema _db;

        public DestinoService(IModeloSistema db)
        {
            _db = db;
        }

        /// <summary>
        /// Lista todos los destinos registrados.
        /// </summary>
        public List<Destino> ObtenerTodos()
        {
            return _db.Destino.ToList();
        }

        /// <summary>
        /// Lista solo los destinos activos.
        /// </summary>
        public List<Destino> ObtenerTodosActivos()
        {
            return _db.Destino
                      .Where(d => d.estado == "A")
                      .ToList();
        }

        /// <summary>
        /// Busca un destino por su ID.
        /// </summary>
        public Destino ObtenerPorId(int id)
        {
            return _db.Destino
                      .SingleOrDefault(d => d.id_destino == id);
        }

        /// <summary>
        /// Agrega un nuevo destino (activo por defecto).
        /// </summary>
        public void Agregar(Destino destino)
        {
            destino.estado = "A";
            _db.Destino.Add(destino);
            _db.SaveChanges();
        }

        /// <summary>
        /// Actualiza los datos de un destino.
        /// </summary>
        public void Actualizar(Destino destino)
        {
            _db.Entry(destino).State = EntityState.Modified;
            _db.SaveChanges();
        }


        /// <summary>
        /// Elimina lógicamente un destino cambiando su estado a inactivo.
        /// </summary>
        public void Eliminar(int id)
        {
            var destino = _db.Destino.Find(id);
            if (destino != null)
            {
                destino.estado = "I";
                _db.SaveChanges();
            }
        }


        //
    }
}