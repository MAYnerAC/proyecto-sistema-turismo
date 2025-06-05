using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//
using ProyectoSistemaTurismo.Interfaces;
using ProyectoSistemaTurismo.Models;

namespace ProyectoSistemaTurismo.Service
{
    public class Tipo_UsuarioService
    {

        private readonly IModeloSistema _db;

        // Constructor
        public Tipo_UsuarioService(IModeloSistema db)
        {
            _db = db;
        }

        public List<Tipo_Usuario> ObtenerTodos()
        {
            return _db.Tipo_Usuario.ToList();
        }

        public List<Tipo_Usuario> ObtenerTodosActivos()
        {
            return _db.Tipo_Usuario
                      .Where(tu => tu.estado == "A") // Filtra solo los activos
                      .ToList();
        }

        public Tipo_Usuario ObtenerPorId(int id)
        {
            return _db.Tipo_Usuario
                      .SingleOrDefault(tu => tu.id_tipo_usuario == id);
        }


        public void Agregar(Tipo_Usuario tipoUsuario)
        {
            tipoUsuario.estado = "A"; // Siempre activo por defecto
            _db.Tipo_Usuario.Add(tipoUsuario);
            _db.SaveChanges();
        }

        public void Actualizar(Tipo_Usuario tipoUsuario)
        {
            _db.Entry(tipoUsuario).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var tipoUsuario = _db.Tipo_Usuario.Find(id);
            if (tipoUsuario != null)
            {
                tipoUsuario.estado = "I"; // Marcar como inactivo
                _db.SaveChanges();
            }
        }

        //
    }
}