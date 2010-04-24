using System;
using System.Collections.Generic;
using System.Text;

namespace CedEntidades
{
	[Serializable]
    public class PersonaFisica
	{
		#region Atributos
		string nombre;
		string apellido;
		string nroHost;
        string nroDoc;
        string tipoDoc;
        string codTiPers;
        string codIdPersona;
		#endregion

		#region Propiedades
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
        public string Apellido
		{
			get
			{
                return apellido;
			}
			set
			{
                apellido = value;
			}
		}
        public string NroHost
		{
			get
			{
                return nroHost;
			}
			set
			{
                nroHost = value;
			}
		}
        public string NroDoc
        {
            get
            {
                return nroDoc;
            }
            set
            {
                nroDoc = value;
            }
        }
        public string TipoDoc
        {
            get
            {
                return tipoDoc;
            }
            set
            {
                tipoDoc = value;
            }
        }
        public string CodIdPersona
        {
            get
            {
                return codIdPersona;
            }
            set
            {
                codIdPersona = value;
            }
        }
        public string CodTiPers
        {
            get
            {
                return codTiPers;
            }
            set
            {
                codTiPers = value;
            }
        }
		#endregion
	}
}