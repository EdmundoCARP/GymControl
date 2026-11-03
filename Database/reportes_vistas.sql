-- =========================================================
-- GymControl - reportes_vistas.sql
-- MariaDB 11.x / 13.x
--
-- Ejecutar DESPUES de gimnasio_db.sql, conectado como root
-- (o con un usuario que pueda crear vistas, usuarios y
-- otorgar permisos).
--
-- Este script:
--   1. Crea las cuatro vistas del modulo de reportes:
--        vw_ingresos_detalle
--        vw_saldos_membresia
--        vw_estado_cuenta
--        vw_horario_semanal
--   2. Crea el usuario de SOLO LECTURA gym_reportes.
--   3. Le otorga SELECT unicamente sobre esas vistas.
--
-- Las vistas son SQL SECURITY DEFINER: se ejecutan con los
-- privilegios de quien las crea (root), por eso gym_reportes
-- puede consultarlas sin acceso a las tablas base.
--
-- La clave del usuario NO se escribe en el codigo de la
-- aplicacion. Se guarda con:
--   dotnet user-secrets set "Reportes:ClaveBD" "<clave>"
-- o en la variable de entorno GYM_REPORTES_CLAVE.
-- Si cambia la clave aqui, actualice el secreto local.
-- =========================================================

USE gimnasio_db;

-- =========================================================
-- 1. VISTAS DE REPORTES
-- =========================================================

-- ---------------------------------------------------------
-- 1.1 vw_ingresos_detalle
--     pagos + membresias + socios + tipos_membresia + usuarios
--     La usan R01, R04, R08 y R09.
-- ---------------------------------------------------------
CREATE OR REPLACE SQL SECURITY DEFINER VIEW vw_ingresos_detalle AS
SELECT
    p.id_pago,
    LPAD(p.id_pago, 6, '0')                          AS numero_recibo,
    DATE(p.fecha_pago)                               AS fecha,
    p.fecha_pago,
    TIME(p.fecha_pago)                               AS hora,
    DATE_FORMAT(p.fecha_pago, '%Y-%m')               AS periodo,
    YEAR(p.fecha_pago)                               AS anio,
    MONTH(p.fecha_pago)                              AS mes,
    s.id_socio,
    s.cedula,
    CONCAT(s.nombres, ' ', s.apellidos)              AS socio,
    m.id_membresia,
    m.id_tipo,
    tm.nombre                                        AS plan,
    m.fecha_inicio,
    m.fecha_vencimiento,
    m.precio_pactado,
    p.monto,
    p.metodo_pago,
    p.referencia,
    p.observacion,
    p.anulado,
    CASE p.anulado WHEN 1 THEN 'Anulado' ELSE 'Vigente' END
                                                     AS estado_pago,
    p.id_usuario_registro,
    COALESCE(u.nombre_usuario, 'Sistema')            AS registrado_por,
    COALESCE((
        SELECT SUM(p2.monto)
          FROM pagos p2
         WHERE p2.id_membresia = m.id_membresia
           AND p2.anulado = 0
    ), 0)                                            AS pagado_membresia,
    m.precio_pactado - COALESCE((
        SELECT SUM(p2.monto)
          FROM pagos p2
         WHERE p2.id_membresia = m.id_membresia
           AND p2.anulado = 0
    ), 0)                                            AS saldo_membresia
FROM pagos p
INNER JOIN membresias m
        ON m.id_membresia = p.id_membresia
INNER JOIN socios s
        ON s.id_socio = m.id_socio
INNER JOIN tipos_membresia tm
        ON tm.id_tipo = m.id_tipo
LEFT JOIN usuarios u
       ON u.id_usuario = p.id_usuario_registro;

