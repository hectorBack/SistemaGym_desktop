CREATE DATABASE IF NOT EXISTS bd_gym;
USE bd_gym;

-- 1. TABLA USUARIOS (Para el sistema)
CREATE TABLE Usuarios (
    UsuarioID INT AUTO_INCREMENT PRIMARY KEY,
    NombreCompleto VARCHAR(100) NOT NULL,
    Usuario VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL, -- Guardar contraseña encriptada
    Rol VARCHAR(20) NOT NULL DEFAULT 'Vendedor', -- Ej. Administrador, Vendedor
    Activo BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- 2. TABLA SOCIOS (Clientes del gimnasio)
CREATE TABLE Socios (
    SocioID INT AUTO_INCREMENT PRIMARY KEY,
    Clave VARCHAR(20) NOT NULL UNIQUE,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    Foto VARCHAR(255),
    Observaciones TEXT,
    Activo BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- 3. TABLA MEMBRESÍAS (Tipos de suscripciones)
CREATE TABLE Membresias (
    MembresiaID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL, -- Ej: Pase Mensual, Pase Anual, Pase Diario
    Precio DECIMAL(10,2) NOT NULL,
    DuracionDias INT NOT NULL, -- Ej: 30 días
    Activo BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- 4. TABLA CATEGORÍAS (Para los productos de la tienda)
CREATE TABLE Categorias (
    CategoriaID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Activo BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- 5. TABLA PRODUCTOS (Suplementos, bebidas, accesorios)
CREATE TABLE Productos (
    ProductoID INT AUTO_INCREMENT PRIMARY KEY,
    CategoriaID INT NOT NULL,
    CodigoBarras VARCHAR(50),
    Nombre VARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL DEFAULT 0,
    Activo BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (CategoriaID) REFERENCES Categorias(CategoriaID)
);

-- 6. TABLA SOCIO_MEMBRESIA (Asignación y vencimiento de pases)
CREATE TABLE SocioMembresia (
    SocioMembresiaID INT AUTO_INCREMENT PRIMARY KEY,
    SocioID INT NOT NULL,
    MembresiaID INT NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL,
    Estado VARCHAR(20) DEFAULT 'Activa', -- Activa, Vencida, Cancelada
    Activo BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (SocioID) REFERENCES Socios(SocioID),
    FOREIGN KEY (MembresiaID) REFERENCES Membresias(MembresiaID)
);

-- 7. TABLA CABECERA VENTAS
CREATE TABLE Ventas (
    VentaID INT AUTO_INCREMENT PRIMARY KEY,
    UsuarioID INT NOT NULL,
    SocioID INT NULL, -- Puede ser NULL si es un cliente casual
    Total DECIMAL(10,2) NOT NULL,
    FechaVenta DATETIME DEFAULT CURRENT_TIMESTAMP,
    Activo BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
    FOREIGN KEY (SocioID) REFERENCES Socios(SocioID)
);

-- 8. TABLA DETALLE VENTAS
CREATE TABLE DetalleVentas (
    DetalleID INT AUTO_INCREMENT PRIMARY KEY,
    VentaID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL,
    Activo BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (VentaID) REFERENCES Ventas(VentaID),
    FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

CREATE TABLE Visitas (
    VisitaID INT AUTO_INCREMENT PRIMARY KEY,
    SocioID INT NULL,                        -- NULL si es un visitante casual
    MembresiaID INT NULL,                    -- ID de la membresía 'Visita'
    Clave VARCHAR(50) NOT NULL,              -- '100' para casuales o la clave del socio
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NULL,
    Telefono VARCHAR(20) NULL,
    MontoPagado DECIMAL(10, 2) NOT NULL DEFAULT 0.00,
    TipoAcceso VARCHAR(20) NOT NULL,         -- 'Socio' o 'Visita Casual'
    Observaciones VARCHAR(255) NULL,
    CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT FK_Visitas_Socios FOREIGN KEY (SocioID) REFERENCES Socios(SocioID) ON DELETE SET NULL,
    CONSTRAINT FK_Visitas_Membresias FOREIGN KEY (MembresiaID) REFERENCES Membresias(MembresiaID) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

ALTER TABLE Visitas 
ADD COLUMN Activo TINYINT(1) NOT NULL DEFAULT 1 AFTER Observaciones;

CREATE TABLE pagos_sociomembresia (
    PagoID INT AUTO_INCREMENT PRIMARY KEY,
    SocioMembresiaID INT NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    Folio VARCHAR(50) NULL,
    FormaPago VARCHAR(30) DEFAULT 'Efectivo',
    Observacion VARCHAR(255) NULL,
    Activo BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT FK_Pagos_SocioMembresia 
        FOREIGN KEY (SocioMembresiaID) 
        REFERENCES SocioMembresia(SocioMembresiaID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE Conceptos (
    ConceptoID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Tipo VARCHAR(50) NOT NULL,
    Observacion VARCHAR(255) NULL,
    EsSistema BOOLEAN NOT NULL DEFAULT FALSE,
    Activo BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- ALTER TABLE Conceptos ADD COLUMN  EsSistema BOOLEAN NOT NULL DEFAULT FALSE;
INSERT INTO Conceptos (ConceptoID, Nombre, Tipo, Observacion, EsSistema, Activo) VALUES
(1, 'Venta Producto', 'Ingreso', 'No se puede modificar', TRUE, TRUE),
(2, 'Compra Producto', 'Egreso', 'No se puede modificar', TRUE, TRUE),
(3, 'Pago Membresia', 'Ingreso', 'No se puede modificar', TRUE, TRUE),
(4, 'Cancelacion Pago Membresia', 'Egreso', 'No se puede modificar', TRUE, TRUE),
(5, 'Cancelacion Venta Producto', 'Egreso', 'No se puede modificar', TRUE, TRUE),
(6, 'Cancelacion Compra Producto', 'Ingreso', 'No se puede modificar', TRUE, TRUE),
(7, 'Visita', 'Ingreso', 'No se puede modificar', TRUE, TRUE),
(8, 'Cancelacion Visita', 'Egreso', 'No se puede modificar', TRUE, TRUE)
ON DUPLICATE KEY UPDATE 
    Nombre = VALUES(Nombre),
    Tipo = VALUES(Tipo),
    Observacion = VALUES(Observacion),
    EsSistema = VALUES(EsSistema);
    
-- Prevenir MODIFICACIÓN de conceptos del sistema
-- 1. Cambiamos el delimitador para que acepte los ; internos
DELIMITER //

-- Prevenir MODIFICACIÓN de conceptos del sistema
CREATE TRIGGER trg_Prevent_Update_Conceptos_Sistema
BEFORE UPDATE ON Conceptos
FOR EACH ROW
BEGIN
    IF OLD.EsSistema = TRUE THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Error: Los conceptos del sistema no se pueden modificar.';
    END IF;
END //

-- Prevenir ELIMINACIÓN de conceptos del sistema
CREATE TRIGGER trg_Prevent_Delete_Conceptos_Sistema
BEFORE DELETE ON Conceptos
FOR EACH ROW
BEGIN
    IF OLD.EsSistema = TRUE THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Error: Los conceptos del sistema no se pueden eliminar.';
    END IF;
END //

-- 2. Restauramos el delimitador original
DELIMITER ;

CREATE TABLE IF NOT EXISTS Movimientos (
    MovimientoID INT AUTO_INCREMENT PRIMARY KEY,
    Tipo VARCHAR(20) NOT NULL,
    ConceptoID INT NOT NULL,
    FormaPago VARCHAR(30) DEFAULT 'Efectivo',
    Total DECIMAL(10,2) NOT NULL,
    Observacion VARCHAR(255) NULL,
    CorteID INT NULL,
    UsuarioID INT NULL, -- Puesto como NULL temporalmente hasta que crees la tabla Usuarios
    Activo BOOLEAN DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,

    -- Única relación activa por ahora (hacia la tabla Conceptos)
    CONSTRAINT FK_Movimientos_Conceptos 
        FOREIGN KEY (ConceptoID) 
        REFERENCES Conceptos(ConceptoID)
        ON DELETE RESTRICT
        ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Ejecutar este bloque en el futuro cuando ya existan las tablas Usuarios y Cortes

-- 1. Enlazar con la tabla Usuarios (cambiando la columna a NOT NULL de ser necesario)
ALTER TABLE Movimientos
    MODIFY COLUMN UsuarioID INT NOT NULL,
    ADD CONSTRAINT FK_Movimientos_Usuarios 
        FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
        ON DELETE RESTRICT ON UPDATE CASCADE;

-- 2. Enlazar con la tabla Cortes
ALTER TABLE Movimientos
    ADD CONSTRAINT FK_Movimientos_Cortes 
        FOREIGN KEY (CorteID) REFERENCES Cortes(CorteID)
        ON DELETE SET NULL ON UPDATE CASCADE;
        
CREATE TABLE Roles (
    RolID INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL UNIQUE,
    Descripcion VARCHAR(255) NULL,
    ModulosPermitidos JSON NOT NULL,
    Activo BOOLEAN NOT NULL DEFAULT TRUE,
    CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 1. Rol Administrador (Acceso total a todos los módulos)
INSERT INTO roles (Nombre, Descripcion, ModulosPermitidos) 
VALUES (
    'Administrador', 
    'Acceso total al sistema', 
    '["Usuarios", "Roles", "Socios", "Membresias", "Clases", "Productos", "Compras", "Ventas", "Registro", "Reportes", "Configuracion", "Respaldar", "Restaurar", "Corte de Caja", "Eliminar", "Conceptos", "Movimientos"]'
);

-- 2. Rol Recepción / Operativo (Acceso limitado)
INSERT INTO roles (Nombre, Descripcion, ModulosPermitidos) 
VALUES (
    'Recepción', 
    'Atención a socios y ventas diarias', 
    '["Socios", "Membresias", "Clases", "Ventas", "Registro", "Corte de Caja", "Movimientos"]'
);

-- Insertar usuario administrador por defecto (Password: admin123 de prueba)
INSERT INTO Usuarios (NombreCompleto, Usuario, Password, Rol) 
VALUES ('Administrador General', 'admin', 'admin123', 'Administrador');

-- Paso 1: Agregar la columna RolID permitiendo NULL temporalmente o sin la FK aún
ALTER TABLE Usuarios 
DROP COLUMN Rol,
ADD COLUMN RolID INT NOT NULL DEFAULT 1 AFTER Password;

-- Paso 2: (Opcional) Asegurarte de que el registro 'admin' tenga asignado el RolID 1 (Administrador)
UPDATE Usuarios 
SET RolID = 1 
WHERE Usuario = 'admin';

-- Paso 3: Agregar la clave foránea ahora que los datos son válidos
ALTER TABLE Usuarios
ADD CONSTRAINT FK_Usuarios_Roles 
    FOREIGN KEY (RolID) REFERENCES roles(RolID)
    ON DELETE RESTRICT 
    ON UPDATE CASCADE;