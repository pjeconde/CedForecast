﻿using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;

namespace CedForecast.WS
{
    [WebService(Namespace = "http://cedeira.com.ar/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Sincronizacion : System.Web.Services.WebService
    {
        [WebMethod]
        public DateTime FechaUltimaSincronizacionArticulo()
        {
            return new DateTime(2000, 1, 1);
        }
        [WebMethod]
        public DateTime FechaUltimaSincronizacionCuenta()
        {
            return new DateTime(2000, 1, 1);
        }
        [WebMethod]
        public DateTime FechaUltimaSincronizacionCliente()
        {
            return new DateTime(2000, 1, 1);
        }
        [WebMethod]
        public DateTime FechaUltimaSincronizacionZona()
        {
            return new DateTime(2000, 1, 1);
        }
        [WebMethod]
        public void Articulo(List<CedForecastWebEntidades.Articulo> Lista)
        {
        }
        [WebMethod]
        public void Cuenta(List<CedForecastWebEntidades.Cuenta> Lista)
        {
        }
        [WebMethod]
        public void Cliente(List<CedForecastWebEntidades.Cliente> Lista)
        {
        }
        //[WebMethod]
        //public void Venta(List<CedForecastWebEntidades.Venta> Lista)
        //{
        //}
        [WebMethod]
        public void Zona(List<CedForecastWebEntidades.Zona> Lista)
        {
        }
    }
}