-- ---------------------------------------------------------
-- 1.2 vw_saldos_membresia
--     membresias + socios + tipos_membresia + pagos
--     La usan R02, R03, R07 y R08.
--     Incluye todas las membresias (tambien las que ya
--     estan pagadas) para que R03 pueda decidir con el
--     filtro "Solo con saldo".
-- ---------------------------------------------------------
CREATE OR REPLACE SQL SECURITY DEFINER VIEW vw_saldos_membresia AS
SELECT
    m.id_membresia,
    s.id_socio,
    s.cedula,
    CONCAT(s.nombres, ' ', s.apellidos)              AS socio,
    s.telefono,
    s.correo,
    m.id_tipo,
    tm.nombre                                        AS plan,
    tm.duracion_dias,
    m.fecha_inicio,
    m.fecha_vencimiento,
    m.precio_pactado,
    COALESCE((
        SELECT SUM(p.monto)
          FROM pagos p
         WHERE p.id_membresia = m.id_membresia
           AND p.anulado = 0
    ), 0)                                            AS pagado,
    m.precio_pactado - COALESCE((
        SELECT SUM(p.monto)
          FROM pagos p
         WHERE p.id_membresia = m.id_membresia
           AND p.anulado = 0
    ), 0)                                            AS saldo,
    m.estado,
    CASE
        WHEN m.estado = 'Activa' AND m.fecha_vencimiento < CURRENT_DATE
            THEN 'Vencida'
        ELSE m.estado
    END                                              AS estado_real,
    DATEDIFF(m.fecha_vencimiento, CURRENT_DATE)      AS dias_restantes,
    GREATEST(DATEDIFF(CURRENT_DATE, m.fecha_vencimiento), 0)
                                                     AS dias_vencido
FROM membresias m
INNER JOIN socios s
        ON s.id_socio = m.id_socio
INNER JOIN tipos_membresia tm
        ON tm.id_tipo = m.id_tipo;

-- ---------------------------------------------------------
-- 1.3 vw_estado_cuenta
--     socios + membresias + tipos_membresia + pagos
--     La usa R05. Se usa LEFT JOIN para que una membresia
--     sin pagos tambien aparezca (con id_pago NULL).
-- ---------------------------------------------------------
CREATE OR REPLACE SQL SECURITY DEFINER VIEW vw_estado_cuenta AS
SELECT
    s.id_socio,
    s.cedula,
    CONCAT(s.nombres, ' ', s.apellidos)              AS socio,
    s.telefono,
    s.correo,
    m.id_membresia,
    m.id_tipo,
    tm.nombre                                        AS plan,
    m.fecha_inicio,
    m.fecha_vencimiento,
    m.precio_pactado,
    m.estado,
    CASE
        WHEN m.estado = 'Activa' AND m.fecha_vencimiento < CURRENT_DATE
            THEN 'Vencida'
        ELSE m.estado
    END                                              AS estado_real,
    p.id_pago,
    LPAD(p.id_pago, 6, '0')                          AS numero_recibo,
    p.fecha_pago,
    DATE(p.fecha_pago)                               AS fecha,
    p.monto,
    p.metodo_pago,
    p.referencia,
    p.anulado,
    COALESCE((
        SELECT SUM(p2.monto)
          FROM pagos p2
         WHERE p2.id_membresia = m.id_membresia
           AND p2.anulado = 0
    ), 0)                                            AS pagado_membresia,
    m.precio_pactado - COALESCE((
        SELECT SUM(p2.monto)
          FROM pagos p2
         WHERE p2.id_membresia = m.id_membresia
           AND p2.anulado = 0
    ), 0)                                            AS saldo_membresia,
    COALESCE((
        SELECT SUM(p3.monto)
          FROM pagos p3
         INNER JOIN membresias m3
                 ON m3.id_membresia = p3.id_membresia
         WHERE m3.id_socio = s.id_socio
           AND p3.anulado = 0
    ), 0)                                            AS pagado_socio_total,
    COALESCE((
        SELECT SUM(m4.precio_pactado)
          FROM membresias m4
         WHERE m4.id_socio = s.id_socio
           AND m4.estado <> 'Cancelada'
    ), 0) - COALESCE((
        SELECT SUM(p4.monto)
          FROM pagos p4
         INNER JOIN membresias m4
                 ON m4.id_membresia = p4.id_membresia
         WHERE m4.id_socio = s.id_socio
           AND p4.anulado = 0
    ), 0)                                            AS saldo_socio_total
