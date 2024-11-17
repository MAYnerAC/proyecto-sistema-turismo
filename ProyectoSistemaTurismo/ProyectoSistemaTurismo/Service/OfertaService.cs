using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//
using ProyectoSistemaTurismo.Models;

namespace ProyectoSistemaTurismo.Service
{
    public class OfertaService
    {
        public List<Oferta> ObtenerTodos()
        {
            using (var db = new ModeloSistema())
            {
                return db.Oferta
                         .Include(o => o.Destino)
                         .Include(o => o.Usuario)
                         .Include(o => o.Tipo_Oferta)
                         .ToList();
            }
        }

        //public List<Oferta> ObtenerTodos()
        //{
        //    var query = new List<Oferta>();
        //    try
        //    {
        //        using (var db = new ModeloSistema())
        //        {
        //            query = db.Oferta.Include("Destino").Include("Usuario").Include("Tipo_Oferta").ToList();
        //        }
        //        return query;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public List<Oferta> ObtenerTodosActivos()
        {
            using (var db = new ModeloSistema())
            {
                return db.Oferta
                         .Include(o => o.Destino)
                         .Include(o => o.Usuario)
                         .Include(o => o.Tipo_Oferta)
                         .Where(o => o.estado == "A")
                         .ToList();
            }
        }

        public Oferta ObtenerPorId(int id)
        {
            using (var db = new ModeloSistema())
            {
                return db.Oferta
                         .Include(o => o.Destino)
                         .Include(o => o.Usuario)
                         .Include(o => o.Tipo_Oferta)
                         .SingleOrDefault(o => o.id_oferta == id);
            }
        }

        public void Agregar(Oferta oferta)
        {
            using (var db = new ModeloSistema())
            {
                oferta.estado = "A"; // Siempre activo por defecto
                oferta.verificado = "N"; // No verificado por defecto
                oferta.visible = "N"; // No visible por defecto
                oferta.fecha_creacion = DateTime.Now; // Fecha actual

                db.Oferta.Add(oferta);
                db.SaveChanges();
            }
        }

        public void Actualizar(Oferta oferta)
        {
            using (var db = new ModeloSistema())
            {
                db.Entry(oferta).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new ModeloSistema())
            {
                var oferta = db.Oferta.Find(id);
                if (oferta != null)
                {
                    oferta.estado = "I"; // Marcar como inactivo
                    oferta.fecha_baja = DateTime.Now; // Registrar la fecha de baja
                    db.SaveChanges();
                }
            }
        }







        //
    }
}