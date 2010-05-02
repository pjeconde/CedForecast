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
            CedForecastWebDB.Cliente datos = new CedForecastWebDB.Cliente(Sesion());
            return datos.FechaUltimaSincronizacion();
        }
        [WebMethod]
        public DateTime FechaUltimaSincronizacionZonas()
        {
            CedForecastWebDB.Zona datos = new CedForecastWebDB.Zona(Sesion());
            return datos.FechaUltimaSincronizacion();
        }
        [WebMethod]
        public void EnviarArticulo(CedForecastWebEntidades.Articulo Elemento)
        {
        }
        [WebMethod]
        public void EnviarCuenta(CedForecastWebEntidades.Cuenta Elemento)
        {
        }
        [WebMethod]
        public void EnviarCliente(CedForecastWebEntidades.Cliente Elemento)
        {
            CedForecastWebDB.Cliente datos = new CedForecastWebDB.Cliente(Sesion());
            datos.Actualizar(Elemento);
        }
        [WebMethod]
        public void EnviarVentas(List<CedForecastWebEntidades.Venta> Lista)
        {
        }
        [WebMethod]
        public void EnviarZona(CedForecastWebEntidades.Zona Elemento)
        {
            CedForecastWebDB.Zona datos = new CedForecastWebDB.Zona(Sesion());
            datos.Actualizar(Elemento);
        }
        [WebMethod]
        public List<CedForecastWebEntidades.Forecast> RecibirForecast(DateTime Fecha)
        {
            List<CedForecastWebEntidades.Forecast> lista = new List<CedForecastWebEntidades.Forecast>();
            return lista;
        }
        private CedEntidades.Sesion Sesion()
        {
            CedEntidades.Sesion sesion = new CedEntidades.Sesion();
            sesion.CnnStr = System.Configuration.ConfigurationManager.AppSettings["CnnStr"].ToString();
            return sesion;
        }
    }
}