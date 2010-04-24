using System;
using System.Collections.Generic;
using System.Text;

namespace CedEntidades
{
	[Serializable]
	public class Grupo
	{
		#region Atributos
		string id;
		string descr;
		string idTGrupo;
		#endregion

		#region Propiedades
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
		public string IdTGrupo
		{
			get
			{
				return idTGrupo;
			}
			set
			{
				idTGrupo = value;
			}
		}
		#endregion
	}
}