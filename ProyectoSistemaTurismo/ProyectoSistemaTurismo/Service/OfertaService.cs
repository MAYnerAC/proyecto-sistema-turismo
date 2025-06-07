using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProyectoSistemaTurismo.Interfaces;

//
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.ViewModels;

namespace ProyectoSistemaTurismo.Service
{
    /// <summary>
    /// Servicio para operaciones sobre ofertas turísticas, incluyendo relaciones con destinos, tipos y usuarios.
    /// </summary>
    public class OfertaService
    {
        private readonly IModeloSistema _db;

        public OfertaService(IModeloSistema db)
        {
            _db = db;
        }

        /// <summary>
        /// Lista todas las ofertas con sus relaciones.
        /// </summary>
        public List<Oferta> ObtenerTodos()
        {
            return _db.Oferta
                      .Include(o => o.Destino)
                      .Include(o => o.Usuario)
                      .Include(o => o.Tipo_Oferta)
                      .ToList();
        }



        /// <summary>
        /// Lista ofertas activas con sus relaciones.
        /// </summary>
        public List<Oferta> ObtenerTodosActivos()
        {
            return _db.Oferta
                      .Include(o => o.Destino)
                      .Include(o => o.Usuario)
                      .Include(o => o.Tipo_Oferta)
                      .Where(o => o.estado == "A")
                      .ToList();
        }

        /// <summary>
        /// Busca una oferta por su ID, incluyendo sus relaciones.
        /// </summary>
        public Oferta ObtenerPorId(int id)
        {
            return _db.Oferta
                      .Include(o => o.Destino)
                      .Include(o => o.Usuario)
                      .Include(o => o.Tipo_Oferta)
                      .SingleOrDefault(o => o.id_oferta == id);
        }

        /// <summary>
        /// Agrega una nueva oferta a la base de datos con valores predeterminados.
        /// </summary>
        public void Agregar(Oferta oferta)
        {
            oferta.estado = "A"; // Siempre activo por defecto
            oferta.verificado = "N"; // No verificado por defecto
            oferta.visible = "N"; // No visible por defecto
            oferta.fecha_creacion = DateTime.Now; // Fecha actual

            _db.Oferta.Add(oferta);
            _db.SaveChanges();
        }

        /// <summary>
        /// Actualiza los datos de una oferta existente.
        /// </summary>
        public void Actualizar(Oferta oferta)
        {
            _db.Entry(oferta).State = EntityState.Modified;
            _db.SaveChanges();
        }

        /// <summary>
        /// Elimina lógicamente una oferta marcándola como inactiva.
        /// </summary>
        public void Eliminar(int id)
        {
            var oferta = _db.Oferta.Find(id);
            if (oferta != null)
            {
                oferta.estado = "I"; // Marcar como inactivo
                oferta.fecha_baja = DateTime.Now; // Registrar la fecha de baja
                _db.SaveChanges();
            }
        }



        /*--------------------------------------------*/

        /// <summary>
        /// Obtiene ofertas activas creadas por un usuario específico.
        /// </summary>
        public List<Oferta> ObtenerPorUsuario(int usuarioId)
        {
            return _db.Oferta
                      .Include(o => o.Destino)
                      .Include(o => o.Usuario)
                      .Include(o => o.Tipo_Oferta)
                      .Where(o => o.id_usuario == usuarioId && o.estado == "A")
                      .ToList();
        }

        /// <summary>
        /// Lista ofertas visibles y activas filtradas por destino, como vista previa.
        /// </summary>
        public List<OfertaPrevia> ObtenerPorDestino(int destinoId)
        {
            return _db.Oferta
                      .Include(o => o.Destino)
                      .Include(o => o.Tipo_Oferta)
                      .Include(o => o.Galeria)
                      .Where(o => o.estado == "A" && o.visible == "S" && o.id_destino == destinoId) // Filtra por destino
                      .Select(o => new OfertaPrevia
                      {
                          id_oferta = o.id_oferta,
                          nombre = o.nombre,
                          descripcion = o.descripcion,
                          telefono = o.telefono,
                          id_tipo_oferta = o.id_tipo_oferta,
                          id_destino = o.id_destino,
                          tipo_oferta = o.Tipo_Oferta.nombre_tipo,
                          nombre_destino = o.Destino.nombre_destino,
                          imagen_url = o.Galeria.FirstOrDefault(g => g.estado == "A").url_imagen,
                          verificado = o.verificado
                      })
                      .OrderByDescending(x => x.verificado) // Ordenar por verificación
                      .ToList();
        }


        /// <summary>
        /// Lista ofertas filtradas por tipo.
        /// </summary>
        public List<Oferta> ObtenerPorTipoOferta(int tipoOfertaId)
        {
            return _db.Oferta
                      .Include(o => o.Destino)
                      .Include(o => o.Usuario)
                      .Include(o => o.Tipo_Oferta)
                      .Where(o => o.id_tipo_oferta == tipoOfertaId && o.estado == "A")
                      .ToList();
        }


        //ObtenerPorDestino()
        //FILTRO


        //ObtenerPorTipo()
        //FILTRO

        //ObtenerPorEtiqueta()
        //FILTRO


        /// <summary>
        /// Lista todas las ofertas activas y visibles como vista previa.
        /// </summary>
        public List<OfertaPrevia> ObtenerOfertasPrevias()
        {
            return _db.Oferta
                      .Include(o => o.Destino)
                      .Include(o => o.Tipo_Oferta)
                      .Include(o => o.Galeria)
                      .Where(o => o.estado == "A" && o.visible == "S")
                      .Select(o => new OfertaPrevia
                      {
                          id_oferta = o.id_oferta,
                          nombre = o.nombre,
                          descripcion = o.descripcion,
                          telefono = o.telefono,
                          id_tipo_oferta = o.id_tipo_oferta,
                          id_destino = o.id_destino,
                          tipo_oferta = o.Tipo_Oferta.nombre_tipo,
                          nombre_destino = o.Destino.nombre_destino,
                          imagen_url = o.Galeria.FirstOrDefault(g => g.estado == "A").url_imagen,
                          verificado = o.verificado
                      })
                      .OrderByDescending(x => x.verificado)
                      .ToList();
        }


        //Se deja de usar ---x---
        /// <summary>
        /// Devuelve los detalles de una oferta visible y activa por ID.
        /// </summary>
        public OfertaPrevia ObtenerDetalleOferta(int idOferta)
        {
            return _db.Oferta
                      .Include(o => o.Destino)
                      .Include(o => o.Tipo_Oferta)
                      .Include(o => o.Galeria)
                      .Where(o => o.id_oferta == idOferta && o.estado == "A" && o.visible == "S")
                      .Select(o => new OfertaPrevia
                      {
                          id_oferta = o.id_oferta,
                          nombre = o.nombre,
                          descripcion = o.descripcion,
                          telefono = o.telefono,
                          id_tipo_oferta = o.id_tipo_oferta,
                          id_destino = o.id_destino,
                          tipo_oferta = o.Tipo_Oferta.nombre_tipo,
                          nombre_destino = o.Destino.nombre_destino,
                          imagen_url = o.Galeria.FirstOrDefault(g => g.estado == "A").url_imagen,
                          verificado = o.verificado
                      })
                      .FirstOrDefault();
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



        //
    }
}