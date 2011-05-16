insert WF_Evento values ('OrdenCpra', 'Anul', 'Anulación', 'Anular', '<Cualquiera>', 'Anulada', 0, 0, 1)
go
insert WF_EsquemaSeg select IdFlow, 'NA', 0, IdEvento, 'Usuarios', 'NA', 0, 0, 1 from WF_Evento where IdEvento='Anul'
go
