using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedEntidades
{
	[Serializable]
	public class WF
	{
		#region Atributos
		private string descrFlow = String.Empty;
		private string idCircuito = String.Empty;
		private string idCircuitoOrig = String.Empty;
		private string descrCircuito = String.Empty;
		private int idNivSeg = 0;
		private string descrNivSeg = String.Empty;
		private string idEstado = String.Empty;
		private string descrEstado = String.Empty;
		private string descrOp = String.Empty;
		private string ultActualiz = String.Empty;
		private Sesion sesion = new Sesion();
		private int idOp;
		private string idFlow = String.Empty;
		private List<Evento> eventosXLotePosibles;
		private List<Evento> eventosPosibles;
        private List<EsqSegEvenPos> esquemaSegEventosPosibles;
		private List<Log> log;
		private string handler; 
		#endregion

		#region Propiedades
        public WF()
        {
            eventosXLotePosibles = new List<Evento>();
            eventosPosibles = new List<Evento>();
            esquemaSegEventosPosibles = new List<EsqSegEvenPos>();
            log = new List<Log>();
			sesion = new Sesion();
        }
		public string IdFlow
		{
			get
			{
				return idFlow;
			}
			set
			{
				idFlow = value;
			}
		}

		public string DescrFlow
		{
			get
			{
				return descrFlow;
			}
			set
			{
				descrFlow = value;
			}
		}

		public string IdCircuito
		{
			get
			{
				return idCircuito;
			}
			set
			{
				idCircuito = value;
			}
		}

		public string IdCircuitoOrig
		{
			get
			{
				return idCircuitoOrig;
			}
			set
			{
				idCircuitoOrig = value;
			}
		}

		public string DescrCircuito
		{
			get
			{
				return descrCircuito;
			}
			set
			{
				descrCircuito = value;
			}
		}

		public int IdNivSeg
		{
			get
			{
				return idNivSeg;
			}
			set
			{
				idNivSeg = value;
			}
		}

		public string DescrNivSeg
		{
			get
			{
				return descrNivSeg;
			}
			set
			{
				descrNivSeg = value;
			}
		}

		public string IdEstado
		{
			get
			{
				return idEstado;
			}
			set
			{
				idEstado = value;
			}
		}

		[System.ComponentModel.Description("Estado"), System.ComponentModel.Category("Incluida")]
		public string DescrEstado
		{
			get
			{
				return descrEstado;
			}
			set
			{
				descrEstado = value;
			}
		}

		public string DescrOp
		{
			get
			{
				return descrOp;
			}
			set
			{
				descrOp = value;
			}
		}

		public string UltActualiz
		{
			get
			{
				return ultActualiz;
			}
			set
			{
				ultActualiz = value;
			}
		}

		public CedEntidades.Sesion Sesion
		{
			get
			{
				return sesion;
			}
			set
			{
				sesion = value;
			}
		}

		public int IdOp
		{
			get
			{
				return idOp;
			}
			set
			{
				idOp = value;
			}
		}
        public List<Evento> EventosPosibles
        {
            get
            {
                return eventosPosibles;
            }
            set
            {
                eventosPosibles = value;
            }
        }
        public List<EsqSegEvenPos> EsquemaSegEventosPosibles
		{
			get
			{
                return esquemaSegEventosPosibles;
			}
			set
			{
                esquemaSegEventosPosibles = value;
			}
		}
        public List<Evento> EventosXLotePosibles
        {
            get
            {
                return eventosXLotePosibles;
            }
            set
            {
                eventosXLotePosibles = value;
            }
        }
		public List<Log> Log
		{
			get
			{
				return log;
			}
			set
			{
				log = value;
			}
		}

		public string Handler
		{
			get
			{
				return handler;
			}
			set
			{
				handler = value;
			}
		}
		
		#endregion
	}
}
