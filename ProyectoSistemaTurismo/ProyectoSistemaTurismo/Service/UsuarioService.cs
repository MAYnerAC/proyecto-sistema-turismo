using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//
using ProyectoSistemaTurismo.Models;

namespace ProyectoSistemaTurismo.Service
{
    public class UsuarioService
    {
        /*
        private readonly ModeloSistema db;

        public UsuarioService(ModeloSistema context)
        {
            db = context;
        }


        public List<Usuario> Listar()
        {
            var usuarios = new List<Usuario>();
            try
            {
                usuarios = db.Usuario.Include("Tipo_Usuario").ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return usuarios;
        }

        public Usuario Obtener(int id)
        {
            var usuario = new Usuario();
            try
            {
                usuario = db.Usuario.Include("Tipo_Usuario")
                                    .Where(x => x.id_usuario == id)
                                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }

            return usuario;
        }

        public List<Usuario> Buscar(string criterio)
        {
            var usuarios = new List<Usuario>();
            try
            {
                usuarios = db.Usuario.Include("Tipo_Usuario")
                                     .Where(x => x.nombre.Contains(criterio) ||
                                                 x.apellido.Contains(criterio) ||
                                                 x.email.Contains(criterio) ||
                                                 x.Tipo_Usuario.nombre_tipo.Contains(criterio))
                                     .ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return usuarios;
        }

        public void Guardar(Usuario usuario)
        {
            try
            {
                if (usuario.id_usuario > 0)
                {
                    db.Entry(usuario).State = EntityState.Modified; // existe
                }
                else
                {
                    db.Entry(usuario).State = EntityState.Added; // nuevo registro
                }
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar(Usuario usuario)
        {
            try
            {
                db.Entry(usuario).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Autenticar(string email, string contrasena)
        {
            return db.Usuario
                     .Any(x => x.email == email && x.contrasena == contrasena);
        }

        public Usuario ObtenerDatos(string correo)
        {
            var usuario = new Usuario();
            try
            {
                usuario = db.Usuario.Include("Tipo_Usuario")
                                    .Where(x => x.email == correo)
                                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }


        */

        //
    }
}