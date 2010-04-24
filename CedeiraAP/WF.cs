using System;
using Microsoft.ApplicationBlocks.ExceptionManagement;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Cedeira.SV
{
	public class WF
	{
		public static CedEntidades.WF Nueva(string IdFlow, string IdCircuito, int IdNivSeg, string DescrOp, CedEntidades.Sesion Sesion)
		{
			CedEntidades.WF wf = new CedEntidades.WF();
			wf.Sesion = Sesion;
			Cedeira.SV.db db = new Cedeira.SV.db(wf.Sesion);
			CedEntidades.Flow flow = db.WF_Flow_get(IdFlow);
			if (flow.IdFlow == IdFlow)
			{
				wf.IdFlow = flow.IdFlow;
				wf.DescrFlow = flow.DescrFlow;
			}
			else
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.WF.FlowInvalido();
			}
			CedEntidades.Circuito circuito = db.WF_Circuito_get(IdCircuito);
			if (circuito.IdCircuito == IdCircuito)
			{
				wf.IdCircuito = circuito.IdCircuito;
				wf.IdCircuitoOrig = circuito.IdCircuito;
				wf.DescrCircuito = circuito.DescrCircuito;
			}
			else
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.WF.CircuitoInvalido();
			}
			CedEntidades.NivSeg nivSeg = db.WF_NivSeg_get(IdNivSeg);
			if (nivSeg.IdNivSeg == IdNivSeg)
			{
				wf.IdNivSeg = nivSeg.IdNivSeg;
				wf.DescrNivSeg = nivSeg.DescrNivSeg;
			}
			else
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.WF.NivSegInvalido();
			}
			wf.DescrOp = DescrOp;
			wf.IdOp = 0;
			wf.IdEstado = String.Empty;
			wf.UltActualiz = String.Empty;
			wf.DescrEstado = String.Empty;
			wf.Log = LeerLog(wf);
			wf.EventosPosibles = LeerEventosPosiblesOpNueva(wf);
			return wf;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Wf"></param>
		public void Leer(ref CedEntidades.WF Wf)
		{
			Cedeira.SV.db db = new Cedeira.SV.db(Wf.Sesion);
			Wf = db.WF_Op_get(Wf.IdOp);
			if (Wf.IdFlow == string.Empty)
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.WF.OpInexistente();
			}
			else
			{
				Wf.Log = LeerLog(Wf);
				Wf.EventosPosibles = LeerEventosPosiblesOpExist(Wf);
				Wf.EventosXLotePosibles = LeerEventosXLotePosiblesOpExist(Wf);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="IdAcceso"></param>
		/// <param name="Sesion"></param>
		/// <returns></returns>
		public static List<CedEntidades.Grupo> GruposXAcceso(string IdAcceso, CedEntidades.Sesion Sesion)
		{
			Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
			return db.WF_GruposXAcceso(IdAcceso);
        }
        public static List<CedEntidades.Evento> EventosIniciales(CedEntidades.Sesion Sesion)
		{
			Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
			return  db.WF_EventosIniciales_qry();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Sesion"></param>
		/// <returns></returns>
		public static List<CedEntidades.Flow> IdFlowCombo(CedEntidades.Sesion Sesion)
		{
			Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
			return db.WF_Flow_lst();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Sesion"></param>
		/// <returns></returns>
		public static List<CedEntidades.Circuito> IdCircuitoCombo(CedEntidades.Sesion Sesion)
		{
			Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
			return db.WF_Circuito_lst();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Sesion"></param>
		/// <returns></returns>
		public static List<CedEntidades.NivSeg> IdNivSegCombo(CedEntidades.Sesion Sesion)
		{
			Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
			return db.WF_NivSeg_lst();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Sesion"></param>
		/// <returns></returns>
		public static List<CedEntidades.Estado> IdEstadoCombo(CedEntidades.Sesion Sesion)
		{
			Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
			return db.WF_Estado_qry();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Wf"></param>
		/// <returns></returns>
        public static List<CedEntidades.Estado> IdEstadoXFlowCombo(CedEntidades.WF Wf, CedEntidades.Sesion Sesion)
		{
			Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
			return db.WF_Estado_qry(Wf.IdFlow);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Sesion"></param>
		/// <returns></returns>
		public static List<CedEntidades.Acceso> IdAccesoCombo(CedEntidades.Sesion Sesion)
		{
			Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
			return db.WF_Acceso_lst();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Wf"></param>
		/// <returns></returns>
		private static List<CedEntidades.Log> LeerLog(CedEntidades.WF Wf)
		{
			
			Cedeira.SV.db db = new Cedeira.SV.db(Wf.Sesion);
			return  db.WF_LogXOp_qry(Wf.IdOp);
		}
		/// <summary>
		/// Informar las siguientes propiedades de WF:IdFlow,IdCircuito y IdNivSeg
		/// </summary>
		/// <returns></returns>
		private static List<CedEntidades.Evento> LeerEventosPosiblesOpNueva(CedEntidades.WF Wf)
		{
			Cedeira.SV.db db = new Cedeira.SV.db(Wf.Sesion);
            return db.WF_EventosIniciales_qry(Wf); ;
		}
		/// <summary>
		/// Informar las siguientes propiedades de WF:IdFlow, IdEstado, IdCircuito y IdNivSeg
		/// </summary>
		/// <returns></returns>
		private static List<CedEntidades.Evento> LeerEventosPosiblesOpExist(CedEntidades.WF Wf)
		{
			Cedeira.SV.db db = new Cedeira.SV.db(Wf.Sesion);
			return db.WF_EventosPosibles_qry(Wf); ;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="IdFlow"></param>
		/// <param name="IdEstado"></param>
		/// <param name="IdCircuito"></param>
		/// <param name="IdNivSeg"></param>
		/// <returns></returns>
		private static List<CedEntidades.Evento> LeerEventosXLotePosiblesOpExist(CedEntidades.WF Wf)
		{
			Cedeira.SV.db db = new Cedeira.SV.db(Wf.Sesion);
			return db.WF_EventosXLotePosibles_qry(Wf);
		}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="Wf"></param>
        //public static List<CedEntidades.EsqSegEvenPos> EsquemaSegEventosPosibles(CedEntidades.WF Wf) 
        //{  
        //    return LeerEsquemaSegEventosPosibles(Wf);  
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdFlow"></param>
        /// <param name="IdCircuito"></param>
        /// <param name="IdNivSeg"></param>
        /// <param name="IdEstadoActual"></param>
        /// <param name="dvEventosPosibles"></param>
        /// <param name="dvLog"></param>
        /// <returns></returns>
        private static List<CedEntidades.EsqSegEvenPos> LeerEsquemaSegEventosPosibles(CedEntidades.WF Wf)
        {
            Cedeira.SV.db db = new Cedeira.SV.db(Wf.Sesion);
            List<CedEntidades.EsqSegEvenPos> esquemaSegEventosPosibles = db.WF_EsquemaSegEventosPosibles_qry(Wf);
            // "Restar" intervenciones registradas en el Log
            if (Wf.Log.Count > 0)
            {
                // Ubico el evento que seteo el estado actual
                int j = -1;	// primera intervencion posterior al seteo del estado actual
                for (int i = Wf.Log.Count - 1; i >= 0; i--)
                {
                    if (Wf.Log[i].Estado != Wf.IdEstado)
                    {
                        break;
                    }
                    else
                    {
                        j = i;
                    }
                }
                if (j != -1)
                {
                    // Hay intervenciones posteriores al seteo del estado actual
                    bool SeRestaronIntervenciones = false;
                    for (int i = j + 1; i < Wf.Log.Count; i++)
                    {
                        // Encontrar el EsquemaSeg al que corresponde la intervencion
                        List<CedEntidades.EsqSegEvenPos> subEsquemaSegEventosPosibles = esquemaSegEventosPosibles.FindAll((delegate(CedEntidades.EsqSegEvenPos e){return e.Evento.Id == Wf.Log[i].Evento.Id;}));
                        for (int h = 0; h < subEsquemaSegEventosPosibles.Count; h++)
                        {
                            if (Wf.Log[i].Grupo.Id == subEsquemaSegEventosPosibles[h].Grupo.Id)
                            {
                                bool CumpleDebeSerSP = false;
                                switch (subEsquemaSegEventosPosibles[h].DebeSerSP)
                                {
                                    case "S":
                                        if (Wf.Log[i].Supervisor)
                                        {
                                            CumpleDebeSerSP = true;
                                        }
                                        break;
                                    case "N":
                                        if (!Wf.Log[i].Supervisor)
                                        {
                                            CumpleDebeSerSP = true;
                                        }
                                        break;
                                    case "NA":
                                        CumpleDebeSerSP = true;
                                        break;
                                }
                                if (CumpleDebeSerSP)
                                {
                                    if (Wf.Log[i].SupervisorNivel >= subEsquemaSegEventosPosibles[h].SupervisorNivelDsd &&
                                        Wf.Log[i].SupervisorNivel <= subEsquemaSegEventosPosibles[h].SupervisorNivelHst)
                                    {
                                            // En eventos que no producen cambios de estado: CantInterv debe ser 0, 
                                            // en esos casos no se lleva control de intervenciones
                                            if (subEsquemaSegEventosPosibles[h].CantInterv != 0)
                                            {
                                                // Restar intervencion
                                                subEsquemaSegEventosPosibles[h].CantInterv =subEsquemaSegEventosPosibles[h].CantInterv - 1;
                                                SeRestaronIntervenciones = true;
                                                //Elimino registro
                                                if (subEsquemaSegEventosPosibles[h].CantInterv == 0)
                                                {
                                                    subEsquemaSegEventosPosibles.RemoveAt(h);
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    if (!SeRestaronIntervenciones)
                    {
                        esquemaSegEventosPosibles = db.WF_EsquemaSegEventosPosibles_qry(Wf);
                    }
                }
            }
            // Chequeo que a todos los eventos posibles les hayan quedado al menos
            // un EsquemaSeg, si no: lo elimino.
            return esquemaSegEventosPosibles;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdEvento"></param>
        /// <param name="drEvento"></param>
        /// <param name="drEsquemaSeg"></param>
        /// <param name="drEsquemaSegUsado"></param>
        /// <param name="drUsuarioGrupoUsado"></param>
        /// <returns></returns>

        private static string IntervencionPermitida(CedEntidades.WF Wf, CedEntidades.Evento Evento, ref List<CedEntidades.Evento> listEvento, ref List<CedEntidades.EsqSegEvenPos> listEsqSegEvenPos, ref CedEntidades.EsqSegEvenPos esqSegEvenPosUsado, ref List<CedEntidades.GrupoXUsuario> listGrupoXUsuario)
        {
            // Verifico que el evento este entre los eventos posibles
            if (listEvento.Count == 0)
            {
                return "EventoInvalido";
            }
            // Verifico que el evento tenga al menos un esquema de seguridad asociado
            else if (listEsqSegEvenPos.Count == 0)
            {
                return "EventoSinSeg";
            }
            else
            {
                // Recorro todos los esquemas de seguridad del evento para determinar 
                // en nombre del cual interviene el usuario
                bool EncontreGrupo = false;
                for (int i = 0; i < listEsqSegEvenPos.Count; i++)
                {
                    string id = listEsqSegEvenPos[i].Grupo.Id;
                    listGrupoXUsuario = Wf.Sesion.Usuario.PerteneceA.FindAll((delegate (CedEntidades.GrupoXUsuario e){return e.Id == id;}));
                    if (listGrupoXUsuario.Count != 0 && GrupoHabilitadoParaAcceso(listGrupoXUsuario[0].Id, Wf))
                    {
                        bool CumpleDebeSerSP = false;
                        switch (listEsqSegEvenPos[i].DebeSerSP)
                        {
                            case "S":
                                if (listGrupoXUsuario[0].Supervisor)
                                {
                                    CumpleDebeSerSP = true;
                                }
                                break;
                            case "N":
                                if (!listGrupoXUsuario[0].Supervisor)
                                {
                                    CumpleDebeSerSP = true;
                                }
                                break;
                            case "NA":
                                CumpleDebeSerSP = true;
                                break;
                        }
                        if (CumpleDebeSerSP)
                        {
                            if (listGrupoXUsuario[0].SupervisorNivel >= listEsqSegEvenPos[i].SupervisorNivelDsd &&
                                listGrupoXUsuario[0].SupervisorNivel <= listEsqSegEvenPos[i].SupervisorNivelHst)
                            {
                                esqSegEvenPosUsado = listEsqSegEvenPos[i];
                                EncontreGrupo = true;
                                break;
                            }
                        }
                    }
                }
                if (EncontreGrupo)
                {
                    // Verificacion CXO
                    if (Wf.Sesion.CXO && listEvento[0].CXO)
                    {
                        if (Wf.Log.Count > 0)
                        {
                            if (Wf.Log[Wf.Log.Count - 1].Usuario.IdUsuario == Wf.Sesion.Usuario.IdUsuario)
                            {
                                return "CXO";
                            }
                        }
                    }
                    return "SI";
                }
                else
                {
                    return "UsuarioNoCumpleSeg";
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdEvento"></param>
        /// <returns></returns>
        public static bool IntervencionPermitida(CedEntidades.Evento Evento, CedEntidades.WF Wf)
        {
            List<CedEntidades.EsqSegEvenPos> listEsqSegEvenPos = new List<CedEntidades.EsqSegEvenPos>();
            listEsqSegEvenPos = LeerEsquemaSegEventosPosibles(Wf);
            CedEntidades.EsqSegEvenPos esqSegEvenPos = new CedEntidades.EsqSegEvenPos();
            List<CedEntidades.GrupoXUsuario> listGrupoXUsuario = new List<CedEntidades.GrupoXUsuario>();
            List<CedEntidades.Evento> listEventosPosibles = Wf.EventosPosibles;
            return IntervencionPermitida(Wf, Evento, ref listEventosPosibles, ref listEsqSegEvenPos, ref esqSegEvenPos, ref listGrupoXUsuario) == "SI";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdEvento"></param>
        /// <param name="UltimaIntervencion"></param>
        /// <returns></returns>
        public static bool IntervencionPermitida(CedEntidades.WF Wf, CedEntidades.Evento Evento, out bool UltimaIntervencion)
        {
            List<CedEntidades.EsqSegEvenPos> listEsqSegEvenPos = new List<CedEntidades.EsqSegEvenPos>();
            listEsqSegEvenPos = LeerEsquemaSegEventosPosibles(Wf);
            CedEntidades.EsqSegEvenPos esqSegEvenPos = new CedEntidades.EsqSegEvenPos();
            List<CedEntidades.GrupoXUsuario> listGrupoXUsuario = new List<CedEntidades.GrupoXUsuario>();
            List<CedEntidades.Evento> listEventosPosibles = Wf.EventosPosibles;
            bool intervPermitida = (IntervencionPermitida(Wf, Evento, ref listEventosPosibles, ref listEsqSegEvenPos, ref esqSegEvenPos, ref listGrupoXUsuario) == "SI");
            UltimaIntervencion = false;
            if (intervPermitida && esqSegEvenPos.CantInterv == 1)
            {
                UltimaIntervencion = true;
            }
            return intervPermitida;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdGrupo"></param>
        /// <returns></returns>
        private static bool GrupoHabilitadoParaAcceso(string idGrupo, CedEntidades.WF Wf)
        {
            try
            {
                Cedeira.SV.db db = new Cedeira.SV.db(Wf.Sesion);
                List<CedEntidades.Grupo> listGrupos = db.WF_GruposXAcceso(Wf.Sesion.IdAcceso);
                listGrupos.Find(delegate(CedEntidades.Grupo e) { return e.Id == idGrupo; });
                return listGrupos.Count != 0;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Ejecutar evento indicando el EstadoHst: se puede usar solo en eventos con el EstadoHst indeterminado (null)
        /// </summary>
        /// <param name="Wf">Objeto de WF</param>
        /// <param name="Evento">Evento a ejecutar</param>
        /// <param name="EstadoHst">EstadoHst</param>
        /// <param name="DevolverHandler">Devuelve un handler ?</param>
        /// <returns></returns>
        public static string EjecutarEvento(CedEntidades.WF Wf, CedEntidades.Evento Evento, CedEntidades.Estado EstadoHst, bool DevolverHandler)
        {
            if (!Evento.IdEstadoHst.IdEstado.Equals(String.Empty))
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.WF.EstadoHstInvalido();
            }
            Evento.IdEstadoHst = EstadoHst;
            return EjecutarEvento(Wf, Evento, DevolverHandler);
        }
        /// <summary>
        /// Ejecutar evento
        /// </summary>
        /// <param name="Wf">Objeto de WF</param>
        /// <param name="Evento">Evento a ejecutar</param>
        /// <param name="DevolverHandler">Devuelve un handler ?</param>
        /// <returns></returns>
        public static string EjecutarEvento(CedEntidades.WF Wf, CedEntidades.Evento Evento, bool DevolverHandler)
        {
            Cedeira.SV.db db = new Cedeira.SV.db(Wf.Sesion);
            List<CedEntidades.Evento> eventosPosibles = Wf.EventosPosibles.FindAll(delegate(CedEntidades.Evento e){return e.Id == Evento.Id;});
            List<CedEntidades.EsqSegEvenPos> esquemaSegEventosPosibles = LeerEsquemaSegEventosPosibles(Wf).FindAll(delegate(CedEntidades.EsqSegEvenPos e) { return e.Evento.Id == Evento.Id; });
            CedEntidades.EsqSegEvenPos esquemaSegEventosPosiblesUsado = new CedEntidades.EsqSegEvenPos();
            List<CedEntidades.GrupoXUsuario> gruposXUsuario = new List<CedEntidades.GrupoXUsuario>();
            switch (IntervencionPermitida(Wf, Evento, ref eventosPosibles, ref esquemaSegEventosPosibles, ref esquemaSegEventosPosiblesUsado, ref gruposXUsuario))
            {
                case "EventoInvalido":
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.WF.EventoInvalido();
                case "EventoSinSeg":
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.WF.EventoSinSeg();
                case "UsuarioNoCumpleSeg":
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.WF.UsuarioNoCumpleSeg();
                case "CXO":
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.WF.CXO();
                default:
                    break;
            }
            if (Evento.IdEstadoHst.IdEstado.Equals(string.Empty))
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.WF.EstadoHstNoDefinido();
            }
            if (Evento.IdEstadoDsd.IdEstado.Equals(string.Empty))
            {
                // Evento inicial (alta de operacion)
                if (!(esquemaSegEventosPosibles.Count == 1 && esquemaSegEventosPosiblesUsado.CantInterv == 1))
                {
                    // (los eventos iniciales no pueden tener varias intervenciones)
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.WF.EstadoHstInvalido();
                }
                else
                {
                    Wf.IdEstado = Evento.IdEstadoHst.IdEstado;
                    Wf.DescrEstado = Evento.IdEstadoHst.DescrEstado;
                    if (!DevolverHandler)
                    {
						Wf.IdOp = db.WF_Op_ins(Wf.IdFlow, Wf.IdCircuito, Wf.IdNivSeg, Wf.IdEstado, Wf.DescrOp, Evento.Id, Wf.Sesion.Usuario.IdUsuario, Evento.Comentario, gruposXUsuario[0].Id, gruposXUsuario[0].Supervisor, gruposXUsuario[0].SupervisorNivel);
                        return String.Empty;
                    }
                    else
                    {
						return db.WF_Op_insHandler(Wf.IdFlow, Wf.IdCircuito, Wf.IdNivSeg, Wf.IdEstado, Wf.DescrOp, Evento.Id, Wf.Sesion.Usuario.IdUsuario.ToString(), Evento.Comentario, gruposXUsuario[0].Id, gruposXUsuario[0].Supervisor, gruposXUsuario[0].SupervisorNivel);
                    }
                }
            }
            else
            {
                // Chequeo si esta es la ultima intervencion (que posibilita el cambio de estado)
                if (esquemaSegEventosPosibles.Count == 1 && esquemaSegEventosPosiblesUsado.CantInterv == 1)
                {
                    // Cambio el estado
                    switch (Evento.IdEstadoHst.IdEstado)
                    {
                        case ("<EstadoAnt>"):
                            // Estado virtual
                            for (int i = Wf.Log.Count - 1; i >= 0; i--)
                            {
                                if (Wf.Log[i].Estado != Wf.IdEstado)
                                {
                                    Wf.IdCircuito = Wf.Log[i].Circuito.IdCircuito;
                                    Wf.IdEstado = Wf.Log[i].Estado;
                                    //Revisar que la decripcion del estado sea el campo comentario de Wf.log[i]
                                    Wf.DescrEstado = Wf.Log[i].Comentario;
                                    if (!DevolverHandler)
                                    {
										db.WF_Op_upd(Wf.IdOp, Wf.IdFlow, Wf.IdCircuito, Wf.IdNivSeg, Wf.IdEstado, Evento.Id, Wf.Sesion.Usuario.IdUsuario, Evento.Comentario, gruposXUsuario[0].Id, gruposXUsuario[0].Supervisor, gruposXUsuario[0].SupervisorNivel, Wf.UltActualiz);
                                        return String.Empty;
                                    }
                                    else
                                    {
										return db.WF_Op_updHandler(Wf.IdOp, Wf.IdFlow, Wf.IdCircuito, Wf.IdNivSeg, Wf.IdEstado, Evento.Id, Wf.Sesion.Usuario.IdUsuario, Evento.Comentario, gruposXUsuario[0].Id, gruposXUsuario[0].Supervisor, gruposXUsuario[0].SupervisorNivel, Wf.UltActualiz);
                                    }
                                }
                            }
                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.WF.EstadoVirtualMalConfigurado();
                        default:
                            // Estado determinado
                            Wf.IdEstado = Evento.IdEstadoHst.IdEstado;
                            Wf.DescrEstado = Evento.IdEstadoHst.DescrEstado;
                            if (!DevolverHandler)
                            {
								db.WF_Op_upd(Wf.IdOp, Wf.IdFlow, Wf.IdCircuito, Wf.IdNivSeg, Wf.IdEstado, Evento.Id, Wf.Sesion.Usuario.IdUsuario, Evento.Comentario, gruposXUsuario[0].Id, gruposXUsuario[0].Supervisor, gruposXUsuario[0].SupervisorNivel, Wf.UltActualiz);
                                return String.Empty;
                            }
                            else
                            {
								return db.WF_Op_updHandler(Wf.IdOp, Wf.IdFlow, Wf.IdCircuito, Wf.IdNivSeg, Wf.IdEstado, Evento.Id, Wf.Sesion.Usuario.IdUsuario, Evento.Comentario, gruposXUsuario[0].Id, gruposXUsuario[0].Supervisor, gruposXUsuario[0].SupervisorNivel, Wf.UltActualiz);
                            }
                    }
                }
                else
                {
                    // Registro intervencion sin cambiar el estado, pero
                    // actualizo WF_Op por si cambio el Circuito o el NivSeg
                    if (!DevolverHandler)
                    {
						db.WF_Op_upd(Wf.IdOp, Wf.IdFlow, Wf.IdCircuito, Wf.IdNivSeg, Wf.IdEstado, Evento.Id, Wf.Sesion.Usuario.IdUsuario, Evento.Comentario, gruposXUsuario[0].Id, gruposXUsuario[0].Supervisor, gruposXUsuario[0].SupervisorNivel, Wf.UltActualiz);
                        return String.Empty;
                    }
                    else
                    {
						return db.WF_Op_updHandler(Wf.IdOp, Wf.IdFlow, Wf.IdCircuito, Wf.IdNivSeg, Wf.IdEstado, Evento.Id, Wf.Sesion.Usuario.IdUsuario, Evento.Comentario, gruposXUsuario[0].Id, gruposXUsuario[0].Supervisor, gruposXUsuario[0].SupervisorNivel, Wf.UltActualiz);
                    }
                }
            }
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Wf"></param>
		public static void EjecutarHandler(CedEntidades.WF Wf)
		{
			Cedeira.SV.db db = new Cedeira.SV.db(Wf.Sesion);
			db.WF_EjecutarHandler(Wf.Handler);
		}
        /// <summary>
        /// Obtener todos los datos relacionados al evento solicitado
        /// </summary>
        /// <param name="Evento">Evento cuyo detalle se solicita</param>
        /// <param name="Sesion">Sesion</param>
        public static void LeerEvento(CedEntidades.Evento Evento, CedEntidades.Sesion Sesion)
        {
            Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
            db.WF_Evento_get(Evento);
        }

        public static void LeerEstado(CedEntidades.Estado Estado, CedEntidades.Sesion Sesion)
        {
            Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
            db.WF_Estado_get(Estado);
        }
    }
}
