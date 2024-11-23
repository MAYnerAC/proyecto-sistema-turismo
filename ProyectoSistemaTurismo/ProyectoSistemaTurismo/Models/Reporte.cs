namespace ProyectoSistemaTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reporte")]
    public partial class Reporte
    {
        [Key]
        public int id_reporte { get; set; }

        public string descripcion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_reporte { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public int id_usuario { get; set; }

        public int id_oferta { get; set; }

        public int id_tipo_reporte { get; set; }

        public int id_estado_reporte { get; set; }

        public virtual Estado_Reporte Estado_Reporte { get; set; }

        public virtual Oferta Oferta { get; set; }

        public virtual Tipo_Reporte Tipo_Reporte { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
