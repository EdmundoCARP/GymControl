-- GymControl - gimnasio_db.sql
-- MariaDB 11.x
-- Proyecto: GymControl - Sistema de Gestión de Gimnasio

CREATE DATABASE IF NOT EXISTS gimnasio_db
  CHARACTER SET utf8mb4
  COLLATE utf8mb4_spanish_ci;

USE gimnasio_db;

SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE IF EXISTS pagos;
DROP TABLE IF EXISTS membresias;
DROP TABLE IF EXISTS horarios;
DROP TABLE IF EXISTS bitacora_accesos;
DROP TABLE IF EXISTS usuarios;
DROP TABLE IF EXISTS actividades;
DROP TABLE IF EXISTS salas;
DROP TABLE IF EXISTS instructores;
DROP TABLE IF EXISTS socios;
DROP TABLE IF EXISTS tipos_membresia;
DROP TABLE IF EXISTS roles;

SET FOREIGN_KEY_CHECKS = 1;

-- =========================================================
-- 1. ROLES
-- =========================================================
CREATE TABLE roles (
    id_rol INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(30) NOT NULL UNIQUE,
    descripcion VARCHAR(150) NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- =========================================================
-- 2. SOCIOS
-- =========================================================
CREATE TABLE socios (
    id_socio INT AUTO_INCREMENT PRIMARY KEY,
    cedula VARCHAR(16) NOT NULL UNIQUE,
    nombres VARCHAR(60) NOT NULL,
    apellidos VARCHAR(60) NOT NULL,
    fecha_nacimiento DATE NULL,
    genero ENUM('F','M') NULL,
    telefono VARCHAR(15) NULL,
    correo VARCHAR(100) NULL,
    direccion VARCHAR(200) NULL,
    fecha_registro DATE NOT NULL DEFAULT (CURRENT_DATE),
    activo TINYINT(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- =========================================================
-- 3. INSTRUCTORES
-- =========================================================
CREATE TABLE instructores (
    id_instructor INT AUTO_INCREMENT PRIMARY KEY,
    cedula VARCHAR(16) NOT NULL UNIQUE,
    nombres VARCHAR(60) NOT NULL,
    apellidos VARCHAR(60) NOT NULL,
    telefono VARCHAR(15) NULL,
    correo VARCHAR(100) NULL,
    especialidad VARCHAR(60) NULL,
    fecha_contratacion DATE NULL,
    activo TINYINT(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- =========================================================
-- 4. ACTIVIDADES
-- =========================================================
CREATE TABLE actividades (
    id_actividad INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    descripcion VARCHAR(200) NULL,
    duracion_min SMALLINT NOT NULL,
    cupo_maximo SMALLINT NOT NULL,
    activo TINYINT(1) NOT NULL DEFAULT 1,
    CONSTRAINT chk_act_duracion CHECK (duracion_min > 0),
    CONSTRAINT chk_act_cupo CHECK (cupo_maximo > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- =========================================================
-- 5. SALAS
-- =========================================================
CREATE TABLE salas (
    id_sala INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(40) NOT NULL UNIQUE,
    capacidad SMALLINT NOT NULL,
    activo TINYINT(1) NOT NULL DEFAULT 1,
    CONSTRAINT chk_sala_capacidad CHECK (capacidad > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- =========================================================
-- 6. TIPOS DE MEMBRESÍA
-- =========================================================
CREATE TABLE tipos_membresia (
    id_tipo INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(40) NOT NULL UNIQUE,
    descripcion VARCHAR(200) NULL,
    duracion_dias SMALLINT NOT NULL,
    precio DECIMAL(10,2) NOT NULL,
    incluye_clases TINYINT(1) NOT NULL DEFAULT 1,
    activo TINYINT(1) NOT NULL DEFAULT 1,
    CONSTRAINT chk_tipo_duracion CHECK (duracion_dias > 0),
    CONSTRAINT chk_tipo_precio CHECK (precio >= 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- =========================================================
-- 7. USUARIOS
-- =========================================================
CREATE TABLE usuarios (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nombre_usuario VARCHAR(40) NOT NULL UNIQUE,
    contrasena_hash VARCHAR(255) NOT NULL,
    sal VARCHAR(64) NOT NULL,
    id_rol INT NOT NULL,
    id_socio INT NULL UNIQUE,
    id_instructor INT NULL UNIQUE,
    intentos_fallidos TINYINT NOT NULL DEFAULT 0,
    activo TINYINT(1) NOT NULL DEFAULT 1,
    ultimo_acceso DATETIME NULL,

    CONSTRAINT fk_usuarios_rol
        FOREIGN KEY (id_rol)
        REFERENCES roles(id_rol)
        ON UPDATE CASCADE
        ON DELETE RESTRICT,

    CONSTRAINT fk_usuarios_socio
        FOREIGN KEY (id_socio)
        REFERENCES socios(id_socio)
        ON UPDATE CASCADE
        ON DELETE RESTRICT,

    CONSTRAINT fk_usuarios_instructor
        FOREIGN KEY (id_instructor)
        REFERENCES instructores(id_instructor)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- =========================================================
-- 8. MEMBRESÍAS
-- =========================================================
CREATE TABLE membresias (
    id_membresia INT AUTO_INCREMENT PRIMARY KEY,
    id_socio INT NOT NULL,
    id_tipo INT NOT NULL,
    fecha_inicio DATE NOT NULL,
    fecha_vencimiento DATE NOT NULL,
    precio_pactado DECIMAL(10,2) NOT NULL,
    estado ENUM('Activa','Vencida','Suspendida','Cancelada') NOT NULL DEFAULT 'Activa',

    CONSTRAINT chk_memb_fechas CHECK (fecha_vencimiento >= fecha_inicio),
    CONSTRAINT chk_memb_precio CHECK (precio_pactado >= 0),

    CONSTRAINT fk_memb_socio
        FOREIGN KEY (id_socio)
        REFERENCES socios(id_socio)
        ON UPDATE CASCADE
        ON DELETE RESTRICT,

    CONSTRAINT fk_memb_tipo
        FOREIGN KEY (id_tipo)
        REFERENCES tipos_membresia(id_tipo)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- =========================================================
-- 9. PAGOS
-- =========================================================
CREATE TABLE pagos (
    id_pago INT AUTO_INCREMENT PRIMARY KEY,
    id_membresia INT NOT NULL,
    id_usuario_registro INT NOT NULL,
    fecha_pago DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    monto DECIMAL(10,2) NOT NULL,
    metodo_pago ENUM('Efectivo','Tarjeta','Transferencia') NOT NULL,
    referencia VARCHAR(50) NULL,
    observacion VARCHAR(200) NULL,
    anulado TINYINT(1) NOT NULL DEFAULT 0,

    CONSTRAINT chk_pago_monto CHECK (monto > 0),

    CONSTRAINT fk_pago_membresia
        FOREIGN KEY (id_membresia)
        REFERENCES membresias(id_membresia)
        ON UPDATE CASCADE
        ON DELETE RESTRICT,

    CONSTRAINT fk_pago_usuario
        FOREIGN KEY (id_usuario_registro)
        REFERENCES usuarios(id_usuario)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- =========================================================
-- 10. HORARIOS
-- =========================================================
CREATE TABLE horarios (
    id_horario INT AUTO_INCREMENT PRIMARY KEY,
    id_instructor INT NOT NULL,
    id_actividad INT NOT NULL,
    id_sala INT NOT NULL,
    dia_semana TINYINT NOT NULL,
    hora_inicio TIME NOT NULL,
    hora_fin TIME NOT NULL,
    activo TINYINT(1) NOT NULL DEFAULT 1,

    CONSTRAINT chk_hor_dia CHECK (dia_semana BETWEEN 1 AND 7),
    CONSTRAINT chk_hor_horas CHECK (hora_fin > hora_inicio),

    CONSTRAINT fk_hor_instructor
        FOREIGN KEY (id_instructor)
        REFERENCES instructores(id_instructor)
        ON UPDATE CASCADE
        ON DELETE RESTRICT,

    CONSTRAINT fk_hor_actividad
        FOREIGN KEY (id_actividad)
        REFERENCES actividades(id_actividad)
        ON UPDATE CASCADE
        ON DELETE RESTRICT,

    CONSTRAINT fk_hor_sala
        FOREIGN KEY (id_sala)
        REFERENCES salas(id_sala)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- =========================================================
-- 11. BITÁCORA DE ACCESOS
-- =========================================================
CREATE TABLE bitacora_accesos (
    id_bitacora INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario INT NULL,
    usuario_intento VARCHAR(40) NOT NULL,
    fecha_hora DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    resultado ENUM('Exitoso','Fallido','Bloqueado') NOT NULL,
    equipo VARCHAR(60) NULL,

    CONSTRAINT fk_bitacora_usuario
        FOREIGN KEY (id_usuario)
        REFERENCES usuarios(id_usuario)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;

-- =========================================================
-- DATOS DE PRUEBA
-- =========================================================

-- Roles
INSERT INTO roles (nombre, descripcion) VALUES
('Administrador', 'Acceso completo al sistema'),
('Recepcionista', 'Gestiona socios, membresías y pagos'),
('Instructor', 'Consulta y gestiona sus actividades y horarios'),
('Socio', 'Consulta su información y membresías');

-- Socios: 15, incluyendo 2 inactivos
INSERT INTO socios
(cedula, nombres, apellidos, fecha_nacimiento, genero, telefono, correo, direccion, activo)
VALUES
('001-010101-0001A', 'Carlos', 'Martínez López', '1995-03-12', 'M', '88880001', 'carlos.martinez@gmail.com', 'Barrio El Centro', 1),
('001-020202-0002B', 'María', 'González Pérez', '1998-07-21', 'F', '88880002', 'maria.gonzalez@gmail.com', 'Barrio El Calvario', 1),
('001-030303-0003C', 'José', 'Hernández Ruiz', '1992-11-05', 'M', '88880003', 'jose.hernandez@gmail.com', 'Barrio San Antonio', 1),
('001-040404-0004D', 'Ana', 'López Torres', '2000-01-18', 'F', '88880004', 'ana.lopez@gmail.com', 'Barrio Esquipulas', 1),
('001-050505-0005E', 'Luis', 'Castillo Pérez', '1990-09-30', 'M', '88880005', 'luis.castillo@gmail.com', 'Barrio La Cruz', 1),
('001-060606-0006F', 'Sofía', 'Ramírez Díaz', '2001-05-14', 'F', '88880006', 'sofia.ramirez@gmail.com', 'Barrio Nuevo', 1),
('001-070707-0007G', 'Diego', 'Mendoza Silva', '1997-02-28', 'M', '88880007', 'diego.mendoza@gmail.com', 'Barrio San José', 1),
('001-080808-0008H', 'Valeria', 'Morales Cruz', '1999-12-09', 'F', '88880008', 'valeria.morales@gmail.com', 'Barrio El Carmen', 1),
('001-090909-0009I', 'Andrés', 'Rivas Flores', '1994-06-17', 'M', '88880009', 'andres.rivas@gmail.com', 'Barrio Las Flores', 1),
('001-101010-0010J', 'Daniela', 'Pineda Vargas', '2002-10-25', 'F', '88880010', 'daniela.pineda@gmail.com', 'Barrio San Martín', 1),
('001-111111-0011K', 'Fernando', 'Sánchez Gómez', '1988-04-03', 'M', '88880011', 'fernando.sanchez@gmail.com', 'Barrio El Rosario', 1),
('001-121212-0012L', 'Camila', 'Ruiz Navarro', '2003-08-11', 'F', '88880012', 'camila.ruiz@gmail.com', 'Barrio El Progreso', 1),
('001-131313-0013M', 'Ricardo', 'Vega Martínez', '1991-01-27', 'M', '88880013', 'ricardo.vega@gmail.com', 'Barrio La Unión', 1),
('001-141414-0014N', 'Paola', 'Torres Molina', '1996-03-19', 'F', '88880014', 'paola.torres@gmail.com', 'Barrio San Francisco', 0),
('001-151515-0015O', 'Miguel', 'Córdoba Reyes', '1989-11-22', 'M', '88880015', 'miguel.cordoba@gmail.com', 'Barrio La Libertad', 0);

-- Tipos de membresía
INSERT INTO tipos_membresia
(nombre, descripcion, duracion_dias, precio, incluye_clases, activo)
VALUES
('Pase diario', 'Acceso durante un día', 1, 80.00, 1, 1),
('Semanal', 'Acceso durante siete días', 7, 250.00, 1, 1),
('Mensual', 'Acceso durante treinta días', 30, 800.00, 1, 1),
('Trimestral', 'Acceso durante noventa días', 90, 2200.00, 1, 1),
('Semestral', 'Acceso durante ciento ochenta días', 180, 4200.00, 1, 1),
('Anual', 'Acceso durante trescientos sesenta y cinco días', 365, 7800.00, 1, 1);

-- Instructores: 4
INSERT INTO instructores
(cedula, nombres, apellidos, telefono, correo, especialidad, fecha_contratacion, activo)
VALUES
('002-010101-0001A', 'Roberto', 'Pérez Silva', '87770001', 'roberto.perez@gmail.com', 'Entrenamiento funcional', '2024-01-15', 1),
('002-020202-0002B', 'Laura', 'Méndez Cruz', '87770002', 'laura.mendez@gmail.com', 'Yoga y movilidad', '2024-03-10', 1),
('002-030303-0003C', 'Javier', 'Torres Gómez', '87770003', 'javier.torres@gmail.com', 'Spinning', '2023-08-20', 1),
('002-040404-0004D', 'Natalia', 'Ruiz Martínez', '87770004', 'natalia.ruiz@gmail.com', 'CrossFit', '2025-02-01', 1);

-- Actividades: 5
INSERT INTO actividades
(nombre, descripcion, duracion_min, cupo_maximo, activo)
VALUES
('Spinning', 'Clase de ciclismo bajo techo', 60, 20, 1),
('Yoga', 'Movilidad, respiración y relajación', 60, 15, 1),
('CrossFit', 'Entrenamiento funcional de alta intensidad', 60, 18, 1),
('Zumba', 'Clase grupal de baile y ejercicio', 45, 25, 1),
('Funcional', 'Entrenamiento funcional general', 50, 20, 1);

-- Salas: 3
INSERT INTO salas (nombre, capacidad, activo) VALUES
('Sala A', 25, 1),
('Sala Ciclo', 20, 1),
('Área Funcional', 30, 1);

-- Usuarios
-- Las contraseñas usan PBKDF2-SHA256, 100000 iteraciones, 16 bytes de sal y 32 bytes de hash.
-- Credenciales de prueba:
-- admin       / Admin123!
-- recepcion   / Recep123!
-- instructor  / Instr123!
-- socio       / Socio123!
-- admin2      / Admin456!
-- bloqueado   / Bloq123!  (cuenta bloqueada)
INSERT INTO usuarios
(nombre_usuario, contrasena_hash, sal, id_rol, id_socio, id_instructor, intentos_fallidos, activo)
VALUES
('admin',
 'zGTd9QPkppLHZMDVWhDCZU1XFTI2SqwkYN2s2ouQWrA=',
 'wNvs6/8sna7oZRYLc7EEHg==',
 1, NULL, NULL, 0, 1),

('recepcion',
 'Zpjwe/xwOQl9uthKpBUOqXXJXo0D+V4Ful6bODEhaBY=',
 '+3B+umcJ7oz8btENdpukdg==',
 2, NULL, NULL, 0, 1),

('instructor',
 'R5hXPgDaB5iNKb62xbpbIJVmdn4gNurHvC2JQujgI5w=',
 'HYKZgAGyxJQ7cnnP2P8d7A==',
 3, NULL, 1, 0, 1),

('socio',
 'VHDe4PPhlUpIhoYByUha3PN6CocQ8MrNvozbjTH2hig=',
 'u2tC5mFScFkeAEB8zDClZg==',
 4, 1, NULL, 0, 1),

('admin2',
 'c0RRYaP2iIxi6G5TQMkvVa/ltsq7bYJP/f388bDzf4Y=',
 '9SBBsp+af4KUhz6GKG3mEg==',
 1, NULL, NULL, 0, 1),

('bloqueado',
 'e+9I9+NTIN6y9K2nyW75569f9TP5uP7r9cwfy3Xa+xI=',
 'V/OGH8xAOzUJ+QpExrzFLw==',
 2, NULL, NULL, 3, 0);

-- Membresías: 15 con estados variados.
-- Se usan fechas relativas a CURRENT_DATE para que el script siga mostrando
-- casos próximos a vencer y vencidos cuando se ejecute.
INSERT INTO membresias
(id_socio, id_tipo, fecha_inicio, fecha_vencimiento, precio_pactado, estado)
VALUES
(1, 3, DATE_SUB(CURRENT_DATE, INTERVAL 10 DAY), DATE_ADD(CURRENT_DATE, INTERVAL 20 DAY), 800.00, 'Activa'),
(2, 3, DATE_SUB(CURRENT_DATE, INTERVAL 20 DAY), DATE_ADD(CURRENT_DATE, INTERVAL 5 DAY), 800.00, 'Activa'),
(3, 4, DATE_SUB(CURRENT_DATE, INTERVAL 60 DAY), DATE_ADD(CURRENT_DATE, INTERVAL 3 DAY), 2200.00, 'Activa'),
(4, 2, DATE_SUB(CURRENT_DATE, INTERVAL 2 DAY), DATE_ADD(CURRENT_DATE, INTERVAL 5 DAY), 250.00, 'Activa'),
(5, 5, DATE_SUB(CURRENT_DATE, INTERVAL 30 DAY), DATE_ADD(CURRENT_DATE, INTERVAL 2 DAY), 4200.00, 'Activa'),
(6, 3, DATE_SUB(CURRENT_DATE, INTERVAL 5 DAY), DATE_ADD(CURRENT_DATE, INTERVAL 25 DAY), 800.00, 'Activa'),
(7, 4, DATE_SUB(CURRENT_DATE, INTERVAL 40 DAY), DATE_ADD(CURRENT_DATE, INTERVAL 50 DAY), 2200.00, 'Activa'),
(8, 3, DATE_SUB(CURRENT_DATE, INTERVAL 50 DAY), DATE_SUB(CURRENT_DATE, INTERVAL 20 DAY), 800.00, 'Vencida'),
(9, 4, DATE_SUB(CURRENT_DATE, INTERVAL 150 DAY), DATE_SUB(CURRENT_DATE, INTERVAL 60 DAY), 2200.00, 'Vencida'),
(10, 2, DATE_SUB(CURRENT_DATE, INTERVAL 20 DAY), DATE_SUB(CURRENT_DATE, INTERVAL 13 DAY), 250.00, 'Vencida'),
(11, 5, DATE_SUB(CURRENT_DATE, INTERVAL 80 DAY), DATE_ADD(CURRENT_DATE, INTERVAL 100 DAY), 4000.00, 'Suspendida'),
(12, 3, DATE_SUB(CURRENT_DATE, INTERVAL 15 DAY), DATE_ADD(CURRENT_DATE, INTERVAL 15 DAY), 750.00, 'Activa'),
(13, 6, DATE_SUB(CURRENT_DATE, INTERVAL 100 DAY), DATE_ADD(CURRENT_DATE, INTERVAL 265 DAY), 7800.00, 'Activa'),
(14, 3, DATE_SUB(CURRENT_DATE, INTERVAL 30 DAY), DATE_ADD(CURRENT_DATE, INTERVAL 0 DAY), 800.00, 'Cancelada'),
(15, 2, DATE_SUB(CURRENT_DATE, INTERVAL 100 DAY), DATE_SUB(CURRENT_DATE, INTERVAL 93 DAY), 250.00, 'Vencida');

-- Pagos: 20 registros.
-- Se incluyen pagos completos, abonos parciales y un pago anulado.
INSERT INTO pagos
(id_membresia, id_usuario_registro, fecha_pago, monto, metodo_pago, referencia, observacion, anulado)
VALUES
(1, 2, NOW(), 400.00, 'Efectivo', NULL, 'Primer abono', 0),
(1, 2, NOW(), 200.00, 'Tarjeta', 'TAR-1001', 'Segundo abono', 0),
(2, 2, NOW(), 500.00, 'Efectivo', NULL, 'Abono parcial', 0),
(3, 2, NOW(), 1000.00, 'Transferencia', 'TRF-1001', 'Abono inicial', 0),
(3, 2, NOW(), 700.00, 'Efectivo', NULL, 'Segundo abono', 0),
(4, 2, NOW(), 250.00, 'Tarjeta', 'TAR-1002', 'Pago completo', 0),
(5, 2, NOW(), 2000.00, 'Transferencia', 'TRF-1002', 'Abono semestral', 0),
(6, 2, NOW(), 800.00, 'Efectivo', NULL, 'Pago completo', 0),
(7, 2, NOW(), 1200.00, 'Tarjeta', 'TAR-1003', 'Abono', 0),
(7, 2, NOW(), 500.00, 'Efectivo', NULL, 'Segundo abono', 0),
(8, 2, DATE_SUB(NOW(), INTERVAL 25 DAY), 800.00, 'Efectivo', NULL, 'Pago de membresía vencida', 0),
(9, 2, DATE_SUB(NOW(), INTERVAL 70 DAY), 1000.00, 'Transferencia', 'TRF-1003', 'Abono', 0),
(10, 2, DATE_SUB(NOW(), INTERVAL 14 DAY), 100.00, 'Efectivo', NULL, 'Abono parcial', 0),
(11, 2, DATE_SUB(NOW(), INTERVAL 20 DAY), 2000.00, 'Tarjeta', 'TAR-1004', 'Pago registrado antes de suspensión', 0),
(12, 2, NOW(), 300.00, 'Efectivo', NULL, 'Abono parcial', 0),
(12, 2, NOW(), 200.00, 'Transferencia', 'TRF-1004', 'Segundo abono', 0),
(13, 2, NOW(), 3000.00, 'Tarjeta', 'TAR-1005', 'Abono anual', 0),
(14, 2, DATE_SUB(NOW(), INTERVAL 10 DAY), 800.00, 'Efectivo', NULL, 'Pago posteriormente anulado', 1),
(15, 2, DATE_SUB(NOW(), INTERVAL 90 DAY), 250.00, 'Efectivo', NULL, 'Pago de membresía vencida', 0),
(2, 2, NOW(), 100.00, 'Transferencia', 'TRF-1005', 'Abono adicional', 0);

-- Horarios: 15, distribuidos de lunes a sábado y sin choques.
INSERT INTO horarios
(id_instructor, id_actividad, id_sala, dia_semana, hora_inicio, hora_fin, activo)
VALUES
(1, 5, 3, 1, '07:00:00', '07:50:00', 1),
(2, 2, 1, 1, '09:00:00', '10:00:00', 1),
(3, 1, 2, 1, '18:00:00', '19:00:00', 1),
(4, 3, 3, 1, '19:30:00', '20:30:00', 1),
(1, 4, 1, 2, '08:00:00', '08:45:00', 1),
(2, 2, 1, 2, '17:00:00', '18:00:00', 1),
(3, 1, 2, 2, '18:30:00', '19:30:00', 1),
(4, 3, 3, 3, '07:00:00', '08:00:00', 1),
(1, 5, 3, 3, '18:00:00', '18:50:00', 1),
(2, 2, 1, 4, '09:00:00', '10:00:00', 1),
(3, 1, 2, 4, '18:00:00', '19:00:00', 1),
(4, 3, 3, 4, '19:30:00', '20:30:00', 1),
(1, 4, 1, 5, '08:00:00', '08:45:00', 1),
(2, 2, 1, 6, '09:00:00', '10:00:00', 1),
(3, 1, 2, 6, '18:00:00', '19:00:00', 1);

-- Bitácora de accesos
INSERT INTO bitacora_accesos
(id_usuario, usuario_intento, fecha_hora, resultado, equipo)
VALUES
(1, 'admin', DATE_SUB(NOW(), INTERVAL 2 DAY), 'Exitoso', 'PC-ADMIN'),
(2, 'recepcion', DATE_SUB(NOW(), INTERVAL 1 DAY), 'Exitoso', 'PC-RECEPCION'),
(4, 'socio', DATE_SUB(NOW(), INTERVAL 8 HOUR), 'Exitoso', 'PC-SOCIO'),
(NULL, 'usuario_inexistente', DATE_SUB(NOW(), INTERVAL 5 HOUR), 'Fallido', 'PC-RECEPCION'),
(6, 'bloqueado', DATE_SUB(NOW(), INTERVAL 2 HOUR), 'Bloqueado', 'PC-RECEPCION');

-- =========================================================
-- USUARIO DE APLICACIÓN
-- =========================================================
-- La aplicación NO debe conectarse con root.
CREATE USER IF NOT EXISTS 'gym_app'@'localhost'
IDENTIFIED BY 'Gym#2026app';

GRANT SELECT, INSERT, UPDATE, DELETE
ON gimnasio_db.* TO 'gym_app'@'localhost';

FLUSH PRIVILEGES;

-- =========================================================
-- CONSULTAS DE COMPROBACIÓN
-- =========================================================
SELECT 'roles' AS tabla, COUNT(*) AS cantidad FROM roles
UNION ALL SELECT 'usuarios', COUNT(*) FROM usuarios
UNION ALL SELECT 'socios', COUNT(*) FROM socios
UNION ALL SELECT 'tipos_membresia', COUNT(*) FROM tipos_membresia
UNION ALL SELECT 'membresias', COUNT(*) FROM membresias
UNION ALL SELECT 'pagos', COUNT(*) FROM pagos
UNION ALL SELECT 'instructores', COUNT(*) FROM instructores
UNION ALL SELECT 'actividades', COUNT(*) FROM actividades
UNION ALL SELECT 'salas', COUNT(*) FROM salas
UNION ALL SELECT 'horarios', COUNT(*) FROM horarios
UNION ALL SELECT 'bitacora_accesos', COUNT(*) FROM bitacora_accesos;
