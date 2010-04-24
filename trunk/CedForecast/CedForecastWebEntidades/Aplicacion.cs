using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Aplicacion
    {
        private string nombre;
        private string codigo;
        private string propietario;
        private string version;
		private string versionParaControl;
        public Aplicacion()
        {
        }
        public string Nombre
        {
			set
			{
				nombre = value;
			}
            get
            {
                return nombre;
            }
        }
        public string Codigo
        {
			set
			{
				codigo = value;
			}
            get
            {
                return codigo;
            }
        }
        public string Propietario
        {
			set
			{
				propietario = value;
			}
            get
            {
                return propietario;
            }
        }
        public string Version
        {
			set
			{
				version = value;
			}
            get
            {
                return version;
            }
        }
		public string VersionParaControl
		{
			set
			{
				versionParaControl = value;
			}
			get
			{
				return versionParaControl;
			}
		}
    }
}