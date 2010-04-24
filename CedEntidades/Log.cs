using System;
using System.Collections.Generic;
using System.Text;

namespace CedEntidades
{
	[Serializable]
	public class Log
	{
		#region Atributos
		int idLog;
		DateTime fecha;
		Evento evento=new Evento();
		string estado;
		string responsable;
		string comentario;
		int idNivSeg;
		bool supervisor;
		Usuario usuario=new Usuario();
		byte supervisorNivel;
		Flow flow=new Flow();
		Circuito circuito=new Circuito();
		Grupo grupo=new Grupo();

		public DateTime Fecha
		{
			get
			{
				return fecha;
			}
			set
			{
				fecha = value;
			}
		}
        public string EventoDescr
        {
            get
            {
                return evento.Descr;
            }
        }
		public Evento Evento
		{
			get
			{
				return evento;
			}
			set
			{
				evento = value;
			}
		}

		public string Estado
		{
			get
			{
				return estado;
			}
			set
			{
				estado = value;
			}
		}

		public string Responsable
		{
			get
			{
				return responsable;
			}
			set
			{
				responsable = value;
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

		public int IdLog
		{
			get
			{
				return idLog;
			}
			set
			{
				idLog = value;
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

		public bool Supervisor
		{
			get
			{
				return supervisor;
			}
			set
			{
				supervisor = value;
			}
		}

        public string UsuarioNombre
        {
            get
            {
                return usuario.Nombre;
            }
        }
		public Usuario Usuario
		{
			get
			{
				return usuario;
			}
			set
			{
				usuario = value;
			}
		}

		public byte SupervisorNivel
		{
			get
			{
				return supervisorNivel;
			}
			set
			{
				supervisorNivel = value;
			}
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

		public Circuito Circuito
		{
			get
			{
				return circuito;
			}
			set
			{
				circuito = value;
			}
		}

		public Grupo Grupo
		{
			get
			{
				return grupo;
			}
			set
			{
				grupo = value;
			}
		} 
		#endregion
	}
}
