using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using CaptchaDotNet2.Security.Cryptography;

namespace CedForecastWebRN
{
    public class PaginaDefault
    {
        public static List<CedForecastWebEntidades.PaginaDefault> Lista(CedForecastWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.PaginaDefault paginaDefault = new CedForecastWebDB.PaginaDefault(Sesion);
            return paginaDefault.Lista(Cuenta);
        }
        public static List<CedForecastWebEntidades.PaginaDefault> Lista(CedForecastWebEntidades.TipoCuenta TipoCuenta, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.PaginaDefault paginaDefault = new CedForecastWebDB.PaginaDefault(Sesion);
            return paginaDefault.Lista(TipoCuenta);
        }
        public static CedForecastWebEntidades.PaginaDefault Predeterminada(CedForecastWebEntidades.TipoCuenta TipoCuenta, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.PaginaDefault paginaDefault = new CedForecastWebDB.PaginaDefault(Sesion);
            return paginaDefault.Predeterminada(TipoCuenta);
        }
    }
}