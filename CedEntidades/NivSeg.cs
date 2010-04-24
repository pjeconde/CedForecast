using System;
using System.Collections.Generic;
using System.Text;

namespace CedEntidades
{
	[Serializable]
	public class NivSeg
	{
		#region Atributos
		int idNivSeg;
		string descrNivSeg;
		#endregion

		#region Propiedades
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
		#endregion
	}
}
