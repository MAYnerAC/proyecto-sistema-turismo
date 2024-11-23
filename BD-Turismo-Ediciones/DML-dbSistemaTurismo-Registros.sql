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
INSERT INTO Tipo_Oferta (nombre_tipo, estado) VALUES ('Atractivo Tur�stico', 'A');
INSERT INTO Tipo_Oferta (nombre_tipo, estado) VALUES ('Instituci�n', 'A');


-- Tabla Tipo de Reporte

INSERT INTO Tipo_Reporte (nombre_tipo, estado) VALUES ('Sugerencia', 'A');
INSERT INTO Tipo_Reporte (nombre_tipo, estado) VALUES ('Lugar Cerrado', 'A');
INSERT INTO Tipo_Reporte (nombre_tipo, estado) VALUES ('Lugar Duplicado', 'A');

-- Tabla Estado de Reporte

INSERT INTO Estado_Reporte (nombre_estado) VALUES ('Pendiente');
INSERT INTO Estado_Reporte (nombre_estado) VALUES ('En Revisi�n');
INSERT INTO Estado_Reporte (nombre_estado) VALUES ('Revisado');


-- Tabla Etiqueta

INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Aventura', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Cultura', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Gastronom�a', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Naturaleza', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Relajaci�n', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Deportes', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Historia', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Aventura Nocturna', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Ecoturismo', 'A');
INSERT INTO Etiqueta (nombre_etiqueta, estado) VALUES ('Arte', 'A');


-- Tabla Destino

INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Tacna', 'Ciudad', 'Ciudad hist�rica del sur de Per�, conocida por sus eventos patri�ticos y comercio.', 'Per�', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Valle Viejo', 'Valle', 'Valle ubicado en las afueras de Tacna, famoso por su producci�n de vino y pisco.', 'Per�', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Pocollay', 'Distrito', 'Distrito tradicional de Tacna, conocido por sus festividades y cultura local.', 'Per�', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Alto de la Alianza', 'Sitio Hist�rico', 'Lugar hist�rico donde ocurri� la Batalla del Alto de la Alianza en 1880.', 'Per�', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Balneario Boca del R�o', 'Playa', 'Balneario popular en Tacna, ideal para disfrutar del sol y el mar.', 'Per�', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Candarave', 'Distrito', 'Distrito de Tacna conocido por sus aguas termales y geiseres naturales.', 'Per�', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Palca', 'Distrito', 'Distrito con hermosos paisajes monta�osos y el pintoresco valle de Palca.', 'Per�', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Laguna de Aricota', 'Lago', 'Hermosa laguna en la provincia de Candarave, popular para actividades recreativas.', 'Per�', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Complejo Arqueol�gico Miculla', 'Sitio Arqueol�gico', 'Sitio arqueol�gico con petroglifos preincaicos, un atractivo cultural de Tacna.', 'Per�', 'A');
INSERT INTO Destino (nombre_destino, tipo_destino, descripcion, pais, estado) VALUES ('Termas de Calientes', 'Aguas Termales', 'Aguas termales ubicadas en el distrito de Pach�a, popular por sus propiedades curativas.', 'Per�', 'A');


-- Tabla Usuario

INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Admin', 'Uno', 'admin1@example.com', 'hashed_password', '123456789', 1, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Admin', 'Dos', 'admin2@example.com', 'hashed_password', '987654321', 1, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Luis', 'Garc�a', 'proveedor1@example.com', 'hashed_password', '111222333', 2, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Marta', 'Fern�ndez', 'proveedor2@example.com', 'hashed_password', '444555666', 2, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Jorge', 'Mart�nez', 'proveedor3@example.com', 'hashed_password', '777888999', 2, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Ana', 'P�rez', 'cliente1@example.com', 'hashed_password', '101010101', 3, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Carlos', 'Ram�rez', 'cliente2@example.com', 'hashed_password', '202020202', 3, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Laura', 'S�nchez', 'cliente3@example.com', 'hashed_password', '303030303', 3, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Pedro', 'Morales', 'cliente4@example.com', 'hashed_password', '404040404', 3, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Sof�a', 'L�pez', 'cliente5@example.com', 'hashed_password', '505050505', 3, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Admin', 'Admin', 'admin@example.com', '123456', '123777789', 1, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('Prov', 'Prov', 'prov@example.com', '123456', '123888789', 2, 'A');
INSERT INTO Usuario (nombre, apellido, email, contrasena, telefono, id_tipo_usuario, estado) VALUES ('User', 'User', 'user@example.com', '123456', '123999789', 3, 'A');


