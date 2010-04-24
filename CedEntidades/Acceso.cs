using System;
using System.Collections.Generic;
using System.Text;

namespace CedEntidades
{
	[Serializable]
	public class Acceso
	{
		#region Atributos
		string idAcceso;
		string descrAcceso;
		#endregion

		#region Propiedades
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
		public string DescrAcceso
		{
			get
			{
				return descrAcceso;
			}
			set
			{
				descrAcceso = value;
			}
		}
		#endregion
	}
}
