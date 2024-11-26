/*Admin*/

Tipo_Usuario.agregar(Tipo_Usuario tipoUsuario)
Tipo_Usuario.editar(Tipo_Usuario tipoUsuario)
Tipo_Usuario.eliminar(int id_tipo_usuario)
Tipo_Usuario.listar()

Tipo_Oferta.agregar(Tipo_Oferta tipoOferta)
Tipo_Oferta.editar(Tipo_Oferta tipoOferta)
Tipo_Oferta.eliminar(int id_tipo_oferta)
Tipo_Oferta.listar()

Etiqueta.agregar(Etiqueta etiqueta)
Etiqueta.editar(Etiqueta etiqueta)
Etiqueta.eliminar(int id_etiqueta)
Etiqueta.listar()

Destino.agregar(Destino destino)
Destino.editar(Destino destino)
Destino.eliminar(int id_destino)
Destino.listar()

Usuario.listar()
Usuario.editar(Usuario usuario)
Usuario.eliminar(int id_usuario)
Usuario.cambiarTipo(int id_usuario, int id_tipo_usuario)
Usuario.desactivar(int id_usuario)
Usuario.activar(int id_usuario)

Oferta.listarTodas()
Oferta.listarPendientes()
Oferta.aprobar(int id_oferta)
Oferta.rechazar(int id_oferta, string motivo)
Oferta.eliminar(int id_oferta)

Comentario.listarTodos()
Comentario.listarPorOferta(int id_oferta)
Comentario.eliminar(int id_comentario)

Galeria.eliminarImagen(int id_imagen)

Preferencias_Usuario.listarPorUsuario(int id_usuario)

Foto_Comentario.eliminar(int id_foto)



/*Proveedor*/

Usuario.registrar(Usuario usuario)
Usuario.iniciarSesion(string email, string contrasena)
Usuario.actualizarPerfil(Usuario usuario)
Usuario.cambiarContrasena(int id_usuario, string nuevaContrasena)

Oferta.agregar(Oferta oferta)
Oferta.editar(Oferta oferta)
Oferta.eliminar(int id_oferta)
Oferta.listarPorProveedor(int id_usuario)
Oferta.verEstado(int id_oferta)

Etiqueta_Oferta.agregar(Etiqueta_Oferta etiquetaOferta)
Etiqueta_Oferta.eliminar(int id_etiqueta_oferta)
Etiqueta_Oferta.listarPorOferta(int id_oferta)

Comentario.agregar(Comentario comentario)
Comentario.editar(Comentario comentario)
Comentario.eliminar(int id_comentario)
Comentario.listarPorUsuario(int id_usuario)

Galeria.agregarImagen(Galeria imagen)
Galeria.editarImagen(Galeria imagen)
Galeria.eliminarImagen(int id_imagen)
Galeria.listarPorOferta(int id_oferta)

Preferencias_Usuario.agregar(Preferencias_Usuario preferencia)
Preferencias_Usuario.eliminar(int id_preferencia)
Preferencias_Usuario.listarPorUsuario(int id_usuario)

Foto_Comentario.agregar(Foto_Comentario fotoComentario)
Foto_Comentario.eliminar(int id_foto)
Foto_Comentario.listarPorComentario(int id_comentario)


/*Turista*/

Usuario.registrar(Usuario usuario)
Usuario.iniciarSesion(string email, string contrasena)
Usuario.actualizarPerfil(Usuario usuario)
Usuario.cambiarContrasena(int id_usuario, string nuevaContrasena)
Usuario.solicitarCambioTipo(int id_usuario, int nuevo_id_tipo_usuario)

Oferta.listar()
Oferta.buscar(string criterio)
Oferta.verDetalle(int id_oferta)

Comentario.agregar(Comentario comentario)
Comentario.editar(Comentario comentario)
Comentario.eliminar(int id_comentario)
Comentario.listarPorUsuario(int id_usuario)

Galeria.verImagen(int id_imagen)
Galeria.listarPorOferta(int id_oferta)

Preferencias_Usuario.agregar(Preferencias_Usuario preferencia)
Preferencias_Usuario.eliminar(int id_preferencia)
Preferencias_Usuario.listarPorUsuario(int id_usuario)

Foto_Comentario.agregar(Foto_Comentario fotoComentario)
Foto_Comentario.eliminar(int id_foto)
Foto_Comentario.listarPorComentario(int id_comentario)




/*---------------------------------------------------------------------------------------------------------------------------------------------------------------------*/


/*--------------------------------------------------------Vistas para Admin--------------------------------------------------------*/

/*Tipo_Usuario*/
TipoUsuario/Index.cshtml (Listar tipos de usuario)
TipoUsuario/Create.cshtml (Agregar tipo de usuario)
TipoUsuario/Edit.cshtml (Editar tipo de usuario)
TipoUsuario/Delete.cshtml (Eliminar tipo de usuario)
TipoUsuario/Details.cshtml (Detalles de tipo de usuario)

/*Tipo_Oferta*/
TipoOferta/Index.cshtml (Listar tipos de oferta)
TipoOferta/Create.cshtml (Agregar tipo de oferta)
TipoOferta/Edit.cshtml (Editar tipo de oferta)
TipoOferta/Delete.cshtml (Eliminar tipo de oferta)
TipoOferta/Details.cshtml (Detalles de tipo de oferta)

/*Etiqueta*/
Etiqueta/Index.cshtml (Listar etiquetas)
Etiqueta/Create.cshtml (Agregar etiqueta)
Etiqueta/Edit.cshtml (Editar etiqueta)
Etiqueta/Delete.cshtml (Eliminar etiqueta)
Etiqueta/Details.cshtml (Detalles de etiqueta)

