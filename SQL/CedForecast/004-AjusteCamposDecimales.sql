alter table dbo.ArticuloInfoAdicional alter column Precio decimal(18, 4) NOT NULL
go
alter table dbo.ArticuloInfoAdicional alter column CoeficienteGastosNacionalizacion decimal(18, 4) NOT NULL
go
alter table dbo.OrdenCompra alter column Precio decimal(18, 4) NOT NULL
go
alter table dbo.OrdenCompra alter column Importe decimal(18, 2) NOT NULL
go
alter table dbo.OrdenCompra alter column ImporteGastosNacionalizacion decimal(18, 2) NOT NULL
go
