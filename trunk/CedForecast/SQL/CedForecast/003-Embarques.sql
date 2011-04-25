delete WF_Flow
go
delete WF_Estado
go
delete WF_EstadoXFlow
go
delete WF_Evento
go
delete WF_Circuito
go
delete WF_NivSeg
go
insert WF_Flow values ('OrdenCpra', 'Ordenes de compra')
go
insert WF_Estado values ('PteInfoEmb', 'Pendiente informacion de embarque', 0)
go
insert WF_Estado values ('PteRecepDocs', 'Pendiente recepcion de documentos', 0)
go
insert WF_Estado values ('PteDesp', 'Pendiente de despacho', 0)
go
insert WF_Estado values ('PteInspRenar', 'Pendiente de inspecciòn RENAR', 0)
go
insert WF_Estado values ('PteIngrADep', 'Pendiente Ingreso a depósito', 0)
go
insert WF_Estado values ('Concluida', 'Concluida', 0)
go
insert WF_Estado values ('Anulada', 'Anulada', 0)
go
insert WF_Estado values ('<Cualquiera>', 'Cualquier estado', 1)
go
insert WF_EstadoXFlow values ('OrdenCpra', 'PteInfoEmb', 0)
go
insert WF_EstadoXFlow values ('OrdenCpra', 'PteRecepDocs', 0)
go
insert WF_EstadoXFlow values ('OrdenCpra', 'PteDesp', 0)
go
insert WF_EstadoXFlow values ('OrdenCpra', 'PteInspRenar', 0)
go
insert WF_EstadoXFlow values ('OrdenCpra', 'PteIngrADep', 0)
go
insert WF_EstadoXFlow values ('OrdenCpra', 'Concluida', 1)
go
insert WF_EstadoXFlow values ('OrdenCpra', 'Anulada', 1)
go
insert WF_Evento values ('OrdenCpra', 'Alta', 'Alta', 'Agregar', NULL, 'PteInfoEmb', 0, 0, 0)
go
insert WF_Evento values ('OrdenCpra', 'ActInfoEmb', 'Actualización Info Embarque (planilla proveedor)', 'Registrar Info Embarque (aut)', 'PteInfoEmb', 'PteRecepDocs', 1, 0, 0)
go
insert WF_Evento values ('OrdenCpra', 'IngInfoEmb', 'Ingreso Info Embarque', 'Ingresar Info Embarque', 'PteInfoEmb', 'PteRecepDocs', 0, 0, 1)
go
insert WF_Evento values ('OrdenCpra', 'RecepDocs', 'Recepción Documentos', 'Recibir Documentos', 'PteRecepDocs', 'PteDesp', 0, 0, 1)
go
insert WF_Evento values ('OrdenCpra', 'RegDesp', 'Registro Despacho', 'Registrar Despacho', 'PteDesp', NULL, 0, 0, 1)
go
insert WF_Evento values ('OrdenCpra', 'InspRenar', 'Inspección RENAR', 'Registrar Inspección RENAR', 'PteInspRenar', 'PteIngrADep', 0, 0, 1)
go
insert WF_Evento values ('OrdenCpra', 'IngrADep', 'Ingreso a Depósito', 'Ingresar a Depósito', 'PteIngrADep', 'Concluida', 0, 0, 1)
go
insert WF_Circuito values ('NA', 'No aplica')
go
insert WF_NivSeg values (0, 'No aplica')
go
CREATE TABLE [dbo].[ArticuloInfoAdicional](
	IdArticulo varchar(20) NOT NULL,
	IdFamiliaArticulo varchar(15) NOT NULL,
	IdArticuloOrigen varchar(20) NOT NULL,
	IdRENAR varchar(20) NOT NULL,
	DescrRENAR varchar(60) NOT NULL,
	IdSENASA varchar(20) NOT NULL,
	IdPresentacion varchar(20) NOT NULL,
	CantidadXPresentacion int NOT NULL,
	CantidadXContenedor int NOT NULL,
	UnidadMedida varchar(2) NOT NULL,
	Precio decimal NOT NULL,
	IdMoneda varchar(3) NOT NULL,
	FechaVigenciaPrecio datetime NOT NULL,
	CoeficienteGastosNacionalizacion decimal NOT NULL,
	CantidadStockSeguridad int NOT NULL,
	PlazoAvisoStockSeguridad int NOT NULL,
	Comentario varchar(255) NOT NULL,
 CONSTRAINT [PK_Table_ArticuloInfoAdicional] PRIMARY KEY CLUSTERED 
(
	IdArticulo  ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.ArticuloInfoAdicional TO ce_update
go
ALTER TABLE [dbo].[ArticuloInfoAdicional]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloInfoAdicional_FamiliaArticulo] FOREIGN KEY([IdFamiliaArticulo])
REFERENCES [dbo].[FamiliaArticulo] ([IdFamiliaArticulo])
GO
ALTER TABLE [dbo].[ArticuloInfoAdicional] CHECK CONSTRAINT [FK_ArticuloInfoAdicional_FamiliaArticulo]
GO
insert ArticuloInfoAdicional select IdArticulo, IdFamiliaArticulo, '', '', '', '', '', 0, 0, '', 0, 'USD', '20000101', 0, 0, 90, '' from FamiliaArticuloXArticulo
go
/* drop table dbo.FamiliaArticuloXArticulo
go*/
CREATE TABLE [dbo].[Tabla](
	Tabla varchar(20) NOT NULL,
	Id varchar(3) NOT NULL,
	Descr varchar(30) NOT NULL,
 CONSTRAINT [PK_Table_Tabla] PRIMARY KEY CLUSTERED 
(
	Tabla ASC,
	Id ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.Tabla TO ce_update
go
insert Tabla values ('PaisOrigen', 'A', 'Alemania')
go
insert Tabla values ('PaisOrigen', 'S', 'Sudafrica')
go
insert Tabla values ('PaisOrigen', 'CH', 'Chile')
go
insert Tabla values ('Moneda', 'USD', 'Dolar estadounidense')
go
insert Tabla values ('Proveedor', 'COM', 'Compo')
go
insert Tabla values ('Proveedor', 'NIT', 'K+S Nitrogen')
go
CREATE TABLE [dbo].[OrdenCompra](
	Prefijo varchar(3) NOT NULL,
	Id int NOT NULL,
	IdItem varchar(1) NOT NULL,
	IdProveedor varchar(3) NOT NULL,
	DescrProveedor varchar(30) NOT NULL,
	Fecha datetime NOT NULL,
	IdPaisOrigen varchar(3) NOT NULL,
	DescrPaisOrigen varchar(30) NOT NULL,
	IdArticulo varchar(20) NOT NULL,
	DescrArticulo varchar(50) NOT NULL,
	FechaEstimadaArriboRequerida datetime NOT NULL,
	CantidadContenedores int NOT NULL,
	ComentarioContenedores varchar(255) NOT NULL,
	CantidadPresentacion int NOT NULL,
	Cantidad int NOT NULL,
	IdMoneda varchar(3) NOT NULL,
	Precio decimal NOT NULL,
	Importe decimal NOT NULL,
	IdReferenciaSAP varchar(20) NOT NULL,
	FechaEstimadaSalida datetime NOT NULL,
	Vapor varchar(20) NOT NULL,
	FechaEstimadaArribo datetime NOT NULL,
	NroConocimientoEmbarque varchar(20) NOT NULL,
	Factura varchar(20) NOT NULL,
	FechaRecepcionDocumentos datetime NOT NULL,
	FechaIngresoAPuerto datetime NOT NULL,
	NroDespacho varchar(20) NOT NULL,
	FechaOficializacion datetime NOT NULL,
	FechaInspeccionRENAR datetime NOT NULL,
	FechaIngresoDeposito datetime NOT NULL,
	ImporteGastosNacionalizacion decimal NOT NULL,
	Comentario varchar(255) NOT NULL,
	IdOpWF int NOT NULL,
 CONSTRAINT [PK_Table_OrdenCompra] PRIMARY KEY CLUSTERED 
(
	Id ASC,
	IdItem ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go
GRANT INSERT, DELETE, UPDATE, SELECT, REFERENCES ON dbo.OrdenCompra TO ce_update
go

