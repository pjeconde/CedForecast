using System;
using System.Data;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Cedeira.SV
{
    public static class Sesion
    {
        /// <summary>
        /// Constructor para acceso al front-end de la aplicacion
        /// </summary>
        public static void Crear(string IdUsuario, string Password, string Dominio, string CnnStr, string CnnStrAplicExterna, string IdAcceso, string Version, string VersionParaControl, CedEntidades.Sesion Sesion)
        {
            Sesion.CnnStrAplicExterna = CnnStrAplicExterna;
            Crear(IdUsuario, Password, Dominio, CnnStr, IdAcceso, Version, VersionParaControl, Sesion);
        }
        public static void Crear(string IdUsuario, string Password, string Dominio, string CnnStr, string IdAcceso, string Version, string VersionParaControl, CedEntidades.Sesion Sesion)
		{
			Sesion.IdAcceso = IdAcceso;
			// Leo el CnnStr de la base de datos
			Sesion.CnnStr = CnnStr;
			Sesion.Version = Version;
			Sesion.VersionParaControl = VersionParaControl;
			// Chequeo de version del assembly
			VerificarAssemblyVersion(Sesion);
			Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
			if (db.WF_Acceso_lst().FindAll(delegate(CedEntidades.Acceso e)
			{
				return e.IdAcceso == IdAcceso;
			}).Count == 0)
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.Sesion.AplicInvalida();
			}
			try
			{
				// Verifico que el usuario tenga acceso a la base de datos 
				db.TesteoConexion(Sesion.CnnStr);
				// Obtengo Parametros
				Sesion.CXO = db.CXO();
				// Obtengo info del usuario
				CedEntidades.Usuario u = new CedEntidades.Usuario();
				u.IdUsuario = IdUsuario;
				Cedeira.SV.Usuario.Leer(u, Sesion);
				u.Password = Password;
				Sesion.Usuario = u;
				Sesion.Dominio = Dominio;
				// Chequeo si esta activo
				if (!Sesion.Usuario.Activo)
				{
					throw new Microsoft.ApplicationBlocks.ExceptionManagement.Sesion.Usuario.NoActivo();
				}
				// Chequeo si no esta dado de baja
				if (Sesion.Usuario.FecBaja.Date < DateTime.Now.Date)
				{
					throw new Microsoft.ApplicationBlocks.ExceptionManagement.Sesion.Usuario.DeBaja();
				}
				// Verifico si el usuario tiene acceso a la aplicacion
				List<CedEntidades.Grupo> gruposConAccPermitido = db.WF_GruposXAcceso(IdAcceso);
				bool PuedeEntrar = false;
				for (int i = 0; i < gruposConAccPermitido.Count; i++)
				{
					List<CedEntidades.GrupoXUsuario> perteneceAConAccPermitido = Sesion.Usuario.PerteneceA.FindAll(delegate(CedEntidades.GrupoXUsuario e)
					{
						return e.Id == gruposConAccPermitido[i].Id;
					});
					if (perteneceAConAccPermitido.Count > 0)
					{
						PuedeEntrar = true;
						break;
					}
				}
				if (!PuedeEntrar)
				{
					throw new Microsoft.ApplicationBlocks.ExceptionManagement.Sesion.Usuario.NoHabilitado();
				}
			}
			catch (Exception ex)
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.Sesion.Crear(ex);
			}
		}
        public static void VerificarAssemblyVersion(CedEntidades.Sesion Sesion)
        {
            Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
            string a = Convert.ToString(db.WF_GetAssemblyVersion_qry());
            if (a != Sesion.VersionParaControl)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Aplicacion.AssemblyVersionInvalida(Sesion.Version, a);
            }
            db = null;
        }
        public static DateTime FechaDB(CedEntidades.Sesion Sesion)
        {
            Cedeira.SV.db db = new Cedeira.SV.db(Sesion);
            return db.FechaDB;
        }
    }
}
