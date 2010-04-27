using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.ComponentModel;

namespace CedForecast.WS
{
    [WebService(Namespace = "http://cedeira.com.ar/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Sincronizacion : System.Web.Services.WebService
    {
        [WebMethod]
        public DateTime FechaUltimaSincronizacionArticulos()
        {
            return new DateTime(2000, 1, 1);
        }
        [WebMethod]
        public DateTime FechaUltimaSincronizacionCuentas()
        {
            return new DateTime(2000, 1, 1);
        }
        [WebMethod]
        public DateTime FechaUltimaSincronizacionClientes()
        {
            return new DateTime(2000, 1, 1);
        }
        [WebMethod]
        public DateTime FechaUltimaSincronizacionZonas()
        {
            return new DateTime(2000, 1, 1);
        }
        [WebMethod]
        public void EnviarArticulos(List<CedForecastWebEntidades.Articulo> Lista)
        {
        }
        [WebMethod]
        public void EnviarCuentas(List<CedForecastWebEntidades.Cuenta> Lista)
        {
        }
        [WebMethod]
        public void EnviarClientes(List<CedForecastWebEntidades.Cliente> Lista)
        {
        }
        [WebMethod]
        public void EnviarVentas(List<CedForecastWebEntidades.Venta> Lista)
        {
        }
        [WebMethod]
        public void EnviarZonas(List<CedForecastWebEntidades.Zona> Lista)
        {
        }
        [WebMethod]
        public List<CedForecastWebEntidades.Forecast> RecibirForecast(DateTime Fecha)
        {
            List<CedForecastWebEntidades.Forecast> lista = new List<CedForecastWebEntidades.Forecast>();
            return lista;
        }
    }
}