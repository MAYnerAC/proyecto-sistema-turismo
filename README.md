# Proyecto Sistema Turismo

- Anahua Coaquira Mayner Gonzalo
- Zevallos Purca Justin Zinedine
- Salinas Condori Erick Javier

## Enlace App Service

```
sistematurismo-czhzfrcgfsbucaa0.brazilsouth-01.azurewebsites.net
```

```
https://sistematurismo-czhzfrcgfsbucaa0.brazilsouth-01.azurewebsites.net/
```

## Aceceso de prueba Usuarios

1. Administrador

```
admin@example.com
123456
```

2. Proveedor

```
prov@example.com
123456
```

3. Turista

```
user@example.com
123456
```

#### Repositorio de cambios e implementaciones:

```
https://github.com/MAYnerAC/proyecto-sistema-turismo
```

## Diagrama

```mermaid
classDiagram

class Tipo_Usuario {
    +int id_tipo_usuario PK
    +varchar(50) nombre_tipo
    +char(1) estado
}

class Tipo_Oferta {
    +int id_tipo_oferta PK
    +varchar(50) nombre_tipo
    +char(1) estado
}

class Etiqueta {
    +int id_etiqueta PK
    +varchar(50) nombre_etiqueta
    +char(1) estado
}

class Destino {
    +int id_destino PK
    +varchar(100) nombre_destino
    +varchar(50) tipo_destino
    +varchar(MAX) descripcion
    +varchar(100) pais
    +char(1) estado
}

class Usuario {
    +int id_usuario PK
    +varchar(100) nombre
    +varchar(100) apellido
    +varchar(100) email
    +varchar(255) contrasena
    +varchar(15) telefono
    +int id_tipo_usuario FK
    +date fecha_registro
    +char(1) estado
}

class Oferta {
    +int id_oferta PK
    +varchar(100) nombre
    +varchar(MAX) descripcion
    +varchar(200) direccion
    +decimal(9,6) ubicacion_lat
    +decimal(9,6) ubicacion_lon
    +varchar(15) telefono
    +varchar(100) email_contacto
    +varchar(200) sitio_web
    +varchar(50) vinculo_con_oferta
    +int id_usuario FK
    +int id_tipo_oferta FK
    +int id_destino FK
    +date fecha_creacion
    +char(1) estado
    +char(1) verificado
    +char(1) visible
    +date fecha_baja
    +varchar(MAX) motivo_baja
}

class Etiqueta_Oferta {
    +int id_etiqueta_oferta PK
    +int id_oferta FK
    +int id_etiqueta FK
}

class Comentario {
    +int id_comentario PK
    +varchar(MAX) contenido
    +int puntuacion
    +date fecha_comentario
    +char(1) estado
    +int id_oferta FK
    +int id_usuario FK
}

class Galeria {
    +int id_imagen PK
    +varchar(200) url_imagen
    +varchar(255) descripcion
    +varchar(50) tipo_imagen
    +date fecha_subida
    +char(1) estado
    +int id_oferta FK
}

class Preferencias_Usuario {
    +int id_preferencia PK
    +int id_usuario FK
    +int id_etiqueta FK
}

class Foto_Comentario {
    +int id_foto PK
    +varchar(255) url_foto
    +varchar(255) descripcion
    +date fecha_subida
    +char(1) estado
    +int id_comentario FK
}

%% Relaciones

Usuario --> Tipo_Usuario : "id_tipo_usuario"
Oferta --> Usuario : "id_usuario"
Oferta --> Tipo_Oferta : "id_tipo_oferta"
Oferta --> Destino : "id_destino"
Etiqueta_Oferta --> Oferta : "id_oferta"
Etiqueta_Oferta --> Etiqueta : "id_etiqueta"
Comentario --> Oferta : "id_oferta"
Comentario --> Usuario : "id_usuario"
Galeria --> Oferta : "id_oferta"
Preferencias_Usuario --> Usuario : "id_usuario"
Preferencias_Usuario --> Etiqueta : "id_etiqueta"
Foto_Comentario --> Comentario : "id_comentario"

```

## Capturas de la aplicacion

![alt text](assets/image.png)

![alt text](assets/image-1.png)

![alt text](assets/image-2.png)

![alt text](assets/image-3.png)

![alt text](assets/image-4.png)

![alt text](assets/image-5.png)

![alt text](assets/image-6.png)

![alt text](assets/image-7.png)

![alt text](assets/image-8.png)

![alt text](assets/image-9.png)

![alt text](assets/image-10.png)

![alt text](assets/image-19.png)

![alt text](assets/image-20.png)

![alt text](assets/image-21.png)

![alt text](assets/image-22.png)

![alt text](assets/image-11.png)

![alt text](assets/image-12.png)

![alt text](assets/image-13.png)

![alt text](assets/image-14.png)

![alt text](assets/image-18.png)

![alt text](assets/image-15.png)

![alt text](assets/image-16.png)

![alt text](assets/image-17.png)

![alt text](assets/image-23.png)

![alt text](assets/image-24.png)

![alt text](assets/image-25.png)

![alt text](assets/image-26.png)

![alt text](assets/image-27.png)

![alt text](assets/image-28.png)

![alt text](assets/image-29.png)

![alt text](assets/image-30.png)

![alt text](assets/image-31.png)

![alt text](assets/image-32.png)

![alt text](assets/image-33.png)

![alt text](assets/image-34.png)
