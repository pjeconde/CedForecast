using System;
using System.Collections.Generic;
using System.Text;

namespace CedEntidades
{
	[Serializable]
	public class Evento
	{
		#region Atributos
		protected Flow flow;
        protected string id;
        protected string descr;
        protected string textoAccion;
        protected Estado idEstadoDsd;
        protected Estado idEstadoHst;
        protected bool automatico;
        protected bool cXO;
        protected bool xLote;
        protected string comentario;
		#endregion

		#region Propiedades
        public Evento()
        {
            flow = new CedEntidades.Flow();
            idEstadoDsd = new CedEntidades.Estado();
            idEstadoHst = new CedEntidades.Estado();
        }
		public Flow Flow
		{
			get
			{
				return flow;
			}
			set
			{
				flow = value;
			}
		}

		public string Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		public string Descr
		{
			get
			{
				return descr;
			}
			set
			{
				descr = value;
			}
		}

		public string TextoAccion
		{
			get
			{
				return textoAccion;
			}
			set
			{
				textoAccion = value;
			}
		}

		public Estado IdEstadoDsd
		{
			get
			{
				return idEstadoDsd;
			}
			set
			{
				idEstadoDsd = value;
			}
		}

		public Estado IdEstadoHst
		{
			get
			{
				return idEstadoHst;
			}
			set
			{
				idEstadoHst = value;
			}
		}

		public bool Automatico
		{
			get
			{
				return automatico;
			}
			set
			{
				automatico = value;
			}
		}

		public bool CXO
		{
			get
			{
				return cXO;
			}
			set
			{
				cXO = value;
			}
		}

		public bool XLote
		{
			get
			{
				return xLote;
			}
			set
			{
				xLote = value;
			}
		}

		public string Comentario
		{
			get
			{
				return comentario;
			}
			set
			{
				comentario = value;
			}
		}

		#endregion
	}
}
