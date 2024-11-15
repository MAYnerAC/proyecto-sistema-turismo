namespace ProyectoSistemaTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Institucion")]
    public partial class Institucion
    {
        [Key]
        public int id_institucion { get; set; }

        [Required]
        [StringLength(50)]
        public string tipo_institucion { get; set; }

        [Column(TypeName = "text")]
        public string servicios_disponibles { get; set; }

        public TimeSpan horario_apertura { get; set; }

        public TimeSpan horario_cierre { get; set; }

        [StringLength(15)]
        public string contacto_telefono { get; set; }

        [StringLength(100)]
        public string contacto_email { get; set; }

        public int id_oferta { get; set; }

        public virtual Oferta Oferta { get; set; }
    }
}
