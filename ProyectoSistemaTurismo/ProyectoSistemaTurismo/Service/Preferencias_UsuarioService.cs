using ProyectoSistemaTurismo.Interfaces;
using ProyectoSistemaTurismo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoSistemaTurismo.Service
{
    /// <summary>
    /// Servicio para gestionar las preferencias de los usuarios con operaciones CRUD.
    /// Incluye relaciones con Usuario y Etiqueta.
    /// </summary>
    public class Preferencias_UsuarioService
    {

        private readonly IModeloSistema _db;

        public Preferencias_UsuarioService(IModeloSistema db)
        {
            _db = db;
        }

        /// <summary>
        /// Obtiene todas las preferencias de usuario, incluyendo datos relacionados.
        /// </summary>
        /// <returns>Lista de Preferencias_Usuario</returns>
        public List<Preferencias_Usuario> ObtenerTodos()
        {
            return _db.Preferencias_Usuario
                      .Include(pu => pu.Usuario)
                      .Include(pu => pu.Etiqueta)
                      .ToList();
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


        /// <summary>
        /// Busca una preferencia de usuario por su ID, con relaciones.
        /// </summary>
        /// <param name="id">ID de la preferencia</param>
        /// <returns>Preferencias_Usuario encontrada o null</returns>
        public Preferencias_Usuario ObtenerPorId(int id)
        {
            return _db.Preferencias_Usuario
                      .Include(pu => pu.Usuario)
                      .Include(pu => pu.Etiqueta)
                      .SingleOrDefault(pu => pu.id_preferencia == id);
        }


        /// <summary>
        /// Agrega una nueva preferencia de usuario a la base de datos.
        /// </summary>
        /// <param name="preferenciaUsuario">Objeto a registrar</param>
        public void Agregar(Preferencias_Usuario preferenciaUsuario)
        {
            _db.Preferencias_Usuario.Add(preferenciaUsuario);
            _db.SaveChanges();
        }

        /// <summary>
        /// Actualiza los datos de una preferencia de usuario existente.
        /// </summary>
        /// <param name="preferenciaUsuario">Objeto actualizado</param>
        public void Actualizar(Preferencias_Usuario preferenciaUsuario)
        {
            _db.Entry(preferenciaUsuario).State = EntityState.Modified;
            _db.SaveChanges();
        }


        /// <summary>
        /// Elimina una preferencia de usuario de la base de datos.
        /// </summary>
        /// <param name="id">ID de la preferencia</param>
        public void Eliminar(int id)
        {
            var preferenciaUsuario = _db.Preferencias_Usuario.Find(id);
            if (preferenciaUsuario != null)
            {
                _db.Preferencias_Usuario.Remove(preferenciaUsuario);
                _db.SaveChanges();
            }
        }



        /*--------------------------------------------*/


        /// <summary>
        /// Obtiene todas las preferencias de un usuario específico, incluyendo la etiqueta.
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <returns>Lista de Preferencias_Usuario</returns>
        public List<Preferencias_Usuario> ObtenerPorUsuario(int idUsuario)
        {
            return _db.Preferencias_Usuario
                      .Include(pu => pu.Etiqueta)
                      .Where(pu => pu.id_usuario == idUsuario)
                      .ToList();
        }









        //
    }
}