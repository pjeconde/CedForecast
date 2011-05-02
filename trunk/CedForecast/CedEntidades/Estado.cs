using System;
using System.Collections.Generic;
using System.Text;

namespace CedEntidades
{
	[Serializable]
	public class Estado
	{
		#region Atributos
		string idEstado;
		string descrEstado;
		bool virtuaL;
        bool final;
		#endregion

		#region Propiedades
		public string IdEstado
		{
			get
			{
				return idEstado;
			}
			set
			{
				idEstado = value;
			}
		}

		public string DescrEstado
		{
			get
			{
				return descrEstado;
			}
			set
			{
				descrEstado = value;
			}
		}

        public bool VirtuaL
        {
            get
            {
                return virtuaL;
            }
            set
            {
                virtuaL = value;
            }
        }
        public bool Final
        {
            get
            {
                return final;
            }
            set
            {
                final = value;
            }
        } 
		#endregion
	}
}
