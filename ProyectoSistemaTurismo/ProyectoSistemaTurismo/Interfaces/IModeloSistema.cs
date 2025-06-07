using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data.Entity;
using ProyectoSistemaTurismo.Models;
using System.Data.Entity.Infrastructure;


namespace ProyectoSistemaTurismo.Interfaces
{
    public interface IModeloSistema : IDisposable
    {
        DbSet<Tipo_Usuario> Tipo_Usuario { get; set; }
        DbSet<Usuario> Usuario { get; set; }
        DbSet<Tipo_Oferta> Tipo_Oferta { get; set; }
        DbSet<Preferencias_Usuario> Preferencias_Usuario { get; set; }
        DbSet<Oferta> Oferta { get; set; }
        DbSet<Galeria> Galeria { get; set; }
        DbSet<Foto_Comentario> Foto_Comentario { get; set; }
        DbSet<Etiqueta> Etiqueta { get; set; }
        DbSet<Etiqueta_Oferta> Etiqueta_Oferta { get; set; }

        //DbSet +



        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
