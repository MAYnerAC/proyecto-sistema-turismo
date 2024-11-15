namespace ProyectoSistemaTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Evento")]
    public partial class Evento
    {
        [Key]
        public int id_evento { get; set; }

        [Required]
        [StringLength(50)]
        public string tipo_evento { get; set; }

        [StringLength(50)]
        public string epoca { get; set; }

        public int? capacidad { get; set; }

        public decimal? precio_entrada { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_evento { get; set; }

        public int id_oferta { get; set; }

        public virtual Oferta Oferta { get; set; }
    }
}
