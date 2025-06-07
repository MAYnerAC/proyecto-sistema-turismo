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
    /// Servicio para gestionar operaciones CRUD sobre la galería de imágenes.
    /// Incluye métodos para filtrar por estado, usuario y oferta.
    /// </summary>
    public class GaleriaService
    {

        private readonly IModeloSistema _db;

        public GaleriaService(IModeloSistema db)
        {
            _db = db;
        }

        /// <summary>
        /// Obtiene todas las imágenes de la galería, incluyendo su oferta relacionada.
        /// </summary>
        public List<Galeria> ObtenerTodos()
        {
            return _db.Galeria
                      .Include(g => g.Oferta)
                      .ToList();
        }

        /// <summary>
        /// Obtiene solo las imágenes activas.
        /// </summary>
        public List<Galeria> ObtenerTodosActivos()
        {
            return _db.Galeria
                      .Include(g => g.Oferta)
                      .Where(g => g.estado == "A")
                      .ToList();
        }

        /// <summary>
        /// Busca una imagen de la galería por su ID, incluyendo la oferta.
        /// </summary>
        public Galeria ObtenerPorId(int id)
        {
            return _db.Galeria
                      .Include(g => g.Oferta)
                      .SingleOrDefault(g => g.id_imagen == id);
        }

        /// <summary>
        /// Agrega una nueva imagen a la galería.
        /// </summary>
        public void Agregar(Galeria galeria)
        {
            galeria.estado = "A"; // Siempre activo por defecto
            galeria.fecha_subida = DateTime.Now; // Fecha actual

            _db.Galeria.Add(galeria);
            _db.SaveChanges();
        }

        /// <summary>
        /// Actualiza los datos de una imagen existente.
        /// </summary>
        public void Actualizar(Galeria galeria)
        {
            _db.Entry(galeria).State = EntityState.Modified;
            _db.SaveChanges();
        }

        /// <summary>
        /// Elimina lógicamente una imagen marcándola como inactiva.
        /// </summary>
        public void Eliminar(int id)
        {
            var galeria = _db.Galeria.Find(id);
            if (galeria != null)
            {
                galeria.estado = "I"; // Marcar como inactivo
                _db.SaveChanges();
            }
        }


        /*--------------------------------------------*/

        /// <summary>
        /// Obtiene todas las imágenes activas asociadas a un usuario específico.
        /// </summary>
        public List<Galeria> ObtenerPorUsuario(int idUsuario)
        {
            return _db.Galeria
                      .Include(g => g.Oferta)
                      .Where(g => g.Oferta.id_usuario == idUsuario && g.estado == "A")
                      .ToList();
        }


        /// <summary>
        /// Obtiene todas las imágenes activas de una oferta específica.
        /// </summary>
        public List<Galeria> ObtenerPorOferta(int idOferta)
        {
            return _db.Galeria
                      .Include(g => g.Oferta)
                      .Where(g => g.id_oferta == idOferta && g.estado == "A")
                      .ToList();
        }







        //
    }
}