namespace ProyectoSistemaTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Etiqueta_Oferta
    {
        [Key]
        public int id_etiqueta_oferta { get; set; }

        public int id_oferta { get; set; }

        public int id_etiqueta { get; set; }

        public virtual Etiqueta Etiqueta { get; set; }

        public virtual Oferta Oferta { get; set; }
    }
}
