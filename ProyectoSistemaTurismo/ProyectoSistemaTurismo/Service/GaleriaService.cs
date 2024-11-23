using ProyectoSistemaTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoSistemaTurismo.Service
{
    public class GaleriaService
    {
        public List<Galeria> ObtenerTodos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Galeria
                             .Include(g => g.Oferta)
                             .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Galeria> ObtenerTodosActivos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Galeria
                             .Include(g => g.Oferta)
                             .Where(g => g.estado == "A")
                             .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Galeria ObtenerPorId(int id)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Galeria
                             .Include(g => g.Oferta)
                             .SingleOrDefault(g => g.id_imagen == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Agregar(Galeria galeria)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    galeria.estado = "A"; // Siempre activo por defecto
                    galeria.fecha_subida = DateTime.Now; // Fecha actual

                    db.Galeria.Add(galeria);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Actualizar(Galeria galeria)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Entry(galeria).State = EntityState.Modified;
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
                    var galeria = db.Galeria.Find(id);
                    if (galeria != null)
                    {
                        galeria.estado = "I"; // Marcar como inactivo
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