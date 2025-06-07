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
    /// Servicio para operaciones CRUD sobre fotos asociadas a comentarios.
    /// </summary>
    public class Foto_ComentarioService
    {

        private readonly IModeloSistema _db;

        public Foto_ComentarioService(IModeloSistema db)
        {
            _db = db;
        }

        /// <summary>
        /// Lista todas las fotos de comentarios, incluyendo su comentario asociado.
        /// </summary>
        public List<Foto_Comentario> ObtenerTodos()
        {
            return _db.Foto_Comentario
                      .Include(fc => fc.Comentario)
                      .ToList();
        }

        /// <summary>
        /// Lista todas las fotos activas.
        /// </summary>
        public List<Foto_Comentario> ObtenerTodosActivos()
        {
            return _db.Foto_Comentario
                      .Include(fc => fc.Comentario)
                      .Where(fc => fc.estado == "A")
                      .ToList();
        }

        /// <summary>
        /// Busca una foto de comentario por ID, incluyendo el comentario.
        /// </summary>
        public Foto_Comentario ObtenerPorId(int id)
        {
            return _db.Foto_Comentario
                      .Include(fc => fc.Comentario)
                      .SingleOrDefault(fc => fc.id_foto == id);
        }

        /// <summary>
        /// Agrega una nueva foto de comentario.
        /// </summary>
        public void Agregar(Foto_Comentario fotoComentario)
        {
            fotoComentario.estado = "A"; // Siempre activo por defecto
            fotoComentario.fecha_subida = DateTime.Now; // Fecha actual

            _db.Foto_Comentario.Add(fotoComentario);
            _db.SaveChanges();
        }

        /// <summary>
        /// Actualiza los datos de una foto de comentario.
        /// </summary>
        public void Actualizar(Foto_Comentario fotoComentario)
        {
            _db.Entry(fotoComentario).State = EntityState.Modified;
            _db.SaveChanges();
        }

        /// <summary>
        /// Elimina lógicamente una foto de comentario (marca como inactivo).
        /// </summary>
        public void Eliminar(int id)
        {
            var fotoComentario = _db.Foto_Comentario.Find(id);
            if (fotoComentario != null)
            {
                fotoComentario.estado = "I"; // Marcar como inactivo
                _db.SaveChanges();
            }
        }




        /*--------------------------------------------*/

        /// <summary>
        /// Lista todas las fotos activas de un comentario específico.
        /// </summary>
        public List<Foto_Comentario> ObtenerPorComentario(int comentarioId)
        {
            return _db.Foto_Comentario
                      .Include(f => f.Comentario)
                      .Where(f => f.id_comentario == comentarioId && f.estado == "A")
                      .ToList();
        }




        //
    }
}