using ProyectoSistemaTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoSistemaTurismo.Service
{
    public class Preferencias_UsuarioService
    {

        public List<Preferencias_Usuario> ObtenerTodos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Preferencias_Usuario
                             .Include(pu => pu.Usuario)
                             .Include(pu => pu.Etiqueta)
                             .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //public List<Preferencias_Usuario> ObtenerActivos()
        //{
        //    try
        //    {
        //        using (var db = new ModeloSistema())
        //        {
        //            return db.Preferencias_Usuario
        //                     .Include(pu => pu.Usuario)
        //                     .Include(pu => pu.Etiqueta)
        //                     .Where(pu => pu.estado == "A")
        //                     .ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        public Preferencias_Usuario ObtenerPorId(int id)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Preferencias_Usuario
                             .Include(pu => pu.Usuario)
                             .Include(pu => pu.Etiqueta)
                             .SingleOrDefault(pu => pu.id_preferencia == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void Agregar(Preferencias_Usuario preferenciaUsuario)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Preferencias_Usuario.Add(preferenciaUsuario);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Actualizar(Preferencias_Usuario preferenciaUsuario)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Entry(preferenciaUsuario).State = EntityState.Modified;
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
                    var preferenciaUsuario = db.Preferencias_Usuario.Find(id);
                    if (preferenciaUsuario != null)
                    {
                        db.Preferencias_Usuario.Remove(preferenciaUsuario);
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


        public List<Preferencias_Usuario> ObtenerPorUsuario(int idUsuario)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Preferencias_Usuario
                             .Include(pu => pu.Etiqueta)
                             .Where(pu => pu.id_usuario == idUsuario)
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