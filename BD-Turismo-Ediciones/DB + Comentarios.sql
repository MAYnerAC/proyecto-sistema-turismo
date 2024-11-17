-- Creación de la base de datos
CREATE DATABASE dbSistemaTurismo;
GO

USE dbSistemaTurismo;
GO

-- Tabla Tipo de Usuario
CREATE TABLE Tipo_Usuario (
    id_tipo_usuario INT PRIMARY KEY IDENTITY(1,1),       -- Identificador único del tipo de usuario
    nombre_tipo VARCHAR(50) NOT NULL UNIQUE,             -- Nombre del tipo de usuario (ej. 'admin', 'proveedor')
    estado CHAR(1) DEFAULT 'A'                           -- Estado del tipo de usuario ('A' = Activo, 'I' = Inactivo)
);

-- Tabla Tipo de Oferta
CREATE TABLE Tipo_Oferta (
    id_tipo_oferta INT PRIMARY KEY IDENTITY(1,1),        -- Identificador único del tipo de oferta
    nombre_tipo VARCHAR(50) NOT NULL UNIQUE,             -- Nombre del tipo de oferta (ej. 'restaurante', 'hospedaje')
    estado CHAR(1) DEFAULT 'A'                           -- Estado del tipo de oferta ('A' = Activo, 'I' = Inactivo)
);

-- Tabla Tipo de Reporte
CREATE TABLE Tipo_Reporte (
    id_tipo_reporte INT PRIMARY KEY IDENTITY(1,1),       -- Identificador único del tipo de reporte
    nombre_tipo VARCHAR(50) NOT NULL UNIQUE,             -- Nombre del tipo de reporte (ej. 'Lugar Cerrado', 'Duplicado')
    estado CHAR(1) DEFAULT 'A'                           -- Estado del tipo de reporte ('A' = Activo, 'I' = Inactivo)
);

-- Tabla Estado de Reporte
CREATE TABLE Estado_Reporte (
    id_estado_reporte INT PRIMARY KEY IDENTITY(1,1),     -- Identificador único del estado del reporte
    nombre_estado VARCHAR(50) NOT NULL UNIQUE            -- Nombre del estado (ej. 'Pendiente', 'Revisado')
);

-- Tabla Etiqueta
CREATE TABLE Etiqueta (
    id_etiqueta INT PRIMARY KEY IDENTITY(1,1),           -- Identificador único de la etiqueta
    nombre_etiqueta VARCHAR(50) NOT NULL UNIQUE,         -- Nombre de la etiqueta (ej. 'Wi-Fi gratis')
    estado CHAR(1) DEFAULT 'A'                           -- Estado de la etiqueta ('A' = Activo, 'I' = Inactivo)
);

-- Tabla Destino
CREATE TABLE Destino (
    id_destino INT PRIMARY KEY IDENTITY(1,1),            -- Identificador único del destino
    nombre_destino VARCHAR(100) NOT NULL UNIQUE,         -- Nombre del destino (ej. 'Cusco')
    tipo_destino VARCHAR(50),                            -- Tipo de destino (ej. 'Ciudad', 'Parque Nacional')
    descripcion TEXT,                                    -- Descripción del destino
    pais VARCHAR(100) NOT NULL,                          -- País donde se ubica el destino
    estado CHAR(1) DEFAULT 'A'                           -- Estado del destino ('A' = Activo, 'I' = Inactivo)
);

-- Tabla Usuario
CREATE TABLE Usuario (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),            -- Identificador único del usuario
    nombre VARCHAR(100) NOT NULL,                        -- Nombre del usuario
    email VARCHAR(100) NOT NULL UNIQUE,                  -- Email del usuario, único
    contrasena VARCHAR(255) NOT NULL,                    -- Contraseña del usuario
    telefono VARCHAR(15) NULL,                           -- Teléfono del usuario
    id_tipo_usuario INT NOT NULL,                        -- Relación con el tipo de usuario
    fecha_registro DATE DEFAULT GETDATE(),               -- Fecha de registro del usuario
    estado CHAR(1) DEFAULT 'A',                          -- Estado del usuario ('A' = Activo, 'I' = Inactivo)
    FOREIGN KEY (id_tipo_usuario) REFERENCES Tipo_Usuario(id_tipo_usuario)
);

