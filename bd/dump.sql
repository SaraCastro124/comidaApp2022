delimiter ;
use ComidApp;
SELECT 'Dump' Estado;

CALL altaRestaurante (@idHavanna, 'havanna@gmail.com', 'Havanna', '9 de julio', 'stord_960' );
CALL altaRestaurante (@idTucson, 'tucson@gmail.com', 'Tucson', 'Av. Cordoba', 'mine_.763');
SELECT @idHavanna, @idTucson;
CALL altaPlato ('albondipapa', 'albondigas con papas fritas', @idAlbondipapa, 300, @idTucson, 50);
CALL altaPlato ('frappuchino', 'cafe con espuma y leche', @idfrappuccino, 480, @idHavanna, 169);
CALL altaPlato ('papas fritas', 'papas fritas', @idpapas, 300, @idTucson, 50);  
CALL registrarCliente (@idAbril, 'Abril', 'Chauque','ab@gmail.com', 's3');
CALL altaDetallePedido (@idPlato, 55, 1, 300);
CALL altaPedido (@idHavanna, @NroPedido, '2022-11-11', @idAbril, 480, 10, 'leche descremada');