/*Destino*/
Destino/Index.cshtml (Listar destinos)
Destino/Create.cshtml (Agregar destino)
Destino/Edit.cshtml (Editar destino)
Destino/Delete.cshtml (Eliminar destino)
Destino/Details.cshtml (Detalles de destino)

/*Usuario*/
Usuario/Index.cshtml (Listar usuarios)
Usuario/Edit.cshtml (Editar usuario)
Usuario/Delete.cshtml (Eliminar usuario)
Usuario/Details.cshtml (Detalles de usuario)
Usuario/ChangeRole.cshtml (Cambiar tipo de usuario)
Usuario/Activate.cshtml (Activar usuario)
Usuario/Deactivate.cshtml (Desactivar usuario)

/*Oferta*/
Oferta/IndexAdmin.cshtml (Listar todas las ofertas)
Oferta/Pending.cshtml (Listar ofertas pendientes de aprobación)
Oferta/Approve.cshtml (Aprobar oferta)
Oferta/Reject.cshtml (Rechazar oferta)
Oferta/Delete.cshtml (Eliminar oferta)
Oferta/DetailsAdmin.cshtml (Detalles de oferta para admin)

/*Comentario*/
Comentario/IndexAdmin.cshtml (Listar todos los comentarios)
Comentario/Delete.cshtml (Eliminar comentario)
Comentario/DetailsAdmin.cshtml (Detalles de comentario)

/*Galeria*/
Galeria/Delete.cshtml (Eliminar imagen)
Galeria/DetailsAdmin.cshtml (Detalles de imagen)

/*Foto_Comentario*/
FotoComentario/Delete.cshtml (Eliminar foto de comentario)
FotoComentario/DetailsAdmin.cshtml (Detalles de foto de comentario)

/*--------------------------------------------------------Vistas para Turista--------------------------------------------------------*/

/*Usuario*/
Usuario/Register.cshtml (Registro de usuario)
Usuario/Login.cshtml (Inicio de sesión)
Usuario/Profile.cshtml (Perfil de usuario)
Usuario/EditProfile.cshtml (Editar perfil)
Usuario/ChangePassword.cshtml (Cambiar contraseña)
Usuario/RequestProvider.cshtml (Solicitar cambio a proveedor)

/*Oferta*/
Oferta/Index.cshtml (Listar ofertas)
Oferta/Search.cshtml (Buscar ofertas)
Oferta/Details.cshtml (Detalles de oferta)

/*Comentario*/
Comentario/Create.cshtml (Agregar comentario)
Comentario/Edit.cshtml (Editar comentario)
Comentario/Delete.cshtml (Eliminar comentario)
Comentario/MyComments.cshtml (Mis comentarios)
Comentario/Details.cshtml (Detalles de comentario)

/*Galeria*/
Galeria/ViewImage.cshtml (Ver imagen)
Galeria/OfferGallery.cshtml (Galería de oferta)

/*Preferencias_Usuario*/
PreferenciasUsuario/Index.cshtml (Mis preferencias)
PreferenciasUsuario/Create.cshtml (Agregar preferencia)
PreferenciasUsuario/Delete.cshtml (Eliminar preferencia)

/*Foto_Comentario*/
FotoComentario/Create.cshtml (Agregar foto a comentario)
FotoComentario/Delete.cshtml (Eliminar foto de comentario)
FotoComentario/MyCommentPhotos.cshtml (Mis fotos de comentarios)

/*--------------------------------------------------------Vistas para Proveedor--------------------------------------------------------*/

/*Usuario*/
Usuario/Profile.cshtml (Perfil de usuario)
Usuario/EditProfile.cshtml (Editar perfil)
Usuario/ChangePassword.cshtml (Cambiar contraseña)

/*Oferta*/
Oferta/MyOffers.cshtml (Mis ofertas)
Oferta/Create.cshtml (Agregar oferta)
Oferta/Edit.cshtml (Editar oferta)
Oferta/Delete.cshtml (Eliminar oferta)
Oferta/DetailsProvider.cshtml (Detalles de oferta)
Oferta/SelectOffer.cshtml (Seleccionar oferta)

/*Etiqueta_Oferta*/
EtiquetaOferta/Manage.cshtml (Gestionar etiquetas de oferta)
EtiquetaOferta/Add.cshtml (Agregar etiqueta a oferta)
EtiquetaOferta/Delete.cshtml (Eliminar etiqueta de oferta)

/*Galeria*/
Galeria/MyOfferGallery.cshtml (Galería de mis ofertas)
Galeria/AddImage.cshtml (Agregar imagen a oferta)
Galeria/EditImage.cshtml (Editar imagen de oferta)
Galeria/DeleteImage.cshtml (Eliminar imagen de oferta)

/*Comentario*/
Comentario/Create.cshtml (Agregar comentario)
Comentario/Edit.cshtml (Editar comentario)
Comentario/Delete.cshtml (Eliminar comentario)
Comentario/MyComments.cshtml (Mis comentarios)
Comentario/Details.cshtml (Detalles de comentario)

/*Preferencias_Usuario*/
PreferenciasUsuario/Index.cshtml (Mis preferencias)
PreferenciasUsuario/Create.cshtml (Agregar preferencia)
PreferenciasUsuario/Delete.cshtml (Eliminar preferencia)

/*Foto_Comentario*/
FotoComentario/Create.cshtml (Agregar foto a comentario)
FotoComentario/Delete.cshtml (Eliminar foto de comentario)
FotoComentario/MyCommentPhotos.cshtml (Mis fotos de comentarios)
