namespace ProyectoSistemaTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Restaurante")]
    public partial class Restaurante
    {
        [Key]
        public int id_restaurante { get; set; }

        [Required]
        [StringLength(50)]
        public string tipo_cocina { get; set; }

        public string especialidades { get; set; }

        public TimeSpan horario_apertura { get; set; }

        public TimeSpan horario_cierre { get; set; }

        public decimal? precio_promedio { get; set; }

        public decimal? precio_minimo { get; set; }

        public decimal? precio_maximo { get; set; }

        public int id_oferta { get; set; }

        public virtual Oferta Oferta { get; set; }
    }
}