-- Tabla Oferta con estado extendido
CREATE TABLE Oferta (
    id_oferta INT PRIMARY KEY IDENTITY(1,1),             -- Identificador único de la oferta
    nombre VARCHAR(100) NOT NULL,                        -- Nombre de la oferta
    descripcion TEXT,                                    -- Descripción de la oferta
    direccion VARCHAR(200),                              -- Dirección física de la oferta
    ubicacion_lat DECIMAL(9,6),                          -- Latitud para la ubicación geográfica
    ubicacion_lon DECIMAL(9,6),                          -- Longitud para la ubicación geográfica
    telefono VARCHAR(15),                                -- Teléfono de contacto de la oferta
    email_contacto VARCHAR(100),                         -- Correo electrónico de contacto
    sitio_web VARCHAR(200),                              -- URL del sitio web de la oferta
    vinculo_con_oferta VARCHAR(50),                      -- Relación con el negocio (Propietario, etc.)
    id_usuario INT NOT NULL,                             -- Relación con el usuario que creó la oferta
    id_tipo_oferta INT NOT NULL,                         -- Relación con el tipo de oferta
    id_destino INT NULL,                                 -- Relación opcional con el destino
    fecha_creacion DATE DEFAULT GETDATE(),               -- Fecha de creación de la oferta
    estado CHAR(1) DEFAULT 'A',                          -- Estado de la oferta ('A' = Activo, 'I' = Inactivo)
    verificado CHAR(1) DEFAULT 'N',                      -- Verificación de la oferta ('S' = Sí, 'N' = No)
    visible CHAR(1) DEFAULT 'N',                         -- Visibilidad de la oferta ('S' = Sí, 'N' = No)
    fecha_baja DATE NULL,                                -- Fecha de baja de la oferta
    motivo_baja TEXT NULL,                               -- Motivo de baja de la oferta
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    FOREIGN KEY (id_tipo_oferta) REFERENCES Tipo_Oferta(id_tipo_oferta),
    FOREIGN KEY (id_destino) REFERENCES Destino(id_destino)
);

-- Tabla Hospedaje
CREATE TABLE Hospedaje (
    id_hospedaje INT PRIMARY KEY IDENTITY(1,1),          -- Identificador único del hospedaje
    categoria VARCHAR(50) NOT NULL,                      -- Categoría del hospedaje (ej. 'Hotel')
    precio_minimo DECIMAL(10, 2) NOT NULL,               -- Precio mínimo del hospedaje
    precio_maximo DECIMAL(10, 2) NOT NULL,               -- Precio máximo del hospedaje
    horario_checkin TIME NOT NULL,                       -- Hora de entrada
    horario_checkout TIME NOT NULL,                      -- Hora de salida
    servicios_adicionales TEXT NULL,                     -- Servicios adicionales del hospedaje
    capacidad INT NULL,                                  -- Capacidad del hospedaje
    id_oferta INT NOT NULL UNIQUE,                              -- Relación con la oferta
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);

-- Tabla Restaurante
CREATE TABLE Restaurante (
    id_restaurante INT PRIMARY KEY IDENTITY(1,1),        -- Identificador único del restaurante
    tipo_cocina VARCHAR(50) NOT NULL,                    -- Tipo de cocina del restaurante
    especialidades TEXT NULL,                            -- Especialidades del restaurante
    horario_apertura TIME NOT NULL,                      -- Hora de apertura
    horario_cierre TIME NOT NULL,                        -- Hora de cierre
    precio_promedio DECIMAL(10, 2) NULL,                 -- Precio promedio por persona
    precio_minimo DECIMAL(10, 2) NULL,                   -- Precio mínimo por persona
    precio_maximo DECIMAL(10, 2) NULL,                   -- Precio máximo por persona
    id_oferta INT NOT NULL UNIQUE,                              -- Relación con la oferta
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);

-- Tabla Evento
CREATE TABLE Evento (
    id_evento INT PRIMARY KEY IDENTITY(1,1),             -- Identificador único del evento
    tipo_evento VARCHAR(50) NOT NULL,                    -- Tipo de evento (ej. 'Concierto')
    epoca VARCHAR(50) NULL,                              -- Época del evento
    capacidad INT NULL,                                  -- Capacidad de asistentes
    precio_entrada DECIMAL(10, 2) NULL,                  -- Precio de entrada
    fecha_evento DATE NOT NULL,                          -- Fecha específica del evento
    id_oferta INT NOT NULL UNIQUE,                              -- Relación con la oferta
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);