-- Tabla Oferta con estado extendido

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Hotel Tacna Plaza', 'Hotel c�ntrico en Tacna, ideal para turistas y viajeros de negocios.', 'Calle Bol�var 456', -18.0096, -70.2463, '123456789', 'contacto@hoteltacna.com', 'www.hoteltacna.com', 'Propietario', 2, 1, 1, 'A', 'S', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Hostal Valle Viejo', 'Hostal acogedor en el Valle Viejo, con vistas espectaculares y ambiente familiar.', 'Av. Central 123', -18.0054, -70.2447, '234567890', 'reservas@hostalvalleviejo.com', 'www.hostalvalleviejo.com', 'Propietario', 3, 1, 2, 'A', 'N', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Hotel Vista del Mar', 'Hotel frente a la playa en el Balneario Boca del R�o, ideal para descansar.', 'Av. Costanera 456', -18.0125, -70.2510, '345678901', 'info@hotelvistadelmar.com', 'www.hotelvistadelmar.com', 'Propietario', 4, 1, 5, 'A', 'S', 'N');


INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Restaurante El Fog�n', 'Restaurante especializado en comida peruana y asados.', 'Av. Grau 789', -18.0125, -70.2510, '987654321', 'contacto@elfogon.com', 'www.elfogon.com', 'Propietario', 3, 2, 1, 'A', 'N', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('La Casona del Valle', 'Restaurante campestre con especialidad en comida criolla.', 'Av. Central 345', -18.0055, -70.2448, '456789012', 'reservas@lacasonadelvalle.com', 'www.lacasonadelvalle.com', 'Propietario', 4, 2, 2, 'A', 'S', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Marisquer�a Boca del R�o', 'Restaurante frente a la playa, especializado en mariscos frescos.', 'Costanera 123', -18.0130, -70.2520, '567890123', 'contacto@marisqueriabocadelrio.com', 'www.marisqueriabocadelrio.com', 'Propietario', 5, 2, 5, 'A', 'N', 'S');


INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Festival del Valle Viejo', 'Evento cultural que incluye m�sica, danza y comida t�pica en el Valle Viejo.', 'Plaza de Armas', -18.0054, -70.2447, '102030405', 'info@valleviejofestival.com', 'www.valleviejofestival.com', 'Organizador', 6, 3, 2, 'A', 'S', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Carnaval de Tacna', 'Celebraci�n tradicional con desfiles, danzas y m�sica.', 'Av. Bolognesi', -18.0137, -70.2490, '112233445', 'contacto@carnavaltacna.com', 'www.carnavaltacna.com', 'Organizador', 7, 3, 1, 'A', 'S', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Festival de la Vendimia', 'Evento anual de cosecha de uvas, con degustaciones y actividades culturales.', 'Campo de Vi�as', -18.0150, -70.2530, '223344556', 'info@festivalvendimia.com', 'www.festivalvendimia.com', 'Organizador', 8, 3, 2, 'A', 'N', 'S');


INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Parque Alto de la Alianza', 'Sitio hist�rico con monumentos y museos de la guerra del Pac�fico.', 'Alto de la Alianza', -18.0008, -70.2421, '112233445', 'info@parquealianza.com', 'www.parquealianza.com', 'Administrador', 9, 4, 4, 'A', 'S', 'N');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Complejo Arqueol�gico Miculla', 'Sitio arqueol�gico con petroglifos preincaicos, un atractivo cultural de Tacna.', 'Carretera Panamericana Sur', -18.0500, -70.3000, '334455667', 'info@miculla.com', 'www.miculla.com', 'Administrador', 10, 4, 9, 'A', 'S', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Cerro Intiorko', 'Monta�a sagrada para los pobladores locales, con vistas espectaculares de la ciudad.', 'Cercan�as de Tacna', -18.0030, -70.2400, '445566778', 'contacto@intiorko.com', 'www.intiorko.com', 'Administrador', 1, 4, 1, 'A', 'N', 'S');


INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Centro Cultural de Tacna', 'Centro cultural para eventos y actividades culturales en Tacna.', 'Av. Bolognesi 123', -18.0137, -70.2490, '334455667', 'contacto@centroculturaltacna.com', 'www.centroculturaltacna.com', 'Operador', 7, 5, 1, 'A', 'N', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Museo Ferroviario de Tacna', 'Museo dedicado a la historia ferroviaria de Tacna.', 'Estaci�n de Trenes de Tacna', -18.0080, -70.2505, '556677889', 'info@museotacna.com', 'www.museotacna.com', 'Administrador', 8, 5, 1, 'A', 'S', 'S');

INSERT INTO Oferta (nombre, descripcion, direccion, ubicacion_lat, ubicacion_lon, telefono, email_contacto, sitio_web, vinculo_con_oferta, id_usuario, id_tipo_oferta, id_destino, estado, verificado, visible) 
VALUES ('Biblioteca Regional de Tacna', 'Biblioteca p�blica con una amplia colecci�n de libros y documentos hist�ricos.', 'Av. San Mart�n 456', -18.0105, -70.2485, '667788990', 'contacto@bibliotecaregionaltacna.com', 'www.bibliotecaregionaltacna.com', 'Administrador', 9, 5, 1, 'A', 'N', 'S');


-- Tabla Hospedaje

INSERT INTO Hospedaje (categoria, precio_minimo, precio_maximo, horario_checkin, horario_checkout, servicios_adicionales, capacidad, id_oferta) 
VALUES ('Hotel 3 Estrellas', 120.00, 250.00, '14:00', '11:00', 'WiFi, Desayuno incluido, Piscina', 50, 1);

INSERT INTO Hospedaje (categoria, precio_minimo, precio_maximo, horario_checkin, horario_checkout, servicios_adicionales, capacidad, id_oferta) 
VALUES ('Hostal Familiar', 40.00, 90.00, '13:00', '12:00', 'WiFi, Cocina compartida', 20, 2);

INSERT INTO Hospedaje (categoria, precio_minimo, precio_maximo, horario_checkin, horario_checkout, servicios_adicionales, capacidad, id_oferta) 
VALUES ('Hotel 4 Estrellas', 150.00, 300.00, '15:00', '11:00', 'WiFi, Desayuno, Piscina, Frente a la playa', 80, 3);


-- Tabla Restaurante

INSERT INTO Restaurante (tipo_cocina, especialidades, horario_apertura, horario_cierre, precio_promedio, precio_minimo, precio_maximo, id_oferta) 
VALUES ('Peruana', 'Ceviche, Lomo Saltado, Aj� de Gallina', '09:00', '23:00', 40.00, 20.00, 80.00, 4);

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
VALUES ('Cultural', 'Oto�o', 700, 25.00, '2024-04-05', 9);


-- Tabla Atractivo Tur�stico

INSERT INTO Atractivo_Turistico (tipo_vegetacion, ubicacion_referencia, horario_apertura, horario_cierre, capacidad, id_oferta) 
VALUES ('Des�rtica', 'Cerca de la carretera principal', '08:00', '18:00', 100, 10);

INSERT INTO Atractivo_Turistico (tipo_vegetacion, ubicacion_referencia, horario_apertura, horario_cierre, capacidad, id_oferta) 
VALUES ('Des�rtica', 'Zona arqueol�gica de Miculla', '09:00', '17:00', 150, 11);

INSERT INTO Atractivo_Turistico (tipo_vegetacion, ubicacion_referencia, horario_apertura, horario_cierre, capacidad, id_oferta) 
VALUES ('Monta�osa', 'Cercan�as de Tacna, vistas a la ciudad', '06:00', '19:00', 200, 12);

-- Tabla Instituci�n

