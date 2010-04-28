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
            a.Append("select Periodo.IdPeriodo, Periodo.FechaVtoConfirmacionCarga, Periodo.Habilitado ");
            a.Append("from Periodo");
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
            Hasta.IdPeriodo = Convert.ToDateTime(Desde["IdPeriodo"]);
            Hasta.FechaVtoConfirmacionCarga = Convert.ToDateTime(Desde["FechaVtoConfirmacionCarga"]);
            Hasta.Habilitado = Convert.ToBoolean(Desde["Habilitado"]);
        }
        public void Modificar(CedForecastWebEntidades.Periodo Periodo)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Periodo set IdPeriodo = '" + Periodo.IdPeriodo.ToString("yyyyMMdd") + "', FechaVtoConfirmacionCarga = '" + Periodo.FechaVtoConfirmacionCarga.ToString("yyyyMMdd") + "', Habilitado = " + Convert.ToInt32(Periodo.Habilitado));
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}
