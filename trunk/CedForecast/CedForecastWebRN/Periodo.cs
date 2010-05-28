using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    public class Periodo
    {
        public Periodo()
        {
        }
        public static void Leer(CedForecastWebEntidades.Periodo Periodo, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Periodo periodo = new CedForecastWebDB.Periodo(Sesion);
            periodo.Leer(Periodo);
        }
        public static void Modificar(List<CedForecastWebEntidades.Periodo> Periodo, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Periodo periodo = new CedForecastWebDB.Periodo(Sesion);
            periodo.Modificar(Periodo);
        }
        public static void ValidarPeriodoYYYYMM(string Periodo)
        {
            try
            {
                DateTime d = Convert.ToDateTime("01/" + Periodo.Substring(4, 2) + "/" + Periodo.Substring(0, 4));
            }
            catch
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Periodo");
            }
        }
        public static void ValidarPeriodoYYYY(string Periodo)
        {
            try
            {
                DateTime d = Convert.ToDateTime("01/01/" + Periodo.Substring(0, 4));
            }
            catch
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Periodo");
            }
        }
    }
}
