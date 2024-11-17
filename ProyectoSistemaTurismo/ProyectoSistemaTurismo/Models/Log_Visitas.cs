namespace ProyectoSistemaTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Log_Visitas
    {
        [Key]
        public int id_log { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_visita { get; set; }

        public int id_oferta { get; set; }

        public int? id_usuario { get; set; }

        public virtual Oferta Oferta { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
