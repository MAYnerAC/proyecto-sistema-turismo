-- Creación de la base de datos
CREATE DATABASE dbSistemaTurismo;
GO

USE dbSistemaTurismo;
GO

-- Tabla Tipo de Usuario
CREATE TABLE Tipo_Usuario (
    id_tipo_usuario INT PRIMARY KEY IDENTITY(1,1),
    nombre_tipo VARCHAR(50) NOT NULL UNIQUE,
    estado CHAR(1) DEFAULT 'A'
);

-- Tabla Tipo de Oferta
CREATE TABLE Tipo_Oferta (
    id_tipo_oferta INT PRIMARY KEY IDENTITY(1,1),
    nombre_tipo VARCHAR(50) NOT NULL UNIQUE,
    estado CHAR(1) DEFAULT 'A'
);
-- Tabla Etiqueta
CREATE TABLE Etiqueta (
    id_etiqueta INT PRIMARY KEY IDENTITY(1,1),
    nombre_etiqueta VARCHAR(50) NOT NULL UNIQUE,
    estado CHAR(1) DEFAULT 'A'
);

-- Tabla Destino
CREATE TABLE Destino (
    id_destino INT PRIMARY KEY IDENTITY(1,1),
    nombre_destino VARCHAR(100) NOT NULL UNIQUE,
    tipo_destino VARCHAR(50),
    descripcion VARCHAR(MAX),
    pais VARCHAR(100) NOT NULL,
    estado CHAR(1) DEFAULT 'A'
);

-- Tabla Usuario
CREATE TABLE Usuario (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    contrasena VARCHAR(255) NOT NULL,
    telefono VARCHAR(15) NULL,
    id_tipo_usuario INT NOT NULL,
    fecha_registro DATE DEFAULT GETDATE(),
    estado CHAR(1) DEFAULT 'A',
    FOREIGN KEY (id_tipo_usuario) REFERENCES Tipo_Usuario(id_tipo_usuario)
);


-- Tabla Oferta con estado extendido
CREATE TABLE Oferta (
    id_oferta INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    descripcion VARCHAR(MAX),
    direccion VARCHAR(200),
    ubicacion_lat DECIMAL(9,6),
    ubicacion_lon DECIMAL(9,6),
    telefono VARCHAR(15),
    email_contacto VARCHAR(100),
    sitio_web VARCHAR(200),
    vinculo_con_oferta VARCHAR(50),
    id_usuario INT NOT NULL,
    id_tipo_oferta INT NOT NULL,
    id_destino INT NULL,
    fecha_creacion DATE DEFAULT GETDATE(),
    estado CHAR(1) DEFAULT 'A',
    verificado CHAR(1) DEFAULT 'N',
    visible CHAR(1) DEFAULT 'N',
    fecha_baja DATE NULL,
    motivo_baja VARCHAR(MAX) NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    FOREIGN KEY (id_tipo_oferta) REFERENCES Tipo_Oferta(id_tipo_oferta),
    FOREIGN KEY (id_destino) REFERENCES Destino(id_destino)
);

-- Tabla Etiqueta_Oferta
CREATE TABLE Etiqueta_Oferta (
    id_etiqueta_oferta INT PRIMARY KEY IDENTITY(1,1),
    id_oferta INT NOT NULL,
    id_etiqueta INT NOT NULL,
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta),
    FOREIGN KEY (id_etiqueta) REFERENCES Etiqueta(id_etiqueta)
);

