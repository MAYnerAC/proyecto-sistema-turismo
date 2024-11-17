using ProyectoSistemaTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoSistemaTurismo.Service
{
    public class DestinoService
    {

        public List<Destino> ObtenerTodos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Destino.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Destino> ObtenerTodosActivos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Destino.Where(d => d.estado == "A").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Destino ObtenerPorId(int id)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Destino.SingleOrDefault(d => d.id_destino == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Agregar(Destino destino)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    destino.estado = "A";
                    db.Destino.Add(destino);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Actualizar(Destino destino)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Entry(destino).State = EntityState.Modified;
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
                    var destino = db.Destino.Find(id);
                    if (destino != null)
                    {
                        destino.estado = "I";
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