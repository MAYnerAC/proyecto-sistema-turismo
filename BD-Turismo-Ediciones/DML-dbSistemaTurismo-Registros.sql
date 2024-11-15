USE dbSistemaTurismo;
GO


-- Tabla Tipo de Usuario

INSERT INTO Tipo_Usuario (nombre_tipo, estado) VALUES ('Administrador', 'A');
INSERT INTO Tipo_Usuario (nombre_tipo, estado) VALUES ('Proveedor', 'A');
INSERT INTO Tipo_Usuario (nombre_tipo, estado) VALUES ('Cliente', 'A');


-- Tabla Tipo de Oferta

INSERT INTO Tipo_Oferta (nombre_tipo, estado) VALUES ('Hospedaje', 'A');
INSERT INTO Tipo_Oferta (nombre_tipo, estado) VALUES ('Restaurante', 'A');
INSERT INTO Tipo_Oferta (nombre_tipo, estado) VALUES ('Evento', 'A');
INSERT INTO Tipo_Oferta (nombre_tipo, estado) VALUES ('Atractivo Turístico', 'A');
INSERT INTO Tipo_Oferta (nombre_tipo, estado) VALUES ('Institución', 'A');


-- Tabla Tipo de Reporte

INSERT INTO Tipo_Reporte (nombre_tipo, estado) VALUES ('Sugerencia', 'A');
INSERT INTO Tipo_Reporte (nombre_tipo, estado) VALUES ('Lugar Cerrado', 'A');
INSERT INTO Tipo_Reporte (nombre_tipo, estado) VALUES ('Lugar Duplicado', 'A');

-- Tabla Estado de Reporte

INSERT INTO Estado_Reporte (nombre_estado) VALUES ('Pendiente');
INSERT INTO Estado_Reporte (nombre_estado) VALUES ('En Revisión');
INSERT INTO Estado_Reporte (nombre_estado) VALUES ('Revisado');


-- Tabla Etiqueta

INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Aventura', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Cultura', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Gastronomía', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Naturaleza', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Relajación', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Deportes', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Historia', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Aventura Nocturna', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Ecoturismo', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Arte', 'A');


-- Tabla Destino

INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Tacna', 'Ciudad', 'Ciudad histórica del sur de Perú, conocida por sus eventos patrióticos y comercio.', 'Perú', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Valle Viejo', 'Valle', 'Valle ubicado en las afueras de Tacna, famoso por su producción de vino y pisco.', 'Perú', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Pocollay', 'Distrito', 'Distrito tradicional de Tacna, conocido por sus festividades y cultura local.', 'Perú', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Alto de la Alianza', 'Sitio Histórico', 'Lugar histórico donde ocurrió la Batalla del Alto de la Alianza en 1880.', 'Perú', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Balneario Boca del Río', 'Playa', 'Balneario popular en Tacna, ideal para disfrutar del sol y el mar.', 'Perú', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Candarave', 'Distrito', 'Distrito de Tacna conocido por sus aguas termales y geiseres naturales.', 'Perú', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Palca', 'Distrito', 'Distrito con hermosos paisajes montañosos y el pintoresco valle de Palca.', 'Perú', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Laguna de Aricota', 'Lago', 'Hermosa laguna en la provincia de Candarave, popular para actividades recreativas.', 'Perú', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Complejo Arqueológico Miculla', 'Sitio Arqueológico', 'Sitio arqueológico con petroglifos preincaicos, un atractivo cultural de Tacna.', 'Perú', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Termas de Calientes', 'Aguas Termales', 'Aguas termales ubicadas en el distrito de Pachía, popular por sus propiedades curativas.', 'Perú', 'A');


-- Tabla Usuario

INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Admin', 'Uno', 'admin1@example.com', 'hashed_password', '123456789', 1, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Admin', 'Dos', 'admin2@example.com', 'hashed_password', '987654321', 1, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Luis', 'García', 'proveedor1@example.com', 'hashed_password', '111222333', 2, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Marta', 'Fernández', 'proveedor2@example.com', 'hashed_password', '444555666', 2, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Jorge', 'Martínez', 'proveedor3@example.com', 'hashed_password', '777888999', 2, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Ana', 'Pérez', 'cliente1@example.com', 'hashed_password', '101010101', 3, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Carlos', 'Ramírez', 'cliente2@example.com', 'hashed_password', '202020202', 3, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Laura', 'Sánchez', 'cliente3@example.com', 'hashed_password', '303030303', 3, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Pedro', 'Morales', 'cliente4@example.com', 'hashed_password', '404040404', 3, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Sofía', 'López', 'cliente5@example.com', 'hashed_password', '505050505', 3, 'A');


-- Tabla Oferta con estado extendido

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Hotel Tacna Plaza', 'Hotel céntrico en Tacna, ideal para turistas y viajeros de negocios.', 'Calle Bolívar 456', -18.0096, -70.2463, '123456789', 'contacto@hoteltacna.com', 'www.hoteltacna.com', 'Propietario', 2, 1, 1, 'A', 'S', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Hostal Valle Viejo', 'Hostal acogedor en el Valle Viejo, con vistas espectaculares y ambiente familiar.', 'Av. Central 123', -18.0054, -70.2447, '234567890', 'reservas@hostalvalleviejo.com', 'www.hostalvalleviejo.com', 'Propietario', 3, 1, 2, 'A', 'N', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Hotel Vista del Mar', 'Hotel frente a la playa en el Balneario Boca del Río, ideal para descansar.', 'Av. Costanera 456', -18.0125, -70.2510, '345678901', 'info@hotelvistadelmar.com', 'www.hotelvistadelmar.com', 'Propietario', 4, 1, 5, 'A', 'S', 'N');


INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Restaurante El Fogón', 'Restaurante especializado en comida peruana y asados.', 'Av. Grau 789', -18.0125, -70.2510, '987654321', 'contacto@elfogon.com', 'www.elfogon.com', 'Propietario', 3, 2, 1, 'A', 'N', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('La Casona del Valle', 'Restaurante campestre con especialidad en comida criolla.', 'Av. Central 345', -18.0055, -70.2448, '456789012', 'reservas@lacasonadelvalle.com', 'www.lacasonadelvalle.com', 'Propietario', 4, 2, 2, 'A', 'S', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Marisquería Boca del Río', 'Restaurante frente a la playa, especializado en mariscos frescos.', 'Costanera 123', -18.0130, -70.2520, '567890123', 'contacto@marisqueriabocadelrio.com', 'www.marisqueriabocadelrio.com', 'Propietario', 5, 2, 5, 'A', 'N', 'S');


INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Festival del Valle Viejo', 'Evento cultural que incluye música, danza y comida típica en el Valle Viejo.', 'Plaza de Armas', -18.0054, -70.2447, '102030405', 'info@valleviejofestival.com', 'www.valleviejofestival.com', 'Organizador', 6, 3, 2, 'A', 'S', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Carnaval de Tacna', 'Celebración tradicional con desfiles, danzas y música.', 'Av. Bolognesi', -18.0137, -70.2490, '112233445', 'contacto@carnavaltacna.com', 'www.carnavaltacna.com', 'Organizador', 7, 3, 1, 'A', 'S', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Festival de la Vendimia', 'Evento anual de cosecha de uvas, con degustaciones y actividades culturales.', 'Campo de Viñas', -18.0150, -70.2530, '223344556', 'info@festivalvendimia.com', 'www.festivalvendimia.com', 'Organizador', 8, 3, 2, 'A', 'N', 'S');


INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Parque Alto de la Alianza', 'Sitio histórico con monumentos y museos de la guerra del Pacífico.', 'Alto de la Alianza', -18.0008, -70.2421, '112233445', 'info@parquealianza.com', 'www.parquealianza.com', 'Administrador', 9, 4, 4, 'A', 'S', 'N');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Complejo Arqueológico Miculla', 'Sitio arqueológico con petroglifos preincaicos, un atractivo cultural de Tacna.', 'Carretera Panamericana Sur', -18.0500, -70.3000, '334455667', 'info@miculla.com', 'www.miculla.com', 'Administrador', 10, 4, 9, 'A', 'S', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Cerro Intiorko', 'Montaña sagrada para los pobladores locales, con vistas espectaculares de la ciudad.', 'Cercanías de Tacna', -18.0030, -70.2400, '445566778', 'contacto@intiorko.com', 'www.intiorko.com', 'Administrador', 1, 4, 1, 'A', 'N', 'S');


INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Centro Cultural de Tacna', 'Centro cultural para eventos y actividades culturales en Tacna.', 'Av. Bolognesi 123', -18.0137, -70.2490, '334455667', 'contacto@centroculturaltacna.com', 'www.centroculturaltacna.com', 'Operador', 7, 5, 1, 'A', 'N', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Museo Ferroviario de Tacna', 'Museo dedicado a la historia ferroviaria de Tacna.', 'Estación de Trenes de Tacna', -18.0080, -70.2505, '556677889', 'info@museotacna.com', 'www.museotacna.com', 'Administrador', 8, 5, 1, 'A', 'S', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Biblioteca Regional de Tacna', 'Biblioteca pública con una amplia colección de libros y documentos históricos.', 'Av. San Martín 456', -18.0105, -70.2485, '667788990', 'contacto@bibliotecaregionaltacna.com', 'www.bibliotecaregionaltacna.com', 'Administrador', 9, 5, 1, 'A', 'N', 'S');


-- Tabla Hospedaje

INSERT INTO Hospedaje (categoria, precio_minimo, precio_maximo, horario_checkin, horario_checkout, servicios_adicionales, capacidad, id_oferta) 
VALUES ('Hotel 3 Estrellas', 120.00, 250.00, '14:00', '11:00', 'WiFi, Desayuno incluido, Piscina', 50, 1);

INSERT INTO Hospedaje (categoria, precio_minimo, precio_maximo, horario_checkin, horario_checkout, servicios_adicionales, capacidad, id_oferta) 
VALUES ('Hostal Familiar', 40.00, 90.00, '13:00', '12:00', 'WiFi, Cocina compartida', 20, 2);

INSERT INTO Hospedaje (categoria, precio_minimo, precio_maximo, horario_checkin, horario_checkout, servicios_adicionales, capacidad, id_oferta) 
VALUES ('Hotel 4 Estrellas', 150.00, 300.00, '15:00', '11:00', 'WiFi, Desayuno, Piscina, Frente a la playa', 80, 3);


-- Tabla Restaurante

INSERT INTO Restaurante (tipo_cocina, especialidades, horario_apertura, horario_cierre, precio_promedio, precio_minimo, precio_maximo, id_oferta) 
VALUES ('Peruana', 'Ceviche, Lomo Saltado, Ají de Gallina', '09:00', '23:00', 40.00, 20.00, 80.00, 4);

INSERT INTO Restaurante (tipo_cocina, especialidades, horario_apertura, horario_cierre, precio_promedio, precio_minimo, precio_maximo, id_oferta) 
VALUES ('Criolla', 'Pachamanca, Cuy Chactado, Rocoto Relleno', '10:00', '22:00', 35.00, 15.00, 70.00, 5);

INSERT INTO Restaurante (tipo_cocina, especialidades, horario_apertura, horario_cierre, precio_promedio, precio_minimo, precio_maximo, id_oferta) 
VALUES ('Mariscos', 'Ceviche de pescado, Arroz con mariscos, Jalea', '11:00', '21:00', 50.00, 25.00, 100.00, 6);

-- Tabla Evento

INSERT INTO Evento (tipo_evento, epoca, capacidad, precio_entrada, fecha_evento, id_oferta) 
VALUES ('Cultural', 'Primavera', 500, 30.00, '2024-09-15', 7);

INSERT INTO Evento (tipo_evento, epoca, capacidad, precio_entrada, fecha_evento, id_oferta) 
VALUES ('Cultural', 'Verano', 1000, 20.00, '2024-02-20', 8);

INSERT INTO Evento (tipo_evento, epoca, capacidad, precio_entrada, fecha_evento, id_oferta) 
VALUES ('Cultural', 'Otoño', 700, 25.00, '2024-04-05', 9);


