USE [dbSistemaTurismo]
GO
/****** Object:  Table [dbo].[Atractivo_Turistico]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atractivo_Turistico](
	[id_atractivo] [int] IDENTITY(1,1) NOT NULL,
	[tipo_vegetacion] [varchar](50) NULL,
	[ubicacion_referencia] [varchar](200) NULL,
	[horario_apertura] [time](7) NOT NULL,
	[horario_cierre] [time](7) NOT NULL,
	[capacidad] [int] NULL,
	[id_oferta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_atractivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comentario]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentario](
	[id_comentario] [int] IDENTITY(1,1) NOT NULL,
	[comentario] [text] NOT NULL,
	[puntuacion] [int] NULL,
	[fecha_comentario] [date] NULL,
	[estado] [char](1) NULL,
	[id_oferta] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_comentario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Destino]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destino](
	[id_destino] [int] IDENTITY(1,1) NOT NULL,
	[nombre_destino] [varchar](100) NOT NULL,
	[tipo_destino] [varchar](50) NULL,
	[descripcion] [text] NULL,
	[pais] [varchar](100) NOT NULL,
	[estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_destino] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado_Reporte]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado_Reporte](
	[id_estado_reporte] [int] IDENTITY(1,1) NOT NULL,
	[nombre_estado] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_estado_reporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Etiqueta]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Etiqueta](
	[id_etiqueta] [int] IDENTITY(1,1) NOT NULL,
	[nombre_etiqueta] [varchar](50) NOT NULL,
	[estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_etiqueta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Etiqueta_Oferta]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Etiqueta_Oferta](
	[id_etiqueta_oferta] [int] IDENTITY(1,1) NOT NULL,
	[id_oferta] [int] NOT NULL,
	[id_etiqueta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_etiqueta_oferta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evento]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evento](
	[id_evento] [int] IDENTITY(1,1) NOT NULL,
	[tipo_evento] [varchar](50) NOT NULL,
	[epoca] [varchar](50) NULL,
	[capacidad] [int] NULL,
	[precio_entrada] [decimal](10, 2) NULL,
	[fecha_evento] [date] NOT NULL,
	[id_oferta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_evento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Foto_Comentario]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foto_Comentario](
	[id_foto] [int] IDENTITY(1,1) NOT NULL,
	[url_foto] [varchar](255) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[fecha_subida] [date] NULL,
	[estado] [char](1) NULL,
	[id_comentario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_foto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Galeria]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Galeria](
	[id_imagen] [int] IDENTITY(1,1) NOT NULL,
	[url_imagen] [varchar](200) NOT NULL,
	[descripcion] [varchar](255) NULL,
	[tipo_imagen] [varchar](50) NULL,
	[fecha_subida] [date] NULL,
	[estado] [char](1) NULL,
	[id_oferta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_imagen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hospedaje]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hospedaje](
	[id_hospedaje] [int] IDENTITY(1,1) NOT NULL,
	[categoria] [varchar](50) NOT NULL,
	[precio_minimo] [decimal](10, 2) NOT NULL,
	[precio_maximo] [decimal](10, 2) NOT NULL,
	[horario_checkin] [time](7) NOT NULL,
	[horario_checkout] [time](7) NOT NULL,
	[servicios_adicionales] [text] NULL,
	[capacidad] [int] NULL,
	[id_oferta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_hospedaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Institucion]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institucion](
	[id_institucion] [int] IDENTITY(1,1) NOT NULL,
	[tipo_institucion] [varchar](50) NOT NULL,
	[servicios_disponibles] [text] NULL,
	[horario_apertura] [time](7) NOT NULL,
	[horario_cierre] [time](7) NOT NULL,
	[contacto_telefono] [varchar](15) NULL,
	[contacto_email] [varchar](100) NULL,
	[id_oferta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_institucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log_Visitas]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log_Visitas](
	[id_log] [int] IDENTITY(1,1) NOT NULL,
	[fecha_visita] [date] NULL,
	[estado] [char](1) NULL,
	[id_oferta] [int] NOT NULL,
	[id_usuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_log] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oferta]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oferta](
	[id_oferta] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [text] NULL,
	[direccion] [varchar](200) NULL,
	[ubicacion_lat] [decimal](9, 6) NULL,
	[ubicacion_lon] [decimal](9, 6) NULL,
	[telefono] [varchar](15) NULL,
	[email_contacto] [varchar](100) NULL,
	[sitio_web] [varchar](200) NULL,
	[vinculo_con_oferta] [varchar](50) NULL,
	[id_usuario] [int] NOT NULL,
	[id_tipo_oferta] [int] NOT NULL,
	[id_destino] [int] NULL,
	[fecha_creacion] [date] NULL,
	[estado] [char](1) NULL,
	[verificado] [char](1) NULL,
	[visible] [char](1) NULL,
	[fecha_baja] [date] NULL,
	[motivo_baja] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_oferta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preferencias_Usuario]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preferencias_Usuario](
	[id_preferencia] [int] IDENTITY(1,1) NOT NULL,
	[estado] [char](1) NULL,
	[id_usuario] [int] NOT NULL,
	[id_etiqueta] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_preferencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publicidad]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publicidad](
	[id_publicidad] [int] IDENTITY(1,1) NOT NULL,
	[tipo_publicidad] [varchar](50) NOT NULL,
	[fecha_inicio] [date] NOT NULL,
	[fecha_fin] [date] NOT NULL,
	[prioridad] [int] NULL,
	[estado] [char](1) NULL,
	[id_oferta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_publicidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reporte]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reporte](
	[id_reporte] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [text] NULL,
	[fecha_reporte] [date] NULL,
	[estado] [char](1) NULL,
	[id_usuario] [int] NOT NULL,
	[id_oferta] [int] NOT NULL,
	[id_tipo_reporte] [int] NOT NULL,
	[id_estado_reporte] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_reporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restaurante]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurante](
	[id_restaurante] [int] IDENTITY(1,1) NOT NULL,
	[tipo_cocina] [varchar](50) NOT NULL,
	[especialidades] [text] NULL,
	[horario_apertura] [time](7) NOT NULL,
	[horario_cierre] [time](7) NOT NULL,
	[precio_promedio] [decimal](10, 2) NULL,
	[precio_minimo] [decimal](10, 2) NULL,
	[precio_maximo] [decimal](10, 2) NULL,
	[id_oferta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_restaurante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suscripcion_Negocio]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suscripcion_Negocio](
	[id_suscripcion] [int] IDENTITY(1,1) NOT NULL,
	[tipo_plan] [varchar](50) NOT NULL,
	[fecha_inicio] [date] NOT NULL,
	[fecha_expiracion] [date] NOT NULL,
	[estado] [char](1) NULL,
	[id_oferta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_suscripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Oferta]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Oferta](
	[id_tipo_oferta] [int] IDENTITY(1,1) NOT NULL,
	[nombre_tipo] [varchar](50) NOT NULL,
	[estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_oferta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Reporte]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Reporte](
	[id_tipo_reporte] [int] IDENTITY(1,1) NOT NULL,
	[nombre_tipo] [varchar](50) NOT NULL,
	[estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_reporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Usuario]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Usuario](
	[id_tipo_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre_tipo] [varchar](50) NOT NULL,
	[estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 9/11/2024 23:06:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellido] [varchar](100) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[contrasena] [varchar](255) NOT NULL,
	[telefono] [varchar](15) NULL,
	[id_tipo_usuario] [int] NOT NULL,
	[fecha_registro] [date] NULL,
	[estado] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Comentario] ON 

INSERT [dbo].[Comentario] ([id_comentario], [comentario], [puntuacion], [fecha_comentario], [estado], [id_oferta], [id_usuario]) VALUES (3, N'Excelente lugar, muy limpio y cómodo.', 5, CAST(N'2024-11-09' AS Date), N'A', 2, 2)
INSERT [dbo].[Comentario] ([id_comentario], [comentario], [puntuacion], [fecha_comentario], [estado], [id_oferta], [id_usuario]) VALUES (4, N'Buen servicio, aunque podría mejorar el tiempo de espera.', 4, CAST(N'2024-11-09' AS Date), N'A', 2, 2)
SET IDENTITY_INSERT [dbo].[Comentario] OFF
GO
SET IDENTITY_INSERT [dbo].[Destino] ON 

INSERT [dbo].[Destino] ([id_destino], [nombre_destino], [tipo_destino], [descripcion], [pais], [estado]) VALUES (1, N'Cusco', N'Ciudad', N'Capital histórica de los incas', N'Perú', N'A')
SET IDENTITY_INSERT [dbo].[Destino] OFF
GO
SET IDENTITY_INSERT [dbo].[Estado_Reporte] ON 

INSERT [dbo].[Estado_Reporte] ([id_estado_reporte], [nombre_estado]) VALUES (3, N'Cerrado')
INSERT [dbo].[Estado_Reporte] ([id_estado_reporte], [nombre_estado]) VALUES (1, N'Pendiente')
INSERT [dbo].[Estado_Reporte] ([id_estado_reporte], [nombre_estado]) VALUES (2, N'Revisado')
SET IDENTITY_INSERT [dbo].[Estado_Reporte] OFF
GO
SET IDENTITY_INSERT [dbo].[Etiqueta] ON 

INSERT [dbo].[Etiqueta] ([id_etiqueta], [nombre_etiqueta], [estado]) VALUES (1, N'Wi-Fi gratis', N'A')
INSERT [dbo].[Etiqueta] ([id_etiqueta], [nombre_etiqueta], [estado]) VALUES (2, N'Piscina', N'A')
SET IDENTITY_INSERT [dbo].[Etiqueta] OFF
GO
SET IDENTITY_INSERT [dbo].[Etiqueta_Oferta] ON 

INSERT [dbo].[Etiqueta_Oferta] ([id_etiqueta_oferta], [id_oferta], [id_etiqueta]) VALUES (1, 2, 1)
INSERT [dbo].[Etiqueta_Oferta] ([id_etiqueta_oferta], [id_oferta], [id_etiqueta]) VALUES (2, 2, 2)
SET IDENTITY_INSERT [dbo].[Etiqueta_Oferta] OFF
GO
SET IDENTITY_INSERT [dbo].[Galeria] ON 

INSERT [dbo].[Galeria] ([id_imagen], [url_imagen], [descripcion], [tipo_imagen], [fecha_subida], [estado], [id_oferta]) VALUES (1, N'/Content/Imagenes/Galeria/Camaleon_Branch.jpeg', N'Una imagen', N'Interior del Hotel', CAST(N'2024-11-09' AS Date), N'A', 2)
INSERT [dbo].[Galeria] ([id_imagen], [url_imagen], [descripcion], [tipo_imagen], [fecha_subida], [estado], [id_oferta]) VALUES (2, N'/Content/Imagenes/Galeria/Camaleon_Branch.jpeg', N'iMAGEN DEL EXTERIRO', N'Exterior del Hotel', CAST(N'2024-11-09' AS Date), N'A', 2)
INSERT [dbo].[Galeria] ([id_imagen], [url_imagen], [descripcion], [tipo_imagen], [fecha_subida], [estado], [id_oferta]) VALUES (3, N'http://imagenes.com/restaurantesabores.jpg', N'Foto de la entrada principal', N'jpg', CAST(N'2024-11-09' AS Date), N'A', 2)
SET IDENTITY_INSERT [dbo].[Galeria] OFF
GO
SET IDENTITY_INSERT [dbo].[Hospedaje] ON 

INSERT [dbo].[Hospedaje] ([id_hospedaje], [categoria], [precio_minimo], [precio_maximo], [horario_checkin], [horario_checkout], [servicios_adicionales], [capacidad], [id_oferta]) VALUES (5, N'5 Estrellas', CAST(20.00 AS Decimal(10, 2)), CAST(200.00 AS Decimal(10, 2)), CAST(N'20:00:00' AS Time), CAST(N'20:00:00' AS Time), N'Desayuno gratis', 50, 2)
SET IDENTITY_INSERT [dbo].[Hospedaje] OFF
GO
SET IDENTITY_INSERT [dbo].[Log_Visitas] ON 

INSERT [dbo].[Log_Visitas] ([id_log], [fecha_visita], [estado], [id_oferta], [id_usuario]) VALUES (1, CAST(N'2024-11-09' AS Date), N'A', 2, 2)
SET IDENTITY_INSERT [dbo].[Log_Visitas] OFF
GO
SET IDENTITY_INSERT [dbo].[Oferta] ON 

INSERT [dbo].[Oferta] ([id_oferta], [nombre], [descripcion], [direccion], [ubicacion_lat], [ubicacion_lon], [telefono], [email_contacto], [sitio_web], [vinculo_con_oferta], [id_usuario], [id_tipo_oferta], [id_destino], [fecha_creacion], [estado], [verificado], [visible], [fecha_baja], [motivo_baja]) VALUES (2, N'Hotel Paraíso', N'Un hotel 5 estrellas en el centro de la ciudad', N'Av. Central 123', CAST(-12.043180 AS Decimal(9, 6)), CAST(-77.028240 AS Decimal(9, 6)), N'123456789', N'contacto@hotelparaiso.com', N'http://hotelparaiso.com', N'Propietario', 2, 1, 1, CAST(N'2024-11-09' AS Date), N'A', N'N', N'N', NULL, NULL)
INSERT [dbo].[Oferta] ([id_oferta], [nombre], [descripcion], [direccion], [ubicacion_lat], [ubicacion_lon], [telefono], [email_contacto], [sitio_web], [vinculo_con_oferta], [id_usuario], [id_tipo_oferta], [id_destino], [fecha_creacion], [estado], [verificado], [visible], [fecha_baja], [motivo_baja]) VALUES (5, N'Restaurante Sabores', N'Restaurante de comida típica local', N'Av. Las Flores 456', CAST(-12.045890 AS Decimal(9, 6)), CAST(-77.030560 AS Decimal(9, 6)), N'123459876', N'contacto@restaurantesabores.com', N'http://restaurantesabores.com', N'Propietario', 2, 2, 1, CAST(N'2024-11-09' AS Date), N'A', N'N', N'N', NULL, NULL)
INSERT [dbo].[Oferta] ([id_oferta], [nombre], [descripcion], [direccion], [ubicacion_lat], [ubicacion_lon], [telefono], [email_contacto], [sitio_web], [vinculo_con_oferta], [id_usuario], [id_tipo_oferta], [id_destino], [fecha_creacion], [estado], [verificado], [visible], [fecha_baja], [motivo_baja]) VALUES (6, N'fwefewq', N'dqw', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 1, NULL, CAST(N'2024-11-09' AS Date), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Oferta] OFF
GO
SET IDENTITY_INSERT [dbo].[Preferencias_Usuario] ON 

INSERT [dbo].[Preferencias_Usuario] ([id_preferencia], [estado], [id_usuario], [id_etiqueta]) VALUES (1, N'A', 2, 1)
INSERT [dbo].[Preferencias_Usuario] ([id_preferencia], [estado], [id_usuario], [id_etiqueta]) VALUES (2, N'A', 2, 2)
SET IDENTITY_INSERT [dbo].[Preferencias_Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Reporte] ON 

INSERT [dbo].[Reporte] ([id_reporte], [descripcion], [fecha_reporte], [estado], [id_usuario], [id_oferta], [id_tipo_reporte], [id_estado_reporte]) VALUES (3, N'Duplicado de otro registro', CAST(N'2024-11-09' AS Date), N'A', 1, 2, 1, 1)
INSERT [dbo].[Reporte] ([id_reporte], [descripcion], [fecha_reporte], [estado], [id_usuario], [id_oferta], [id_tipo_reporte], [id_estado_reporte]) VALUES (4, N'Informe sobre condiciones de higiene', CAST(N'2024-11-09' AS Date), N'A', 2, 2, 2, 1)
SET IDENTITY_INSERT [dbo].[Reporte] OFF
GO
SET IDENTITY_INSERT [dbo].[Suscripcion_Negocio] ON 

INSERT [dbo].[Suscripcion_Negocio] ([id_suscripcion], [tipo_plan], [fecha_inicio], [fecha_expiracion], [estado], [id_oferta]) VALUES (1, N'Premium', CAST(N'2024-11-09' AS Date), CAST(N'2025-05-09' AS Date), N'A', 2)
SET IDENTITY_INSERT [dbo].[Suscripcion_Negocio] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipo_Oferta] ON 

INSERT [dbo].[Tipo_Oferta] ([id_tipo_oferta], [nombre_tipo], [estado]) VALUES (1, N'Hotel', N'A')
INSERT [dbo].[Tipo_Oferta] ([id_tipo_oferta], [nombre_tipo], [estado]) VALUES (2, N'Restaurante', N'A')
INSERT [dbo].[Tipo_Oferta] ([id_tipo_oferta], [nombre_tipo], [estado]) VALUES (3, N'Evento', N'A')
SET IDENTITY_INSERT [dbo].[Tipo_Oferta] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipo_Reporte] ON 

INSERT [dbo].[Tipo_Reporte] ([id_tipo_reporte], [nombre_tipo], [estado]) VALUES (1, N'Duplicado', N'A')
INSERT [dbo].[Tipo_Reporte] ([id_tipo_reporte], [nombre_tipo], [estado]) VALUES (2, N'Cerrado', N'A')
INSERT [dbo].[Tipo_Reporte] ([id_tipo_reporte], [nombre_tipo], [estado]) VALUES (3, N'Sugerencia de edición', N'A')
SET IDENTITY_INSERT [dbo].[Tipo_Reporte] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipo_Usuario] ON 

INSERT [dbo].[Tipo_Usuario] ([id_tipo_usuario], [nombre_tipo], [estado]) VALUES (1, N'Admin', N'A')
INSERT [dbo].[Tipo_Usuario] ([id_tipo_usuario], [nombre_tipo], [estado]) VALUES (2, N'Proveedor', N'A')
INSERT [dbo].[Tipo_Usuario] ([id_tipo_usuario], [nombre_tipo], [estado]) VALUES (3, N'Turista', N'A')
SET IDENTITY_INSERT [dbo].[Tipo_Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id_usuario], [nombre], [apellido], [email], [contrasena], [telefono], [id_tipo_usuario], [fecha_registro], [estado]) VALUES (1, N'Juan', N'Perez', N'admin@example.com', N'123456', N'123456789', 1, CAST(N'2024-11-09' AS Date), N'A')
INSERT [dbo].[Usuario] ([id_usuario], [nombre], [apellido], [email], [contrasena], [telefono], [id_tipo_usuario], [fecha_registro], [estado]) VALUES (2, N'Ana', N'Ramos', N'prov@example.com', N'123456', N'987654321', 2, CAST(N'2024-11-09' AS Date), N'A')
INSERT [dbo].[Usuario] ([id_usuario], [nombre], [apellido], [email], [contrasena], [telefono], [id_tipo_usuario], [fecha_registro], [estado]) VALUES (3, N'Pedro', N'Romero', N'turi@example.com', N'123456', N'987784321', 3, CAST(N'2024-11-09' AS Date), N'A')
INSERT [dbo].[Usuario] ([id_usuario], [nombre], [apellido], [email], [contrasena], [telefono], [id_tipo_usuario], [fecha_registro], [estado]) VALUES (4, N'Jorge', N'Perez', N'dodo@gmail.com', N'123456', NULL, 1, NULL, NULL)
INSERT [dbo].[Usuario] ([id_usuario], [nombre], [apellido], [email], [contrasena], [telefono], [id_tipo_usuario], [fecha_registro], [estado]) VALUES (5, N'Usuario', N'Perez', N'juan1@gmail.com', N'123456', NULL, 3, NULL, NULL)
INSERT [dbo].[Usuario] ([id_usuario], [nombre], [apellido], [email], [contrasena], [telefono], [id_tipo_usuario], [fecha_registro], [estado]) VALUES (6, N'Mayner', N'Anahua', N'ramperez@gmail.com', N'123456', NULL, 3, CAST(N'2024-11-09' AS Date), N'A')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Destino__20AF82777EBA1A67]    Script Date: 9/11/2024 23:06:29 ******/
ALTER TABLE [dbo].[Destino] ADD UNIQUE NONCLUSTERED 
(
	[nombre_destino] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Estado_R__2F8C63750A7914AE]    Script Date: 9/11/2024 23:06:29 ******/
