CREATE DATABASE RRPAYROLL_DB
go
USE RRPAYROLL_DB
go
CREATE TABLE [dbo].[Provincias](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[Nombre] [varchar](200) NOT NULL,
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

CREATE TABLE [dbo].[Deducciones](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[Nombre] [varchar](200) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL,
	[Default] [bit] NULL)

CREATE TABLE [dbo].[Percepciones](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[Nombre] [varchar](200) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL,
	[Default] [bit] NULL)

CREATE TABLE [dbo].[Estados](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[Nombre] [varchar](200) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

CREATE TABLE [dbo].[Puestos](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[Nombre] [varchar](200) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

CREATE TABLE [dbo].[Nacionalidades](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[Nombre] [varchar](200) NOT NULL,
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

CREATE TABLE [dbo].[TipoCuentas](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[Nombre] [varchar](200) NOT NULL,
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

CREATE TABLE [dbo].[Bancos](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[Nombre] [varchar](200) NOT NULL,
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

CREATE TABLE [dbo].[Empleados](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[Documento] [varchar](200) NOT NULL unique,
	[Nombres] [varchar](200) NOT NULL,
	[Apellidos] [varchar](200) NOT NULL,
	[FechaNacimiento] date NOT NULL,
	[Sexo] [char](1) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Telefono] [varchar](200) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[IdNacionalidad] [int] NULL foreign key references Nacionalidades(Id),
	[IdProvincia] [int] NULL foreign key references Provincias(Id),
	[CuentaBancaria] [varchar](200) NULL,
	[IdTipoCuenta] [int] NULL foreign key references TipoCuentas(Id),
	[IdBanco] [int] NULL foreign key references Bancos(Id),
	[IdEstado] [int]  NULL foreign key references Estados(Id),
	[Contratado] [bit] NULL,
	[FechaContratacion] datetime NULL,
	[FechaLiquidacion] datetime NULL,
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[RNC] [varchar](200) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Telefono] [varchar](200) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[IdEstado] [int] NULL foreign key references Estados(Id),
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

create table dbo.Roles
(
	Id int identity primary key not null,
	Nombre varchar(200) not null,
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL
);

create table dbo.Usuarios
(
	Id int identity primary key,
	Nombre varchar(200) not null unique,
	Contrasena varchar(200) not null,
	ContrasenaAnterior varchar(200) null,
	IdEmpleado int foreign key references Empleados(Id) null,
	IdEstado int foreign key references Estados(Id) null,
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL
);

create table dbo.RolUsuarios
(
	Id int identity primary key,
	IdUsuario int foreign key references Usuarios(Id),
	IdRol int foreign key references Roles(Id),
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL
);

CREATE TABLE [dbo].[Licencias](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[FechaInicio] datetime NOT NULL,
	[FechaFin] datetime NOT NULL,
	[Motivo] [varchar](200) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[IdEmpleado] [int] NULL foreign key references Empleados(Id),
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL,
	[Pagado] [bit] NULL)

CREATE TABLE [dbo].[Proyectos](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[Nombre] [varchar](200) NOT NULL,
	[Cliente] [varchar](200) NOT NULL,
	[Locacion] [varchar](200) NULL,
	[Descripcion] [varchar](200) NULL,
	[FechaInicio] datetime NOT NULL,
	[FechaFinal] datetime NOT NULL,
	[IdEstado] [int] NULL foreign key references Estados(Id),
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

CREATE TABLE [dbo].[EmpleadoProyectos](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[IdPuesto] [int]  NULL foreign key references Puestos(Id),
	[IdProyecto] [int]  NULL foreign key references Proyectos(Id),
	[IdEmpleado] [int] foreign key references Empleados(Id)NOT NULL,
	[FechaCreacion] datetime NOT NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL,
	[Horas] [int] NULL,
	[PagoHoras] [float] NULL)

CREATE TABLE [dbo].[Asistencias](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[FechaEntrada] datetime NOT NULL,
	[FechaSalida] datetime NOT NULL,
	[IdEmpleadoProyecto] [int] NULL foreign key references EmpleadoProyectos(Id),
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

CREATE TABLE [dbo].[Horas](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[HorasInicio] datetime NOT NULL,
	[HoraFinal] datetime NULL,
	[IdAsistencia] [int] NULL foreign key references Asistencias(Id),
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

CREATE TABLE [dbo].[Permisos](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[FechaInicio] datetime NOT NULL,
	[Motivo] [varchar](200) NOT NULL,
	[FechaFinal] datetime NOT NULL,
	[Pagado] [bit] NULL,
	[IdAsistencia] [int] NULL foreign key references Asistencias(Id),
	[FechaMCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

CREATE TABLE [dbo].[Actividades](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[Titulo] [varchar](200) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[IdProyecto] [int] NULL foreign key references Proyectos(Id),
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

CREATE TABLE [dbo].[ActividadesAsignadas](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[IdActividad] [int] NULL foreign key references Actividades(Id),
	[IdEmpleadoProyecto] [int] NULL foreign key references EmpleadoProyectos(Id),
	[FechaInicio] datetime NOT NULL,
	[FechaFin] datetime NOT NULL,
	[IdEstado] [int] NULL foreign key references Estados(Id),
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

	create table dbo.TipoNomina
(
	Id int identity primary key,
	Nombre [varchar](200) not null,
	[Descripcion] [varchar](200) NOT NULL,
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL
);

create table dbo.Nominas
(
	Id int identity primary key,
	IdTipoNomina int foreign key references TipoNomina(Id) NOT NULL,
	IdEstado int foreign key references Estados(Id),
	IdProyecto int foreign key references Proyectos(Id) NULL,
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL
);

CREATE TABLE [dbo].[NominaDetalle](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[Fecha] datetime NOT NULL,
	[SalarioBruto] [decimal](18, 2) NOT NULL,
	[AFP] [decimal](18, 2) NOT NULL,
	[INFOTEP] [decimal](18, 2) NOT NULL,
	[ISR] [decimal](18, 2) NOT NULL,
	[SFS] [decimal](18, 2) NOT NULL,
	[SalarioNeto] [decimal](18, 2) NOT NULL,
	[IdNomina] [int] NULL foreign key references Nominas(Id),
	[IdEmpleado] [int] NULL foreign key references Empleados(Id),
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

CREATE TABLE [dbo].[Nomina_Percepciones](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[IdNominaDetalle] [int] NULL foreign key references NominaDetalle(Id),
	[IdPercepciones] [int] NULL foreign key references Percepciones(Id),
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

CREATE TABLE [dbo].[Nomina_Deducciones](
	[Id] [int] IDENTITY(1,1) NOT NULL primary key,
	[IdNominaDetalle] [int] NULL foreign key references NominaDetalle(Id),
	[IdDeducciones] [int] NULL foreign key references Deducciones(Id),
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

Create table TipoPago
(
	Id int identity primary key,
	Nombre [varchar](200),
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)

Create table Pagos
(
	Id int identity primary key,
	Fecha datetime not null,
	Monto decimal(10,2) not null,
	Comision decimal(10,2) not null,
	IdEmpleado int FOREIGN KEY  REFERENCES Empleados(Id),
	IdNominaDetalle int FOREIGN KEY REFERENCES NominaDetalle(Id),
	IdEstado int FOREIGN KEY REFERENCES Estados(Id),
	[FechaCreacion] datetime NULL,
	[CreadoPor] [varchar](200) NULL,
	[FechaModificacion] datetime NULL,
	[ModificadoPor] [varchar](200) NULL)