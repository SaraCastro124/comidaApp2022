use ComidApp;

-- 1 Realizar los SP para dar de alta todas las entidades menos la tabla Cliente.
DELIMITER $$
DROP PROCEDURE IF EXISTS altaRestaurante $$
CREATE PROCEDURE altaRestaurante (unIdRestaurante SMALLINT UNSIGNED, unEmail VARCHAR(45), unNombre VARCHAR(50), unDomicilio VARCHAR(45), UnaClave CHAR(64))
BEGIN
INSERT INTO Restaurante (idRestaurante, email, nombre, domicilio, clave)
VALUES (unIdRestaurante, unEmail, unNombre, unDomicilio, UnaClave);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaPedido $$
CREATE PROCEDURE altaPedido (unIdRestaurante SMALLINT UNSIGNED, unNroPedido SMALLINT UNSIGNED, unaFechaHora DATETIME, unIdCliente SMALLINT UNSIGNED, unPrecio DECIMAL(7,2), unaOpinion TINYINT UNSIGNED, unaDescripcion VARCHAR(50))
BEGIN
    INSERT INTO Pedido (idRestaurante, NroPedido, Fechahora, idCliente, Precio, opinion, descripcion)
        VALUES (unIdRestaurante, unNroPedido , unaFechaHora, unIdCliente, unPrecio, unaOpinion, unaDescripcion);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaPlato $$
CREATE PROCEDURE altaPlato (unNombre VARCHAR(50), unaDescripcion VARCHAR(45), unIdPlato SMALLINT UNSIGNED, unPrecioUnitario DECIMAL(7,2), unIdRestaurante SMALLINT UNSIGNED, unaDisponibilidad SMALLINT UNSIGNED)

BEGIN
INSERT INTO Plato (nombre, descripcion, idPlato, precioUnitario, idRestaurante, disponibilidad)
VALUES (unNombre, unaDescripcion, unIdPlato, unPrecioUnitario, unIdRestaurante, unaDisponibilidad);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaDetallePedido $$
CREATE PROCEDURE altaDetallePedido (unIdPlato SMALLINT UNSIGNED, unNroPedido SMALLINT UNSIGNED, unaCantidad TINYINT UNSIGNED, unPrecio DECIMAL(7,2))
BEGIN
    INSERT INTO DetallePedido (idPlato, NroPedido, cantidad, precio)
        VALUES (unIdPlato, unNroPedido, unaCantidad, unPrecio);
END $$

-- 2 Se pide hacer el SP ‘registrarCliente’ que reciba los datos del cliente. Es importante guardar encriptada la contraseña del cliente usando SHA256.
DELIMITER $$
DROP PROCEDURE IF EXISTS registrarCliente $$
CREATE PROCEDURE registrarCliente (unIdCliente SMALLINT UNSIGNED, unNombre VARCHAR(45), unApellido VARCHAR(50), unEmail VARCHAR(45), unaClave CHAR(64))
BEGIN
	INSERT INTO Cliente (idCLiente, nombre, apellido, email, clave)
		VALUES (unIdCliente, unNombre, unApellido, unEmail, unaClave);
	SELECT SHA2('clave', SHA256);
END $$

-- 3 Se pide hacer el SF ‘gananciaResto’ que reciba por parámetro un identificador de restaurant y 2 fechas, se debe devolver la ganancia que tuvo ese resto entre esas 2 fechas (inclusive). GANANCIA = SUMATORIA (cantidad * precio unitario plato)
DELIMITER $$
DROP FUNCTION IF EXISTS gananciaResto $$
CREATE FUNCTION gananciaResto (unIdRestaurente SMALLINT UNSIGNED, unInicio DATETIME, unFinal DATETIME)
RETURNS DECIMAL(7, 2) READS SQL DATA
BEGIN
    DECLARE ganancia DECIMAL(7, 2);
    
    SELECT SUM(cantidad * precio)  INTO ganancia
    FROM DetallePedido
    JOIN Pedido USING (NroPedido)
    WHERE idRestaurante = unIdRestaurante
    AND fechaHora BETWEEN inicio AND fin;
    
    RETURN ganancia;
END $$

-- 4 Se pide hacer el SP ‘Buscar’ que reciba por parámetro una cadena. El SP tiene que devolver los platos que contengan la cadena en su nombre, descripción o nombre del restaurante 

DELIMITER $$
DROP FUNCTION IF EXISTS Buscar $$
CREATE PROCEDURE Buscar (busqueda VARCHAR(50))
BEGIN
    SELECT idPlato, descripcion, P.nombre, precioUnitario, idRestaurante, disponibilidad
    FROM Plato P
    JOIN Restaurante R USING (idRestaurante)
    WHERE MATCH(P.nombre, R.nombre, descripcion) AGAINST (busqueda);    
END $$ 