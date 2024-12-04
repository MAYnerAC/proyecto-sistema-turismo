/*
UPDATE Galeria
SET url_imagen = 'https://bit.ly/4fMxoFd';


UPDATE Foto_Comentario
SET url_foto = 'https://bit.ly/4fMxoFd';
*/



--select *from Tipo_Usuario
--select *from Usuario

select * from Oferta
select * from Galeria
select * from Foto_Comentario
select * from Comentario
select * from Usuario



SELECT 
    o.id_oferta,
    o.nombre,
    o.descripcion,
    o.telefono,
    o.id_tipo_oferta,
    o.id_destino,
    t.nombre_tipo AS tipo_oferta,
    d.nombre_destino AS destino,
    g.url_imagen AS imagen
FROM Oferta o
JOIN Tipo_Oferta t ON o.id_tipo_oferta = t.id_tipo_oferta
JOIN Destino d ON o.id_destino = d.id_destino
LEFT JOIN Galeria g ON o.id_oferta = g.id_oferta
WHERE o.estado = 'A' AND o.visible = 'S' AND o.verificado = 'S'
ORDER BY o.fecha_creacion DESC;












SELECT 
    o.id_oferta,
    o.nombre,
    o.descripcion,
    o.telefono,
    o.id_tipo_oferta,
    o.id_destino,
    t.nombre_tipo AS tipo_oferta,
    d.nombre_destino AS destino,
    g.url_imagen AS imagen_url,
    o.verificado
FROM Oferta o
JOIN Tipo_Oferta t ON o.id_tipo_oferta = t.id_tipo_oferta
JOIN Destino d ON o.id_destino = d.id_destino
LEFT JOIN Galeria g ON o.id_oferta = g.id_oferta
WHERE o.estado = 'A' 
    AND o.visible = 'S'
ORDER BY o.verificado DESC, o.fecha_creacion DESC;















SELECT 
    o.id_oferta,
    o.nombre,
    o.descripcion,
    o.telefono,
    o.id_tipo_oferta,
    o.id_destino,
    t.nombre_tipo AS tipo_oferta,
    d.nombre_destino AS destino,
    (SELECT TOP 1 g.url_imagen 
     FROM Galeria g 
     WHERE g.id_oferta = o.id_oferta AND g.estado = 'A') AS imagen_url,
    o.verificado
FROM Oferta o
JOIN Tipo_Oferta t ON o.id_tipo_oferta = t.id_tipo_oferta
JOIN Destino d ON o.id_destino = d.id_destino
WHERE o.estado = 'A' 
    AND o.visible = 'S'
ORDER BY o.verificado DESC, o.fecha_creacion DESC;
