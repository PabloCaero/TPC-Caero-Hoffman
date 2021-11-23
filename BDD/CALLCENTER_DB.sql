Create Database CALLCENTER_DB
go

Use CALLCENTER_DB
go

Create Table Direccion(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
CALLE VARCHAR(150) NOT NULL,
ALTURA INT NOT NULL,
LOCALIDAD VARCHAR(100) NOT NULL,
CODIGOPOSTAL VARCHAR(10) NOT NULL,
PROVINCIA VARCHAR(100) NOT NULL
)

Create Table Especialidades(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
ESPECIALIDAD VARCHAR(100) NOT NULL UNIQUE
)

Create Table Prioridades(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
PRIORIDAD VARCHAR(100) NOT NULL UNIQUE
)

Create Table Clientes(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
NOMBRE VARCHAR(150) NOT NULL,
APELLIDO VARCHAR(150) NOT NULL,
DNI VARCHAR(15) NOT NULL UNIQUE,
IDDIRECCION INT NOT NULL FOREIGN KEY REFERENCES Direccion(ID),
EMAIL VARCHAR(250) NOT NULL,
TELEFONO VARCHAR(30) NOT NULL,
FECHANACIMIENTO DATE NOT NULL CHECK(YEAR(FECHANACIMIENTO) > 1900)
)

ALTER TABLE Clientes  
ADD FECHAALTA DATE NULL CHECK(YEAR(FECHAALTA) > 1900)







Create Table Cargos(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
NOMBRECARGO VARCHAR(150) NOT NULL
)

Create Table Empleados(
ID INT NOT NULL PRIMARY KEY IDENTITY(1000, 1),
NOMBREUSUARIO VARCHAR(150) NOT NULL UNIQUE,
CONTRASE�A VARCHAR(150) NOT NULL,
NOMBRE VARCHAR(150) NOT NULL,
IDCARGO INT NOT NULL FOREIGN KEY REFERENCES Cargos(ID),
APELLIDO VARCHAR(150) NOT NULL,
DNI VARCHAR(15) NOT NULL UNIQUE,
IDDIRECCION INT NOT NULL FOREIGN KEY REFERENCES Direccion(ID),
EMAIL VARCHAR(250) NOT NULL,
TELEFONO VARCHAR(30) NOT NULL,
FECHANACIMIENTO DATE NOT NULL CHECK(YEAR(FECHANACIMIENTO) > 1900)
)


Create Table Estados(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
NOMBREESTADO VARCHAR(100) NOT NULL UNIQUE
)

Create Table Incidentes(
ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
IDEMPLEADO INT NOT NULL FOREIGN KEY REFERENCES Empleados(ID),
IDCLIENTE INT NOT NULL FOREIGN KEY REFERENCES Clientes(ID),
IDESPECIALIDAD INT NOT NULL FOREIGN KEY REFERENCES Especialidades(ID),
IDPRIORIDAD INT NOT NULL FOREIGN KEY REFERENCES Prioridades(ID),
FECHA_INICIO DATE NOT NULL,
FECHA_CIERRE DATE NULL,
DETALLES VARCHAR(2000) NOT NULL,
IDESTADO INT NOT NULL FOREIGN KEY REFERENCES Estados(ID),
CHECK(FECHA_INICIO <= FECHA_CIERRE)
)

ALTER TABLE Incidentes  
ADD COMENTARIOFINAL VARCHAR(2000) NULL

Insert Into Especialidades(ESPECIALIDAD) 
VALUES('Hardware'),
	  ('Software'),
	  ('Servidor'),
	  ('Red'),
	  ('Consulta'),
	  ('Otro');
	  

Insert Into Prioridades(PRIORIDAD) 
VALUES('Prioridad Baja'),
	  ('Prioridad Mediana'),
	  ('Prioridad Alta'),
	  ('Cr�tico');

Insert Into Cargos(NOMBRECARGO) 
VALUES('Administrador'),
	  ('Supervisor'),
	  ('Telefonista');

Insert Into Estados(NOMBREESTADO) 
VALUES('Abierto'),
	  ('En An�lisis'),
	  ('Cerrado'),
	  ('Reabierto'),
	  ('Asignado'),
	  ('Resuelto');

Insert Into Direccion(CALLE, ALTURA, LOCALIDAD, CODIGOPOSTAL, PROVINCIA) 
VALUES('Tomas Iriarte', 1576, 'Benavidez', 'CP1621', 'Buenos Aires'),
	  ('Bartolom� Mitre', 1786, 'Capital Federal', 'CP A1741', 'Buenos Aires'),
	  ('Almirante Brown', 2054, 'Lugones', 'CP 9741', 'Buenos Aires'),
	  ('Diaz Velez', 3786, 'Tortuguitas', 'CP 2741', 'Buenos Aires');

Insert Into Clientes(NOMBRE, APELLIDO, DNI, IDDIRECCION, EMAIL, TELEFONO, FECHANACIMIENTO)
VALUES('Nicolas', 'Hoffman', '37327693', 1, 'nhoffman@alumnos.frgp.edu.ar', '+54 1163088646', '1994-08-05'),
	  ('Pablo', 'Caero', '38327693', 2, 'pcaero@alumnos.frgp.edu.ar', '+54 3327413030', '1995-09-25');

Insert Into Empleados(NOMBREUSUARIO, CONTRASE�A, NOMBRE, APELLIDO, IDCARGO, DNI, IDDIRECCION, EMAIL, TELEFONO, FECHANACIMIENTO)
VALUES('nhoffman', 'voyaentrar1234', 'Nicole', 'Hoffman', 2,  '32327693', 3, 'nicolehoffman@alumnos.frgp.edu.ar', '+54 1163088642', '1994-08-05'),
	  ('paucaero', 'ahientro234', 'Paula', 'Caero',3, '31327693', 4, 'paulacaero@alumnos.frgp.edu.ar', '+54 3327413031', '1995-09-25');

Insert Into Incidentes(IDEMPLEADO, IDCLIENTE, FECHA_INICIO, FECHA_CIERRE, DETALLES, IDPRIORIDAD, IDESPECIALIDAD, IDESTADO, COMENTARIOFINAL)
VALUES(1000, 1, getDate(), NULL, 'Se solicita un n�mero telef�nico del embajador de Rusia', 1, 1, 2, NULL),
	  (1001, 2, getDate(), NULL, 'Se solicita un n�mero telef�nico del embajador de China', 2, 2, 3, NULL);
use CALLCENTER_DB

Select * From Cargos
Select * From Clientes
Select * From Incidentes
Select * From Empleados
Select * From Estados
Select * From Direccion


--Use CALLCENTER_DB
--Insert Into Clientes(NOMBRE, APELLIDO, DNI, IDDIRECCION, EMAIL, TELEFONO, FECHANACIMIENTO)
--VALUES('Prueba', 'Prueba', '37327693', (Select max(ID) From Direccion), 'nhoffman@alumnos.frgp.edu.ar', '+54 1163088646', '1994-08-05')
--Select max(ID) From Direccion
--Delete From Clientes Where ID = 3

/*Create Procedure SP_ListarCargos AS
BEGIN
Select ID, NOMBRECARGO From Cargos
END*/



