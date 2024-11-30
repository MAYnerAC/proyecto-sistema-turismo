using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//
using ProyectoSistemaTurismo.Models;

namespace ProyectoSistemaTurismo.Service
{
    public class ComentarioService
    {

        public List<Comentario> ObtenerTodos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Comentario
                             .Include(c => c.Oferta)
                             .Include(c => c.Usuario)
                             .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Comentario> ObtenerTodosActivos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Comentario
                             .Include(c => c.Oferta)
                             .Include(c => c.Usuario)
                             .Where(c => c.estado == "A")
                             .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Comentario ObtenerPorId(int id)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Comentario
                             .Include(c => c.Oferta)
                             .Include(c => c.Usuario)
                             .SingleOrDefault(c => c.id_comentario == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Agregar(Comentario comentario)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    comentario.estado = "A"; // Siempre activo por defecto
                    comentario.fecha_comentario = DateTime.Now; // Fecha actual

                    db.Comentario.Add(comentario);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Actualizar(Comentario comentario)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Entry(comentario).State = EntityState.Modified;
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
                    var comentario = db.Comentario.Find(id);
                    if (comentario != null)
                    {
                        comentario.estado = "I"; // Marcar como inactivo
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

        public List<Comentario> ObtenerPorOferta(int idOferta)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Comentario
                             .Include(c => c.Oferta)
                             .Include(c => c.Usuario)
                             .Where(c => c.id_oferta == idOferta && c.estado == "A")
                             .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }






        //ObtenerPorUsuario()
        //AUN






        //
    }
}