-- Tabla Atractivo Turístico

INSERT INTO Atractivo_Turistico (tipo_vegetacion, ubicacion_referencia, horario_apertura, horario_cierre, capacidad, id_oferta) 
VALUES ('Desértica', 'Cerca de la carretera principal', '08:00', '18:00', 100, 10);

INSERT INTO Atractivo_Turistico (tipo_vegetacion, ubicacion_referencia, horario_apertura, horario_cierre, capacidad, id_oferta) 
VALUES ('Desértica', 'Zona arqueológica de Miculla', '09:00', '17:00', 150, 11);

INSERT INTO Atractivo_Turistico (tipo_vegetacion, ubicacion_referencia, horario_apertura, horario_cierre, capacidad, id_oferta) 
VALUES ('Montañosa', 'Cercanías de Tacna, vistas a la ciudad', '06:00', '19:00', 200, 12);

-- Tabla Institución

INSERT INTO Institucion (tipo_institucion, servicios_disponibles, horario_apertura, horario_cierre, contacto_telefono, contacto_email, id_oferta) 
VALUES ('Centro Cultural', 'Exposiciones, Talleres, Biblioteca', '09:00', '20:00', '334455667', 'contacto@centroculturaltacna.com', 13);

INSERT INTO Institucion (tipo_institucion, servicios_disponibles, horario_apertura, horario_cierre, contacto_telefono, contacto_email, id_oferta) 
VALUES ('Museo', 'Exhibiciones históricas, Guías turísticas', '10:00', '18:00', '556677889', 'info@museotacna.com', 14);

INSERT INTO Institucion (tipo_institucion, servicios_disponibles, horario_apertura, horario_cierre, contacto_telefono, contacto_email, id_oferta) 
VALUES ('Biblioteca', 'Préstamo de libros, Sala de lectura, Archivos históricos', '08:00', '18:00', '667788990', 'contacto@bibliotecaregionaltacna.com', 15);


-- Tabla Etiqueta_Oferta

INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (1, 5);
INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (1, 4);
INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (2, 4);
INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (3, 5);

INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (4, 3);
INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (5, 3);
INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (6, 3);
INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (6, 2);

INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (7, 2);
INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (7, 10);
INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (8, 2);
INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (9, 2);

INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (10, 7);
INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (11, 7);
INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (12, 1);

INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (13, 10);
INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (14, 7);
INSERT INTO Etiqueta_Oferta (id_oferta, id_etiqueta) VALUES (15, 2);


-- Tabla Comentario/Contribucion

