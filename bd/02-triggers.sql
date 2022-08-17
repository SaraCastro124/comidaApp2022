USE ComidApp;

-- 1 Se tiene que hacer un trigger para que cada vez que se inserte un plato en un pedido determinado, se incremente el monto correspondiente en Venta. En caso de que no exista tal registro, se tiene que crear.
DELIMITER $$
DROP TRIGGER IF EXISTS AftInsDetallePedido $$
CREATE TRIGGER AftInsDetallePedido AFTER INSERT ON DetallePedido
FOR EACH ROW
BEGIN
		DECLARE varAnio SMALLINT UNSIGNED DEFAULT YEAR(CURDATE());
        DECLARE varMes SMALLINT UNSIGNED DEFAULT MONTH(CURDATE());
		DECLARE varIdResto SMALLINT UNSIGNED;
	
		SELECT idRestaurante INTO varIdResto
        FROM Plato
        WHERE idPlato = new.idPlato;
        
        IF(EXISTS(SELECT * 
				  FROM VentaResto
                  WHERE idRestaurante = varIdResto
                  AND Anio = varAnio
                  AND idPlato = new.idPlato
                  AND Mes = varMes )) THEN 
                  UPDATE VentaResto
                  SET monto = monto + new.precio * new.cantidad
                  WHERE idRestaurante = varIdResto
                  AND Anio = varAnio
                  AND idPlato = new.idPlato
                  AND Mes = varMes ;
        ELSE
			INSERT INTO ventaResto(anio, idPlato, mes, idRestaurante, monto)
						VALUES(varAnio, new.idplato, varMes,  varIdResto, new.precio * new.cantidad);
        END IF;

END $$
