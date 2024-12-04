using ProyectoSistemaTurismo.Models;
using ProyectoSistemaTurismo.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProyectoSistemaTurismo.Service
{
    public class ReporteService
    {

        public List<OfertaPorTipoReporte> ObtenerOfertasPorTipo(int idOferta)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    var result = db.Oferta
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
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<OfertaPorDestinoReporte> ObtenerOfertasPorDestino(int idOferta)
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    var result = db.Oferta
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
            }
            catch (Exception)
            {
                throw;
            }
        }


        //


    }
}