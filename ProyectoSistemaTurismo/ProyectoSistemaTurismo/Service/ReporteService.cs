using ProyectoSistemaTurismo.Interfaces;
using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProyectoSistemaTurismo.Service
{
    /// <summary>
    /// Servicio para generar reportes personalizados de ofertas.
    /// </summary>
    public class ReporteService
    {
        private readonly IModeloSistema _db;

        public ReporteService(IModeloSistema db)
        {
            _db = db;
        }

        /// <summary>
        /// Obtiene la cantidad de ofertas por tipo, filtradas por ID de oferta.
        /// </summary>
        public List<OfertaPorTipoReporte> ObtenerOfertasPorTipo(int idOferta)
        {
            var result = _db.Oferta
                            .Where(o => o.id_oferta == idOferta)
                            .GroupBy(o => o.Tipo_Oferta.nombre_tipo)
                            .Select(g => new OfertaPorTipoReporte
                            {
                                TipoOferta = g.Key,
                                Cantidad = g.Count()
                            })
                            .ToList();
            return result;
        }

        /// <summary>
        /// Obtiene la cantidad de ofertas por destino, filtradas por ID de oferta.
        /// </summary>
        public List<OfertaPorDestinoReporte> ObtenerOfertasPorDestino(int idOferta)
        {
            var result = _db.Oferta
                            .Where(o => o.id_oferta == idOferta)
                            .GroupBy(o => o.Destino.nombre_destino)
                            .Select(g => new OfertaPorDestinoReporte
                            {
                                Destino = g.Key,
                                Cantidad = g.Count()
                            })
                            .ToList();
            return result;
        }


        //


    }
}