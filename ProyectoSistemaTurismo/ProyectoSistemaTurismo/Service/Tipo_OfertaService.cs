using ProyectoSistemaTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoSistemaTurismo.Service
{
    public class Tipo_OfertaService
    {

        public List<Tipo_Oferta> ObtenerTodos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Tipo_Oferta.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Tipo_Oferta> ObtenerTodosActivos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Tipo_Oferta.Where(t => t.estado == "A").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Tipo_Oferta ObtenerPorId(int id)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Tipo_Oferta.SingleOrDefault(t => t.id_tipo_oferta == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Agregar(Tipo_Oferta tipoOferta)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    tipoOferta.estado = "A";
                    db.Tipo_Oferta.Add(tipoOferta);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Actualizar(Tipo_Oferta tipoOferta)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Entry(tipoOferta).State = EntityState.Modified;
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
                    var tipoOferta = db.Tipo_Oferta.Find(id);
                    if (tipoOferta != null)
                    {
                        tipoOferta.estado = "I";
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