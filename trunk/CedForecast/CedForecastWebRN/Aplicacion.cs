using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
	public static class Aplicacion
	{
		public static CedForecastWebEntidades.Aplicacion Crear()
		{
			CedForecastWebEntidades.Aplicacion aplic = new CedForecastWebEntidades.Aplicacion();
			aplic.Nombre = System.Configuration.ConfigurationManager.AppSettings["NombreAplic"].ToString(); ;
			aplic.Codigo = System.Configuration.ConfigurationManager.AppSettings["CodigoAplic"].ToString();
			aplic.Propietario = System.Configuration.ConfigurationManager.AppSettings["Propietario"].ToString(); ;
			aplic.Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
			aplic.VersionParaControl = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
			return aplic;
		}
	}
}
