CREATE DATABASE CedForecast 
GO
USE CedForecast
GO
CREATE ROLE ce_update
GO
/****** Objeto:  Table [dbo].[WCTbGrupos]    Fecha de la secuencia de comandos: 05/04/2010 10:45:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WCTbGrupos](
	[IdGrupo] [varchar](15) NOT NULL,
	[Descr] [varchar](40) NOT NULL,
	[IdTGrupo] [char](3) NULL,
 CONSTRAINT [XPKWCTbGrupos] PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[WCUsuarios]    Fecha de la secuencia de comandos: 05/04/2010 10:45:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WCUsuarios](
	[IdUsuario] [varchar](15) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[Activo] [bit] NULL,
	[Alias] [varchar](30) NULL,
	[FecAlta] [smalldatetime] NOT NULL,
	[FecBaja] [smalldatetime] NOT NULL,
	[RequierePassword] [bit] NULL,
	[Email] [varchar](255) NULL,
 CONSTRAINT [XPKWCUsuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto:  Table [dbo].[WCGrupos]    Fecha de la secuencia de comandos: 05/04/2010 10:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WCGrupos](
	[IdGrupo] [varchar](15) NOT NULL,
	[IdUsuario] [varchar](15) NOT NULL,
	[Supervisor] [bit] NULL,
	[SupervisorNivel] [tinyint] NOT NULL,
 CONSTRAINT [XPKWCGrupos] PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC,
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[WCGrupos]  WITH CHECK ADD  CONSTRAINT [FK_WCTbGrupos_WCGrupos] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[WCTbGrupos] ([IdGrupo])
GO
ALTER TABLE [dbo].[WCGrupos] CHECK CONSTRAINT [FK_WCTbGrupos_WCGrupos]
GO
ALTER TABLE [dbo].[WCGrupos]  WITH CHECK ADD  CONSTRAINT [FK_WCUsuarios_WCGrupos] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[WCUsuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[WCGrupos] CHECK CONSTRAINT [FK_WCUsuarios_WCGrupos]
GO
/****** Objeto:  Table [dbo].[WF_Acceso]    Fecha de la secuencia de comandos: 05/04/2010 10:46:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WF_Acceso](
	[IdAcceso] [varchar](15) NOT NULL,
	[DescrAcceso] [varchar](50) NOT NULL,
	[AssemblyVersion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_WF_Acceso] PRIMARY KEY CLUSTERED 
(
	[IdAcceso] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[WF_Circuito]    Fecha de la secuencia de comandos: 05/04/2010 10:48:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WF_Circuito](
	[IdCircuito] [varchar](15) NOT NULL,
	[DescrCircuito] [varchar](50) NOT NULL,
 CONSTRAINT [PK_WF_Circuito] PRIMARY KEY CLUSTERED 
(
	[IdCircuito] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[WF_Estado]    Fecha de la secuencia de comandos: 05/04/2010 10:49:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WF_Estado](
	[IdEstado] [varchar](15) NOT NULL,
	[DescrEstado] [varchar](50) NOT NULL,
	[Virtual] [bit] NOT NULL,
 CONSTRAINT [PK_WF_Estado] PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[WF_Flow]    Fecha de la secuencia de comandos: 05/04/2010 10:50:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WF_Flow](
	[IdFlow] [varchar](10) NOT NULL,
	[DescrFlow] [varchar](50) NOT NULL,
 CONSTRAINT [PK_WF_Flow] PRIMARY KEY CLUSTERED 
(
	[IdFlow] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[WF_NivSeg]    Fecha de la secuencia de comandos: 05/04/2010 10:50:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WF_NivSeg](
	[IdNivSeg] [int] NOT NULL,
	[DescrNivSeg] [varchar](50) NOT NULL,
 CONSTRAINT [PK_WF_NivSeg] PRIMARY KEY CLUSTERED 
(
	[IdNivSeg] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[WF_Parm]    Fecha de la secuencia de comandos: 05/04/2010 10:51:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WF_Parm](
	[IdParm] [varchar](30) NOT NULL,
	[ValorInt] [int] NOT NULL,
	[ValorStr] [varchar](200) NOT NULL,
 CONSTRAINT [PK_WF_Parm] PRIMARY KEY CLUSTERED 
(
	[IdParm] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[WF_Evento]    Fecha de la secuencia de comandos: 05/04/2010 10:49:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WF_Evento](
	[IdFlow] [varchar](10) NOT NULL,
	[IdEvento] [varchar](15) NOT NULL,
	[DescrEvento] [varchar](50) NOT NULL,
	[TextoAccion] [varchar](40) NOT NULL,
	[IdEstadoDsd] [varchar](15) NULL,
	[IdEstadoHst] [varchar](15) NULL,
	[Automatico] [bit] NULL,
	[CXO] [bit] NOT NULL,
	[XLote] [bit] NOT NULL,
 CONSTRAINT [PK_WF_Evento] PRIMARY KEY CLUSTERED 
(
	[IdFlow] ASC,
	[IdEvento] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[WF_Evento]  WITH NOCHECK ADD  CONSTRAINT [FK_WF_Evento_WF_Flow] FOREIGN KEY([IdFlow])
REFERENCES [dbo].[WF_Flow] ([IdFlow])
GO
ALTER TABLE [dbo].[WF_Evento] CHECK CONSTRAINT [FK_WF_Evento_WF_Flow]
GO
/****** Objeto:  Table [dbo].[WF_EsquemaSeg]    Fecha de la secuencia de comandos: 05/04/2010 10:48:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WF_EsquemaSeg](
	[IdFlow] [varchar](10) NOT NULL,
	[IdCircuito] [varchar](15) NOT NULL,
	[IdNivSeg] [int] NOT NULL,
	[IdEvento] [varchar](15) NOT NULL,
	[IdGrupo] [varchar](15) NOT NULL,
	[DebeSerSP] [varchar](2) NOT NULL,
	[SupervisorNivelDsd] [tinyint] NOT NULL,
	[SupervisorNivelHst] [tinyint] NOT NULL,
	[CantInterv] [int] NOT NULL,
 CONSTRAINT [PK_WF_EsquemaSeg] PRIMARY KEY CLUSTERED 
(
	[IdFlow] ASC,
	[IdCircuito] ASC,
	[IdNivSeg] ASC,
	[IdEvento] ASC,
	[IdGrupo] ASC,
	[DebeSerSP] ASC,
	[SupervisorNivelDsd] ASC,
	[SupervisorNivelHst] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[WF_EsquemaSeg]  WITH NOCHECK ADD  CONSTRAINT [FK_WF_EsquemaSeg_WF_Evento] FOREIGN KEY([IdFlow], [IdEvento])
REFERENCES [dbo].[WF_Evento] ([IdFlow], [IdEvento])
GO
ALTER TABLE [dbo].[WF_EsquemaSeg] CHECK CONSTRAINT [FK_WF_EsquemaSeg_WF_Evento]
GO
ALTER TABLE [dbo].[WF_EsquemaSeg]  WITH CHECK ADD  CONSTRAINT [FK_WF_EventoSeg_WCTbGrupos] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[WCTbGrupos] ([IdGrupo])
GO
ALTER TABLE [dbo].[WF_EsquemaSeg] CHECK CONSTRAINT [FK_WF_EventoSeg_WCTbGrupos]
GO
ALTER TABLE [dbo].[WF_EsquemaSeg]  WITH CHECK ADD  CONSTRAINT [FK_WF_EventoSeg_WF_Circuito] FOREIGN KEY([IdCircuito])
REFERENCES [dbo].[WF_Circuito] ([IdCircuito])
GO
ALTER TABLE [dbo].[WF_EsquemaSeg] CHECK CONSTRAINT [FK_WF_EventoSeg_WF_Circuito]
GO
ALTER TABLE [dbo].[WF_EsquemaSeg]  WITH CHECK ADD  CONSTRAINT [FK_WF_EventoSeg_WF_NivSeg] FOREIGN KEY([IdNivSeg])
REFERENCES [dbo].[WF_NivSeg] ([IdNivSeg])
GO
ALTER TABLE [dbo].[WF_EsquemaSeg] CHECK CONSTRAINT [FK_WF_EventoSeg_WF_NivSeg]
GO
/****** Objeto:  Table [dbo].[WF_EstadoXFlow]    Fecha de la secuencia de comandos: 05/04/2010 10:49:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WF_EstadoXFlow](
	[IdFlow] [varchar](10) NOT NULL,
	[IdEstado] [varchar](15) NOT NULL,
	[EstadoFinal] [bit] NOT NULL,
 CONSTRAINT [PK_WF_EstadoXFlow] PRIMARY KEY CLUSTERED 
(
	[IdFlow] ASC,
	[IdEstado] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[WF_EstadoXFlow]  WITH CHECK ADD  CONSTRAINT [FK_WF_EstadoXFlow_WF_Estado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[WF_Estado] ([IdEstado])
GO
ALTER TABLE [dbo].[WF_EstadoXFlow] CHECK CONSTRAINT [FK_WF_EstadoXFlow_WF_Estado]
GO
ALTER TABLE [dbo].[WF_EstadoXFlow]  WITH CHECK ADD  CONSTRAINT [FK_WF_EstadoXFlow_WF_Flow] FOREIGN KEY([IdFlow])
REFERENCES [dbo].[WF_Flow] ([IdFlow])
GO
ALTER TABLE [dbo].[WF_EstadoXFlow] CHECK CONSTRAINT [FK_WF_EstadoXFlow_WF_Flow]
GO
/****** Objeto:  Table [dbo].[WF_PermisoGrupoXAcceso]    Fecha de la secuencia de comandos: 05/04/2010 10:51:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WF_PermisoGrupoXAcceso](
	[IdGrupo] [varchar](15) NOT NULL,
	[IdAcceso] [varchar](15) NOT NULL,
	[Permiso] [bit] NOT NULL,
 CONSTRAINT [PK_WF_PermisoGrupoXAcceso] PRIMARY KEY CLUSTERED 
(
	[IdGrupo] ASC,
	[IdAcceso] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[WF_PermisoGrupoXAcceso]  WITH CHECK ADD  CONSTRAINT [FK_WF_PermisoGrupoXAcceso_WCTbGrupos] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[WCTbGrupos] ([IdGrupo])
GO
ALTER TABLE [dbo].[WF_PermisoGrupoXAcceso] CHECK CONSTRAINT [FK_WF_PermisoGrupoXAcceso_WCTbGrupos]
GO
ALTER TABLE [dbo].[WF_PermisoGrupoXAcceso]  WITH CHECK ADD  CONSTRAINT [FK_WF_PermisoGrupoXAcceso_WF_Acceso] FOREIGN KEY([IdAcceso])
REFERENCES [dbo].[WF_Acceso] ([IdAcceso])
GO
ALTER TABLE [dbo].[WF_PermisoGrupoXAcceso] CHECK CONSTRAINT [FK_WF_PermisoGrupoXAcceso_WF_Acceso]
GO
/****** Objeto:  Table [dbo].[WF_Op]    Fecha de la secuencia de comandos: 05/04/2010 10:51:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WF_Op](
	[IdOp] [int] IDENTITY(1,1) NOT NULL,
	[IdFlow] [varchar](10) NOT NULL,
	[IdCircuito] [varchar](15) NOT NULL,
	[IdNivSeg] [int] NOT NULL,
	[IdEstado] [varchar](15) NOT NULL,
	[DescrOp] [varchar](255) NOT NULL,
	[UltActualiz] [timestamp] NOT NULL,
	[DatoActual] [bit] NOT NULL,
 CONSTRAINT [PK_WF_Op] PRIMARY KEY NONCLUSTERED 
(
	[IdOp] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[WF_Op]  WITH NOCHECK ADD  CONSTRAINT [FK_WF_Op_WF_Circuito] FOREIGN KEY([IdCircuito])
REFERENCES [dbo].[WF_Circuito] ([IdCircuito])
GO
ALTER TABLE [dbo].[WF_Op] CHECK CONSTRAINT [FK_WF_Op_WF_Circuito]
GO
ALTER TABLE [dbo].[WF_Op]  WITH NOCHECK ADD  CONSTRAINT [FK_WF_Op_WF_Estado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[WF_Estado] ([IdEstado])
GO
ALTER TABLE [dbo].[WF_Op] CHECK CONSTRAINT [FK_WF_Op_WF_Estado]
GO
ALTER TABLE [dbo].[WF_Op]  WITH NOCHECK ADD  CONSTRAINT [FK_WF_Op_WF_NivSeg] FOREIGN KEY([IdNivSeg])
REFERENCES [dbo].[WF_NivSeg] ([IdNivSeg])
GO
ALTER TABLE [dbo].[WF_Op] CHECK CONSTRAINT [FK_WF_Op_WF_NivSeg]
GO
/****** Objeto:  Table [dbo].[WF_Log]    Fecha de la secuencia de comandos: 05/04/2010 10:50:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WF_Log](
	[IdLog] [int] IDENTITY(1,1) NOT NULL,
	[IdOp] [int] NOT NULL,
	[IdUsuario] [varchar](15) NOT NULL,
	[IdFlow] [varchar](10) NOT NULL,
	[IdCircuito] [varchar](15) NOT NULL,
	[IdNivSeg] [int] NOT NULL,
	[IdEvento] [varchar](15) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Comentario] [varchar](255) NOT NULL,
	[IdEstado] [varchar](15) NOT NULL,
	[IdGrupo] [varchar](15) NOT NULL,
	[Supervisor] [bit] NOT NULL,
	[SupervisorNivel] [tinyint] NOT NULL,
	[DatoActual] [bit] NOT NULL,
 CONSTRAINT [PK_WF_Log] PRIMARY KEY CLUSTERED 
(
	[IdLog] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[WF_Log]  WITH NOCHECK ADD  CONSTRAINT [FK_WF_Log_WCTbGrupos] FOREIGN KEY([IdGrupo])
REFERENCES [dbo].[WCTbGrupos] ([IdGrupo])
GO
ALTER TABLE [dbo].[WF_Log] CHECK CONSTRAINT [FK_WF_Log_WCTbGrupos]
GO
ALTER TABLE [dbo].[WF_Log]  WITH NOCHECK ADD  CONSTRAINT [FK_WF_Log_WCUsuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[WCUsuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[WF_Log] CHECK CONSTRAINT [FK_WF_Log_WCUsuarios]
GO
ALTER TABLE [dbo].[WF_Log]  WITH NOCHECK ADD  CONSTRAINT [FK_WF_Log_WF_Estado] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[WF_Estado] ([IdEstado])
GO
ALTER TABLE [dbo].[WF_Log] CHECK CONSTRAINT [FK_WF_Log_WF_Estado]
GO
ALTER TABLE [dbo].[WF_Log]  WITH CHECK ADD  CONSTRAINT [FK_WF_Log_WF_Op] FOREIGN KEY([IdOp])
REFERENCES [dbo].[WF_Op] ([IdOp])
GO
ALTER TABLE [dbo].[WF_Log] CHECK CONSTRAINT [FK_WF_Log_WF_Op]
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.WCGrupos TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.WCTbGrupos TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.WCUsuarios TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.WF_Acceso TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.WF_Circuito TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.WF_EsquemaSeg TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.WF_Estado TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.WF_EstadoXFlow TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.WF_Evento TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.WF_Flow TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.WF_Log TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.WF_NivSeg TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.WF_Op TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.WF_Parm TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.WF_PermisoGrupoXAcceso TO ce_update
GO
insert WCTbGrupos values ('Usuarios', 'Usuarios', 'ACC')
GO
insert WCUsuarios values ('Claudio', 'Claudio A. Cedeira', 1, 'DESA', '20100501', '20671231', 0, 'claudio.cedeira@cedeira.com.ar')
GO
insert WCUsuarios values ('Pol', 'Pablo J.E.Conde', 1, 'DESA', '20100501', '20671231', 0, 'pjeconde@yahoo.com.ar')
GO
insert WCGrupos values ('Usuarios', 'Claudio', 0, 0)
GO
insert WCGrupos values ('Usuarios', 'Pol', 0, 0)
GO
insert WF_Acceso values ('FrontEnd', 'FrontEnd CedForecast', '1.0')
GO
insert WF_Parm values ('CXO', 1, '1-SI 0-NO')
GO
insert WF_PermisoGrupoXAcceso values ('Usuarios', 'FrontEnd', 1)
GO