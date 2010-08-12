using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace CedForecastWebRN
{
    public class Fun
    {
        public static bool NoHayNadieLogueado(CedForecastWebEntidades.Sesion Sesion)
        {
            bool b = (Sesion.Cuenta.Id == null);
            return b;
        }
        public static bool NoEstaLogueadoUnAdministrador(CedForecastWebEntidades.Sesion Sesion)
        {
            bool b = (Sesion.Cuenta.TipoCuenta.Id != "Admin" || Sesion.Cuenta.EstadoCuenta.Id != "Vigente");
            return b;
        }
        public static bool NoEstaLogueadoUnOperForecast(CedForecastWebEntidades.Sesion Sesion)
        {
            bool b = (!((Sesion.Cuenta.TipoCuenta.Id == "OperForecast" && Sesion.Cuenta.EstadoCuenta.Id == "Vigente") || (Sesion.Cuenta.TipoCuenta.Id == "SupForecast" && Sesion.Cuenta.EstadoCuenta.Id == "Vigente")));
            return b;
        }
        //public static bool EstaLogueadoUnUsuarioPremium(CedForecastWebEntidades.Sesion Sesion)
        //{
        //    bool b = (Sesion.Cuenta.TipoCuenta.Id == "Prem" && Sesion.Cuenta.EstadoCuenta.Id == "Vigente") ||
        //             (Sesion.Cuenta.TipoCuenta.Id == "Admin" && Sesion.Cuenta.EstadoCuenta.Id == "Vigente");
        //    return b;
        //}
        //public static bool NoEstaLogueadoUnUsuarioPremium(CedForecastWebEntidades.Sesion Sesion)
        //{
        //    return !EstaLogueadoUnUsuarioPremium(Sesion);
        //}
        //public static bool NoActivar(CedForecastWebEntidades.Sesion Sesion)
        //{
        //    bool b = !Sesion.Cuenta.Activar;
        //    return b;
        //}
    }
}
