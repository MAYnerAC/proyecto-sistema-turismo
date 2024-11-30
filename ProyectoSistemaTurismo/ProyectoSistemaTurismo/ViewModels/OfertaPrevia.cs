using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSistemaTurismo.ViewModels
{
    public class OfertaPrevia
    {
        public int id_oferta { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string telefono { get; set; }
        public int id_tipo_oferta { get; set; }
        public int? id_destino { get; set; }
        public string tipo_oferta { get; set; }
        public string nombre_destino { get; set; }
        public string imagen_url { get; set; }
        public string verificado { get; set; }



        //
    }
}