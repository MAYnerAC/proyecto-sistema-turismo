namespace ProyectoSistemaTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Etiqueta")]
    public partial class Etiqueta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Etiqueta()
        {
            Etiqueta_Oferta = new HashSet<Etiqueta_Oferta>();
            Preferencias_Usuario = new HashSet<Preferencias_Usuario>();
        }

        [Key]
        public int id_etiqueta { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre_etiqueta { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Etiqueta_Oferta> Etiqueta_Oferta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Preferencias_Usuario> Preferencias_Usuario { get; set; }
    }
}
