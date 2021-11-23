
--BUSQUEDA DE INCIDENTE POR ID
Select I.ID, I.IDEMPLEADO, I.IDCLIENTE, I.IDESTADO, I.DETALLES, I.COMENTARIOFINAL, I.FECHA_INICIO, I.FECHA_CIERRE, E.NOMBRE AS NOMBREEMPLEADO, E.APELLIDO AS APELLIDOEMPLEADO, C.NOMBRE AS NOMBRECLIENTE, C.APELLIDO AS APELLIDOCLIENTE, ES.NOMBREESTADO From Incidentes I, Empleados E, Clientes C, Estados ES Where I.IDCLIENTE = C.ID AND I.IDESTADO = ES.ID AND I.IDEMPLEADO = E.ID AND I.ID = 1

--BUSQUEDA DE INCIDENTE POR APELLIDO O NOMBRE DE EMPLEADO

Select I.ID, I.IDEMPLEADO, I.IDCLIENTE, I.IDESTADO, I.DETALLES, I.COMENTARIOFINAL, I.FECHA_INICIO, I.FECHA_CIERRE, E.NOMBRE AS NOMBREEMPLEADO, E.APELLIDO AS APELLIDOEMPLEADO, C.NOMBRE AS NOMBRECLIENTE, C.APELLIDO AS APELLIDOCLIENTE, ES.NOMBREESTADO From Incidentes I, Empleados E, Clientes C, Estados ES Where I.IDCLIENTE = C.ID AND I.IDESTADO = ES.ID AND I.IDEMPLEADO = E.ID AND E.NOMBRE LIKE '%@NOMBRE%' OR E.APELLIDO LIKE '@APELLIDO'

--BUSQUEDA DE INCIDENTE POR APELLIDO O NOMBRE DE CLIENTE

Select I.ID, I.IDEMPLEADO, I.IDCLIENTE, I.IDESTADO, I.DETALLES, I.COMENTARIOFINAL, I.FECHA_INICIO, I.FECHA_CIERRE, E.NOMBRE AS NOMBREEMPLEADO, E.APELLIDO AS APELLIDOEMPLEADO, C.NOMBRE AS NOMBRECLIENTE, C.APELLIDO AS APELLIDOCLIENTE, ES.NOMBREESTADO From Incidentes I, Empleados E, Clientes C, Estados ES Where I.IDCLIENTE = C.ID AND I.IDESTADO = ES.ID AND I.IDEMPLEADO = E.ID AND C.NOMBRE LIKE '%@NOMBRE%' OR C.APELLIDO LIKE '@APELLIDO'

Select I.ID, I.IDEMPLEADO, I.IDCLIENTE, I.IDESTADO, I.DETALLES, I.COMENTARIOFINAL, I.FECHA_INICIO, I.FECHA_CIERRE, E.NOMBRE AS NOMBREEMPLEADO, E.APELLIDO AS APELLIDOEMPLEADO, C.NOMBRE AS NOMBRECLIENTE, C.APELLIDO AS APELLIDOCLIENTE, ES.NOMBREESTADO From Incidentes I, Empleados E, Clientes C, Estados ES Where I.IDCLIENTE = C.ID AND I.IDESTADO = ES.ID AND I.IDEMPLEADO = E.ID AND I.ID = 1


Select I.ID, I.IDEMPLEADO, I.IDCLIENTE, I.IDESTADO, I.DETALLES, I.COMENTARIOFINAL, I.FECHA_INICIO, I.FECHA_CIERRE, E.NOMBRE AS NOMBREEMPLEADO, E.APELLIDO AS APELLIDOEMPLEADO, C.NOMBRE AS NOMBRECLIENTE, C.APELLIDO AS APELLIDOCLIENTE, ES.NOMBREESTADO From Incidentes I, Empleados E, Clientes C, Estados ES Where I.IDCLIENTE = C.ID AND I.IDESTADO = ES.ID AND I.IDEMPLEADO = E.ID AND I.ID = 1