-- Tabla Atractivo Turístico
CREATE TABLE Atractivo_Turistico (
    id_atractivo INT PRIMARY KEY IDENTITY(1,1),          -- Identificador único del atractivo turístico
    tipo_vegetacion VARCHAR(50) NULL,                    -- Tipo de vegetación del atractivo
    ubicacion_referencia VARCHAR(200) NULL,              -- Ubicación de referencia
    horario_apertura TIME NOT NULL,                      -- Hora de apertura
    horario_cierre TIME NOT NULL,                        -- Hora de cierre
    capacidad INT NULL,                                  -- Capacidad de visitantes
    id_oferta INT NOT NULL UNIQUE,                              -- Relación con la oferta
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);

-- Tabla Institución
CREATE TABLE Institucion (
    id_institucion INT PRIMARY KEY IDENTITY(1,1),        -- Identificador único de la institución
    tipo_institucion VARCHAR(50) NOT NULL,               -- Tipo de institución (ej. 'Centro Cultural')
    servicios_disponibles TEXT NULL,                     -- Servicios disponibles en la institución
    horario_apertura TIME NOT NULL,                      -- Hora de apertura
    horario_cierre TIME NOT NULL,                        -- Hora de cierre
    contacto_telefono VARCHAR(15) NULL,                  -- Teléfono de contacto
    contacto_email VARCHAR(100) NULL,                    -- Email de contacto
    id_oferta INT NOT NULL UNIQUE,                              -- Relación con la oferta
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);

-- Tabla Etiqueta_Oferta
CREATE TABLE Etiqueta_Oferta (
    id_etiqueta_oferta INT PRIMARY KEY IDENTITY(1,1),    -- Identificador único de la relación etiqueta-oferta
    id_oferta INT NOT NULL,                              -- Relación con la oferta
    id_etiqueta INT NOT NULL,                            -- Relación con la etiqueta
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta),
    FOREIGN KEY (id_etiqueta) REFERENCES Etiqueta(id_etiqueta)
);

