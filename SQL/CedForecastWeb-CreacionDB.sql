CREATE DATABASE CedForecastWeb 
GO
CREATE LOGIN CedFW_usuario WITH PASSWORD = 'mosca430rijo', DEFAULT_DATABASE=CedForecastWeb
GO
USE CedForecastWeb
GO
CREATE ROLE ce_update
GO
CREATE USER CedFW_usuario FOR LOGIN CedFW_usuario
GO
EXEC sp_addrolemember 'ce_update', 'CedFW_usuario'
GO
/****** Objeto:  Table [dbo].[Articulo]    Fecha de la secuencia de comandos: 05/03/2010 09:23:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Articulo](
	[IdArticulo] [varchar](20) NOT NULL,
	[DescrArticulo] [varchar](50) NOT NULL,
	[IdGrupoArticulo] [varchar](4) NOT NULL,
	[PesoBruto] [float] NOT NULL,
	[UnidadMedida] [varchar](3) NOT NULL,
	[FechaUltModif] [datetime] NOT NULL,
	[Habilitado] [bit] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[Cliente]    Fecha de la secuencia de comandos: 05/03/2010 09:24:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [varchar](6) NOT NULL,
	[DescrCliente] [varchar](40) NOT NULL,
	[IdZona] [varchar](4) NOT NULL,
	[Habilitado] [bit] NOT NULL,
	[FechaUltModif] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[ConfirmacionCarga]    Fecha de la secuencia de comandos: 05/03/2010 09:25:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ConfirmacionCarga](
	[IdPeriodo] [datetime] NOT NULL,
	[IdCuenta] [varchar](50) NOT NULL,
	[FechaConfirmacionCarga] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[EstadoCuenta]    Fecha de la secuencia de comandos: 05/03/2010 09:28:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EstadoCuenta](
	[IdEstadoCuenta] [varchar](15) NOT NULL,
	[DescrEstadoCuenta] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoCuenta] PRIMARY KEY CLUSTERED 
(
	[IdEstadoCuenta] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[TipoCuenta]    Fecha de la secuencia de comandos: 05/03/2010 09:29:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoCuenta](
	[IdTipoCuenta] [varchar](15) NOT NULL,
	[DescrTipoCuenta] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoCuenta] PRIMARY KEY CLUSTERED 
(
	[IdTipoCuenta] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[PaginaDefault]    Fecha de la secuencia de comandos: 05/03/2010 09:29:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PaginaDefault](
	[IdPaginaDefault] [varchar](15) NOT NULL,
	[DescrPaginaDefault] [varchar](50) NOT NULL,
	[URL] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Table_PaginaDefault] PRIMARY KEY CLUSTERED 
(
	[IdPaginaDefault] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[PaginaDefaultXTipoCuenta]    Fecha de la secuencia de comandos: 05/03/2010 09:30:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PaginaDefaultXTipoCuenta](
	[IdTipoCuenta] [varchar](15) NOT NULL,
	[IdPaginaDefault] [varchar](15) NOT NULL,
	[Predeterminada] [bit] NOT NULL,
 CONSTRAINT [PK_Table_PaginaDefaultXTipoCuenta] PRIMARY KEY CLUSTERED 
(
	[IdTipoCuenta] ASC,
	[IdPaginaDefault] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[PaginaDefaultXTipoCuenta]  WITH CHECK ADD  CONSTRAINT [FK_PaginaDefaultXTipoCuenta_PaginaDefault] FOREIGN KEY([IdPaginaDefault])
REFERENCES [dbo].[PaginaDefault] ([IdPaginaDefault])
GO
ALTER TABLE [dbo].[PaginaDefaultXTipoCuenta] CHECK CONSTRAINT [FK_PaginaDefaultXTipoCuenta_PaginaDefault]
GO
ALTER TABLE [dbo].[PaginaDefaultXTipoCuenta]  WITH CHECK ADD  CONSTRAINT [FK_PaginaDefaultXTipoCuenta_TipoCuenta] FOREIGN KEY([IdTipoCuenta])
REFERENCES [dbo].[TipoCuenta] ([IdTipoCuenta])
GO
ALTER TABLE [dbo].[PaginaDefaultXTipoCuenta] CHECK CONSTRAINT [FK_PaginaDefaultXTipoCuenta_TipoCuenta]
GO
/****** Objeto:  Table [dbo].[Cuenta]    Fecha de la secuencia de comandos: 05/03/2010 09:25:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cuenta](
	[IdCuenta] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Email] [varchar](128) NOT NULL,
	[IdDivision] [varchar](30) NULL,
	[Password] [varchar](50) NOT NULL,
	[Pregunta] [varchar](256) NOT NULL,
	[Respuesta] [varchar](256) NOT NULL,
	[IdTipoCuenta] [varchar](15) NOT NULL,
	[IdEstadoCuenta] [varchar](15) NOT NULL,
	[IdPaginaDefault] [varchar](15) NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[CantidadEnviosMail] [int] NOT NULL,
	[FechaUltimoReenvioMail] [datetime] NOT NULL,
	[EmailSMS] [varchar](50) NOT NULL,
	[RecibeAvisoAltaCuenta] [bit] NOT NULL,
	[FechaUltModif] [datetime] NOT NULL,
 CONSTRAINT [PK_Table_Cuenta] PRIMARY KEY CLUSTERED 
(
	[IdCuenta] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_EstadoCuenta] FOREIGN KEY([IdEstadoCuenta])
REFERENCES [dbo].[EstadoCuenta] ([IdEstadoCuenta])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_EstadoCuenta]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_PaginaDefault] FOREIGN KEY([IdPaginaDefault])
REFERENCES [dbo].[PaginaDefault] ([IdPaginaDefault])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_PaginaDefault]
GO
ALTER TABLE [dbo].[Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Cuenta_TipoCuenta] FOREIGN KEY([IdTipoCuenta])
REFERENCES [dbo].[TipoCuenta] ([IdTipoCuenta])
GO
ALTER TABLE [dbo].[Cuenta] CHECK CONSTRAINT [FK_Cuenta_TipoCuenta]
GO
/****** Objeto:  Table [dbo].[CuentaDepurada]    Fecha de la secuencia de comandos: 05/03/2010 09:31:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CuentaDepurada](
	[IdCuenta] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Email] [varchar](128) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Pregunta] [varchar](256) NOT NULL,
	[Respuesta] [varchar](256) NOT NULL,
	[IdTipoCuenta] [varchar](15) NOT NULL,
	[IdEstadoCuenta] [varchar](15) NOT NULL,
	[IdPaginaDefault] [varchar](15) NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[CantidadEnviosMail] [int] NOT NULL,
	[FechaUltimoReenvioMail] [datetime] NOT NULL,
	[EmailSMS] [varchar](50) NOT NULL,
	[RecibeAvisoAltaCuenta] [bit] NOT NULL,
	[FechaUltModif] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[Division]    Fecha de la secuencia de comandos: 05/03/2010 09:32:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Division](
	[IdDivision] [varchar](30) NOT NULL,
	[DescrDivision] [varchar](60) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[Flag]    Fecha de la secuencia de comandos: 05/03/2010 09:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Flag](
	[IdFlag] [varchar](30) NOT NULL,
	[Valor] [bit] NOT NULL,
 CONSTRAINT [PK_Flag] PRIMARY KEY CLUSTERED 
(
	[IdFlag] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[GrupoArticulo]    Fecha de la secuencia de comandos: 05/03/2010 09:32:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GrupoArticulo](
	[IdGrupoArticulo] [varchar](4) NOT NULL,
	[DescrGrupoArticulo] [varchar](50) NOT NULL,
	[IdDivision] [varchar](30) NOT NULL,
 CONSTRAINT [PK_DivisionXGrupoArticulo_1] PRIMARY KEY CLUSTERED 
(
	[IdGrupoArticulo] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[Periodo]    Fecha de la secuencia de comandos: 05/03/2010 09:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periodo](
	[IdPeriodo] [datetime] NOT NULL,
	[FechaVtoConfirmacionCarga] [datetime] NOT NULL,
	[Habilitado] [bit] NOT NULL,
 CONSTRAINT [PK_Periodo] PRIMARY KEY CLUSTERED 
(
	[IdPeriodo] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto:  Table [dbo].[Texto]    Fecha de la secuencia de comandos: 05/03/2010 09:33:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Texto](
	[IdTexto] [varchar](50) NOT NULL,
	[DescrTexto] [text] NOT NULL,
 CONSTRAINT [PK_Texto] PRIMARY KEY CLUSTERED 
(
	[IdTexto] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[Forecast]    Fecha de la secuencia de comandos: 05/03/2010 09:34:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Forecast](
	[IdCuenta] [varchar](50) NOT NULL,
	[IdDivision] [varchar](30) NOT NULL,
	[IdCliente] [varchar](6) NOT NULL,
	[IdArticulo] [varchar](20) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Cantidad] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Forecast] PRIMARY KEY CLUSTERED 
(
	[IdCuenta] ASC,
	[IdDivision] ASC,
	[IdArticulo] ASC,
	[IdCliente] ASC,
	[Fecha] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[Zona]    Fecha de la secuencia de comandos: 05/03/2010 09:34:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Zona](
	[IdZona] [varchar](4) NOT NULL,
	[DescrZona] [varchar](15) NOT NULL,
	[Habilitada] [bit] NOT NULL,
	[FechaUltModif] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[Venta]    Fecha de la secuencia de comandos: 05/04/2010 08:55:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Venta](
	[IdPeriodo] [varchar](6) NOT NULL,
	[IdArticulo] [varchar](20) NOT NULL,
	[IdCliente] [varchar](6) NOT NULL,
	[Cantidad] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[IdPeriodo] ASC,
	[IdArticulo] ASC,
	[IdCliente] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[VentaAux]    Fecha de la secuencia de comandos: 05/04/2010 08:55:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VentaAux](
	[IdPeriodo] [varchar](6) NOT NULL,
	[IdArticulo] [varchar](20) NOT NULL,
	[IdCliente] [varchar](6) NOT NULL,
	[Cantidad] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_VentaAux] PRIMARY KEY CLUSTERED 
(
	[IdPeriodo] ASC,
	[IdArticulo] ASC,
	[IdCliente] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.Articulo TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.Cliente TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.ConfirmacionCarga TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.Cuenta TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.CuentaDepurada TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.Division TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.EstadoCuenta TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.Flag TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.Forecast TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.GrupoArticulo TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.PaginaDefault TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.PaginaDefaultXTipoCuenta TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.Periodo TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.Texto TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.TipoCuenta TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.Zona TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.Venta TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.VentaAux TO ce_update
GO
insert TipoCuenta values ('Admin', 'Administrador')
GO
insert TipoCuenta values ('OperForecast', 'Operador Forecast')
GO
insert PaginaDefault values ('Admin', 'Administración', 'Default')
GO
insert PaginaDefault values ('Forecast', 'Forecast', 'Default')
GO
insert PaginaDefault values ('Inicio', 'Inicio', 'Inicio')
GO
insert PaginaDefaultXTipoCuenta values ('Admin', 'Admin', 1)
GO
insert PaginaDefaultXTipoCuenta values ('Admin', 'Inicio', 0)
GO
insert PaginaDefaultXTipoCuenta values ('OperForecast', 'Forecast', 1)
GO
insert Texto values ('Forecast-TerminosyCondiciones', '')
GO
insert Division values ('K+S NITROGEN', 'K+S NITROGEN')
GO
insert Division values ('COMPO EXPERT', 'COMPO EXPERT')
GO
insert EstadoCuenta values ('Baja', 'De baja')
GO
insert EstadoCuenta values ('PteConf', 'Pendiente de confirmación')
GO
insert EstadoCuenta values ('Suspend', 'Suspendida')
GO
insert EstadoCuenta values ('Vigente', 'Vigente')
GO
insert Flag values ('ModoDepuracion', 0)
GO
insert GrupoArticulo values ('EXP', 'EXP', 'COMPO EXPERT')
GO
insert GrupoArticulo values ('NI1', 'NITROGEN 1', 'K+S NITROGEN')
GO
insert GrupoArticulo values ('NI2', 'NITROGEN 2', 'K+S NITROGEN')
GO

