using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
//
using ProyectoSistemaTurismo.Interfaces;
using System.Data.Entity.Infrastructure;


namespace ProyectoSistemaTurismo.Models
{
    public partial class ModeloSistema : DbContext, IModeloSistema
    {
        public ModeloSistema()
            : base("name=ModeloSistema")
        {
        }

        public virtual DbSet<Atractivo_Turistico> Atractivo_Turistico { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Destino> Destino { get; set; }
        public virtual DbSet<Estado_Reporte> Estado_Reporte { get; set; }
        public virtual DbSet<Etiqueta> Etiqueta { get; set; }
        public virtual DbSet<Etiqueta_Oferta> Etiqueta_Oferta { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Foto_Comentario> Foto_Comentario { get; set; }
        public virtual DbSet<Galeria> Galeria { get; set; }
        public virtual DbSet<Hospedaje> Hospedaje { get; set; }
        public virtual DbSet<Institucion> Institucion { get; set; }
        public virtual DbSet<Log_Visitas> Log_Visitas { get; set; }
        public virtual DbSet<Oferta> Oferta { get; set; }
        public virtual DbSet<Preferencias_Usuario> Preferencias_Usuario { get; set; }
        public virtual DbSet<Publicidad> Publicidad { get; set; }
        public virtual DbSet<Reporte> Reporte { get; set; }
        public virtual DbSet<Restaurante> Restaurante { get; set; }
        public virtual DbSet<Suscripcion_Negocio> Suscripcion_Negocio { get; set; }
        public virtual DbSet<Tipo_Oferta> Tipo_Oferta { get; set; }
        public virtual DbSet<Tipo_Reporte> Tipo_Reporte { get; set; }
        public virtual DbSet<Tipo_Usuario> Tipo_Usuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        public new DbEntityEntry Entry(object entity)
        {
            return base.Entry(entity);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atractivo_Turistico>()
                .Property(e => e.tipo_vegetacion)
                .IsUnicode(false);

            modelBuilder.Entity<Atractivo_Turistico>()
                .Property(e => e.ubicacion_referencia)
                .IsUnicode(false);

            modelBuilder.Entity<Comentario>()
                .Property(e => e.contenido)
                .IsUnicode(false);

            modelBuilder.Entity<Comentario>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Comentario>()
                .HasMany(e => e.Foto_Comentario)
                .WithRequired(e => e.Comentario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Destino>()
                .Property(e => e.nombre_destino)
                .IsUnicode(false);

            modelBuilder.Entity<Destino>()
                .Property(e => e.tipo_destino)
                .IsUnicode(false);

            modelBuilder.Entity<Destino>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Destino>()
                .Property(e => e.pais)
                .IsUnicode(false);

            modelBuilder.Entity<Destino>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Estado_Reporte>()
                .Property(e => e.nombre_estado)
                .IsUnicode(false);

            modelBuilder.Entity<Estado_Reporte>()
                .HasMany(e => e.Reporte)
                .WithRequired(e => e.Estado_Reporte)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Etiqueta>()
                .Property(e => e.nombre_etiqueta)
                .IsUnicode(false);

            modelBuilder.Entity<Etiqueta>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Etiqueta>()
                .HasMany(e => e.Etiqueta_Oferta)
                .WithRequired(e => e.Etiqueta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Evento>()
                .Property(e => e.tipo_evento)
                .IsUnicode(false);

            modelBuilder.Entity<Evento>()
                .Property(e => e.epoca)
                .IsUnicode(false);

            modelBuilder.Entity<Evento>()
                .Property(e => e.precio_entrada)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Foto_Comentario>()
                .Property(e => e.url_foto)
                .IsUnicode(false);

            modelBuilder.Entity<Foto_Comentario>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Foto_Comentario>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Galeria>()
                .Property(e => e.url_imagen)
                .IsUnicode(false);

            modelBuilder.Entity<Galeria>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Galeria>()
                .Property(e => e.tipo_imagen)
                .IsUnicode(false);

            modelBuilder.Entity<Galeria>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hospedaje>()
                .Property(e => e.categoria)
                .IsUnicode(false);

            modelBuilder.Entity<Hospedaje>()
                .Property(e => e.precio_minimo)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Hospedaje>()
                .Property(e => e.precio_maximo)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Hospedaje>()
                .Property(e => e.servicios_adicionales)
                .IsUnicode(false);

            modelBuilder.Entity<Institucion>()
                .Property(e => e.tipo_institucion)
                .IsUnicode(false);

            modelBuilder.Entity<Institucion>()
                .Property(e => e.servicios_disponibles)
                .IsUnicode(false);

            modelBuilder.Entity<Institucion>()
                .Property(e => e.contacto_telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Institucion>()
                .Property(e => e.contacto_email)
                .IsUnicode(false);

            modelBuilder.Entity<Oferta>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Oferta>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Oferta>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Oferta>()
                .Property(e => e.ubicacion_lat)
                .HasPrecision(9, 6);

            modelBuilder.Entity<Oferta>()
                .Property(e => e.ubicacion_lon)
                .HasPrecision(9, 6);

            modelBuilder.Entity<Oferta>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Oferta>()
                .Property(e => e.email_contacto)
                .IsUnicode(false);

            modelBuilder.Entity<Oferta>()
                .Property(e => e.sitio_web)
                .IsUnicode(false);

            modelBuilder.Entity<Oferta>()
                .Property(e => e.vinculo_con_oferta)
                .IsUnicode(false);

            modelBuilder.Entity<Oferta>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Oferta>()
                .Property(e => e.verificado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Oferta>()
                .Property(e => e.visible)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Oferta>()
                .Property(e => e.motivo_baja)
                .IsUnicode(false);

            modelBuilder.Entity<Oferta>()
                .HasMany(e => e.Atractivo_Turistico)
                .WithRequired(e => e.Oferta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Oferta>()
                .HasMany(e => e.Comentario)
                .WithRequired(e => e.Oferta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Oferta>()
                .HasMany(e => e.Etiqueta_Oferta)
                .WithRequired(e => e.Oferta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Oferta>()
                .HasMany(e => e.Evento)
                .WithRequired(e => e.Oferta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Oferta>()
                .HasMany(e => e.Galeria)
                .WithRequired(e => e.Oferta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Oferta>()
                .HasMany(e => e.Hospedaje)
                .WithRequired(e => e.Oferta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Oferta>()
                .HasMany(e => e.Institucion)
                .WithRequired(e => e.Oferta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Oferta>()
                .HasMany(e => e.Log_Visitas)
                .WithRequired(e => e.Oferta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Oferta>()
                .HasMany(e => e.Publicidad)
                .WithRequired(e => e.Oferta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Oferta>()
                .HasMany(e => e.Reporte)
                .WithRequired(e => e.Oferta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Oferta>()
                .HasMany(e => e.Restaurante)
                .WithRequired(e => e.Oferta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Oferta>()
                .HasMany(e => e.Suscripcion_Negocio)
                .WithRequired(e => e.Oferta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publicidad>()
                .Property(e => e.tipo_publicidad)
                .IsUnicode(false);

            modelBuilder.Entity<Publicidad>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Reporte>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Reporte>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Restaurante>()
                .Property(e => e.tipo_cocina)
                .IsUnicode(false);

            modelBuilder.Entity<Restaurante>()
                .Property(e => e.especialidades)
                .IsUnicode(false);

            modelBuilder.Entity<Restaurante>()
                .Property(e => e.precio_promedio)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Restaurante>()
                .Property(e => e.precio_minimo)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Restaurante>()
                .Property(e => e.precio_maximo)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Suscripcion_Negocio>()
                .Property(e => e.tipo_plan)
                .IsUnicode(false);

            modelBuilder.Entity<Suscripcion_Negocio>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Oferta>()
                .Property(e => e.nombre_tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Oferta>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Oferta>()
                .HasMany(e => e.Oferta)
                .WithRequired(e => e.Tipo_Oferta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Reporte>()
                .Property(e => e.nombre_tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Reporte>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Reporte>()
                .HasMany(e => e.Reporte)
                .WithRequired(e => e.Tipo_Reporte)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Usuario>()
                .Property(e => e.nombre_tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Usuario>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Usuario>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Tipo_Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.contrasena)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Comentario)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Oferta)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Preferencias_Usuario)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Reporte)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
