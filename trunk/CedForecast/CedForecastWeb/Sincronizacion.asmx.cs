using System;
using System.Data;
using System.Web;
using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.ComponentModel;

namespace CedForecastWeb
{
    /// <summary>
    /// Descripción breve de Sincronizacion
    /// </summary>
    [WebService(Namespace = "http://cedeira.com.ar/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Sincronizacion : System.Web.Services.WebService
    {
        [WebMethod]
        public DateTime FechaUltimaSincronizacionArticulos()
        {
            CedForecastWebDB.Articulo datos = new CedForecastWebDB.Articulo(Sesion());
            return datos.FechaUltimaSincronizacion();
        }
        [WebMethod]
        public DateTime FechaUltimaSincronizacionCuentas()
        {
            CedForecastWebDB.Cuenta datos = new CedForecastWebDB.Cuenta(Sesion());
            return datos.FechaUltimaSincronizacion();
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
            CedForecastWebDB.Articulo datos = new CedForecastWebDB.Articulo(Sesion());
            datos.Actualizar(Elemento);
        }
        [WebMethod]
        public void EnviarCuenta(CedForecastWebEntidades.Cuenta Elemento)
        {
            CedForecastWebDB.Cuenta datos = new CedForecastWebDB.Cuenta(Sesion());
            datos.Actualizar(Elemento);
        }
        [WebMethod]
        public void EnviarCliente(CedForecastWebEntidades.Cliente Elemento)
        {
            CedForecastWebDB.Cliente datos = new CedForecastWebDB.Cliente(Sesion());
            datos.Actualizar(Elemento);
        }
        [WebMethod]
        public void IniciarEnvioVenta()
        {
            CedForecastWebDB.Venta datos = new CedForecastWebDB.Venta(Sesion());
            datos.IniciarEnvioVenta();
        }
        [WebMethod]
        public void EnviarVenta(CedForecastWebEntidades.Venta Elemento)
        {
            CedForecastWebDB.Venta datos = new CedForecastWebDB.Venta(Sesion());
            datos.AgregarEnAux(Elemento);
        }
        [WebMethod]
        public void TerminarEnvioVenta()
        {
            CedForecastWebDB.Venta datos = new CedForecastWebDB.Venta(Sesion());
            datos.Confirmar();
        }
        [WebMethod]
        public void EnviarZona(CedForecastWebEntidades.Zona Elemento)
        {
            CedForecastWebDB.Zona datos = new CedForecastWebDB.Zona(Sesion());
            datos.Actualizar(Elemento);
        }
        [WebMethod]
        public List<CedForecastWebEntidades.Forecast> RecibirRollingForecast(string Periodo)
        {
            CedForecastWebDB.Forecast datos = new CedForecastWebDB.Forecast(Sesion());
            return datos.ListaRollingForecast(Periodo);
        }
        [WebMethod]
        public List<CedForecastWebEntidades.Forecast> RecibirProyeccionAnual(string Año)
        {
            CedForecastWebDB.Forecast datos = new CedForecastWebDB.Forecast(Sesion());
            return datos.ListaProyeccionAnual(Año);
        }
        private CedEntidades.Sesion Sesion()
        {
            CedEntidades.Sesion sesion = new CedEntidades.Sesion();
            sesion.CnnStr = System.Configuration.ConfigurationManager.AppSettings["CnnStr"].ToString();
            return sesion;
        }
    }
}
