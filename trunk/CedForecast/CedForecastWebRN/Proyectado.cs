using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    public class Proyectado
    {
        public Proyectado()
        {
        }
        public static List<CedForecastWebEntidades.Proyectado> Lista(CedForecastWebEntidades.Proyectado Proyectado, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Proyectado proyectado = new CedForecastWebDB.Proyectado(Sesion);
            return proyectado.Lista(Proyectado);
        }
        public static void Guardar(List<CedForecastWebEntidades.Proyectado> Proyectado, string IdTipoPlanilla, string IdCuenta, string IdCliente, string IdFamiliaArticulo, string Periodo, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Proyectado proyectado = new CedForecastWebDB.Proyectado(Sesion);
            proyectado.Guardar(Proyectado, IdTipoPlanilla, IdCuenta, IdCliente, IdFamiliaArticulo, Periodo);
        }
        public static List<CedForecastWebEntidades.Proyectado> Lista(out int CantidadFilas, int IndicePagina, int TamañoPagina, string OrderBy, CedForecastWebEntidades.Proyectado Proyectado, string SessionID, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Proyectado proyectado = new CedForecastWebDB.Proyectado(Sesion);
            List<CedForecastWebEntidades.Proyectado> listaForecast = new List<CedForecastWebEntidades.Proyectado>();
            listaForecast = proyectado.Lista(Proyectado);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "IdPeriodo desc";
            }
            return proyectado.Lista(out CantidadFilas, IndicePagina, TamañoPagina, OrderBy, SessionID, listaForecast);
        }
    }
}
