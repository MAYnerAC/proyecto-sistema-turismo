using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProyectoSistemaTurismo.Interfaces;

//
using ProyectoSistemaTurismo.Models;

namespace ProyectoSistemaTurismo.Service
{
    /// <summary>
    /// Servicio para operaciones CRUD sobre comentarios.
    /// Incluye relaciones con oferta y usuario.
    /// </summary>
    public class ComentarioService
    {
        private readonly IModeloSistema _db;

        public ComentarioService(IModeloSistema db)
        {
            _db = db;
        }

        /// <summary>
        /// Lista todos los comentarios, incluyendo oferta y usuario.
        /// </summary>
        public List<Comentario> ObtenerTodos()
        {
            return _db.Comentario
                      .Include(c => c.Oferta)
                      .Include(c => c.Usuario)
                      .ToList();
        }

        /// <summary>
        /// Lista los comentarios activos, incluyendo oferta y usuario.
        /// </summary>
        public List<Comentario> ObtenerTodosActivos()
        {
            return _db.Comentario
                      .Include(c => c.Oferta)
                      .Include(c => c.Usuario)
                      .Where(c => c.estado == "A")
                      .ToList();
        }

        /// <summary>
        /// Busca un comentario por su ID, incluyendo relaciones.
        /// </summary>
        public Comentario ObtenerPorId(int id)
        {
            return _db.Comentario
                      .Include(c => c.Oferta)
                      .Include(c => c.Usuario)
                      .SingleOrDefault(c => c.id_comentario == id);
        }

        /// <summary>
        /// Agrega un nuevo comentario (activo y con fecha actual).
        /// </summary>
        public void Agregar(Comentario comentario)
        {
            comentario.estado = "A"; // Siempre activo por defecto
            comentario.fecha_comentario = DateTime.Now; // Fecha actual
            _db.Comentario.Add(comentario);
            _db.SaveChanges();
        }

        /// <summary>
        /// Actualiza los datos de un comentario.
        /// </summary>
        public void Actualizar(Comentario comentario)
        {
            _db.Entry(comentario).State = EntityState.Modified;
            _db.SaveChanges();
        }

        /// <summary>
        /// Elimina lógicamente un comentario (cambia su estado a inactivo).
        /// </summary>
        public void Eliminar(int id)
        {
            var comentario = _db.Comentario.Find(id);
            if (comentario != null)
            {
                comentario.estado = "I"; // Marcar como inactivo
                _db.SaveChanges();
            }
        }

        /*--------------------------------------------*/

        /// <summary>
        /// Lista los comentarios activos de una oferta específica, con sus relaciones.
        /// </summary>
        public List<Comentario> ObtenerPorOferta(int idOferta)
        {
            return _db.Comentario
                      .Include(c => c.Oferta)
                      .Include(c => c.Usuario)
                      .Where(c => c.id_oferta == idOferta && c.estado == "A")
                      .ToList();
        }






        //ObtenerPorUsuario()
        //AUN






        //
    }
}