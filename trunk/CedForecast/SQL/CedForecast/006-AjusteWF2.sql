insert WF_Evento values ('OrdenCpra', 'Anul', 'Anulación', 'Anular', '<Cualquiera>', 'Anulada', 0, 0, 1)
go
insert WF_EsquemaSeg select IdFlow, 'NA', 0, IdEvento, 'Usuarios', 'NA', 0, 0, 1 from WF_Evento where IdEvento='Anul'
go
insert WF_Estado values ('<ElMismo>', 'El mismo estado', 1)
go
insert WF_Evento values ('OrdenCpra', 'CambioEst', 'Cambio de Estado', 'Cambiar Estado', '<Cualquiera>', NULL, 0, 0, 0)
go
insert WF_EsquemaSeg select IdFlow, 'NA', 0, IdEvento, 'Usuarios', 'NA', 0, 0, 1 from WF_Evento where IdEvento='CambioEst'
go
insert WF_Evento values ('OrdenCpra', 'Modif', 'Modificación', 'Modificar', '<Cualquiera>', '<ElMismo>', 0, 0, 1)
go
insert WF_EsquemaSeg select IdFlow, 'NA', 0, IdEvento, 'Usuarios', 'NA', 0, 0, 1 from WF_Evento where IdEvento='Modif'
go
