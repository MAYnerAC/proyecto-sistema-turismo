USE dbSistemaTurismo
GO

/*
INSERT INTO Tipo_Usuario (nombre_tipo, estado) VALUES ('Admin', 'A');
INSERT INTO Tipo_Usuario (nombre_tipo, estado) VALUES ('Proveedor', 'A');
INSERT INTO Tipo_Usuario (nombre_tipo, estado) VALUES ('Turista', 'A');

INSERT INTO Tipo_Oferta (nombre_tipo, estado) VALUES ('Hotel', 'A');
INSERT INTO Tipo_Oferta (nombre_tipo, estado) VALUES ('Restaurante', 'A');
INSERT INTO Tipo_Oferta (nombre_tipo, estado) VALUES ('Evento', 'A');

INSERT INTO Tipo_Reporte (nombre_tipo, estado) VALUES ('Duplicado', 'A');
INSERT INTO Tipo_Reporte (nombre_tipo, estado) VALUES ('Cerrado', 'A');
INSERT INTO Tipo_Reporte (nombre_tipo, estado) VALUES ('Sugerencia de edición', 'A');

INSERT INTO Estado_Reporte (nombre_estado) VALUES ('Pendiente');
INSERT INTO Estado_Reporte (nombre_estado) VALUES ('Revisado');
INSERT INTO Estado_Reporte (nombre_estado) VALUES ('Cerrado');

INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, fecha_registro, estado) 
VALUES ('Juan', 'Perez', 'admin@example.com', '123456', '123456789', 1, GETDATE(), 'A');

INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, fecha_registro, estado) 
VALUES ('Ana', 'Ramos', 'prov@example.com', '123456', '987654321', 2, GETDATE(), 'A');

INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, fecha_registro, estado) 
VALUES ('Pedro', 'Romero', 'turi@example.com', '123456', '987784321', 3, GETDATE(), 'A');

INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) 
VALUES ('Cusco', 'Ciudad', 'Capital histórica de los incas', 'Perú', 'A');


INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, fecha_creacion, estado, verificado, visible) 
VALUES ('Hotel Paraíso', 'Un hotel 5 estrellas en el centro de la ciudad', 'Av. Central 123', -12.04318, -77.02824, '123456789', 'contacto@hotelparaiso.com', 'http://hotelparaiso.com', 'Propietario', 1, 1, 1, GETDATE(), 'A', 'N', 'N');


INSERT INTO Comentario (comentario, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Excelente lugar, muy limpio y cómodo.', 5, GETDATE(), 'A', 1, 2);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('Duplicado de otro registro', GETDATE(), 'A', 1, 2, 1, 1);

INSERT INTO Etiqueta (nombre_etiqueta, estado) 
VALUES ('Wi-Fi gratis', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) 
VALUES ('Piscina', 'A');





-- Inserciones en Oferta
INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, fecha_creacion, estado, verificado, visible)
VALUES 
('Restaurante Sabores', 'Restaurante de comida típica local', 'Av. Las Flores 456', -12.04589, -77.03056, '123459876', 'contacto@restaurantesabores.com', 'http://restaurantesabores.com', 'Propietario', 2, 2, 1, GETDATE(), 'A', 'N', 'N');

-- Inserciones en Comentario
INSERT INTO Comentario (comentario, puntuacion, fecha_comentario, estado, id_oferta, id_usuario)
VALUES 
('Buen servicio, aunque podría mejorar el tiempo de espera.', 4, GETDATE(), 'A', 2, 2);

-- Inserciones en Galeria
INSERT INTO Galeria (url_imagen, descripcion, tipo_imagen, fecha_subida, estado, id_oferta)
VALUES 
('http://imagenes.com/restaurantesabores.jpg', 'Foto de la entrada principal', 'jpg', GETDATE(), 'A', 2);

-- Inserciones en Reporte
INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte)
VALUES 
('Informe sobre condiciones de higiene', GETDATE(), 'A', 2, 2, 2, 1);

-- Inserciones en Etiqueta_Oferta
INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta)
VALUES 
(2, 1), -- Wi-Fi gratis
(2, 2); -- Piscina

-- Inserciones en Log_Visitas
INSERT INTO Log_Visitas (fecha_visita, estado, id_oferta, id_usuario)
VALUES 
(GETDATE(), 'A', 2, 2);

-- Inserciones en Preferencias_Usuario
INSERT INTO Preferencias_Usuario (estado, id_usuario, id_etiqueta)
VALUES 
('A', 2, 1), -- Wi-Fi gratis
('A', 2, 2); -- Piscina

-- Inserciones en Suscripcion_Negocio
INSERT INTO Suscripcion_Negocio (tipo_plan, fecha_inicio, fecha_expiracion, estado, id_oferta)
VALUES 
('Premium', GETDATE(), DATEADD(MONTH, 6, GETDATE()), 'A', 2);

*/








-- Seleccionar todos los registros de Tipo_Usuario
SELECT * FROM Tipo_Usuario;

-- Seleccionar todos los registros de Tipo_Oferta
SELECT * FROM Tipo_Oferta;

-- Seleccionar todos los registros de Tipo_Reporte
SELECT * FROM Tipo_Reporte;

-- Seleccionar todos los registros de Estado_Reporte
SELECT * FROM Estado_Reporte;

-- Seleccionar todos los registros de Etiqueta
SELECT * FROM Etiqueta;

-- Seleccionar todos los registros de Destino
SELECT * FROM Destino;

-- Seleccionar todos los registros de Usuario
SELECT * FROM Usuario;

-- Seleccionar todos los registros de Oferta
SELECT * FROM Oferta;

-- Seleccionar todos los registros de Hospedaje
SELECT * FROM Hospedaje;

-- Seleccionar todos los registros de Restaurante
SELECT * FROM Restaurante;

-- Seleccionar todos los registros de Evento
SELECT * FROM Evento;

-- Seleccionar todos los registros de Atractivo_Turistico
SELECT * FROM Atractivo_Turistico;

-- Seleccionar todos los registros de Institucion
SELECT * FROM Institucion;

-- Seleccionar todos los registros de Etiqueta_Oferta
SELECT * FROM Etiqueta_Oferta;

-- Seleccionar todos los registros de Comentario
SELECT * FROM Comentario;

-- Seleccionar todos los registros de Galeria
SELECT * FROM Galeria;

-- Seleccionar todos los registros de Log_Visitas
SELECT * FROM Log_Visitas;

-- Seleccionar todos los registros de Preferencias_Usuario
SELECT * FROM Preferencias_Usuario;

-- Seleccionar todos los registros de Publicidad
SELECT * FROM Publicidad;

-- Seleccionar todos los registros de Suscripcion_Negocio
SELECT * FROM Suscripcion_Negocio;

-- Seleccionar todos los registros de Reporte
SELECT * FROM Reporte;

-- Seleccionar todos los registros de Foto_Comentario
SELECT * FROM Foto_Comentario;
