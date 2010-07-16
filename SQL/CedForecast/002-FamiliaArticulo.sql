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
insert FamiliaArticulo values ('BioE', 'BIOESTIMULANTE')
go
insert FamiliaArticulo values ('Fert', 'FERTIRRIEGO')
go
insert FamiliaArticulo values ('Foli', 'FOLIARES')
go
insert FamiliaArticulo values ('Gran', 'GRANULADO')
go
insert FamiliaArticulo values ('LibC', 'LIB. CONTROLADA')
go
insert FamiliaArticulo values ('LibL', 'LIB. LENTA')
go
insert FamiliaArticuloXArticulo values ('20600001', 'BioE')
go
insert FamiliaArticuloXArticulo values ('20600002', 'BioE')
go
insert FamiliaArticuloXArticulo values ('20600003', 'BioE')
go
insert FamiliaArticuloXArticulo values ('20700001', 'BioE')
go
insert FamiliaArticuloXArticulo values ('20700002', 'BioE')
go
insert FamiliaArticuloXArticulo values ('20700003', 'BioE')
go
insert FamiliaArticuloXArticulo values ('20700004', 'BioE')
go
insert FamiliaArticuloXArticulo values ('20100001', 'Fert')
go
insert FamiliaArticuloXArticulo values ('20100002', 'Fert')
go
insert FamiliaArticuloXArticulo values ('20100003', 'Fert')
go
insert FamiliaArticuloXArticulo values ('20100004', 'Fert')
go
insert FamiliaArticuloXArticulo values ('20100005', 'Fert')
go
insert FamiliaArticuloXArticulo values ('20100006', 'Fert')
go
insert FamiliaArticuloXArticulo values ('20100007', 'Fert')
go
insert FamiliaArticuloXArticulo values ('20500001', 'Fert')
go
insert FamiliaArticuloXArticulo values ('20500002', 'Fert')
go
insert FamiliaArticuloXArticulo values ('20500003', 'Fert')
go
insert FamiliaArticuloXArticulo values ('20800053', 'Fert')
go
insert FamiliaArticuloXArticulo values ('30100020', 'Fert')
go
insert FamiliaArticuloXArticulo values ('20800057', 'Fert')
go
insert FamiliaArticuloXArticulo values ('20200001', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200002', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200003', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200004', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200005', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200006', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200007', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200008', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200009', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200010', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200011', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200012', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200013', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200014', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200015', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200016', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200017', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200018', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200019', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200020', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200021', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200022', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200023', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200024', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200025', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200026', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200027', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200028', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200029', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200030', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200031', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200040', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200051', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200061', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20200070', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20300001', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20300002', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20300003', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20300005', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20300006', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20300007', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20300008', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20300009', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20300010', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20400001', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20400002', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20400003', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20400005', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20400010', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20800050', 'Foli')
go
insert FamiliaArticuloXArticulo values ('20800080', 'Gran')
go
insert FamiliaArticuloXArticulo values ('30100001', 'Gran')
go
insert FamiliaArticuloXArticulo values ('30100010', 'Gran')
go
insert FamiliaArticuloXArticulo values ('20800082', 'Gran')
go
insert FamiliaArticuloXArticulo values ('20800083', 'Gran')
go
insert FamiliaArticuloXArticulo values ('20800084', 'Gran')
go
insert FamiliaArticuloXArticulo values ('20800081', 'Gran')
go
insert FamiliaArticuloXArticulo values ('20800001', 'LibC')
go
insert FamiliaArticuloXArticulo values ('20800002', 'LibC')
go
insert FamiliaArticuloXArticulo values ('20800003', 'LibC')
go
insert FamiliaArticuloXArticulo values ('20800004', 'LibC')
go
insert FamiliaArticuloXArticulo values ('20800006', 'LibC')
go
insert FamiliaArticuloXArticulo values ('20800007', 'LibC')
go
insert FamiliaArticuloXArticulo values ('20800008', 'LibC')
go
insert FamiliaArticuloXArticulo values ('20800020', 'LibL')
go
insert FamiliaArticuloXArticulo values ('20800021', 'LibL')
go
insert FamiliaArticuloXArticulo values ('20800025', 'LibL')
go