ALTER TABLE [dbo].[Estado_Reporte] ADD UNIQUE NONCLUSTERED 
(
	[nombre_estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Etiqueta__3F48E4F1708C3CC8]    Script Date: 9/11/2024 23:06:29 ******/
ALTER TABLE [dbo].[Etiqueta] ADD UNIQUE NONCLUSTERED 
(
	[nombre_etiqueta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Tipo_Ofe__0C60C00DBEDDF59F]    Script Date: 9/11/2024 23:06:29 ******/
ALTER TABLE [dbo].[Tipo_Oferta] ADD UNIQUE NONCLUSTERED 
(
	[nombre_tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Tipo_Rep__0C60C00DD6F8F284]    Script Date: 9/11/2024 23:06:29 ******/
ALTER TABLE [dbo].[Tipo_Reporte] ADD UNIQUE NONCLUSTERED 
(
	[nombre_tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Tipo_Usu__0C60C00DC7101BB0]    Script Date: 9/11/2024 23:06:29 ******/
ALTER TABLE [dbo].[Tipo_Usuario] ADD UNIQUE NONCLUSTERED 
(
	[nombre_tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__AB6E61649FB2169A]    Script Date: 9/11/2024 23:06:29 ******/
ALTER TABLE [dbo].[Usuario] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comentario] ADD  DEFAULT (getdate()) FOR [fecha_comentario]
GO
ALTER TABLE [dbo].[Comentario] ADD  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Destino] ADD  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Etiqueta] ADD  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Foto_Comentario] ADD  DEFAULT (getdate()) FOR [fecha_subida]
GO
ALTER TABLE [dbo].[Foto_Comentario] ADD  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Galeria] ADD  DEFAULT (getdate()) FOR [fecha_subida]
GO
ALTER TABLE [dbo].[Galeria] ADD  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Log_Visitas] ADD  DEFAULT (getdate()) FOR [fecha_visita]
GO
ALTER TABLE [dbo].[Log_Visitas] ADD  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Oferta] ADD  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[Oferta] ADD  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Oferta] ADD  DEFAULT ('N') FOR [verificado]
GO
ALTER TABLE [dbo].[Oferta] ADD  DEFAULT ('N') FOR [visible]
GO
ALTER TABLE [dbo].[Preferencias_Usuario] ADD  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Publicidad] ADD  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Reporte] ADD  DEFAULT (getdate()) FOR [fecha_reporte]
GO
ALTER TABLE [dbo].[Reporte] ADD  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Suscripcion_Negocio] ADD  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Tipo_Oferta] ADD  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Tipo_Reporte] ADD  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Tipo_Usuario] ADD  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (getdate()) FOR [fecha_registro]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT ('A') FOR [estado]
GO
ALTER TABLE [dbo].[Atractivo_Turistico]  WITH CHECK ADD FOREIGN KEY([id_oferta])
REFERENCES [dbo].[Oferta] ([id_oferta])
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD FOREIGN KEY([id_oferta])
REFERENCES [dbo].[Oferta] ([id_oferta])
GO
ALTER TABLE [dbo].[Comentario]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Etiqueta_Oferta]  WITH CHECK ADD FOREIGN KEY([id_etiqueta])
REFERENCES [dbo].[Etiqueta] ([id_etiqueta])
GO
ALTER TABLE [dbo].[Etiqueta_Oferta]  WITH CHECK ADD FOREIGN KEY([id_oferta])
REFERENCES [dbo].[Oferta] ([id_oferta])
GO
ALTER TABLE [dbo].[Evento]  WITH CHECK ADD FOREIGN KEY([id_oferta])
REFERENCES [dbo].[Oferta] ([id_oferta])
GO
ALTER TABLE [dbo].[Foto_Comentario]  WITH CHECK ADD FOREIGN KEY([id_comentario])
REFERENCES [dbo].[Comentario] ([id_comentario])
GO
ALTER TABLE [dbo].[Galeria]  WITH CHECK ADD FOREIGN KEY([id_oferta])
REFERENCES [dbo].[Oferta] ([id_oferta])
GO
ALTER TABLE [dbo].[Hospedaje]  WITH CHECK ADD FOREIGN KEY([id_oferta])
REFERENCES [dbo].[Oferta] ([id_oferta])
GO
ALTER TABLE [dbo].[Institucion]  WITH CHECK ADD FOREIGN KEY([id_oferta])
REFERENCES [dbo].[Oferta] ([id_oferta])
GO
ALTER TABLE [dbo].[Log_Visitas]  WITH CHECK ADD FOREIGN KEY([id_oferta])
REFERENCES [dbo].[Oferta] ([id_oferta])
GO
ALTER TABLE [dbo].[Log_Visitas]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Oferta]  WITH CHECK ADD FOREIGN KEY([id_destino])
REFERENCES [dbo].[Destino] ([id_destino])
GO
ALTER TABLE [dbo].[Oferta]  WITH CHECK ADD FOREIGN KEY([id_tipo_oferta])
REFERENCES [dbo].[Tipo_Oferta] ([id_tipo_oferta])
GO
ALTER TABLE [dbo].[Oferta]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Preferencias_Usuario]  WITH CHECK ADD FOREIGN KEY([id_etiqueta])
REFERENCES [dbo].[Etiqueta] ([id_etiqueta])
GO
ALTER TABLE [dbo].[Preferencias_Usuario]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Publicidad]  WITH CHECK ADD FOREIGN KEY([id_oferta])
REFERENCES [dbo].[Oferta] ([id_oferta])
GO
ALTER TABLE [dbo].[Reporte]  WITH CHECK ADD FOREIGN KEY([id_estado_reporte])
REFERENCES [dbo].[Estado_Reporte] ([id_estado_reporte])
GO
ALTER TABLE [dbo].[Reporte]  WITH CHECK ADD FOREIGN KEY([id_oferta])
REFERENCES [dbo].[Oferta] ([id_oferta])
GO
ALTER TABLE [dbo].[Reporte]  WITH CHECK ADD FOREIGN KEY([id_tipo_reporte])
REFERENCES [dbo].[Tipo_Reporte] ([id_tipo_reporte])
GO
ALTER TABLE [dbo].[Reporte]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Restaurante]  WITH CHECK ADD FOREIGN KEY([id_oferta])
REFERENCES [dbo].[Oferta] ([id_oferta])
GO
ALTER TABLE [dbo].[Suscripcion_Negocio]  WITH CHECK ADD FOREIGN KEY([id_oferta])
REFERENCES [dbo].[Oferta] ([id_oferta])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([id_tipo_usuario])
REFERENCES [dbo].[Tipo_Usuario] ([id_tipo_usuario])
GO
