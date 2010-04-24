using System;
using System.Collections.Generic;
using System.Text;

namespace CedEntidades
{
	[Serializable]
	public class Circuito
	{
		#region Atributos
		string idCircuito;
		string descrCircuito;
		#endregion

		#region Propiedades
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
	#endregion
	}
}
