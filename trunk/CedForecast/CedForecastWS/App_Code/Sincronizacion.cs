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
        public void EnviarArticulo(CedForecastWebEntidades.Articulo NuevoElemento)
        {
        }
        [WebMethod]
        public void EnviarCuenta(CedForecastWebEntidades.Cuenta NuevoElemento)
        {
        }
        [WebMethod]
        public void EnviarCliente(CedForecastWebEntidades.Cliente NuevoElemento)
        {
        }
        [WebMethod]
        public void EnviarVentas(List<CedForecastWebEntidades.Venta> Lista)
        {
        }
        [WebMethod]
        public void EnviarZona(CedForecastWebEntidades.Zona NuevoElemento)
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