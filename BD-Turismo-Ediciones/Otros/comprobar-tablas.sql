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

