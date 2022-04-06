DROP DATABASE IF EXIST ComidApp;
CREATE DATABASE ComidApp;

CREATE TABLE ComidApp.Restaurante (
    idRestaurante SMALLINT UNSIGNED NOT NULL,
    Email VARCHAR(45) NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Domicilio VARCHAR (45) NOT NULL,
    Clave CHAR(64) NOT NULL,
    PRIMARY KEY (idRestaurante),
    CONSTRAINT UQ_Restaurante_Email UNIQUE (Email)
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
    CONSTRAINT FK_Pedido_Cliente FOREIGN KEY (idCliente)
    REFERENCES ComidApp.Restaurante (idRestaurante)
    REFERENCES ComidApp.Cliente (idCliente)
);

CREATE TABLE ComidApp.detallePedido ()
    idPlato SMALLINT UNSIGNED NOT NULL,
    NroPedido SMALLINT UNSIGNED NOT NULL,
    Cantidad TINYINT UNSIGNED NOT NULL,
    Precio DECIMAL(7,2) NOT NULL,
    PRIMARY KEY (idPlato),
    PRIMARY KEY (NroPedido),
    CONSTRAINT FK_detallePedido_Plato FOREIGN KEY (idPlato)
    CONSTRAINT FK_detallePedido_Pedido FOREIGN KEY (NroPedido)
    REFERENCES ComidApp.Pedido (NroPedido)
    REFERENCES ComidApp.Plato (idPlato)

);

CREATE TABLE Plato (
    nombre VARCHAR(50) NOT NULL,
    descripcion VARCHAR(50) NOT NULL,
    idPlato SMALLINT UNSIGNED NOT NULL,
    precioUnitario DECIMAL(7,2) NOT NULL,
    idRestaurante SMALLINT UNSIGNED NOT NULL,
    disponibilidad SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idPlato),
    CONSTRAINT FK_Plato_Restaurante FOREIGN KEY (idRestaurante)
    REFERENCES ComidApp.Restaurante (idPlato )
    CONSTRAINT FK_Plato_detallePedido FOREIGN KEY (idPlato)
    REFERENCES ComidApp.detallePedido (idPlato)
);

