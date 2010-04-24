using System;
using System.Collections.Generic;
using System.Text;

namespace CedEntidades
{
	[Serializable]
	public class Flow
	{
		#region Atributos
		string idFlow;
		string descrFlow;
		#endregion

		#region Propiedades
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
		#endregion
	}
}
