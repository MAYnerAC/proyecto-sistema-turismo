using ProyectoSistemaTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoSistemaTurismo.Service
{
    public class Tipo_UsuarioService
    {

        public List<Tipo_Usuario> ObtenerTodos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Tipo_Usuario.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Tipo_Usuario> ObtenerTodosActivos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Tipo_Usuario
                             .Where(tu => tu.estado == "A") // Filtra solo los activos
                             .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Tipo_Usuario ObtenerPorId(int id)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Tipo_Usuario
                             .SingleOrDefault(tu => tu.id_tipo_usuario == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Agregar(Tipo_Usuario tipoUsuario)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    tipoUsuario.estado = "A"; // Siempre activo por defecto
                    db.Tipo_Usuario.Add(tipoUsuario);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Actualizar(Tipo_Usuario tipoUsuario)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Entry(tipoUsuario).State = EntityState.Modified;
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
                    var tipoUsuario = db.Tipo_Usuario.Find(id);
                    if (tipoUsuario != null)
                    {
                        tipoUsuario.estado = "I"; // Marcar como inactivo
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