namespace ProyectoSistemaTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Publicidad")]
    public partial class Publicidad
    {
        [Key]
        public int id_publicidad { get; set; }

        [Required]
        [StringLength(50)]
        public string tipo_publicidad { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_inicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_fin { get; set; }

        public int? prioridad { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public int id_oferta { get; set; }

        public virtual Oferta Oferta { get; set; }
    }
}