-- Tabla Comentario/Contribucion
CREATE TABLE Comentario (
    id_comentario INT PRIMARY KEY IDENTITY(1,1),
    contenido VARCHAR(MAX) NOT NULL,
    puntuacion INT,
    fecha_comentario DATE DEFAULT GETDATE(),
    estado CHAR(1) DEFAULT 'A',
    id_oferta INT NOT NULL,
    id_usuario INT NOT NULL,
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

-- Tabla Galeria
CREATE TABLE Galeria (
    id_imagen INT PRIMARY KEY IDENTITY(1,1),
    url_imagen VARCHAR(200) NOT NULL,
    descripcion VARCHAR(255) NULL,
    tipo_imagen VARCHAR(50) NULL,
    fecha_subida DATE DEFAULT GETDATE(),
    estado CHAR(1) DEFAULT 'A',
    id_oferta INT NOT NULL,
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);




-- Tabla Preferencias de Usuario
CREATE TABLE Preferencias_Usuario (
    id_preferencia INT PRIMARY KEY IDENTITY(1,1),
    id_usuario INT NOT NULL,
    id_etiqueta INT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    FOREIGN KEY (id_etiqueta) REFERENCES Etiqueta(id_etiqueta)
);



-- Tabla Foto de Comentario
CREATE TABLE Foto_Comentario (
    id_foto INT PRIMARY KEY IDENTITY(1,1),
    url_foto VARCHAR(255) NOT NULL,
    descripcion VARCHAR(255),
    fecha_subida DATE DEFAULT GETDATE(),
    estado CHAR(1) DEFAULT 'A',
    id_comentario INT NOT NULL,
    FOREIGN KEY (id_comentario) REFERENCES Comentario(id_comentario)
);





/*
-- Tabla Tipo de Reporte
CREATE TABLE Tipo_Reporte (
    id_tipo_reporte INT PRIMARY KEY IDENTITY(1,1),
    nombre_tipo VARCHAR(50) NOT NULL UNIQUE,
    estado CHAR(1) DEFAULT 'A'
);

-- Tabla Estado de Reporte
CREATE TABLE Estado_Reporte (
    id_estado_reporte INT PRIMARY KEY IDENTITY(1,1),
    nombre_estado VARCHAR(50) NOT NULL UNIQUE
);
*/

/*
-- Tabla Hospedaje
CREATE TABLE Hospedaje (
    id_hospedaje INT PRIMARY KEY IDENTITY(1,1),
    categoria VARCHAR(50) NOT NULL,
    precio_minimo DECIMAL(10, 2) NOT NULL,
    precio_maximo DECIMAL(10, 2) NOT NULL,
    horario_checkin TIME NOT NULL,
    horario_checkout TIME NOT NULL,
    servicios_adicionales VARCHAR(MAX) NULL,
    capacidad INT NULL,
    id_oferta INT NOT NULL UNIQUE,
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);

-- Tabla Restaurante
CREATE TABLE Restaurante (
    id_restaurante INT PRIMARY KEY IDENTITY(1,1),
    tipo_cocina VARCHAR(50) NOT NULL,
    especialidades VARCHAR(MAX) NULL,
    horario_apertura TIME NOT NULL,
    horario_cierre TIME NOT NULL,
    precio_promedio DECIMAL(10, 2) NULL,
    precio_minimo DECIMAL(10, 2) NULL,
    precio_maximo DECIMAL(10, 2) NULL,
    id_oferta INT NOT NULL UNIQUE,
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);


-- Tabla Evento
CREATE TABLE Evento (
    id_evento INT PRIMARY KEY IDENTITY(1,1),
    tipo_evento VARCHAR(50) NOT NULL,
    epoca VARCHAR(50) NULL,
    capacidad INT NULL,
    precio_entrada DECIMAL(10, 2) NULL,
    fecha_evento DATE NOT NULL,
    id_oferta INT NOT NULL UNIQUE,
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);

-- Tabla Atractivo Turístico
CREATE TABLE Atractivo_Turistico (
    id_atractivo INT PRIMARY KEY IDENTITY(1,1),
    tipo_vegetacion VARCHAR(50) NULL,
    ubicacion_referencia VARCHAR(200) NULL,
    horario_apertura TIME NOT NULL,
    horario_cierre TIME NOT NULL,
    capacidad INT NULL,
    id_oferta INT NOT NULL UNIQUE,
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);

-- Tabla Institución
CREATE TABLE Institucion (
    id_institucion INT PRIMARY KEY IDENTITY(1,1),
    tipo_institucion VARCHAR(50) NOT NULL,
    servicios_disponibles VARCHAR(MAX) NULL,
    horario_apertura TIME NOT NULL,
    horario_cierre TIME NOT NULL,
    contacto_telefono VARCHAR(15) NULL,
    contacto_email VARCHAR(100) NULL,
    id_oferta INT NOT NULL UNIQUE,
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);
*/

/*
-- Tabla Log de Visitas
CREATE TABLE Log_Visitas (
    id_log INT PRIMARY KEY IDENTITY(1,1),
    fecha_visita DATE DEFAULT GETDATE(),
    id_oferta INT NOT NULL,
    id_usuario INT,
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);
*/

/*
-- Tabla Publicidad
CREATE TABLE Publicidad (
    id_publicidad INT PRIMARY KEY IDENTITY(1,1),
    tipo_publicidad VARCHAR(50) NOT NULL,
    fecha_inicio DATE NOT NULL,
    fecha_fin DATE NOT NULL,
    prioridad INT,
    estado CHAR(1) DEFAULT 'A',
    id_oferta INT NOT NULL,
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);

-- Tabla Suscripción de Negocio
CREATE TABLE Suscripcion_Negocio (
    id_suscripcion INT PRIMARY KEY IDENTITY(1,1),
    tipo_plan VARCHAR(50) NOT NULL,
    fecha_inicio DATE NOT NULL,
    fecha_expiracion DATE NOT NULL,
    estado CHAR(1) DEFAULT 'A',
    id_oferta INT NOT NULL,
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);

-- Tabla Reporte
CREATE TABLE Reporte (
    id_reporte INT PRIMARY KEY IDENTITY(1,1),
    descripcion VARCHAR(MAX),
    fecha_reporte DATE DEFAULT GETDATE(),
    estado CHAR(1) DEFAULT 'A',
    id_usuario INT NOT NULL,
    id_oferta INT NOT NULL,
    id_tipo_reporte INT NOT NULL,
    id_estado_reporte INT NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta),
    FOREIGN KEY (id_tipo_reporte) REFERENCES Tipo_Reporte(id_tipo_reporte),
    FOREIGN KEY (id_estado_reporte) REFERENCES Estado_Reporte(id_estado_reporte)
);
*/
