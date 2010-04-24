using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data.OleDb;

namespace Cedeira.SV
{
	public class db 
	{
		protected CedEntidades.Sesion sesion = new CedEntidades.Sesion();
		private string[] sqls;
		private SqlConnection sqlConexion;
		private SqlCommand sqlCommand;
		private SqlDataAdapter sqlAdapter;
		private SqlTransaction sqlTransaccion;

        private OdbcConnection ODBCConexion;
        private OdbcTransaction ODBCTransaccion;
        private OdbcDataAdapter ODBCAdapter;
        private OdbcCommand ODBCComando;

        private bool usaTransaccion = false;
		private int i;
		private int[] cantReg;
		private DataSet ds;
		private DataView[] dv;
		private DataTable[] tb;
		
		public db(CedEntidades.Sesion Sesion)
		{
			// Constructor
			this.sesion = Sesion;
		}
		#region " Codigo de acceso a Base de datos "
		public enum TipoRetorno
		{
			None,
			CantReg,
			DV,
			DS,
			TB
		};
		public enum Transaccion
		{
			Acepta,
			NoAcepta,
			Usa
		};
		protected object Ejecutar(object Sql, TipoRetorno TipoRetorno, Transaccion Transaccion, string CnnStrDB)
		{
			/*
			ESTE ES EL UNICO METODO QUE ACCEDE A LA BASE DE DATOS Y NO DEBE SER PUBLICO PARA QUE NO SEA INVOCADO NI
			DESDE LA CAPA DE REGLA DE NEGOCIO NI DE LA DE PRESENTACION
					Sql: 1) un string con una o mas instrucciones SQL.
						 2) un string array con uno o mas strings que contengan una o mas instrucciones SQL 
							cada uno. 
			TipoRetorno: 1) None: se ejecuta como un comando y no devuelve ningun resultado
						 2) CantReg: se ejecuta como un comando y devuelve un integer, o un integer array 
							(uno por cada Sql string array), indicando la cantidad registros se vieron afectados.
						 3) Dv: devuelve un dataview o un dataview array (cada uno con una tabla), 
							segun los datos obtenidos de la DB.
						 4) ds: devuelve un dataset con una o mas tablas segun los datos obtenidos de la DB. 
			Transaccion: 1) Acepta: en el caso de recibir un Sql string array, activa la transaccion.
						 2) NoAcepta: no activa la trasaccion
						 3) Usa: activa la transaccion
			*/
            if (CnnStrDB != null && CnnStrDB.Contains("Microsoft.Jet.OLEDB"))
            {
                string StrConexion = CnnStrDB;
                OleDbConnection Conexion = new OleDbConnection(StrConexion);
                OleDbDataAdapter Adapter = new OleDbDataAdapter(Sql.ToString(), Conexion);
                OleDbCommandBuilder SQLComandos = new OleDbCommandBuilder(Adapter);
                switch (TipoRetorno)
                {
                    case (TipoRetorno.None):
                    case (TipoRetorno.CantReg):
                        Conexion.Open();
                        Adapter.Fill(ds);
                        cantReg[0] = ds.Tables[0].Rows.Count;
                        Conexion.Close();
                        break;
                    case (TipoRetorno.DS):
                    case (TipoRetorno.DV):
                    case (TipoRetorno.TB):
                        Conexion.Open();
                        ds = new DataSet();
                        Adapter.Fill(ds);
                        Conexion.Close();
                        switch (TipoRetorno)
                        {
                            case (TipoRetorno.DV):
                                if (ds.Tables.Count > 0)
                                {
                                    dv = new DataView[ds.Tables.Count];
                                    for (i = 0; i < ds.Tables.Count; i++)
                                    {
                                        dv[i] = ds.Tables[i].DefaultView;
                                    }
                                }
                                break;
                            case (TipoRetorno.TB):
                                if (ds.Tables.Count > 0)
                                {
                                    tb = new DataTable[ds.Tables.Count];
                                    for (i = 0; i < ds.Tables.Count; i++)
                                    {
                                        tb[i] = ds.Tables[i];
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                }
                switch(TipoRetorno)
			    {
				    case TipoRetorno.None:
					    return new System.Object();
				    case TipoRetorno.CantReg:
					    return cantReg;
				    case TipoRetorno.DS:
					    return ds;
				    case TipoRetorno.TB:
					    switch(ds.Tables.Count)
					    {
						    case 0:
							    return new DataTable();
						    case 1:
							    return tb[0];
						    default:
							    return tb;
					    }
				    default: //case TipoRetorno.Dv:
					    switch(ds.Tables.Count)
					    {
						    case 0:
							    return new DataView();
						    case 1:
							    return dv[0];
						    default:
							    return dv;
					    }
			    }
            }
            else
            //SQL Server
            {
                switch(Sql.GetType().FullName.ToString())
			    {
				    case "System.String[]":
					    sqls = (string[])Sql;
					    break;
				    default:	//case "System.String":
					    sqls = new String[] { (string)Sql };
					    break;
			    }
			    cantReg = new int[sqls.Length];
			    try
			    {
				    sqlConexion = new SqlConnection(CnnStrDB);
				    sqlConexion.Open();
				    switch(Transaccion)
				    {
					    case (Transaccion.Acepta):
						    usaTransaccion = (sqls.Length > 1);
						    break;
					    case (Transaccion.NoAcepta):
						    usaTransaccion = false;
						    break;
					    default: //(Transaccion.Usa):
						    usaTransaccion = true;
						    break;
				    }
				    if(usaTransaccion)
					    sqlTransaccion = sqlConexion.BeginTransaction();
				    switch(TipoRetorno)
				    {
					    case (TipoRetorno.None):
					    case (TipoRetorno.CantReg):
						    sqlCommand = new SqlCommand();
						    sqlCommand.Connection = sqlConexion;
						    sqlCommand.CommandTimeout = 90;
						    if(usaTransaccion)
						    {
							    sqlCommand.Transaction = sqlTransaccion;
						    }
						    for(i = 0; i < sqls.Length; i++)
						    {
							    sqlCommand.CommandText = sqls[i];
							    System.Diagnostics.Debug.WriteLine(sqlCommand.CommandText);
							    cantReg[i] = sqlCommand.ExecuteNonQuery();
						    }
						    break;
					    case (TipoRetorno.DS):
					    case (TipoRetorno.DV):
					    case (TipoRetorno.TB):
						    ds = new DataSet();
						    for(i = 0; i < sqls.Length; i++)
						    {
							    System.Diagnostics.Debug.WriteLine(sqls[i]);
							    sqlAdapter = new SqlDataAdapter(sqls[i], sqlConexion);
							    if(usaTransaccion)
							    {
								    sqlAdapter.SelectCommand.Transaction = sqlTransaccion;
							    }
							    sqlAdapter.SelectCommand.CommandTimeout = 90;
							    if(i == 0)
							    {
								    sqlAdapter.Fill(ds);
							    }
							    else
							    {
								    ds.Tables.Add();
								    sqlAdapter.Fill(ds.Tables[ds.Tables.Count - 1]);
							    }
						    }
						    switch(TipoRetorno)
						    {
							    case (TipoRetorno.DV):
								    if(ds.Tables.Count > 0)
								    {
									    dv = new DataView[ds.Tables.Count];
									    for(i = 0; i < ds.Tables.Count; i++)
									    {
										    dv[i] = ds.Tables[i].DefaultView;
									    }
								    }
								    break;
							    case (TipoRetorno.TB):
								    if(ds.Tables.Count > 0)
								    {
									    tb = new DataTable[ds.Tables.Count];
									    for(i = 0; i < ds.Tables.Count; i++)
									    {
										    tb[i] = ds.Tables[i];
									    }
								    }
								    break;
							    default:
								    break;
						    }
						    break;
				    }
				    if(usaTransaccion)
				    {
					    sqlTransaccion.Commit();
				    }
				    sqlConexion.Close();
				    switch(TipoRetorno)
				    {
					    case TipoRetorno.None:
						    return new System.Object();
					    case TipoRetorno.CantReg:
						    if(sqls.Length > 1)
						    {
							    return cantReg;
						    }
						    else
						    {
							    return cantReg[0];
						    }
					    case TipoRetorno.DS:
						    return ds;
					    case TipoRetorno.TB:
						    switch(ds.Tables.Count)
						    {
							    case 0:
								    return new DataTable();
							    case 1:
								    return tb[0];
							    default:
								    return tb;
						    }
					    default: //case TipoRetorno.Dv:
						    switch(ds.Tables.Count)
						    {
							    case 0:
								    return new DataView();
							    case 1:
								    return dv[0];
							    default:
								    return dv;
						    }
				    }
			    }
			    catch(System.Data.SqlClient.SqlException ex1)
			    {
				    if(((System.Data.SqlClient.SqlException)(ex1)).Procedure == "ConnectionOpen (Connect()).")
				    {
					    throw new Microsoft.ApplicationBlocks.ExceptionManagement.db.Conexion(ex1);
				    }
				    else
				    {
					    if(usaTransaccion)
					    {
						    try
						    {
							    sqlTransaccion.Rollback();
							    throw new Microsoft.ApplicationBlocks.ExceptionManagement.db.EjecucionConRollback(ex1);
						    }
						    catch(Microsoft.ApplicationBlocks.ExceptionManagement.db.EjecucionConRollback)
						    {
							    throw new Microsoft.ApplicationBlocks.ExceptionManagement.db.EjecucionConRollback(ex1);
						    }
						    catch
						    {
							    throw new Microsoft.ApplicationBlocks.ExceptionManagement.db.Rollback(ex1);
						    }
					    }
					    else
					    {
						    throw new Microsoft.ApplicationBlocks.ExceptionManagement.db.Ejecucion(ex1);
					    }
				    }
			    }
            }
		}
		public void TesteoConexion(string CnnStrDB)
		{
			try
			{
				sqlConexion = new SqlConnection(CnnStrDB);
				sqlConexion.Open();
				sqlConexion.Close();
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.db.Conexion(ex);
			}
		}
        protected object EjecutarODBC(object Sql, TipoRetorno TipoRetorno, Transaccion Transaccion, string CnnStrDB, string nombreODBC)
        {
            switch (Sql.GetType().FullName.ToString())
            {
                case "System.String[]":
                    sqls = (string[])Sql;
                    break;
                default:	//case "System.String":
                    sqls = new String[] { (string)Sql };
                    break;
            }
            cantReg = new int[sqls.Length];
            switch (Transaccion)
            {
                case (Transaccion.Acepta):
                    usaTransaccion = (sqls.Length > 1);
                    break;
                case (Transaccion.NoAcepta):
                    usaTransaccion = false;
                    break;
                default: //(Transaccion.Usa):
                    usaTransaccion = true;
                    break;
            }
            if (usaTransaccion) ODBCTransaccion = ODBCConexion.BeginTransaction();
            try
            {
                ODBCConexion = new OdbcConnection("dsn=" + nombreODBC + ";uid=" + sesion.Usuario.IdUsuario + ";pwd=" + sesion.Usuario.Password + ";");
                ODBCConexion.Open();
                ODBCComando = new OdbcCommand(Sql.ToString(), ODBCConexion);
                ds = new DataSet();
				for(i = 0; i < sqls.Length; i++)
				{
					System.Diagnostics.Debug.WriteLine(sqls[i]);
                    ODBCAdapter = new OdbcDataAdapter(sqls[i], ODBCConexion);
					if(usaTransaccion)
					{
                        ODBCAdapter.SelectCommand.Transaction = ODBCTransaccion;
					}
                    ODBCAdapter.SelectCommand.CommandTimeout = 90;
					if(i == 0)
					{
                        ODBCAdapter.Fill(ds);
					}
					else
					{
						ds.Tables.Add();
                        ODBCAdapter.Fill(ds.Tables[ds.Tables.Count - 1]);
					}
				}
                return ds;
            }
            catch (Exception ex)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.db.Conexion(ex);
            }
        }
		#endregion
		#region " Codigo para CedEntidades.Usuario "

        public List<CedEntidades.GrupoXUsuario> US_PerteneceA(string IdUsuario)
        {
            DataView dv = US_GruposXUsuario_get(IdUsuario, true);
            List<CedEntidades.GrupoXUsuario> listaDeGrupos = new List<CedEntidades.GrupoXUsuario>();
            for (int i = 0; i < dv.Table.Rows.Count; i++)
            {
                CedEntidades.GrupoXUsuario grupo = new CedEntidades.GrupoXUsuario();
                grupo.Id = dv.Table.Rows[i]["IdGrupo"].ToString();
                grupo.Descr = dv.Table.Rows[i]["Descr"].ToString();
                grupo.IdTGrupo = dv.Table.Rows[i]["IdTGrupo"].ToString();
                grupo.Supervisor = Convert.ToBoolean(dv.Table.Rows[i]["Supervisor"]);
                grupo.SupervisorNivel = Convert.ToByte(dv.Table.Rows[i]["SupervisorNivel"]);
                grupo.DescrGrupoSPyNV = dv.Table.Rows[i]["DescrGrupoSPyNV"].ToString();
                listaDeGrupos.Add(grupo);
            }
            return listaDeGrupos;
        }
        public List<CedEntidades.Grupo> US_NoPerteneceA(string IdUsuario)
        {
            DataView dv = US_GruposXUsuario_get(IdUsuario, false);
            List<CedEntidades.Grupo> listaDeGrupos = new List<CedEntidades.Grupo>();
            for (int i = 0; i < dv.Table.Rows.Count; i++)
            {
                CedEntidades.Grupo grupo = new CedEntidades.Grupo();
                grupo.Id = dv.Table.Rows[i]["IdGrupo"].ToString();
                grupo.Descr = dv.Table.Rows[i]["Descr"].ToString();
                grupo.IdTGrupo = dv.Table.Rows[i]["IdTGrupo"].ToString();
                listaDeGrupos.Add(grupo);
            }
            return listaDeGrupos;
        }
        public DataView US_Usuario_get(string IdUsuario)
		{
			return (DataView)Ejecutar("SELECT IdUsuario, Nombre, Activo, Alias, FecAlta, FecBaja, RequierePassword, Email FROM WCUsuarios where IdUsuario='" + IdUsuario + "'",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
		}

        public DataView US_Usuario_qry()
        {
            return (DataView)Ejecutar("SELECT IdUsuario, Nombre, Activo, Alias, FecAlta, FecBaja, RequierePassword, Email FROM WCUsuarios where IdUsuario<>'XNoDefine' order by Nombre",
                TipoRetorno.DV,
                Transaccion.NoAcepta,
                sesion.CnnStr);
        }

        public DataView US_Usuario_qry(List<CedEntidades.Grupo> ExcluirGrupos)
        {
            StringBuilder b = new StringBuilder(String.Empty);
            for (int i = 0; i < ExcluirGrupos.Count; i++)
            {
                b.Append("'" + ExcluirGrupos[i].Id + "', ");
            }
            StringBuilder a = new StringBuilder(String.Empty);
            a.Append("select IdUsuario, Nombre, Activo, Alias, FecAlta, FecBaja, RequierePassword, Email from WCUsuarios where IdUsuario in ( ");
            a.Append("select WCGrupos.IdUsuario from WCTbGrupos, WCGrupos where WCTbGrupos.IdGrupo not in ( ");
            a.Append(b.ToString().Substring(0, b.ToString().Length-2));
            a.Append(") and WCTbGrupos.IdGrupo=WCGrupos.IdGrupo ");
            a.Append(") order by Nombre ");
            return (DataView)Ejecutar(a.ToString(),
                TipoRetorno.DV,
                Transaccion.NoAcepta,
                sesion.CnnStr);
        }

        private DataView US_GruposXUsuario_get(string IdUsuario, bool Pertenece)
		{
			if(Pertenece)
			{
                return (DataView)Ejecutar("Select WCGrupos.IdGrupo, WCTbGrupos.Descr, WCTbGrupos.IdTGrupo, Supervisor, SupervisorNivel, Descr+' '+'('+WCGrupos.IdGrupo+'): '+case Supervisor when 1 then 'SP, ' else 'no SP, ' end+'NV='+convert(varchar,SupervisorNivel) as DescrGrupoSPyNV from WCGrupos, WCTbGrupos where IdUsuario='" + IdUsuario + "' and WCGrupos.IdGrupo=WCTbGrupos.IdGrupo order by WCTbGrupos.Descr",
					TipoRetorno.DV,
					Transaccion.NoAcepta,
					sesion.CnnStr);
			}
			else
			{
                return (DataView)Ejecutar("Select WCTbGrupos.IdGrupo, WCTbGrupos.Descr, WCTbGrupos.IdTGrupo from WCTbGrupos where IdGrupo not in (Select IdGrupo from WCGrupos where IdUsuario='" + IdUsuario + "') order by WCTbGrupos.Descr",
					TipoRetorno.DV,
					Transaccion.NoAcepta,
					sesion.CnnStr);
			}
		}

		#endregion
		#region " Codigo para dbWF "
		public CedEntidades.WF WF_Op_get(int IdOp)
		{
			DataView dv = (DataView)Ejecutar(
				"Select WF_Op.*, WF_Flow.DescrFlow, WF_Circuito.DescrCircuito, WF_NivSeg.DescrNivSeg, WF_Estado.DescrEstado " +
				"from WF_Op, WF_Flow, WF_Circuito, WF_NivSeg, WF_Estado " +
				"where IdOp=" + IdOp + " and WF_Op.IdFlow=WF_Flow.IdFlow and WF_Op.IdCircuito=WF_Circuito.IdCircuito and WF_Op.IdNivSeg=WF_NivSeg.IdNivSeg and WF_Op.IdEstado=WF_Estado.IdEstado",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
			CedEntidades.WF wf = new CedEntidades.WF();
			if (dv.Table.Rows.Count != 0)
			{
				// Info OpWF
				wf.IdOp = IdOp;
				wf.IdFlow = Convert.ToString(dv.Table.Rows[0]["IdFlow"]);
				wf.DescrFlow = Convert.ToString(dv.Table.Rows[0]["DescrFlow"]);
				wf.IdCircuito = Convert.ToString(dv.Table.Rows[0]["IdCircuito"]);
				wf.IdCircuitoOrig = wf.IdCircuito;
				wf.DescrCircuito = Convert.ToString(dv.Table.Rows[0]["DescrCircuito"]);
				wf.IdNivSeg = Convert.ToInt32(dv.Table.Rows[0]["IdNivSeg"]);
				wf.DescrNivSeg = Convert.ToString(dv.Table.Rows[0]["DescrNivSeg"]);
				wf.DescrOp = Convert.ToString(dv.Table.Rows[0]["DescrOp"]);
				wf.IdEstado = Convert.ToString(dv.Table.Rows[0]["IdEstado"]);
				wf.UltActualiz = Cedeira.SV.db.ByteArray2TimeStamp((byte[])dv.Table.Rows[0]["UltActualiz"]);
				wf.DescrEstado = Convert.ToString(dv.Table.Rows[0]["DescrEstado"]);
				wf.Sesion = sesion;
			}
			return wf;
		}
		public List<CedEntidades.Log> WF_LogXOp_qry(int IdOp)
		{
			DataView dv = (DataView)Ejecutar(
				"Select " +
				"WF_Log.Fecha, WF_Evento.DescrEvento as Evento, WF_Estado.DescrEstado as Estado, WCUsuarios.Nombre+' ('+WF_Log.IdUsuario+')' as Responsable, " +
				"WF_Log.Comentario, WF_Log.IdLog, WF_Log.IdFlow, WF_Log.IdCircuito, WF_Log.IdNivSeg, WF_Log.IdGrupo, WF_Log.Supervisor, WF_Log.IdUsuario, " +
				"WF_Log.SupervisorNivel, WF_Log.IdEvento, WF_Log.IdEstado, WF_Flow.DescrFlow, WF_Circuito.DescrCircuito, WCTbGrupos.Descr as DescrGrupo " +
				"from WF_Log, WCUsuarios, WF_Evento, WF_Estado, WF_Flow, WF_Circuito, WCTbGrupos " +
				"where IdOp=" + IdOp + " and WF_Log.IdUsuario=WCUsuarios.IdUsuario " +
				"and WF_Log.IdFlow=WF_Evento.IdFlow " +
				"and WF_Log.IdFlow=WF_Flow.IdFlow " +
				"and WF_Log.IdCircuito=WF_Circuito.IdCircuito " +
				"and WF_Log.IdGrupo=WCTbGrupos.IdGrupo " +
				"and WF_Log.IdEvento=WF_Evento.IdEvento and WF_Log.IdEstado=WF_Estado.IdEstado",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
			List<CedEntidades.Log> logList = new List<CedEntidades.Log>();
			for (int i = 0; i < dv.Table.Rows.Count; i++)
			{
				CedEntidades.Log l = new CedEntidades.Log();
				l.Circuito.IdCircuito = Convert.ToString(dv.Table.Rows[i]["IdCircuito"]);
				l.Comentario = Convert.ToString(dv.Table.Rows[i]["Comentario"]);
				l.Estado = Convert.ToString(dv.Table.Rows[i]["Estado"]);
				l.Evento.Id = Convert.ToString(dv.Table.Rows[i]["IdEvento"]);
				l.Fecha = Convert.ToDateTime(dv.Table.Rows[i]["Fecha"]);
				l.Flow.IdFlow = Convert.ToString(dv.Table.Rows[i]["IdFlow"]);
				l.Grupo.Id = Convert.ToString(dv.Table.Rows[i]["IdGrupo"]);
				l.IdLog = Convert.ToInt32(dv.Table.Rows[i]["IdLog"]);
				l.IdNivSeg = Convert.ToInt32(dv.Table.Rows[i]["IdNivSeg"]);
				l.Responsable = Convert.ToString(dv.Table.Rows[i]["Responsable"]);
				l.Supervisor = Convert.ToBoolean(dv.Table.Rows[i]["Supervisor"]);
				l.SupervisorNivel = Convert.ToByte(dv.Table.Rows[i]["SupervisorNivel"]);
				l.Usuario.IdUsuario = Convert.ToString(dv.Table.Rows[i]["IdUsuario"]);
				logList.Add(l);
			}
			return logList;

		}
        public System.Collections.Generic.List<CedEntidades.Evento> WF_EventosIniciales_qry(CedEntidades.WF Wf)
		{
            StringBuilder a=new StringBuilder(String.Empty);
            a.Append("select WF_Evento.*, WF_Flow.DescrFlow, EstadoHst.DescrEstado as DescrEstadoHst ");
            a.Append("from WF_Evento ");
            a.Append("inner join WF_Flow on WF_Evento.IdFlow=WF_Flow.IdFlow ");
            a.Append("left outer join WF_Estado EstadoHst on EstadoHst.IdEstado=WF_Evento.IdEstadoHst ");
            a.Append("where WF_Evento.IdFlow='" + Wf.IdFlow + "' and WF_Evento.IdEstadoDsd is null ");
 			DataView dv = (DataView)Ejecutar(
				a.ToString(),
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
            System.Collections.Generic.List<CedEntidades.Evento> eventosPos = new System.Collections.Generic.List<CedEntidades.Evento>();
            for (int i = 0; i < dv.Table.Rows.Count; i++)
            {
                CedEntidades.Evento evento = new CedEntidades.Evento();
                evento.Flow.IdFlow = Convert.ToString(dv.Table.Rows[i]["IdFlow"]);
                evento.Id = Convert.ToString(dv.Table.Rows[i]["IdEvento"]);
                evento.Descr = Convert.ToString(dv.Table.Rows[i]["DescrEvento"]);
                evento.TextoAccion = Convert.ToString(dv.Table.Rows[i]["TextoAccion"]);
                evento.IdEstadoDsd.IdEstado = Convert.ToString(dv.Table.Rows[i]["IdEstadoDsd"]);
                evento.IdEstadoHst.IdEstado = Convert.ToString(dv.Table.Rows[i]["IdEstadoHst"]);
                evento.Automatico = Convert.ToBoolean(dv.Table.Rows[i]["Automatico"]);
                evento.CXO = Convert.ToBoolean(dv.Table.Rows[i]["CXO"]);
                evento.XLote = Convert.ToBoolean(dv.Table.Rows[i]["XLote"]);
                evento.Flow.DescrFlow = Convert.ToString(dv.Table.Rows[i]["DescrFlow"]);
                evento.IdEstadoHst.DescrEstado = Convert.ToString(dv.Table.Rows[i]["DescrEstadoHst"]);
                eventosPos.Add(evento);
            }
            return eventosPos;
		}
		public List<CedEntidades.Evento> WF_EventosIniciales_qry()
		{
			DataView dv = (DataView)Ejecutar(
				"select IdFlow+'-'+IdEvento as IdEventoInicial, IdFlow+'-'+DescrEvento as DescrEventoInicial from WF_Evento where IdEstadoDsd is null",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
			List<CedEntidades.Evento> eventosInic = new List<CedEntidades.Evento>();
			for (int i = 0; i < dv.Table.Rows.Count; i++)
			{
				CedEntidades.Evento e = new CedEntidades.Evento();
				e.Id = Convert.ToString(dv.Table.Rows[i]["IdEvento"]);
				e.Descr = Convert.ToString(dv.Table.Rows[i]["DescrEventoInicial"]);
				eventosInic.Add(e);
			}
			return eventosInic;
		}
        public System.Collections.Generic.List<CedEntidades.Evento> WF_EventosPosibles_qry(CedEntidades.WF Wf)
		{
			string a = "Select WF_Evento.*, WF_Flow.DescrFlow, EstadoDsd.DescrEstado as DescrEstadoDsd, EstadoHst.DescrEstado as DescrEstadoHst " +
				"from WF_Evento " +
				"inner join WF_Flow on WF_Evento.IdFlow=WF_Flow.IdFlow " +
				"inner join WF_Estado EstadoDsd on WF_Evento.IdEstadoDsd=EstadoDsd.IdEstado " +
				"left outer join WF_Estado EstadoHst on WF_Evento.IdEstadoHst=EstadoHst.IdEstado " +
				"where WF_Evento.IdFlow='" + Wf.IdFlow + "' and WF_Evento.IdEstadoDsd in ('" + Wf.IdEstado + "', '<Cualquiera>') " +
				"and WF_Evento.IdEvento in (select IdEvento from WF_EsquemaSeg where IdCircuito='" + Wf.IdCircuito + "' and IdFlow='" + Wf.IdFlow + "') ";
			DataView dv = (DataView)Ejecutar(
				a,
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
            System.Collections.Generic.List<CedEntidades.Evento> eventosPos = new System.Collections.Generic.List<CedEntidades.Evento>();
            for (int i = 0; i < dv.Table.Rows.Count; i++)
            {
                CedEntidades.Evento evento = new CedEntidades.Evento();
                evento.Flow.IdFlow = Convert.ToString(dv.Table.Rows[i]["IdFlow"]);
                evento.Id = Convert.ToString(dv.Table.Rows[i]["IdEvento"]);
                evento.Descr = Convert.ToString(dv.Table.Rows[i]["DescrEvento"]);
                evento.TextoAccion = Convert.ToString(dv.Table.Rows[i]["TextoAccion"]);
                evento.IdEstadoDsd.IdEstado = Convert.ToString(dv.Table.Rows[i]["IdEstadoDsd"]);
                evento.IdEstadoHst.IdEstado = Convert.ToString(dv.Table.Rows[i]["IdEstadoHst"]);
                evento.Automatico = Convert.ToBoolean(dv.Table.Rows[i]["Automatico"]);
                evento.CXO = Convert.ToBoolean(dv.Table.Rows[i]["CXO"]);
                evento.XLote = Convert.ToBoolean(dv.Table.Rows[i]["XLote"]);
                evento.Flow.DescrFlow = Convert.ToString(dv.Table.Rows[i]["DescrFlow"]);
                evento.IdEstadoDsd.DescrEstado = Convert.ToString(dv.Table.Rows[i]["DescrEstadoDsd"]);
                evento.IdEstadoHst.DescrEstado = Convert.ToString(dv.Table.Rows[i]["DescrEstadoHst"]);
                eventosPos.Add(evento);
            }
            return eventosPos;
		}
        public System.Collections.Generic.List<CedEntidades.Evento> WF_EventosXLotePosibles_qry(CedEntidades.WF Wf)
		{
			string a = "Select WF_Evento.*, WF_Flow.DescrFlow, EstadoDsd.DescrEstado as DescrEstadoDsd, EstadoHst.DescrEstado as DescrEstadoHst " +
				"from WF_Evento, WF_Flow, WF_Estado EstadoDsd, WF_Estado EstadoHst " +
                "where WF_Evento.IdFlow='" + Wf.IdFlow + "' and WF_Evento.IdEstadoDsd in ('" + Wf.IdEstado + "', '<Cualquiera>') " +
				"and WF_Evento.IdFlow=WF_Flow.IdFlow " +
				"and EstadoDsd.IdEstado=WF_Evento.IdEstadoDsd and EstadoHst.IdEstado=WF_Evento.IdEstadoHst " +
                "and WF_Evento.IdEvento in (select IdEvento from WF_EsquemaSeg where IdCircuito='" + Wf.IdCircuito + "' and IdFlow='" + Wf.IdFlow + "') " +
				"and WF_Evento.XLote=1 ";
			DataView dv = (DataView)Ejecutar(
				a,
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
            System.Collections.Generic.List<CedEntidades.Evento> eventosPos = new System.Collections.Generic.List<CedEntidades.Evento>();
            for (int i = 0; i < dv.Table.Rows.Count; i++)
            {
                CedEntidades.Evento evento = new CedEntidades.Evento();
                evento.Flow.IdFlow = Convert.ToString(dv.Table.Rows[i]["IdFlow"]);
                evento.Id = Convert.ToString(dv.Table.Rows[i]["IdEvento"]);
                evento.Descr = Convert.ToString(dv.Table.Rows[i]["DescrEvento"]);
                evento.TextoAccion = Convert.ToString(dv.Table.Rows[i]["TextoAccion"]);
                evento.IdEstadoDsd.IdEstado = Convert.ToString(dv.Table.Rows[i]["IdEstadoDsd"]);
                evento.IdEstadoHst.IdEstado = Convert.ToString(dv.Table.Rows[i]["IdEstadoHst"]);
                evento.Automatico = Convert.ToBoolean(dv.Table.Rows[i]["Automatico"]);
                evento.CXO = Convert.ToBoolean(dv.Table.Rows[i]["CXO"]);
                evento.XLote = Convert.ToBoolean(dv.Table.Rows[i]["XLote"]);
                evento.Flow.DescrFlow = Convert.ToString(dv.Table.Rows[i]["DescrFlow"]);
                evento.IdEstadoDsd.DescrEstado = Convert.ToString(dv.Table.Rows[i]["DescrEstadoDsd"]);
                evento.IdEstadoHst.DescrEstado = Convert.ToString(dv.Table.Rows[i]["DescrEstadoHst"]);
                eventosPos.Add(evento);
            }
            return eventosPos;

		}
		public System.Collections.Generic.List<CedEntidades.EsqSegEvenPos> WF_EsquemaSegEventosPosibles_qry(CedEntidades.WF Wf)
		{
			string ListaEventos = String.Empty;
			for(int i = 0; i < Wf.EventosPosibles.Count; i++)
			{
				ListaEventos = ListaEventos + "'" + Wf.EventosPosibles[i].Id + "'";
                if (i != Wf.EventosPosibles.Count - 1)
				{
					ListaEventos = ListaEventos + ", ";
				}
			}
			if(ListaEventos == String.Empty)
				ListaEventos = "''";
            string a = "select WF_EsquemaSeg.IdEvento, WF_EsquemaSeg.CantInterv, WF_EsquemaSeg.IdGrupo, WF_EsquemaSeg.DebeSerSP, WF_EsquemaSeg.SupervisorNivelDsd, WF_EsquemaSeg.SupervisorNivelHst, WCTbGrupos.Descr as DescrGrupo, WF_Evento.DescrEvento, WF_Evento.Automatico, WF_Evento.CXO, WF_Evento.XLote " +
				"from WF_EsquemaSeg, WCTbGrupos, WF_Evento " +
				"where WF_EsquemaSeg.IdFlow='" + Wf.IdFlow + "' and WF_EsquemaSeg.IdCircuito='" + Wf.IdCircuito + "' and (WF_EsquemaSeg.IdNivSeg=" + Wf.IdNivSeg + " or WF_EsquemaSeg.IdNivSeg=0) and WF_EsquemaSeg.IdEvento in (" + ListaEventos + ") " +
				"and WF_EsquemaSeg.IdGrupo=WCTbGrupos.IdGrupo " +
				"and WF_EsquemaSeg.IdFlow=WF_Evento.IdFlow and WF_EsquemaSeg.IdEvento=WF_Evento.IdEvento";
			System.Collections.Generic.List<CedEntidades.EsqSegEvenPos> listaEsqSegEvenPos = new List<CedEntidades.EsqSegEvenPos>();
            DataView dv = (DataView)Ejecutar(a,TipoRetorno.DV,Transaccion.NoAcepta,sesion.CnnStr);
            for(int i = 0; i< dv.Table.Rows.Count;i++)
            {
                CedEntidades.EsqSegEvenPos esqSegEvenPos = new CedEntidades.EsqSegEvenPos();
				esqSegEvenPos.Evento.Id = Convert.ToString(dv.Table.Rows[i]["IdEvento"]);
                esqSegEvenPos.Evento.Automatico = Convert.ToBoolean(dv.Table.Rows[i]["Automatico"]);
                esqSegEvenPos.Evento.CXO = Convert.ToBoolean(dv.Table.Rows[i]["CXO"]);
                esqSegEvenPos.Evento.XLote = Convert.ToBoolean(dv.Table.Rows[i]["XLote"]);
                esqSegEvenPos.Evento.Descr = Convert.ToString(dv.Table.Rows[i]["DescrEvento"]);
                esqSegEvenPos.CantInterv = Convert.ToInt32(dv.Table.Rows[i]["CantInterv"]);
                esqSegEvenPos.Grupo.Id = Convert.ToString(dv.Table.Rows[i]["IdGrupo"]);
                esqSegEvenPos.DebeSerSP = Convert.ToString(dv.Table.Rows[i]["DebeSerSP"]);
                esqSegEvenPos.SupervisorNivelDsd = Convert.ToInt32(dv.Table.Rows[i]["SupervisorNivelDsd"]);
                esqSegEvenPos.SupervisorNivelHst = Convert.ToInt32(dv.Table.Rows[i]["SupervisorNivelHst"]);
                esqSegEvenPos.Grupo.Descr = Convert.ToString(dv.Table.Rows[i]["DescrGrupo"]);
                listaEsqSegEvenPos.Add(esqSegEvenPos);
            }
            return listaEsqSegEvenPos;
		}
		public CedEntidades.Flow WF_Flow_get(string IdFlow)
		{
			
			DataView dv = (DataView)Ejecutar("Select IdFlow, DescrFlow from WF_Flow where IdFlow='" + IdFlow + "'",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
			CedEntidades.Flow flow = new CedEntidades.Flow();
			if(dv.Table.Rows.Count > 0)
            {
				flow.IdFlow = Convert.ToString(dv.Table.Rows[0]["IdFlow"]);
				flow.DescrFlow = Convert.ToString(dv.Table.Rows[0]["DescrFlow"]);
			}
			return flow;
		}
		public CedEntidades.Circuito WF_Circuito_get(string IdCircuito)
		{
			DataView dv = (DataView)Ejecutar("Select  IdCircuito, DescrCircuito from WF_Circuito where IdCircuito='" + IdCircuito + "'",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
			CedEntidades.Circuito circuito = new CedEntidades.Circuito();
			if (dv.Table.Rows.Count > 0)
			{
				circuito.IdCircuito = Convert.ToString(dv.Table.Rows[0]["IdCircuito"]);
				circuito.DescrCircuito = Convert.ToString(dv.Table.Rows[0]["DescrCircuito"]);
			}
			return circuito;
		}
		public CedEntidades.NivSeg WF_NivSeg_get(int IdNivSeg)
		{
			DataView dv = (DataView)Ejecutar("Select IdNivSeg, DescrNivSeg from WF_NivSeg where IdNivSeg=" + IdNivSeg,
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
			CedEntidades.NivSeg nivSeg = new CedEntidades.NivSeg();
			if (dv.Table.Rows.Count > 0)
			{
				nivSeg.IdNivSeg = Convert.ToInt32(dv.Table.Rows[0]["IdNivSeg"]);
				nivSeg.DescrNivSeg = Convert.ToString(dv.Table.Rows[0]["DescrNivSeg"]);
			}
			return nivSeg;
		}
		public List<CedEntidades.Flow> WF_Flow_lst()
		{
			DataView dv =  (DataView)Ejecutar("Select IdFlow as Id, DescrFlow as Descr from WF_Flow",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
			List<CedEntidades.Flow> flows = new List<CedEntidades.Flow>();
			for (int i = 0; i < dv.Table.Rows.Count; i++)
			{
				CedEntidades.Flow f = new CedEntidades.Flow();
				f.IdFlow = Convert.ToString(dv.Table.Rows[i]["Id"]);
				f.DescrFlow = Convert.ToString(dv.Table.Rows[i]["Descr"]);
				flows.Add(f);
			}
			return flows;

		}
		public List<CedEntidades.Circuito> WF_Circuito_lst()
		{
			DataView dv = (DataView)Ejecutar("Select IdCircuito as Id, DescrCircuito as Descr from WF_Circuito",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
			List<CedEntidades.Circuito> circuitos = new List<CedEntidades.Circuito>();
			for (int i = 0; i < dv.Table.Rows.Count; i++)
			{
				CedEntidades.Circuito c = new CedEntidades.Circuito();
				c.IdCircuito = Convert.ToString(dv.Table.Rows[i]["Id"]);
				c.DescrCircuito = Convert.ToString(dv.Table.Rows[i]["Descr"]);
				circuitos.Add(c);
			}
			return circuitos;
		}
		public List<CedEntidades.NivSeg> WF_NivSeg_lst()
		{
			DataView dv = (DataView)Ejecutar("Select IdNivSeg as Id, DescrNivSeg as Descr from WF_NivSeg",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
			List<CedEntidades.NivSeg> niveles = new List<CedEntidades.NivSeg>();
			for (int i = 0; i < dv.Table.Rows.Count; i++)
			{
				CedEntidades.NivSeg n = new CedEntidades.NivSeg();
				n.IdNivSeg = Convert.ToInt32(dv.Table.Rows[i]["Id"]);
				n.DescrNivSeg = Convert.ToString(dv.Table.Rows[i]["Descr"]);
				niveles.Add(n);
			}
			return niveles;
		}
		public DataView WF_Estado_lst()
		{
			return (DataView)Ejecutar("select WF_Estado.IdEstado as Id, DescrEstado as Descr, IdFlow, EstadoFinal from WF_Estado, WF_EstadoXFlow where WF_Estado.IdEstado=WF_EstadoXFlow.IdEstado and Virtual<>1 order by IdFlow, EstadoFinal",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
		}
		public List<CedEntidades.Acceso> WF_Acceso_lst()
		{
			DataView dv = (DataView)Ejecutar("Select IdAcceso as Id, DescrAcceso as Descr from WF_Acceso",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
			List<CedEntidades.Acceso> accesos = new List<CedEntidades.Acceso>();
			for (int i = 0; i < dv.Table.Rows.Count; i++)
			{
				CedEntidades.Acceso a = new CedEntidades.Acceso();
				a.IdAcceso = Convert.ToString(dv.Table.Rows[i]["Id"]);
				a.DescrAcceso = Convert.ToString(dv.Table.Rows[i]["Descr"]);
				accesos.Add(a);
			}
			return accesos;
		}
		public List<CedEntidades.Estado> WF_Estado_qry()
		{
			DataView dv = (DataView)Ejecutar("select IdEstado as Id, DescrEstado as Descr, Virtual from WF_Estado where Virtual<>1 order by DescrEstado",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
			List<CedEntidades.Estado> estados = new List<CedEntidades.Estado>();
			for (int i = 0; i < dv.Table.Rows.Count; i++)
			{
				CedEntidades.Estado e = new CedEntidades.Estado();
				e.IdEstado = Convert.ToString(dv.Table.Rows[i]["Id"]);
				e.DescrEstado = Convert.ToString(dv.Table.Rows[i]["Descr"]);
				e.VirtuaL = Convert.ToBoolean(dv.Table.Rows[i]["Virtual"]);
				estados.Add(e);
			}
			return estados;
		}
		public List<CedEntidades.Estado> WF_Estado_qry(string IdFlow)
		{
            string a = "select WF_Estado.IdEstado as Id, WF_Estado.DescrEstado as Descr from WF_Estado, WF_EstadoXFlow where WF_Estado.IdEstado=WF_EstadoXFlow.IdEstado and WF_EstadoXFlow.IdFlow='" + IdFlow + "' and WF_Estado.Virtual<>1 order by DescrEstado ";
			DataView dv = (DataView)Ejecutar(a,
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
			List<CedEntidades.Estado> estados = new List<CedEntidades.Estado>();
			for (int i = 0; i < dv.Table.Rows.Count; i++)
			{
				CedEntidades.Estado e = new CedEntidades.Estado();
				e.IdEstado = Convert.ToString(dv.Table.Rows[i]["Id"]);
				e.DescrEstado = Convert.ToString(dv.Table.Rows[i]["Descr"]);
				e.VirtuaL = false;
				estados.Add(e);
			}
			return estados;

		}
		public void WF_Evento_get(CedEntidades.Evento Evento)
		{
            DataView dv = (DataView)Ejecutar("SELECT IdEvento  as Id, DescrEvento as Descr, TextoAccion, IdEstadoDsd, IdEstadoHst, Automatico, CXO, XLote FROM WF_Evento where IdFlow = '" + Evento.Flow.IdFlow + "' AND IdEvento =  '" + Evento.Id + "'",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
			Evento.Descr = Convert.ToString(dv.Table.Rows[0]["Id"]);
			Evento.TextoAccion = Convert.ToString(dv.Table.Rows[0]["TextoAccion"]);
			Evento.IdEstadoDsd.IdEstado = Convert.ToString(dv.Table.Rows[0]["IdEstadoDsd"]);
			Evento.IdEstadoHst.IdEstado = Convert.ToString(dv.Table.Rows[0]["IdEstadoHst"]);
			Evento.Automatico = Convert.ToBoolean(dv.Table.Rows[0]["Automatico"]);
			Evento.CXO = Convert.ToBoolean(dv.Table.Rows[0]["CXO"]);
			Evento.XLote = Convert.ToBoolean(dv.Table.Rows[0]["XLote"]);
		}

        public void WF_Estado_get(CedEntidades.Estado Estado)
        {
            DataView dv = (DataView)Ejecutar("SELECT DescrEstado, Virtual FROM WF_Estado where IdEstado =  '" + Estado.IdEstado + "' ",
                TipoRetorno.DV,
                Transaccion.NoAcepta,
                sesion.CnnStr);
            Estado.DescrEstado = Convert.ToString(dv.Table.Rows[0]["DescrEstado"]);
            Estado.VirtuaL = Convert.ToBoolean(dv.Table.Rows[0]["Virtual"]);
        }

		public DataView WF_OpsEnTramite_lst()
		{
			return (DataView)Ejecutar("SELECT IdOp, IdFlow, IdCircuito, IdNivSeg, IdEstado, DescrOp, UltActualiz FROM WF_Op",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
		}
		public string WF_Op_insHandler(string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string DescrOp, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel)
		{
			return
				"insert WF_Op values ('" + IdFlow + "', '" + IdCircuito + "', " + IdNivSeg + ", '" + IdEstado + "', '" + DescrOp + "', null) " +
				"declare @IdOp int " +
				"select @IdOp=@@Identity " +
				"insert WF_Log values (@IdOp, '" + IdUsuario + "', '" + IdFlow + "', '" + IdCircuito + "', " + IdNivSeg + ", '" + IdEvento + "', getdate(), '" + Comentario + "', '" + IdEstado + "', '" + IdGrupo + "', " + System.Math.Abs(Convert.ToSByte(Supervisor)) + ", " + SupervisorNivel + ") ";
		}
		public int WF_Op_ins(string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string DescrOp, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel)
		{
			DataView dv = (DataView)Ejecutar(
				WF_Op_insHandler(IdFlow, IdCircuito, IdNivSeg, IdEstado, DescrOp, IdEvento, IdUsuario, Comentario, IdGrupo, Supervisor, SupervisorNivel),
				TipoRetorno.DV,
				Transaccion.Usa,
				sesion.CnnStr);
            return Convert.ToInt32(dv.Table.Rows[0]["IdOp"]);
		}
		public string WF_Op_updHandler(int IdOp, string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel, string UltActualiz)
		{
			return
				"update WF_Op set IdEstado='" + IdEstado + "', IdCircuito='" + IdCircuito + "', IdNivSeg=" + IdNivSeg + " where IdOp=" + IdOp + " and UltActualiz=" + UltActualiz + " " +
				"if @@rowcount=0 " +
				"   raiserror ('WorkFlow de la operacion inexistente o contenido modificado por otro usuario', 16, 1) " +
				"else " +
				"   begin " +
				"      insert WF_Log values (" + IdOp + ", '" + IdUsuario + "', '" + IdFlow + "', '" + IdCircuito + "', " + IdNivSeg + ", '" + IdEvento + "', getdate(), '" + Comentario + "', '" + IdEstado + "', '" + IdGrupo + "', " + System.Math.Abs(Convert.ToSByte(Supervisor)) + ", " + SupervisorNivel + ") ";
		}
		public void WF_Op_upd(int IdOp, string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel, string UltActualiz)
		{
			Ejecutar(
				"update WF_Op set IdEstado='" + IdEstado + "', IdCircuito='" + IdCircuito + "', IdNivSeg=" + IdNivSeg + " where IdOp=" + IdOp + " and UltActualiz=" + UltActualiz + " " +
				"insert WF_Log values (" + IdOp + ", '" + IdUsuario + "', '" + IdFlow + "', '" + IdCircuito + "', " + IdNivSeg + ", '" + IdEvento + "', getdate(), '" + Comentario + "', '" + IdEstado + "', '" + IdGrupo + "', " + System.Math.Abs(Convert.ToSByte(Supervisor)) + ", " + SupervisorNivel + ")",
				TipoRetorno.None,
				Transaccion.Usa,
				sesion.CnnStr);
		}
		public string WF_Log_insHandler(int IdOp, string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel)
		{
			return "insert WF_Log values (" + IdOp + ", '" + IdUsuario + "', '" + IdFlow + "', '" + IdCircuito + "', " + IdNivSeg + ", '" + IdEvento + "', getdate(), '" + Comentario + "', '" + IdEstado + "', '" + IdGrupo + "', " + System.Math.Abs(Convert.ToSByte(Supervisor)) + ", " + SupervisorNivel + ")";
		}
		public void WF_Log_ins(int IdOp, string IdFlow, string IdCircuito, int IdNivSeg, string IdEstado, string IdEvento, string IdUsuario, string Comentario, string IdGrupo, bool Supervisor, byte SupervisorNivel)
		{
			Ejecutar(
				WF_Log_insHandler(IdOp, IdFlow, IdCircuito, IdNivSeg, IdEstado, IdEvento, IdUsuario, Comentario, IdGrupo, Supervisor, SupervisorNivel),
				TipoRetorno.None,
				Transaccion.Usa,
				sesion.CnnStr);
		}
		public void WF_EjecutarHandler(string Handler)
		{
			string a = Handler + " ";
			a = a + "   end";
			Ejecutar(
				a,
				TipoRetorno.None,
				Transaccion.Usa,
				sesion.CnnStr);
		}
		public DataView WF_Parm_get(string IdParm)
		{
			return (DataView)Ejecutar(
				"select IdParm, ValorInt, ValorStr from WF_Parm where IdParm='" + IdParm + "'",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
		}
		public void WF_ParmValorInt_upd(string IdParm, int Valor)
		{
			string a = "update WF_Parm set ValorInt=" + Valor + " where IdParm='" + IdParm + "'";
			Ejecutar(
				a,
				TipoRetorno.None,
				Transaccion.Usa,
				sesion.CnnStr);
		}
		public void WF_ParmValorStr_upd(string IdParm, string Valor)
		{
			string a = "update WF_Parm set ValorStr='" + Valor + "' where IdParm='" + IdParm + "'";
			Ejecutar(
				a,
				TipoRetorno.None,
				Transaccion.Usa,
				sesion.CnnStr);
		}
        public List<CedEntidades.Grupo> WF_GruposXAcceso(string IdAcceso)
        {
            List<CedEntidades.Grupo> gruposXAcceso = new List<CedEntidades.Grupo>();
            DataView dv = WF_GruposXAcceso_qry(IdAcceso);
            for (int i = 0; i < dv.Table.Rows.Count; i++)
            {
                CedEntidades.Grupo grupo = new CedEntidades.Grupo();
                grupo.Id = dv.Table.Rows[i]["IdGrupo"].ToString();
                grupo.Descr = dv.Table.Rows[i]["Descr"].ToString();
                grupo.IdTGrupo = dv.Table.Rows[i]["IdTGrupo"].ToString();
                gruposXAcceso.Add(grupo);
            }
            return gruposXAcceso;
        }
        private DataView WF_GruposXAcceso_qry(string IdAcceso)
		{
			return (DataView)Ejecutar("select IdGrupo, Descr, IdTGrupo from WCTbGrupos where IdGrupo in (select IdGrupo from WF_PermisoGrupoXAcceso where IdAcceso='" + IdAcceso + "' and Permiso=1)",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
		}
		private DataView WF_Acceso_get(string IdGrupo, string IdAcceso)
		{
			return (DataView)Ejecutar("select IdGrupo, IdAcceso, Permiso from WF_PermisoGrupoXAcceso where IdGrupo='" + IdGrupo + "' and IdAcceso='" + IdAcceso + "'",
				TipoRetorno.DV,
				Transaccion.NoAcepta,
				sesion.CnnStr);
		}
		public string WF_GetAssemblyVersion_qry()
		{
			return ((DataView)Ejecutar("select AssemblyVersion from WF_Acceso where IdAcceso='" + sesion.IdAcceso + "'",
				TipoRetorno.DV, Transaccion.NoAcepta, sesion.CnnStr)).Table.Rows[0][0].ToString();
		}
		public bool CXO()
		{
			return Convert.ToInt32(WF_Parm_get("CXO").Table.Rows[0]["ValorInt"]) == 1;
		}
		#endregion

		public DateTime FechaDB
		{
			get
			{
				DataView dv = (DataView)Ejecutar("select getdate()", TipoRetorno.DV, Transaccion.NoAcepta, sesion.CnnStr);
				return (DateTime)dv.Table.Rows[0][0];
			}
		}
		public static string ByteArray2TimeStamp(byte[] ts)
		{
			string a = "0x";
			for(int i = 0; i < ts.Length; i++)
			{
				if(ts[i].ToString("X").Length == 1)
				{
					a += "0" + ts[i].ToString("X");
				}
				else
				{
					a += ts[i].ToString("X");
				}
			}
			return a;
		}
		public static byte[] TimeStamp2ByteArray(string value)
		{
			byte[] b = new byte[8];
			for(int i = 0; i < 8; i++)
			{
				string a = value.Substring(i * 2 + 2, 2);
				b[i] = Convert.ToByte(a, 16);
			}
			return b;
		}
		public DataTable CamposHabilitados_qry(string Tabla, string ListaCamposHabilitados)
		{
			string a;
			if(ListaCamposHabilitados.Trim() != String.Empty)
			{
				a = "select " + ListaCamposHabilitados + " from " + Tabla + " where 0=1";
			}
			else
			{
				a = "select null from " + Tabla + " where 0=1";
			}
			return (DataTable)Ejecutar(
				a,
				TipoRetorno.TB,
				Transaccion.NoAcepta,
				sesion.CnnStr);
		}
		public DataTable InfoCamposHabilitados_qry(string Tabla, DataTable CamposHabilitados)
		{
			string a = "and syscolumns.name in (";
			for(int i = 0; i < CamposHabilitados.Columns.Count; i++)
			{
				a += "'" + CamposHabilitados.Columns[i].ColumnName + "', ";
			}
			a = "select syscolumns.name Propiedad,systypes.name Tipo,syscolumns.length Long,syscolumns.xprec-syscolumns.xscale Enteros, syscolumns.xscale Decimales, isnull(sysproperties.value, syscolumns.name) Descripcion from syscolumns, systypes, sysproperties where syscolumns.id=(select id from dbo.sysobjects where name='" + Tabla + "') and systypes.xtype=syscolumns.xtype and syscolumns.id*=sysproperties.id and syscolumns.colid*=sysproperties.smallid " +
				a.Substring(0, a.Length - 2) + ")";
			return (DataTable)Ejecutar(
				a,
				TipoRetorno.TB,
				Transaccion.NoAcepta,
				sesion.CnnStr);
		}
		public DataTable InfoCampos_qry(string NombreTabla)
		{
			string a = "select syscolumns.name Propiedad,systypes.name Tipo,syscolumns.length Long,syscolumns.xprec-syscolumns.xscale Enteros, syscolumns.xscale Decimales, isnull(sysproperties.value, syscolumns.name) Descripcion from syscolumns, systypes, sysproperties where syscolumns.id=(select id from dbo.sysobjects where name='" + NombreTabla + "') and systypes.xtype=syscolumns.xtype and syscolumns.id*=sysproperties.id and syscolumns.colid*=sysproperties.smallid";
			return (DataTable)Ejecutar(a, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
		}
		public void DepurarFila(string NombreTabla, string Id)
		{
			string a = "delete " + NombreTabla + " where Id" + NombreTabla + "='" + Id + "'";
			Ejecutar(
				a,
				TipoRetorno.None,
				Transaccion.NoAcepta,
				sesion.CnnStr);
		}
		public string SevidoryDB()
		{
			return SevidoryDB(sesion.CnnStr);
		}
		public string SevidoryDB(string CnnStrDB)
		{
			try
			{
				sqlConexion = new SqlConnection(CnnStrDB);
				return sqlConexion.DataSource + "." + sqlConexion.Database;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.db.Conexion(ex);
			}
		}
		public string ReemplazarApostrofos(string cadena)
		{
			string aux = cadena.Replace("'", "''");
			return aux;
		}
	}
}
