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
        //DbSet +



        DbEntityEntry Entry(object entity);
        int SaveChanges();
    }
}
