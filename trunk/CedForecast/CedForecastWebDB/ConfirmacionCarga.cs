using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastWebDB
{
    public class ConfirmacionCarga: db
    {
        public ConfirmacionCarga(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public void Leer(CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select ConfirmacionCarga.IdPeriodo, ConfirmacionCarga.IdCuenta, Cuenta.Nombre, ConfirmacionCarga.FechaConfirmacionCarga ");
            a.Append("from ConfirmacionCarga left outer join Cuenta on ConfirmacionCarga.IdCuenta=Cuenta.IdCuenta ");
            a.Append("where Cuenta.IdCuenta='" + ConfirmacionCarga.Cuenta.Id.ToString() + "' and IdPeriodo = '" + ConfirmacionCarga.IdPeriodo.ToString("yyyyMMdd") + "'");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("ConfirmacionCarga para Cuenta " + ConfirmacionCarga.Cuenta.Id.ToString() + " y Periodo " + ConfirmacionCarga.IdPeriodo.ToString("yyyyMMdd"));
            }
            else
            {
                Copiar(dt.Rows[0], ConfirmacionCarga);
            }
        }
        public List<CedForecastWebEntidades.ConfirmacionCarga> Lista(CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ConfirmacionCarga.IdPeriodo, ConfirmacionCarga.IdCuenta, Cuenta.Nombre, ConfirmacionCarga.FechaConfirmacionCarga ");
            a.Append("from ConfirmacionCarga left outer join Cuenta on ConfirmacionCarga.IdCuenta=Cuenta.IdCuenta ");
            a.Append("where 1=1 ");
            if (ConfirmacionCarga.Cuenta.Id.ToString() != "")
            {
                a.Append(" and ConfirmacionCarga.IdCuenta='" + ConfirmacionCarga.Cuenta.Id.ToString() + "'");
            }
            if (ConfirmacionCarga.IdPeriodo != null)
            {
                a.Append("and ConfirmacionCarga.IdPeriodo = '" + ConfirmacionCarga.IdPeriodo.ToString("yyyyMMdd") + "'");
            }
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.ConfirmacionCarga> lista = new List<CedForecastWebEntidades.ConfirmacionCarga>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.ConfirmacionCarga confirmacionCarga = new CedForecastWebEntidades.ConfirmacionCarga();
                    Copiar(dt.Rows[i], confirmacionCarga);
                    lista.Add(confirmacionCarga);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastWebEntidades.ConfirmacionCarga Hasta)
        {
            Hasta.IdPeriodo = Convert.ToDateTime(Desde["IdPeriodo"]);
            Hasta.Cuenta = new CedForecastWebEntidades.Cuenta();
            Hasta.Cuenta.Id = Convert.ToString(Desde["IdCuenta"]);
            Hasta.Cuenta.Nombre = Convert.ToString(Desde["Nombre"]);
            Hasta.FechaConfirmacionCarga = Convert.ToDateTime(Desde["FechaConfirmacionCarga"]);
       }
    }
}
