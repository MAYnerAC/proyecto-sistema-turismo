namespace ProyectoSistemaTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Foto_Comentario
    {
        [Key]
        public int id_foto { get; set; }

        [Required]
        [StringLength(255)]
        public string url_foto { get; set; }

        [StringLength(255)]
        public string descripcion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_subida { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public int id_comentario { get; set; }

        public virtual Comentario Comentario { get; set; }
    }
}
