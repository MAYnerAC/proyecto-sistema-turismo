-- Creación de la base de datos
CREATE DATABASE TurismoDB;
GO

USE TurismoDB;
GO

-- Tabla Rol
CREATE TABLE Rol (
    id_rol INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(50) NOT NULL UNIQUE
);

-- Tabla TipoServicio
CREATE TABLE TipoServicio (
    id_tipo INT PRIMARY KEY IDENTITY(1,1),
    nombre_tipo VARCHAR(50) NOT NULL UNIQUE
);

-- Tabla Usuario
CREATE TABLE Usuario (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    contraseña VARCHAR(255) NOT NULL,
    id_rol INT NOT NULL,
    fecha_registro DATE DEFAULT GETDATE(),
    estado CHAR(1) DEFAULT 'A',
    relacion_negocio VARCHAR(50),
    FOREIGN KEY (id_rol) REFERENCES Rol(id_rol)
);

-- Tabla ServicioTuristico con estado extendido
CREATE TABLE ServicioTuristico (
    id_servicio INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT,
    id_tipo INT NOT NULL,
    direccion VARCHAR(200),
    ubicacion_lat DECIMAL(9,6),
    ubicacion_lon DECIMAL(9,6),
    telefono VARCHAR(15),
    email_contacto VARCHAR(100),
    sitio_web VARCHAR(200),
    id_usuario INT NOT NULL,
    fecha_creacion DATE DEFAULT GETDATE(),
    estado CHAR(1) DEFAULT 'A',
    verificado CHAR(1) DEFAULT 'N',
    visible CHAR(1) DEFAULT 'N',
    fecha_baja DATE NULL,
    motivo_baja TEXT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    FOREIGN KEY (id_tipo) REFERENCES TipoServicio(id_tipo)
);


-- Tabla DetalleServicio
CREATE TABLE DetalleServicio (
    id_detalle INT PRIMARY KEY IDENTITY(1,1),
    id_servicio INT NOT NULL,
    precio_entrada DECIMAL(10, 2) NULL,
    duracion_promedio INT NULL,
    ubicacion_referencia VARCHAR(200) NULL,
    capacidad INT NULL,
    categoria_hospedaje VARCHAR(50) NULL,
    horario_apertura TIME NULL,
    horario_cierre TIME NULL,
    precio_minimo DECIMAL(10, 2) NULL,
    precio_maximo DECIMAL(10, 2) NULL,
    tipo_cocina VARCHAR(50) NULL,
    especialidades TEXT NULL,
    epoca VARCHAR(50) NULL,
    fecha_evento DATE NULL,
    tipo_evento VARCHAR(50) NULL,
    estado CHAR(1) DEFAULT 'A',
    FOREIGN KEY (id_servicio) REFERENCES ServicioTuristico(id_servicio)
);

-- Tabla Etiqueta
CREATE TABLE Etiqueta (
    id_etiqueta INT PRIMARY KEY IDENTITY(1,1),
    nombre_etiqueta VARCHAR(50) NOT NULL UNIQUE
);

-- Tabla EtiquetaServicio
CREATE TABLE EtiquetaServicio (
    id_etiqueta_servicio INT PRIMARY KEY IDENTITY(1,1),
    id_servicio INT NOT NULL,
    id_etiqueta INT NOT NULL,
    FOREIGN KEY (id_servicio) REFERENCES ServicioTuristico(id_servicio),
    FOREIGN KEY (id_etiqueta) REFERENCES Etiqueta(id_etiqueta)
);

-- Tabla Comentario
CREATE TABLE Comentario (
    id_comentario INT PRIMARY KEY IDENTITY(1,1),
    id_servicio INT NOT NULL,
    id_usuario INT NOT NULL,
    comentario TEXT NOT NULL,
    puntuacion INT,
    fecha_comentario DATE DEFAULT GETDATE(),
    estado CHAR(1) DEFAULT 'A',
    FOREIGN KEY (id_servicio) REFERENCES ServicioTuristico(id_servicio),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

-- Tabla Galeria
CREATE TABLE Galeria (
    id_imagen INT PRIMARY KEY IDENTITY(1,1),
    id_servicio INT NOT NULL,
    url_imagen VARCHAR(200) NOT NULL,
    descripcion VARCHAR(255),
    tipo_imagen VARCHAR(50) NULL,
    fecha_subida DATE DEFAULT GETDATE(),
    estado CHAR(1) DEFAULT 'A',
    FOREIGN KEY (id_servicio) REFERENCES ServicioTuristico(id_servicio)
);

-- Tabla LogVisitas
CREATE TABLE LogVisitas (
    id_log INT PRIMARY KEY IDENTITY(1,1),
    id_servicio INT NOT NULL,
    id_usuario INT,
    fecha_visita DATE DEFAULT GETDATE(),
    estado CHAR(1) DEFAULT 'A',
    FOREIGN KEY (id_servicio) REFERENCES ServicioTuristico(id_servicio),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

-- Tabla PreferenciasUsuario
CREATE TABLE PreferenciasUsuario (
    id_preferencia INT PRIMARY KEY IDENTITY(1,1),
    id_usuario INT NOT NULL,
    id_tipo INT NULL,
    id_etiqueta INT NULL,
    estado CHAR(1) DEFAULT 'A',
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario),
    FOREIGN KEY (id_tipo) REFERENCES TipoServicio(id_tipo),
    FOREIGN KEY (id_etiqueta) REFERENCES Etiqueta(id_etiqueta)
);

-- Tabla Publicidad
CREATE TABLE Publicidad (
    id_publicidad INT PRIMARY KEY IDENTITY(1,1),
    id_servicio INT NOT NULL,
    tipo_publicidad VARCHAR(50) NOT NULL,
    fecha_inicio DATE NOT NULL,
    fecha_fin DATE NOT NULL,
    prioridad INT,
    estado CHAR(1) DEFAULT 'A',
    FOREIGN KEY (id_servicio) REFERENCES ServicioTuristico(id_servicio)
);

-- Tabla SuscripcionNegocio
CREATE TABLE SuscripcionNegocio (
    id_suscripcion INT PRIMARY KEY IDENTITY(1,1),
    id_servicio INT NOT NULL,
    tipo_plan VARCHAR(50) NOT NULL,
    fecha_inicio DATE NOT NULL,
    fecha_expiracion DATE NOT NULL,
    estado CHAR(1) DEFAULT 'A',
    FOREIGN KEY (id_servicio) REFERENCES ServicioTuristico(id_servicio)
);

-- Tabla SolicitudVerificacionProveedor
CREATE TABLE SolicitudVerificacionProveedor (
    id_solicitud INT PRIMARY KEY IDENTITY(1,1),
    id_usuario INT NOT NULL,
    fecha_solicitud DATE DEFAULT GETDATE(),
    estado CHAR(1) DEFAULT 'A',
    comentarios_admin TEXT,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);
