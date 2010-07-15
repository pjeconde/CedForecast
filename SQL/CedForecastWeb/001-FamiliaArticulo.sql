/****** Objeto:  Table [dbo].[FamiliaArticulo]    Fecha de la secuencia de comandos: 13/07/2010 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FamiliaArticulo](
	[IdFamiliaArticulo] [varchar](15) NOT NULL,
	[DescrFamiliaArticulo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Table_FamiliaArticulo] PRIMARY KEY CLUSTERED 
(
	[IdFamiliaArticulo] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Objeto:  Table [dbo].[FamiliaArticuloXArticulo]    Fecha de la secuencia de comandos: 13/07/2010 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FamiliaArticuloXArticulo](
	[IdArticulo] [varchar](20) NOT NULL,
	[IdFamiliaArticulo] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Table_FamiliaArticuloXArticulo] PRIMARY KEY CLUSTERED 
(
	[IdArticulo] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[FamiliaArticuloXArticulo]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaArticuloXArticulo_FamiliaArticulo] FOREIGN KEY([IdFamiliaArticulo])
REFERENCES [dbo].[FamiliaArticulo] ([IdFamiliaArticulo])
GO
ALTER TABLE [dbo].[FamiliaArticuloXArticulo] CHECK CONSTRAINT [FK_FamiliaArticuloXArticulo_FamiliaArticulo]
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.FamiliaArticulo TO ce_update
GO
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.FamiliaArticuloXArticulo TO ce_update
GO
