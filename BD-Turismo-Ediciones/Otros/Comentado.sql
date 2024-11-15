


-- ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*

-- Tabla PlanPublicidad
CREATE TABLE PlanPublicidad (
    id_plan_publicidad INT PRIMARY KEY IDENTITY(1,1),
    nombre_plan VARCHAR(50) NOT NULL UNIQUE,
    descripcion TEXT,
    duracion_dias INT NOT NULL,
    costo DECIMAL(10, 2) NOT NULL
);

-- Tabla PlanSuscripcion
CREATE TABLE PlanSuscripcion (
    id_plan_suscripcion INT PRIMARY KEY IDENTITY(1,1),
    nombre_plan VARCHAR(50) NOT NULL UNIQUE,
    descripcion TEXT,
    duracion_dias INT NOT NULL,
    costo DECIMAL(10, 2) NOT NULL
);

-- ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

/*
-- Tabla DetalleMuseo
CREATE TABLE Museo (
    id_museo INT PRIMARY KEY IDENTITY(1,1),
    id_oferta INT NOT NULL,
    exposicion_principal VARCHAR(100) NOT NULL,
    horario_apertura TIME NOT NULL,
    horario_cierre TIME NOT NULL,
    precio_entrada DECIMAL(10, 2) NULL,
    duracion_promedio INT NULL,
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);


CREATE TABLE Iglesia (
    id_iglesia INT PRIMARY KEY IDENTITY(1,1),
    id_oferta INT NOT NULL,
    capacidad INT NULL,
    denominacion VARCHAR(50) NULL,
    horario_apertura TIME NOT NULL,
    horario_cierre TIME NOT NULL,
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);

CREATE TABLE NegocioLocal (
    id_negocio INT PRIMARY KEY IDENTITY(1,1),
    id_oferta INT NOT NULL,
    tipo_negocio VARCHAR(50) NOT NULL,
    horario_apertura TIME NOT NULL,
    horario_cierre TIME NOT NULL,
    precio_minimo DECIMAL(10, 2) NULL,
    precio_maximo DECIMAL(10, 2) NULL,
    FOREIGN KEY (id_oferta) REFERENCES Oferta(id_oferta)
);
*/


-- ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// TABLAS AGREGADAS
/*
-- Tabla DetalleServicio
CREATE TABLE DetalleServicio (
    id_detalle INT PRIMARY KEY IDENTITY(1,1),
    id_servicio INT NOT NULL,
    precio_entrada DECIMAL(10, 2) NULL,          -- Precio de entrada (si aplica)
    duracion_promedio INT NULL,                  -- Duración promedio de la visita en minutos
    ubicacion_referencia VARCHAR(200) NULL,      -- Ubicación adicional o referencia
    capacidad INT NULL,                          -- Capacidad del lugar
    categoria_hospedaje VARCHAR(50) NULL,        -- Categoría para hospedaje (hotel, hostal, etc.)
    horario_apertura TIME NULL,                  -- Hora de apertura
    horario_cierre TIME NULL,                    -- Hora de cierre
    precio_minimo DECIMAL(10, 2) NULL,           -- Precio mínimo (para servicios con rango de precios)
    precio_maximo DECIMAL(10, 2) NULL,           -- Precio máximo
    tipo_cocina VARCHAR(50) NULL,                -- Tipo de cocina (para restaurantes)
    especialidades TEXT NULL,                    -- Especialidades del lugar (gastronómico o cultural)
    epoca VARCHAR(50) NULL,                      -- Época del evento (si aplica)
    fecha_evento DATE NULL,                      -- Fecha específica para eventos únicos
    tipo_evento VARCHAR(50) NULL,                -- Tipo de evento (concierto, feria, etc.)
    estado CHAR(1) DEFAULT 'A',                  -- Estado del registro
    FOREIGN KEY (id_servicio) REFERENCES ServicioTuristico(id_servicio)
);
*/


/*Wi-Fi gratis, Piscina, Aire acondicionado, Servicio de lavandería, Apto para niños, Restaurante, Transporte desde/hacia el aeropuerto, Jacuzzi, Gimnasio, Libre de humo, Transporte incluido, Desayuno incluido, Estacionamiento gratuito, Sanitario, Aperitivos, Almuerzo, Agradable, Ideal para ir con niños, Grupos, Happy hour, Menú especial, Guía disponible.*/


-- ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
-- Tabla Valoracion
CREATE TABLE Valoracion (
    id_valoracion INT PRIMARY KEY IDENTITY(1,1),
    id_servicio INT NOT NULL,
    id_usuario INT NOT NULL,
    puntuacion INT NOT NULL CHECK (puntuacion BETWEEN 1 AND 5),
    fecha_valoracion DATE DEFAULT GETDATE(),
    estado CHAR(1) DEFAULT 'A',
    FOREIGN KEY (id_servicio) REFERENCES ServicioTuristico(id_servicio),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

-- Tabla Departamento
CREATE TABLE Departamento (
    id_departamento INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL UNIQUE
);

-- Tabla Provincia
CREATE TABLE Provincia (
    id_provincia INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    id_departamento INT NOT NULL,
    FOREIGN KEY (id_departamento) REFERENCES Departamento(id_departamento)
);

-- Tabla Distrito
CREATE TABLE Distrito (
    id_distrito INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    id_provincia INT NOT NULL,
    FOREIGN KEY (id_provincia) REFERENCES Provincia(id_provincia)
);

-- Tabla Ubigeo
CREATE TABLE Ubigeo (
    id_ubigeo CHAR(6) PRIMARY KEY,      -- Código de 6 dígitos que incluye el departamento, provincia y distrito
    nombre VARCHAR(100) NOT NULL,       -- Nombre del departamento, provincia o distrito
    nivel CHAR(1) NOT NULL,             -- Indica el nivel: '1' = Departamento, '2' = Provincia, '3' = Distrito
    id_padre CHAR(6),                   -- Código del nivel superior: NULL para departamentos, código del departamento para provincias, etc.
    CONSTRAINT fk_padre FOREIGN KEY (id_padre) REFERENCES Ubigeo(id_ubigeo)
);
*/