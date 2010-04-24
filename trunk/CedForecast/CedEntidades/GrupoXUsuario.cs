using System;
using System.Collections.Generic;
using System.Text;

namespace CedEntidades
{
    [Serializable]
    public class GrupoXUsuario : Grupo
    {
		#region Atributos
		bool supervisor;
		byte supervisorNivel;
        string descrGrupoSPyNV;
		#endregion

		#region Propiedades
        public bool Supervisor
		{
			get
			{
                return supervisor;
			}
			set
			{
                supervisor = value;
			}
		}
        public byte SupervisorNivel
		{
			get
			{
                return supervisorNivel;
			}
			set
			{
                supervisorNivel = value;
			}
		}
        public string DescrGrupoSPyNV
		{
			get
			{
                return descrGrupoSPyNV;
			}
			set
			{
                descrGrupoSPyNV = value;
			}
		}
		#endregion
    }
}
