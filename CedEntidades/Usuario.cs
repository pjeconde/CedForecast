using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedEntidades
{
	[Serializable]
	public class Usuario
	{
		#region Atributos
		private string idUsuario = String.Empty;
		private string password = String.Empty;
		private string nombre = String.Empty;
		private bool activo = true;
		private string alias = String.Empty;
		private DateTime fecAlta = System.DateTime.Now;
		private System.DateTime fecBaja = new DateTime(2064, 12, 31);
		private string email = String.Empty;
		private List<GrupoXUsuario> perteneceA;
        private List<Grupo> noPerteneceA; 
		#endregion

        #region Constructor
        public Usuario()
        {
            perteneceA = new List<GrupoXUsuario>();
            noPerteneceA = new List<Grupo>();
        }
        #endregion

        #region Propiedades
		public string IdUsuario
		{
			get
			{
				return idUsuario.ToUpper();
			}
			set
			{
				idUsuario = value;
			}
		}

		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				password = value;
			}
		}

		public string Nombre
		{
			get
			{
				return nombre;
			}
			set
			{
				nombre = value;
			}
		}

		public bool Activo
		{
			get
			{
				return activo;
			}
			set
			{
				activo = value;
			}
		}

		public string Alias
		{
			get
			{
				return alias;
			}
			set
			{
				alias = value;
			}
		}

		public DateTime FecAlta
		{
			get
			{
				return fecAlta;
			}
			set
			{
				fecAlta = value;
			}
		}

		public System.DateTime FecBaja
		{
			get
			{
				return fecBaja;
			}
			set
			{
				fecBaja = value;
			}
		}

		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
			}
		}

        public List<GrupoXUsuario> PerteneceA
        {
            get
            {
                return perteneceA;
            }
            set
            {
                perteneceA = value;
            }
        }

        public List<Grupo> NoPerteneceA
        {
            get
            {
                return noPerteneceA;
            }
            set
            {
                noPerteneceA = value;
            }
        }
		#endregion
	}
}
