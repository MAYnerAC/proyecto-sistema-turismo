namespace ProyectoSistemaTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Galeria")]
    public partial class Galeria
    {
        [Key]
        public int id_imagen { get; set; }

        [Required]
        public string url_imagen { get; set; }

        public string descripcion { get; set; }

        [StringLength(50)]
        public string tipo_imagen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_subida { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public int id_oferta { get; set; }

        public virtual Oferta Oferta { get; set; }
    }
}
