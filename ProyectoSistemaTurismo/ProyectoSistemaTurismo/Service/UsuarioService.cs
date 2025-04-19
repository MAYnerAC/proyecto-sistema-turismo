using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//
using ProyectoSistemaTurismo.Models;

namespace ProyectoSistemaTurismo.Service
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con los usuarios.
    /// Incluye métodos para CRUD y filtrado por estado.
    /// </summary>
    public class UsuarioService
    {
        /// <summary>
        /// Obtiene la lista completa de usuarios, incluyendo su tipo de usuario.
        /// </summary>
        /// <returns>Lista de objetos Usuario</returns>
        public List<Usuario> ObtenerTodos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Usuario.Include(u => u.Tipo_Usuario).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene solo los usuarios con estado "A" (activos).
        /// </summary>
        /// <returns>Lista de usuarios activos</returns>
        public List<Usuario> ObtenerTodosActivos()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Usuario
                             .Include(u => u.Tipo_Usuario)
                             .Where(u => u.estado == "A")
                             .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca un usuario por su ID, incluyendo su tipo.
        /// </summary>
        /// <param name="id">ID del usuario</param>
        /// <returns>Objeto Usuario o null si no se encuentra</returns>
        public Usuario ObtenerPorId(int id)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Usuario
                             .Include(u => u.Tipo_Usuario)
                             .SingleOrDefault(u => u.id_usuario == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Agrega un nuevo usuario a la base de datos.
        /// Se asigna estado "A" por defecto y fecha actual.
        /// </summary>
        /// <param name="usuario">Usuario a agregar</param>
        public void Agregar(Usuario usuario)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    usuario.estado = "A"; // Estado activo por defecto
                    usuario.fecha_registro = DateTime.Now; // Fecha de registro actual
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Actualiza la información de un usuario existente.
        /// </summary>
        /// <param name="usuario">Usuario con datos actualizados</param>
        public void Actualizar(Usuario usuario)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina lógicamente un usuario cambiando su estado a "I".
        /// </summary>
        /// <param name="id">ID del usuario a eliminar</param>
        public void Eliminar(int id)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    var usuario = db.Usuario.Find(id);
                    if (usuario != null)
                    {
                        usuario.estado = "I";
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*------------------------------------------------------------------------------------------------*/


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