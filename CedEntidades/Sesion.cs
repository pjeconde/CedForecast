using System;
using System.Collections.Generic;
using System.Text;

namespace CedEntidades
{
	[Serializable]
	public class Sesion
	{
		#region Atributos
		private string cnnStr;
        private string cnnStrAplicExterna;
		private CedEntidades.Usuario usuario;
		private string dominio;
		private bool cXO;
		private string idAcceso;
		private string version;
		private string versionParaControl;
        private DateTime loginFechaUltimoAcceso;
        private int loginDiasRestantesPassword;
		#endregion
		#region Constructor
		public Sesion()
		{
			usuario = new Usuario();
		}
		#endregion
		#region Propiedades
		public string CnnStr
		{
			get
			{
				return cnnStr;
			}
			set
			{
				cnnStr = value;
			}
		}

        public string CnnStrAplicExterna
        {
            get
            {
                return cnnStrAplicExterna;
            }
            set
            {
                cnnStrAplicExterna = value;
            }
        }

		public CedEntidades.Usuario Usuario
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

		public string Dominio
		{
			get
			{
				return dominio;
			}
			set
			{
				dominio = value;
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
		public string IdAcceso
		{
			get
			{
				return idAcceso;
			}
			set
			{
				idAcceso = value;
			}
		}

		public string Version
		{
			get
			{
				return version;
			}
			set
			{
				version = value;
			}
		}
		public string VersionParaControl
		{
			get
			{
				return versionParaControl;
			}
			set
			{
				versionParaControl = value;
			}
		}
        public DateTime LoginFechaUltimoAcceso
        {
            get
            {
                return loginFechaUltimoAcceso;
            }
            set
            {
                loginFechaUltimoAcceso = value;
            }
        }
        public int LoginDiasRestantesPassword
        {
            get
            {
                return loginDiasRestantesPassword;
            }
            set
            {
                loginDiasRestantesPassword = value;
            }
        }
		#endregion
	}
}
