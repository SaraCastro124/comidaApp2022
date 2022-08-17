DROP DATABASE IF EXISTS ComidApp;
CREATE DATABASE ComidApp;

CREATE TABLE ComidApp.Restaurante (
    idRestaurante SMALLINT UNSIGNED NOT NULL,
    Email VARCHAR(45) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Domicilio VARCHAR (45) NOT NULL,
    Clave CHAR(64) NOT NULL,
    PRIMARY KEY (idRestaurante),
    CONSTRAINT UQ_Restaurante_Email UNIQUE (Email),
    FULLTEXT (nombre)
);

CREATE TABLE ComidApp.Cliente (
    idCliente SMALLINT UNSIGNED NOT NULL,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    Email VARCHAR (45) NOT NULL,
    Clave CHAR(64) NOT NULL,
    PRIMARY KEY (idCliente),
    CONSTRAINT UQ_Cliente_Email UNIQUE (Email)
);

CREATE TABLE ComidApp.Pedido(
    idRestaurante SMALLINT UNSIGNED NOT NULL,
    NroPedido SMALLINT UNSIGNED NOT NULL,
    fechaHora DATETIME NOT NULL,
    idCliente SMALLINT UNSIGNED NOT NULL,
    precio DECIMAL(7.2) NOT NULL,
    opinion TINYINT UNSIGNED NOT NULL,
    descripcion VARCHAR(50) NOT NULL,
    PRIMARY KEY (NroPedido),
    CONSTRAINT FK_Pedido_Restaurante FOREIGN KEY (idRestaurante)
        REFERENCES ComidApp.Restaurante (idRestaurante),
    CONSTRAINT FK_Pedido_Cliente FOREIGN KEY (idCliente)
        REFERENCES ComidApp.Cliente (idCliente)
);

CREATE TABLE ComidApp.Plato (
    nombre VARCHAR(50) NOT NULL,
    descripcion VARCHAR(50) NOT NULL,
    idPlato SMALLINT UNSIGNED NOT NULL,
    precioUnitario DECIMAL(7,2) NOT NULL,
    idRestaurante SMALLINT UNSIGNED NOT NULL,
    disponibilidad SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idPlato),
    CONSTRAINT FK_Plato_Restaurante FOREIGN KEY (idRestaurante)
        REFERENCES ComidApp.Restaurante (idRestaurante),
    FULLTEXT (nombre, descripcion)
);

CREATE TABLE ComidApp.detallePedido (
    idPlato SMALLINT UNSIGNED NOT NULL,
    NroPedido SMALLINT UNSIGNED NOT NULL,
    Cantidad TINYINT UNSIGNED NOT NULL,
    Precio DECIMAL(7,2) NOT NULL,
    PRIMARY KEY (NroPedido, idPlato),
    CONSTRAINT FK_detallePedido_Plato FOREIGN KEY (idPlato)
        REFERENCES ComidApp.Plato (idPlato),
    CONSTRAINT FK_detallePedido_Pedido FOREIGN KEY (NroPedido)
        REFERENCES ComidApp.Pedido (NroPedido)
);

CREATE TABLE ComidAppp.VentaResto (
    Monto Decimal (9,2) NOT NULL,
    Anio SMALLINT UNSIGNED NOT NULL,
    idPlato SMALLINT UNSIGNED NOT NULL,
    Mes TINYINT UNSIGNED NOT NULL, 
    idRestaurante SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (Anio, Mes, idPlato, idRestaurante),
    CONSTRAINT FK_VentaResto_Plato  FOREIGN KEY (idPlato)
        REFERENCES ComidApp.Plato (idPlato),
    CONSTRAINT FK_VentaResto_Restaurante FOREIGN KEY (idRestaurante)
        REFERENCES ComidApp.Restaurante (idRestaurante)
);