FROM socios s
INNER JOIN membresias m
        ON m.id_socio = s.id_socio
INNER JOIN tipos_membresia tm
        ON tm.id_tipo = m.id_tipo
LEFT JOIN pagos p
       ON p.id_membresia = m.id_membresia;

-- ---------------------------------------------------------
-- 1.4 vw_horario_semanal
--     horarios + actividades + instructores + salas
--     La usan R06 y R08.
-- ---------------------------------------------------------
CREATE OR REPLACE SQL SECURITY DEFINER VIEW vw_horario_semanal AS
SELECT
    h.id_horario,
    h.dia_semana,
    h.dia_semana                                     AS dia,
    CASE h.dia_semana
        WHEN 1 THEN 'Lunes'
        WHEN 2 THEN 'Martes'
        WHEN 3 THEN 'Miércoles'
        WHEN 4 THEN 'Jueves'
        WHEN 5 THEN 'Viernes'
        WHEN 6 THEN 'Sábado'
        WHEN 7 THEN 'Domingo'
    END                                              AS nombre_dia,
    h.hora_inicio,
    h.hora_fin,
    TIMESTAMPDIFF(MINUTE, h.hora_inicio, h.hora_fin) AS minutos,
    ROUND(TIMESTAMPDIFF(MINUTE, h.hora_inicio, h.hora_fin) / 60, 2)
                                                     AS horas,
    a.id_actividad,
    a.nombre                                         AS actividad,
    a.cupo_maximo,
    i.id_instructor,
    CONCAT(i.nombres, ' ', i.apellidos)              AS instructor,
    i.especialidad,
    sa.id_sala,
    sa.nombre                                        AS sala,
    sa.capacidad,
    ROUND(a.cupo_maximo * 100.0 / NULLIF(sa.capacidad, 0), 1)
                                                     AS ocupacion_pct,
    CASE h.activo WHEN 1 THEN 'Activo' ELSE 'Inactivo' END
                                                     AS estado
FROM horarios h
INNER JOIN actividades a
        ON a.id_actividad = h.id_actividad
INNER JOIN instructores i
        ON i.id_instructor = h.id_instructor
INNER JOIN salas sa
        ON sa.id_sala = h.id_sala;

-- =========================================================
-- 2. USUARIO DE SOLO LECTURA PARA REPORTES
-- =========================================================
-- La clave debe coincidir con el secreto Reportes:ClaveBD.
-- No se escribe en el codigo fuente de la aplicacion.
-- =========================================================
CREATE USER IF NOT EXISTS 'gym_reportes'@'localhost'
    IDENTIFIED BY 'Gym#2026rep';

-- Por si el usuario ya existia con otra clave.
ALTER USER 'gym_reportes'@'localhost'
    IDENTIFIED BY 'Gym#2026rep';

-- Quitar permisos previos (deja solo lo que se otorga abajo).
REVOKE ALL PRIVILEGES, GRANT OPTION FROM 'gym_reportes'@'localhost';

-- SELECT unicamente sobre las vistas del modulo de reportes.
GRANT SELECT ON gimnasio_db.vw_ingresos_detalle  TO 'gym_reportes'@'localhost';
GRANT SELECT ON gimnasio_db.vw_saldos_membresia  TO 'gym_reportes'@'localhost';
GRANT SELECT ON gimnasio_db.vw_estado_cuenta     TO 'gym_reportes'@'localhost';
GRANT SELECT ON gimnasio_db.vw_horario_semanal   TO 'gym_reportes'@'localhost';

FLUSH PRIVILEGES;

-- =========================================================
-- 3. COMPROBACION
-- =========================================================
SHOW GRANTS FOR 'gym_reportes'@'localhost';

SELECT 'ingresos_detalle'  AS vista, COUNT(*) AS filas FROM vw_ingresos_detalle
UNION ALL SELECT 'saldos_membresia', COUNT(*) FROM vw_saldos_membresia
UNION ALL SELECT 'estado_cuenta',    COUNT(*) FROM vw_estado_cuenta
UNION ALL SELECT 'horario_semanal',  COUNT(*) FROM vw_horario_semanal;