INSERT INTO Institucion (tipo_institucion, servicios_disponibles, horario_apertura, horario_cierre, contacto_telefono, contacto_email, id_oferta) 
VALUES ('Centro Cultural', 'Exposiciones, Talleres, Biblioteca', '09:00', '20:00', '334455667', 'contacto@centroculturaltacna.com', 13);

INSERT INTO Institucion (tipo_institucion, servicios_disponibles, horario_apertura, horario_cierre, contacto_telefono, contacto_email, id_oferta) 
VALUES ('Museo', 'Exhibiciones hist�ricas, Gu�as tur�sticas', '10:00', '18:00', '556677889', 'info@museotacna.com', 14);

INSERT INTO Institucion (tipo_institucion, servicios_disponibles, horario_apertura, horario_cierre, contacto_telefono, contacto_email, id_oferta) 
VALUES ('Biblioteca', 'Pr�stamo de libros, Sala de lectura, Archivos hist�ricos', '08:00', '18:00', '667788990', 'contacto@bibliotecaregionaltacna.com', 15);


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

INSERT INTO Comentario (contenido, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Excelente servicio y ubicaci�n c�ntrica.', 5, '2024-03-10', 'A', 1, 6);

INSERT INTO Comentario (contenido, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Muy acogedor y buena atenci�n.', 4, '2024-03-11', 'A', 2, 7);

INSERT INTO Comentario (contenido, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Perfecto para un descanso frente al mar.', 5, '2024-03-12', 'A', 3, 8);

INSERT INTO Comentario (contenido, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Comida deliciosa, especialmente los asados.', 5, '2024-03-13', 'A', 4, 9);

INSERT INTO Comentario (contenido, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Ambiente familiar y agradable.', 4, '2024-03-14', 'A', 5, 10);

INSERT INTO Comentario (contenido, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Los mariscos estaban frescos y deliciosos.', 5, '2024-03-15', 'A', 6, 6);

INSERT INTO Comentario (contenido, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Un evento lleno de cultura y tradici�n.', 5, '2024-03-16', 'A', 7, 7);

INSERT INTO Comentario (contenido, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Muy divertido y colorido.', 4, '2024-03-17', 'A', 8, 8);

INSERT INTO Comentario (contenido, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Excelente ambiente para disfrutar de las uvas y el vino.', 5, '2024-03-18', 'A', 9, 9);

INSERT INTO Comentario (contenido, puntuacion, fecha_comentario, estado, id_oferta, id_usuario) 
VALUES ('Un lugar hist�rico impresionante.', 5, '2024-03-19', 'A', 10, 10);


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
VALUES ('https://example.com/complejo_miculla.jpg', 'Petroglifos en el complejo arqueol�gico', 'Foto', '2024-02-10', 'A', 11);




-- Tabla Log de Visitas
--(Usar otro metodo?)

INSERT INTO Log_Visitas (fecha_visita, id_oferta, id_usuario) 
VALUES ('2024-03-01', 1, 6);

INSERT INTO Log_Visitas (fecha_visita, id_oferta, id_usuario) 
VALUES ('2024-03-02', 2, 7);

INSERT INTO Log_Visitas (fecha_visita, id_oferta, id_usuario) 
VALUES ('2024-03-03', 3, 8);

INSERT INTO Log_Visitas (fecha_visita, id_oferta, id_usuario) 
VALUES ('2024-03-04', 4, 9);

INSERT INTO Log_Visitas (fecha_visita, id_oferta, id_usuario) 
VALUES ('2024-03-05', 5, 10);

INSERT INTO Log_Visitas (fecha_visita, id_oferta, id_usuario) 
VALUES ('2024-03-06', 6, 6);

INSERT INTO Log_Visitas (fecha_visita, id_oferta, id_usuario) 
VALUES ('2024-03-07', 7, 7);

INSERT INTO Log_Visitas (fecha_visita, id_oferta, id_usuario) 
VALUES ('2024-03-08', 8, 8);

INSERT INTO Log_Visitas (fecha_visita, id_oferta, id_usuario) 
VALUES ('2024-03-09', 10, 9);

INSERT INTO Log_Visitas (fecha_visita, id_oferta, id_usuario) 
VALUES ('2024-03-10', 11, 10);



-- Tabla Preferencias de Usuario

-- Preferencias de usuarios por distintas etiquetas
INSERT INTO Preferencias_Usuario (id_usuario, id_etiqueta) 
VALUES (6, 1);

INSERT INTO Preferencias_Usuario (id_usuario, id_etiqueta) 
VALUES (7, 2);

INSERT INTO Preferencias_Usuario (id_usuario, id_etiqueta) 
VALUES (8, 3);

INSERT INTO Preferencias_Usuario (id_usuario, id_etiqueta) 
VALUES (9, 4);

INSERT INTO Preferencias_Usuario (id_usuario, id_etiqueta) 
VALUES (10, 5);

INSERT INTO Preferencias_Usuario (id_usuario, id_etiqueta) 
VALUES (6, 6);

INSERT INTO Preferencias_Usuario (id_usuario, id_etiqueta) 
VALUES (7, 7);

INSERT INTO Preferencias_Usuario (id_usuario, id_etiqueta) 
VALUES (8, 8);

INSERT INTO Preferencias_Usuario (id_usuario, id_etiqueta) 
VALUES (9, 9);

INSERT INTO Preferencias_Usuario (id_usuario, id_etiqueta) 
VALUES (10, 10);


-- Tabla Publicidad

-- Tabla Suscripci�n de Negocio

-- Tabla Reporte

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('El lugar estaba cerrado cuando intent� visitarlo.', '2024-03-01', 'A', 6, 1, 2, 1);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('Sugerencia de mejorar los servicios de internet.', '2024-03-02', 'A', 7, 2, 1, 2);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('Este lugar est� duplicado en el sistema.', '2024-03-03', 'A', 8, 3, 3, 3);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('No se respetan los horarios indicados.', '2024-03-04', 'A', 9, 4, 2, 1);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('Sugerencia de a�adir m�s opciones vegetarianas al men�.', '2024-03-05', 'A', 10, 5, 1, 2);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('El lugar parec�a estar cerrado en horarios publicados.', '2024-03-06', 'A', 6, 6, 2, 3);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('Este evento est� duplicado en el sistema.', '2024-03-07', 'A', 7, 7, 3, 1);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('Sugerencia de mejorar la limpieza del evento.', '2024-03-08', 'A', 8, 8, 1, 2);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('Este sitio est� duplicado en el sistema.', '2024-03-09', 'A', 9, 10, 3, 3);

INSERT INTO Reporte (descripcion, fecha_reporte, estado, id_usuario, id_oferta, id_tipo_reporte, id_estado_reporte) 
VALUES ('Sugerencia de a�adir m�s iluminaci�n en el sitio.', '2024-03-10', 'A', 10, 11, 1, 1);


-- Tabla Foto de Comentario

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_hotel_tacna_plaza.jpg', 'Fachada del hotel visitado.', '2024-03-10', 'A', 1);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_hostal_valle_viejo.jpg', 'Vista desde la habitaci�n.', '2024-03-11', 'A', 2);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_hotel_vista_del_mar.jpg', 'Vista al mar desde el hotel.', '2024-03-12', 'A', 3);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_restaurante_el_fogon.jpg', 'Asado servido en el restaurante.', '2024-03-13', 'A', 4);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_casona_valle.jpg', 'Vista del jard�n del restaurante.', '2024-03-14', 'A', 5);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_marisqueria_boca.jpg', 'Comedor frente al mar.', '2024-03-15', 'A', 6);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_festival_valle.jpg', 'Escenario del festival.', '2024-03-16', 'A', 7);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_carnaval_tacna.jpg', 'Carro aleg�rico en el carnaval.', '2024-03-17', 'A', 8);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_parque_alianza.jpg', 'Monumento en el Parque Alto de la Alianza.', '2024-03-18', 'A', 10);

INSERT INTO Foto_Comentario (url_foto, descripcion, fecha_subida, estado, id_comentario) 
VALUES ('https://example.com/foto_miculla.jpg', 'Petroglifo en Miculla.', '2024-03-19', 'A', 10);
