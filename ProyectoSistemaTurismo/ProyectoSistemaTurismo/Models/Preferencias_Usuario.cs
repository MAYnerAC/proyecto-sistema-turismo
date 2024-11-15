namespace ProyectoSistemaTurismo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Preferencias_Usuario
    {
        [Key]
        public int id_preferencia { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public int id_usuario { get; set; }

        public int? id_etiqueta { get; set; }

        public virtual Etiqueta Etiqueta { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
