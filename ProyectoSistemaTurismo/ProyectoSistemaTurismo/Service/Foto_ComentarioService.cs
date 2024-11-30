using ProyectoSistemaTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoSistemaTurismo.Service
{
    public class Foto_ComentarioService
    {
        public List<Foto_Comentario> ObtenerTodos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Foto_Comentario
                             .Include(fc => fc.Comentario)
                             .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Foto_Comentario> ObtenerTodosActivos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Foto_Comentario
                             .Include(fc => fc.Comentario)
                             .Where(fc => fc.estado == "A")
                             .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Foto_Comentario ObtenerPorId(int id)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Foto_Comentario
                             .Include(fc => fc.Comentario)
                             .SingleOrDefault(fc => fc.id_foto == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Agregar(Foto_Comentario fotoComentario)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    fotoComentario.estado = "A"; // Siempre activo por defecto
                    fotoComentario.fecha_subida = DateTime.Now; // Fecha actual

                    db.Foto_Comentario.Add(fotoComentario);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Actualizar(Foto_Comentario fotoComentario)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Entry(fotoComentario).State = EntityState.Modified;
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
                    var fotoComentario = db.Foto_Comentario.Find(id);
                    if (fotoComentario != null)
                    {
                        fotoComentario.estado = "I"; // Marcar como inactivo
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        /*--------------------------------------------*/

        public List<Foto_Comentario> ObtenerPorComentario(int comentarioId)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Foto_Comentario
                             .Include(f => f.Comentario)
                             .Where(f => f.id_comentario == comentarioId && f.estado == "A")
                             .ToList();
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