INSERT INTO Comentario (comentario, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Excelente servicio y ubicación céntrica.', 5, '2024-03-10', 'A', 1, 6);

INSERT INTO Comentario (comentario, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Muy acogedor y buena atención.', 4, '2024-03-11', 'A', 2, 7);

INSERT INTO Comentario (comentario, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Perfecto para un descanso frente al mar.', 5, '2024-03-12', 'A', 3, 8);

INSERT INTO Comentario (comentario, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Comida deliciosa, especialmente los asados.', 5, '2024-03-13', 'A', 4, 9);

INSERT INTO Comentario (comentario, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Ambiente familiar y agradable.', 4, '2024-03-14', 'A', 5, 10);

INSERT INTO Comentario (comentario, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Los mariscos estaban frescos y deliciosos.', 5, '2024-03-15', 'A', 6, 6);

INSERT INTO Comentario (comentario, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Un evento lleno de cultura y tradición.', 5, '2024-03-16', 'A', 7, 7);

INSERT INTO Comentario (comentario, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Muy divertido y colorido.', 4, '2024-03-17', 'A', 8, 8);

INSERT INTO Comentario (comentario, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Excelente ambiente para disfrutar de las uvas y el vino.', 5, '2024-03-18', 'A', 9, 9);

INSERT INTO Comentario (comentario, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Un lugar histórico impresionante.', 5, '2024-03-19', 'A', 10, 10);


-- Tabla Galeria

INSERT INTO Galeria (url_imagen, descripcion, tipo_imagen, fecha_subida, estado, id_oferta) 
VALUES ('https://example.com/hotel_tacna_plaza.jpg', 'Vista de la fachada del hotel', 'Foto', '2024-02-01', 'A', 1);

INSERT INTO Galeria (url_imagen, descripcion, tipo_imagen, fecha_subida, estado, id_oferta) 
VALUES ('https://example.com/hostal_valle_viejo.jpg', 'Entrada principal del hostal', 'Foto', '2024-02-02', 'A', 2);

INSERT INTO Galeria (url_imagen, descripcion, tipo_imagen, fecha_subida, estado, id_oferta) 
VALUES ('https://example.com/hotel_vista_del_mar.jpg', 'Vista desde la playa del hotel', 'Foto', '2024-02-03', 'A', 3);

INSERT INTO Galeria (url_imagen, descripcion, tipo_imagen, fecha_subida, estado, id_oferta) 
VALUES ('https://example.com/restaurante_el_fogon.jpg', 'Comedor principal del restaurante', 'Foto', '2024-02-04', 'A', 4);

INSERT INTO Galeria (url_imagen, descripcion, tipo_imagen, fecha_subida, estado, id_oferta) 
VALUES ('https://example.com/la_casona_del_valle.jpg', 'Jardines del restaurante', 'Foto', '2024-02-05', 'A', 5);

INSERT INTO Galeria (url_imagen, descripcion, tipo_imagen, fecha_subida, estado, id_oferta) 
VALUES ('https://example.com/marisqueria_boca_del_rio.jpg', 'Vista del comedor frente al mar', 'Foto', '2024-02-06', 'A', 6);

INSERT INTO Galeria (url_imagen, descripcion, tipo_imagen, fecha_subida, estado, id_oferta) 
VALUES ('https://example.com/festival_valle_viejo.jpg', 'Escenario principal del festival', 'Foto', '2024-02-07', 'A', 7);

INSERT INTO Galeria (url_imagen, descripcion, tipo_imagen, fecha_subida, estado, id_oferta) 
VALUES ('https://example.com/carnaval_tacna.jpg', 'Desfile principal del carnaval', 'Foto', '2024-02-08', 'A', 8);

INSERT INTO Galeria (url_imagen, descripcion, tipo_imagen, fecha_subida, estado, id_oferta) 
VALUES ('https://example.com/parque_alto_de_la_alianza.jpg', 'Monumento en el parque', 'Foto', '2024-02-09', 'A', 10);

INSERT INTO Galeria (url_imagen, descripcion, tipo_imagen, fecha_subida, estado, id_oferta) 
VALUES ('https://example.com/complejo_miculla.jpg', 'Petroglifos en el complejo arqueológico', 'Foto', '2024-02-10', 'A', 11);




-- Tabla Log de Visitas
--(Usar otro metodo?)

INSERT INTO Log_Visitas (fecha_visita, estado, id_oferta, id_usuario) 
VALUES ('2024-03-01', 'A', 1, 6);

INSERT INTO Log_Visitas (fecha_visita, estado, id_oferta, id_usuario) 
VALUES ('2024-03-02', 'A', 2, 7);

INSERT INTO Log_Visitas (fecha_visita, estado, id_oferta, id_usuario) 
VALUES ('2024-03-03', 'A', 3, 8);

INSERT INTO Log_Visitas (fecha_visita, estado, id_oferta, id_usuario) 
VALUES ('2024-03-04', 'A', 4, 9);

INSERT INTO Log_Visitas (fecha_visita, estado, id_oferta, id_usuario) 
VALUES ('2024-03-05', 'A', 5, 10);

INSERT INTO Log_Visitas (fecha_visita, estado, id_oferta, id_usuario) 
VALUES ('2024-03-06', 'A', 6, 6);

INSERT INTO Log_Visitas (fecha_visita, estado, id_oferta, id_usuario) 
VALUES ('2024-03-07', 'A', 7, 7);

INSERT INTO Log_Visitas (fecha_visita, estado, id_oferta, id_usuario) 
VALUES ('2024-03-08', 'A', 8, 8);

INSERT INTO Log_Visitas (fecha_visita, estado, id_oferta, id_usuario) 
VALUES ('2024-03-09', 'A', 10, 9);

INSERT INTO Log_Visitas (fecha_visita, estado, id_oferta, id_usuario) 
VALUES ('2024-03-10', 'A', 11, 10);



-- Tabla Preferencias de Usuario

-- Preferencias de usuarios por distintas etiquetas
INSERT INTO Preferencias_Usuario (estado, id_usuario, id_etiqueta) 
VALUES ('A', 6, 1);

INSERT INTO Preferencias_Usuario (estado, id_usuario, id_etiqueta) 
VALUES ('A', 7, 2);

INSERT INTO Preferencias_Usuario (estado, id_usuario, id_etiqueta) 
VALUES ('A', 8, 3);

INSERT INTO Preferencias_Usuario (estado, id_usuario, id_etiqueta) 
VALUES ('A', 9, 4);

INSERT INTO Preferencias_Usuario (estado, id_usuario, id_etiqueta) 
VALUES ('A', 10, 5);

INSERT INTO Preferencias_Usuario (estado, id_usuario, id_etiqueta) 
VALUES ('A', 6, 6);

INSERT INTO Preferencias_Usuario (estado, id_usuario, id_etiqueta) 
VALUES ('A', 7, 7);

INSERT INTO Preferencias_Usuario (estado, id_usuario, id_etiqueta) 
VALUES ('A', 8, 8);

INSERT INTO Preferencias_Usuario (estado, id_usuario, id_etiqueta) 
VALUES ('A', 9, 9);

INSERT INTO Preferencias_Usuario (estado, id_usuario, id_etiqueta) 
VALUES ('A', 10, 10);


-- Tabla Publicidad

-- Tabla Suscripción de Negocio

-- Tabla Reporte

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('El lugar estaba cerrado cuando intenté visitarlo.', '2024-03-01', 'A', 6, 1, 2, 1);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('Sugerencia de mejorar los servicios de internet.', '2024-03-02', 'A', 7, 2, 1, 2);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('Este lugar está duplicado en el sistema.', '2024-03-03', 'A', 8, 3, 3, 3);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('No se respetan los horarios indicados.', '2024-03-04', 'A', 9, 4, 2, 1);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('Sugerencia de añadir más opciones vegetarianas al menú.', '2024-03-05', 'A', 10, 5, 1, 2);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('El lugar parecía estar cerrado en horarios publicados.', '2024-03-06', 'A', 6, 6, 2, 3);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('Este evento está duplicado en el sistema.', '2024-03-07', 'A', 7, 7, 3, 1);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('Sugerencia de mejorar la limpieza del evento.', '2024-03-08', 'A', 8, 8, 1, 2);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('Este sitio está duplicado en el sistema.', '2024-03-09', 'A', 9, 10, 3, 3);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('Sugerencia de añadir más iluminación en el sitio.', '2024-03-10', 'A', 10, 11, 1, 1);


-- Tabla Foto de Comentario

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_hotel_tacna_plaza.jpg', 'Fachada del hotel visitado.', '2024-03-10', 'A', 1);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_hostal_valle_viejo.jpg', 'Vista desde la habitación.', '2024-03-11', 'A', 2);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_hotel_vista_del_mar.jpg', 'Vista al mar desde el hotel.', '2024-03-12', 'A', 3);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_restaurante_el_fogon.jpg', 'Asado servido en el restaurante.', '2024-03-13', 'A', 4);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_casona_valle.jpg', 'Vista del jardín del restaurante.', '2024-03-14', 'A', 5);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_marisqueria_boca.jpg', 'Comedor frente al mar.', '2024-03-15', 'A', 6);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_festival_valle.jpg', 'Escenario del festival.', '2024-03-16', 'A', 7);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_carnaval_tacna.jpg', 'Carro alegórico en el carnaval.', '2024-03-17', 'A', 8);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_parque_alianza.jpg', 'Monumento en el Parque Alto de la Alianza.', '2024-03-18', 'A', 10);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_miculla.jpg', 'Petroglifo en Miculla.', '2024-03-19', 'A', 10);
