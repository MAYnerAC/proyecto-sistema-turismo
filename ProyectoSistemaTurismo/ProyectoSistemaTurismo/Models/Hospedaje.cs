namespace ProyectoSistemaTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hospedaje")]
    public partial class Hospedaje
    {
        [Key]
        public int id_hospedaje { get; set; }

        [Required]
        [StringLength(50)]
        public string categoria { get; set; }

        public decimal precio_minimo { get; set; }

        public decimal precio_maximo { get; set; }

        public TimeSpan horario_checkin { get; set; }

        public TimeSpan horario_checkout { get; set; }

        [Column(TypeName = "text")]
        public string servicios_adicionales { get; set; }

        public int? capacidad { get; set; }

        public int id_oferta { get; set; }

        public virtual Oferta Oferta { get; set; }
    }
}
