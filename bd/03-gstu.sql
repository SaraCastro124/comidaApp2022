USE ComidApp;

SELECT 'Creando Usuarios y Roles' Estado;

-- 1 Crear el usuario Cliente, que se tiene que poder conectar desde cualquier terminal y ver todo en la BD, menos la contraseña de los restaurantes. Puede dar de alta el pedido y el detalle del mismo.

DROP USER IF EXISTS 'cliente'@'%';

CREATE USER 'cliente'@'%' IDENTIFIED BY 'passCliente';

GRANT SELECT ON ComidApp.Cliente TO 'cliente'@'%';

GRANT SELECT ON ComidApp.Pedido TO 'cliente'@'%';

GRANT SELECT ON ComidApp.detallePedido TO 'cliente'@'%';

GRANT SELECT ON ComidApp.Plato TO 'cliente'@'%';

GRANT SELECT ON ComidApp.VentaResto TO 'cliente'@'%';

GRANT
SELECT
(
        idRestaurante,
        email,
        nombre,
        domicilio
    ) ON ComidApp.Restaurante TO 'cliente' @'%';

GRANT
INSERT
(
        idPlato,
        Nropedido,
        cantidad,
        precio
    ) ON ComidApp.detallePedido TO 'cliente' @'%';

-- 2 Crear el usuario admin, que desde la terminal donde corre el sistema

-- tiene que poder ver todas las tablas y puede eliminar filas en Plato y Restaurant.

DROP USER IF EXISTS 'Admin'@'localhost';

CREATE USER 'Admin'@'localhost' IDENTIFIED BY 'passAdmin';

GRANT SELECT ON ComidApp.* TO 'Admin'@'localhost';

GRANT DELETE ON ComidApp.Plato TO 'Admin'@'localhost';

GRANT DELETE ON ComidApp.Restaurante TO 'Admin'@'localhost';

-- 3 Crear el usuario adminResto que puede conectarse desde el terminal donde corre el sistema y puede ver todas las tablas y dar de alta Restaurant, Platos (toda la fila) y puede modificar el stock, precio unitario y disponibilidad de los platos.

DROP USER IF EXISTS 'adminResto'@'localhost';

CREATE USER 'adminResto'@'localhost' IDENTIFIED BY 'passAdminResto';

GRANT SELECT ON ComidApp.* TO 'adminResto'@'localhost';

GRANT INSERT ON ComidApp.Restaurante TO 'adminResto'@'localhost';

GRANT
INSERT,
UPDATE
(
        idPlato,
        precioUnitario,
        disponibilidad
    ) ON ComidApp.Plato TO 'adminResto' @'localhost';