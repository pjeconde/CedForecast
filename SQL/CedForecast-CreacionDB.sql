CREATE DATABASE CedForecast 
GO
USE CedForecast
CREATE ROLE ce_update
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
insert WCUsuarios values ('Pablo', 'Pablo J.E.Conde', 1, 'DESA', '20100501', '20671231', 0, 'pablo.conde@cedeira.com.ar')
GO
insert WCGrupos values ('Usuarios', 'Claudio', 0, 0)
GO
insert WCGrupos values ('Usuarios', 'Pablo', 0, 0)
GO
insert WF_Acceso values ('FrontEnd', 'FrontEnd CedForecast', '1.0')
GO
insert WF_Parm values ('CXO', 1, '1-SI 0-NO')
GO
insert WF_PermisoGrupoXAcceso values ('Usuarios', 'FrontEnd', 1)
GO