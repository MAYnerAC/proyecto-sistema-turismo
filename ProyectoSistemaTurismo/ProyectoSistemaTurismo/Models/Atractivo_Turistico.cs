namespace ProyectoSistemaTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Atractivo_Turistico
    {
        [Key]
        public int id_atractivo { get; set; }

        [StringLength(50)]
        public string tipo_vegetacion { get; set; }

        [StringLength(200)]
        public string ubicacion_referencia { get; set; }

        public TimeSpan horario_apertura { get; set; }

        public TimeSpan horario_cierre { get; set; }

        public int? capacidad { get; set; }

        public int id_oferta { get; set; }

        public virtual Oferta Oferta { get; set; }
    }
}
