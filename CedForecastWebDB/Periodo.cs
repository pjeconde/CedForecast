using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastWebDB
{
    public class Periodo : db
    {
        public Periodo(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public void Leer(CedForecastWebEntidades.Periodo Periodo)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Periodo.IdTipoPlanilla, Periodo.IdPeriodo, Periodo.FechaInhabilitacionCarga, Periodo.CargaHabilitada ");
            a.Append("from Periodo ");
            a.Append("where IdTipoPlanilla = '" + Periodo.IdTipoPlanilla + "'");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Periodo");
            }
            else
            {
                Copiar(dt.Rows[0], Periodo);
            }
        }
        private void Copiar(DataRow Desde, CedForecastWebEntidades.Periodo Hasta)
        {
            Hasta.IdTipoPlanilla = Convert.ToString(Desde["IdTipoPlanilla"]);
            Hasta.IdPeriodo = Convert.ToString(Desde["IdPeriodo"]);
            Hasta.FechaInhabilitacionCarga = Convert.ToDateTime(Desde["FechaInhabilitacionCarga"]);
            Hasta.CargaHabilitada = Convert.ToBoolean(Desde["CargaHabilitada"]);
        }
        public void Modificar(CedForecastWebEntidades.Periodo Periodo)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Periodo set IdPeriodo = '" + Periodo.IdPeriodo + "', FechaInhabilitacionCarga = '" + Periodo.FechaInhabilitacionCarga.ToString("yyyyMMdd") + "', CargaHabilitada = " + Convert.ToInt32(Periodo.CargaHabilitada) + " where IdTipoPlanilla = '" + Periodo.IdTipoPlanilla + "'");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}