-- Tabla Comentario/Contribución
CREATE TABLE Comentario (
    id_comentario INT PRIMARY KEY IDENTITY(1,1),         -- Identificador único del comentario
    comentario TEXT NOT NULL,                            -- Contenido del comentario
    puntuacion INT,                                      -- Puntuación del comentario
    fecha_comentario DATE DEFAULT GETDATE(),             -- Fecha del comentario
    estado CHAR(1) DEFAULT 'A',                          -- Estado del comentario ('A' = Activo, 'I' = Inactivo)
    id_oferta INT NOT NULL,                              -- Relación con la oferta
    id_usuario INT NOT NULL,                             -- Relación con el usuario que comentó
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

-- Tabla Galeria
CREATE TABLE Galeria (
    id_imagen INT PRIMARY KEY IDENTITY(1,1),             -- Identificador único de la imagen
    url_imagen VARCHAR(200) NOT NULL,                    -- URL de la imagen
    descripcion VARCHAR(255) NULL,                       -- Descripción de la imagen
    tipo_imagen VARCHAR(50) NULL,                        -- Tipo de imagen (ej. 'miniatura')
    fecha_subida DATE DEFAULT GETDATE(),                 -- Fecha de subida de la imagen
    estado CHAR(1) DEFAULT 'A',                          -- Estado de la imagen ('A' = Activa, 'I' = Inactiva)
    id_oferta INT NOT NULL,                              -- Relación con la oferta
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);

-- Tabla Log de Visitas
CREATE TABLE Log_Visitas (
    id_log INT PRIMARY KEY IDENTITY(1,1),                -- Identificador único del log de visitas
    fecha_visita DATE DEFAULT GETDATE(),                 -- Fecha de la visita
--    estado CHAR(1) DEFAULT 'A',                          -- Estado del log ('A' = Activo, 'I' = Inactivo)
    id_oferta INT NOT NULL,                              -- Relación con la oferta
    id_usuario INT,                                      -- Relación con el usuario que visitó
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

-- Tabla Preferencias de Usuario
CREATE TABLE Preferencias_Usuario (
    id_preferencia INT PRIMARY KEY IDENTITY(1,1),        -- Identificador único de la preferencia
--    estado CHAR(1) DEFAULT 'A',                          -- Estado de la preferencia ('A' = Activo, 'I' = Inactivo)
    id_usuario INT NOT NULL,                             -- Relación con el usuario
    id_etiqueta INT NULL,                                -- Relación con la etiqueta
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    FOREIGN KEY (id_etiqueta) REFERENCES Etiqueta(id_etiqueta)
);

-- Tabla Publicidad
CREATE TABLE Publicidad (
    id_publicidad INT PRIMARY KEY IDENTITY(1,1),         -- Identificador único de la publicidad
    tipo_publicidad VARCHAR(50) NOT NULL,                -- Tipo de publicidad (ej. 'Banner')
    fecha_inicio DATE NOT NULL,                          -- Fecha de inicio de la publicidad
    fecha_fin DATE NOT NULL,                             -- Fecha de fin de la publicidad
    prioridad INT,                                       -- Nivel de prioridad de la publicidad
    estado CHAR(1) DEFAULT 'A',                          -- Estado de la publicidad ('A' = Activa, 'I' = Inactiva)
    id_oferta INT NOT NULL,                              -- Relación con la oferta
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);

-- Tabla Suscripción de Negocio
CREATE TABLE Suscripcion_Negocio (
    id_suscripcion INT PRIMARY KEY IDENTITY(1,1),        -- Identificador único de la suscripción
    tipo_plan VARCHAR(50) NOT NULL,                      -- Tipo de plan de suscripción
    fecha_inicio DATE NOT NULL,                          -- Fecha de inicio de la suscripción
    fecha_expiracion DATE NOT NULL,                      -- Fecha de expiración de la suscripción
    estado CHAR(1) DEFAULT 'A',                          -- Estado de la suscripción ('A' = Activa, 'I' = Inactiva)
    id_oferta INT NOT NULL,                              -- Relación con la oferta
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);

-- Tabla Reporte
CREATE TABLE Reporte (
    id_reporte INT PRIMARY KEY IDENTITY(1,1),            -- Identificador único del reporte
    descripcion TEXT,                                    -- Descripción del reporte
    fecha_reporte DATE DEFAULT GETDATE(),                -- Fecha del reporte
    estado CHAR(1) DEFAULT 'A',                          -- Estado del reporte ('A' = Activo, 'I' = Inactivo)
    id_usuario INT NOT NULL,                             -- Relación con el usuario que reporta
    id_oferta INT NULL,                                  -- Relación con la oferta (si aplica)
    id_destino INT NULL,                                 -- Relación con el destino (si aplica)
    id_tipo_reporte INT NOT NULL,                        -- Relación con el tipo de reporte
    id_estado_reporte INT NOT NULL,                      -- Relación con el estado del reporte
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta),
    FOREIGN KEY (id_destino) REFERENCES Destino(id_destino),
    FOREIGN KEY (id_tipo_reporte) REFERENCES Tipo_Reporte(id_tipo_reporte),
    FOREIGN KEY (id_estado_reporte) REFERENCES Estado_Reporte(id_estado_reporte)
);

-- Tabla Foto de Comentario
CREATE TABLE Foto_Comentario (
    id_foto INT PRIMARY KEY IDENTITY(1,1),               -- Identificador único de la foto del comentario
    url_foto VARCHAR(255) NOT NULL,                      -- URL de la foto
    descripcion VARCHAR(255),                            -- Descripción de la foto
    fecha_subida DATE DEFAULT GETDATE(),                 -- Fecha de subida de la foto
    estado CHAR(1) DEFAULT 'A',                          -- Estado de la foto ('A' = Activa, 'I' = Inactiva)
    id_comentario INT NOT NULL,                          -- Relación con el comentario
    FOREIGN KEY (id_comentario) REFERENCES Comentario(id_comentario)
);

-- Explicación de estados(Tabla Oferta u Oferta Turistica):
-- verificado = 'S', visible = 'N': El servicio ha sido aprobado pero no se muestra aún al público.
-- verificado = 'N', visible = 'S': El servicio es visible sin aprobación formal (caso raro).
-- verificado = 'S', visible = 'S': El servicio está aprobado y visible al público.
-- verificado = 'N', visible = 'N': Estado inicial, el servicio no está aprobado ni visible.


--Explora más cosas de nuestros patrocinadores - WORD


/*
-- Tabla Solicitud de Verificación de Proveedor
CREATE TABLE Solicitud_Verificacion_Proveedor (
    id_solicitud INT PRIMARY KEY IDENTITY(1,1),
    id_usuario INT NOT NULL,                        -- Usuario que solicita la verificación
    fecha_solicitud DATE DEFAULT GETDATE(),         -- Fecha de creación de la solicitud
    estado CHAR(1) DEFAULT 'P',                     -- Estado de la solicitud ('P' = Pendiente, 'A' = Aprobado, 'R' = Rechazado)
    comentarios_admin TEXT,                         -- Comentarios del administrador
    fecha_resolucion DATE NULL,                     -- Fecha en la que se resolvió la solicitud
    id_admin INT NULL,                              -- Administrador que revisó la solicitud
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    FOREIGN KEY (id_admin) REFERENCES Usuario(id_usuario)
);
*/