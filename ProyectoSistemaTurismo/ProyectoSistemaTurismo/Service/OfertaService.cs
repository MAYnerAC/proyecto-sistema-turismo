using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.ViewModels;

namespace ProyectoSistemaTurismo.Service
{
    public class OfertaService
    {
        public List<Oferta> ObtenerTodos()
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }



        public List<Oferta> ObtenerTodosActivos()
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        public Oferta ObtenerPorId(int id)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        public void Agregar(Oferta oferta)
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        public void Actualizar(Oferta oferta)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    db.Entry(oferta).State = EntityState.Modified;
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
                    var oferta = db.Oferta.Find(id);
                    if (oferta != null)
                    {
                        oferta.estado = "I"; // Marcar como inactivo
                        oferta.fecha_baja = DateTime.Now; // Registrar la fecha de baja
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

        public List<Oferta> ObtenerPorUsuario(int usuarioId)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Oferta
                             .Include(o => o.Destino)
                             .Include(o => o.Usuario)
                             .Include(o => o.Tipo_Oferta)
                             .Where(o => o.id_usuario == usuarioId && o.estado == "A")
                             .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<OfertaPrevia> ObtenerPorDestino(int destinoId)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Oferta
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
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Oferta> ObtenerPorTipoOferta(int tipoOfertaId)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Oferta
                             .Include(o => o.Destino)
                             .Include(o => o.Usuario)
                             .Include(o => o.Tipo_Oferta)
                             .Where(o => o.id_tipo_oferta == tipoOfertaId && o.estado == "A")
                             .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //ObtenerPorDestino()
        //FILTRO


        //ObtenerPorTipo()
        //FILTRO

        //ObtenerPorEtiqueta()
        //FILTRO


        public List<OfertaPrevia> ObtenerOfertasPrevias()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    return db.Oferta
                        .Include(o => o.Destino)
                        .Include(o => o.Tipo_Oferta)
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
                        .OrderByDescending(x => x.verificado)// == "N"
                        .ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        //Se deja de usar ---x---
        public OfertaPrevia ObtenerDetalleOferta(int idOferta)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    var oferta = db.Oferta
                        .Include(o => o.Destino)
                        .Include(o => o.Tipo_Oferta)
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

                    return oferta;
                }
            }
            catch (Exception)
            {
                throw;
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



        //
    }
}