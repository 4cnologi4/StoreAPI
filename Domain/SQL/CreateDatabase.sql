CREATE TABLE Clientes (
    ClienteId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Apellidos NVARCHAR(100),
    Direccion NVARCHAR(255)
);

CREATE TABLE Tienda (
    TiendaId INT IDENTITY(1,1) PRIMARY KEY,
    Sucursal NVARCHAR(100),
    Direccion NVARCHAR(255)
);

CREATE TABLE Articulos (
    ArticuloId INT IDENTITY(1,1) PRIMARY KEY,
    Codigo NVARCHAR(50),
    Descripcion NVARCHAR(255),
    Precio DECIMAL(18,2),
    Imagen NVARCHAR(255),
    Stock INT
);

CREATE TABLE Articulo_Tienda (
    ArticuloId INT,
    TiendaId INT,
    Fecha DATETIME,
    FOREIGN KEY (ArticuloId) REFERENCES Articulos(ArticuloId),
    FOREIGN KEY (TiendaId) REFERENCES Tienda(TiendaId)
);

CREATE TABLE Cliente_Articulo (
    ClienteId INT,
    ArticuloId INT,
    Fecha DATETIME,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(ClienteId),
    FOREIGN KEY (ArticuloId) REFERENCES Articulos(ArticuloId)
);

