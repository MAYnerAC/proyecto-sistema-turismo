using ProyectoSistemaTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoSistemaTurismo.Service
{
    public class EtiquetaService
    {

        public List<Etiqueta> ObtenerTodos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Etiqueta.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Etiqueta> ObtenerTodosActivos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Etiqueta
                             .Where(e => e.estado == "A") // Filtrar solo los activos
                             .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Etiqueta ObtenerPorId(int id)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Etiqueta
                             .SingleOrDefault(e => e.id_etiqueta == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Agregar(Etiqueta etiqueta)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    etiqueta.estado = "A"; // Siempre activo por defecto
                    db.Etiqueta.Add(etiqueta);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Actualizar(Etiqueta etiqueta)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Entry(etiqueta).State = EntityState.Modified;
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
                    var etiqueta = db.Etiqueta.Find(id);
                    if (etiqueta != null)
                    {
                        etiqueta.estado = "I"; // Marcar como inactivo
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