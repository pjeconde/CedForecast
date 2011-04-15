insert WF_Flow values ('Embarque', 'Embarques')
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
insert WF_EstadoXFlow values ('Embarque', 'PteInfoEmb', 0)
go
insert WF_EstadoXFlow values ('Embarque', 'PteRecepDocs', 0)
go
insert WF_EstadoXFlow values ('Embarque', 'PteDesp', 0)
go
insert WF_EstadoXFlow values ('Embarque', 'PteInspRenar', 0)
go
insert WF_Estado values ('Embarque', 'PteIngrADep', 0)
go
insert WF_EstadoXFlow values ('Embarque', 'Concluida', 1)
go
insert WF_EstadoXFlow values ('Embarque', 'Anulada', 1)
go
insert WF_Evento values ('Embarque', 'Alta', 'Alta', 'Agregar', NULL, 'PteInfoEmb', 0, 0, 0)
go
insert WF_Evento values ('Embarque', 'ActInfoEmb', 'Actualización Info Embarque (planilla proveedor)', 'Registrar Info Embarque (aut)', 'PteInfoEmb', 'PteRecepDocs', 1, 0, 0)
go
insert WF_Evento values ('Embarque', 'IngInfoEmb', 'Ingreso Info Embarque', 'Ingresar Info Embarque', 'PteInfoEmb', 'PteRecepDocs', 0, 0, 1)
go
insert WF_Evento values ('Embarque', 'RecepDocs', 'Recepción Documentos', 'Recibir Documentos', 'PteRecepDocs', 'PteDesp', 0, 0, 1)
go
insert WF_Evento values ('Embarque', 'RegDesp', 'Registro Despacho', 'Registrar Despacho', 'PteDesp', NULL, 0, 0, 1)
go
insert WF_Evento values ('Embarque', 'InspRenar', 'Inspección RENAR', 'Registrar Inspección RENAR', 'PteInspRenar', 'PteIngrADep', 0, 0, 1)
go
insert WF_Evento values ('Embarque', 'IngrADep', 'Ingreso a Depósito', 'Ingresar a Depósito', 'PteIngrADep', 'Concluida', 0, 0, 1)
go