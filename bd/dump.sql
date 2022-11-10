delimiter ;
use ComidApp;

CALL altaRestaurante (@idHavanna, 'havanna@gmail.com', 'havanna', '9 de julio', 'stord_960' );
CALL altaRestaurante (@idTucson, 'tucson@gmail.com', 'tucson', 'Av. Cordoba', 'mine_.763');
CALL altaPlato ('albondipapa', 'albondigas con papas fritas', @idAlbondipapa, 300, 3, 50);
CALL altaPlato ('frappuchino', 'cafe con espuma y leche', @idfrappuccino, 480, 5, 169);
CALL altaPlato ('papas fritas', 'papas fritas', @idpapas, 300, 3, 50);  
CALL registrarCliente (@idAbril, 'Abril', 'Chauque','ab@gmail.com', 's3');
