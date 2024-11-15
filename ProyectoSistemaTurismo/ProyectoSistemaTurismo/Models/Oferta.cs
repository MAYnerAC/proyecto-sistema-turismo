namespace ProyectoSistemaTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Oferta")]
    public partial class Oferta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oferta()
        {
            Atractivo_Turistico = new HashSet<Atractivo_Turistico>();
            Comentario = new HashSet<Comentario>();
            Etiqueta_Oferta = new HashSet<Etiqueta_Oferta>();
            Evento = new HashSet<Evento>();
            Galeria = new HashSet<Galeria>();
            Hospedaje = new HashSet<Hospedaje>();
            Institucion = new HashSet<Institucion>();
            Log_Visitas = new HashSet<Log_Visitas>();
            Publicidad = new HashSet<Publicidad>();
            Reporte = new HashSet<Reporte>();
            Restaurante = new HashSet<Restaurante>();
            Suscripcion_Negocio = new HashSet<Suscripcion_Negocio>();
        }

        [Key]
        public int id_oferta { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [StringLength(200)]
        public string direccion { get; set; }

        public decimal? ubicacion_lat { get; set; }

        public decimal? ubicacion_lon { get; set; }

        [StringLength(15)]
        public string telefono { get; set; }

        [StringLength(100)]
        public string email_contacto { get; set; }

        [StringLength(200)]
        public string sitio_web { get; set; }

        [StringLength(50)]
        public string vinculo_con_oferta { get; set; }

        public int id_usuario { get; set; }

        public int id_tipo_oferta { get; set; }

        public int? id_destino { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_creacion { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [StringLength(1)]
        public string verificado { get; set; }

        [StringLength(1)]
        public string visible { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_baja { get; set; }

        [Column(TypeName = "text")]
        public string motivo_baja { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Atractivo_Turistico> Atractivo_Turistico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentario> Comentario { get; set; }

        public virtual Destino Destino { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Etiqueta_Oferta> Etiqueta_Oferta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evento> Evento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Galeria> Galeria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hospedaje> Hospedaje { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Institucion> Institucion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Log_Visitas> Log_Visitas { get; set; }

        public virtual Tipo_Oferta Tipo_Oferta { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Publicidad> Publicidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reporte> Reporte { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Restaurante> Restaurante { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Suscripcion_Negocio> Suscripcion_Negocio { get; set; }
    }
}
