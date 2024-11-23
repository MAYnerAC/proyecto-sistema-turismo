namespace ProyectoSistemaTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comentario")]
    public partial class Comentario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comentario()
        {
            Foto_Comentario = new HashSet<Foto_Comentario>();
        }

        [Key]
        public int id_comentario { get; set; }

        [Required]
        public string contenido { get; set; }

        public int? puntuacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_comentario { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public int id_oferta { get; set; }

        public int id_usuario { get; set; }

        public virtual Oferta Oferta { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Foto_Comentario> Foto_Comentario { get; set; }
    }
}
