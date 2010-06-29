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
            a.Append("select ConfirmacionCarga.IdTipoPlanilla, ConfirmacionCarga.IdPeriodo, ConfirmacionCarga.IdCuenta, Cuenta.Nombre, ConfirmacionCarga.FechaConfirmacionCarga, ConfirmacionCarga.IdEstadoConfirmacionCarga, ConfirmacionCarga.Comentario ");
            a.Append("from ConfirmacionCarga left outer join Cuenta on ConfirmacionCarga.IdCuenta=Cuenta.IdCuenta ");
            a.Append("where ConfirmacionCarga.IdTipoPlanilla = '" + ConfirmacionCarga.IdTipoPlanilla + "' and Cuenta.IdCuenta='" + ConfirmacionCarga.Cuenta.Id.ToString() + "' and IdPeriodo = '" + ConfirmacionCarga.IdPeriodo + "' ");
            a.Append("and FechaConfirmacionCarga in (select Max(FechaConfirmacionCarga) from ConfirmacionCarga where IdTipoPlanilla = '" + ConfirmacionCarga.IdTipoPlanilla + "' and IdCuenta='" + ConfirmacionCarga.Cuenta.Id.ToString() + "' and IdPeriodo = '" + ConfirmacionCarga.IdPeriodo + "')");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                Copiar(dt.Rows[0], ConfirmacionCarga);
            }
        }
        public List<CedForecastWebEntidades.ConfirmacionCarga> Lista(CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ConfirmacionCarga.IdTipoPlanilla, ConfirmacionCarga.IdPeriodo, ConfirmacionCarga.IdCuenta, Cuenta.Nombre, ConfirmacionCarga.FechaConfirmacionCarga, ConfirmacionCarga.IdEstadoConfirmacionCarga, ConfirmacionCarga.Comentario ");
            a.Append("from ConfirmacionCarga left outer join Cuenta on ConfirmacionCarga.IdCuenta=Cuenta.IdCuenta ");
            a.Append("where 1=1 ");
            if (ConfirmacionCarga.IdTipoPlanilla != null)
            {
                a.Append("and ConfirmacionCarga.IdTipoPlanilla='" + ConfirmacionCarga.IdTipoPlanilla + "'");
            }
            if (ConfirmacionCarga.Cuenta.Id.ToString() != "")
            {
                a.Append(" and ConfirmacionCarga.IdCuenta='" + ConfirmacionCarga.Cuenta.Id.ToString() + "'");
            }
            if (ConfirmacionCarga.IdPeriodo != null)
            {
                a.Append("and ConfirmacionCarga.IdPeriodo = '" + ConfirmacionCarga.IdPeriodo + "'");
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
            Hasta.IdTipoPlanilla = Convert.ToString(Desde["IdTipoPlanilla"]);
            Hasta.IdPeriodo = Convert.ToString(Desde["IdPeriodo"]);
            Hasta.Cuenta = new CedForecastWebEntidades.Cuenta();
            Hasta.Cuenta.Id = Convert.ToString(Desde["IdCuenta"]);
            Hasta.Cuenta.Nombre = Convert.ToString(Desde["Nombre"]);
            Hasta.FechaConfirmacionCarga = Convert.ToDateTime(Desde["FechaConfirmacionCarga"]);
            Hasta.Comentario = Convert.ToString(Desde["Comentario"]);
            Hasta.IdEstadoConfirmacionCarga = Convert.ToString(Desde["IdEstadoConfirmacionCarga"]);
        }
        public List<CedForecastWebEntidades.ConfirmacionCarga> Lista(int IndicePagina, int TamañoPagina, string OrderBy, CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("ConfirmacionCarga.IdTipoPlanilla, ConfirmacionCarga.IdPeriodo, ConfirmacionCarga.IdCuenta, Cuenta.Nombre, ConfirmacionCarga.FechaConfirmacionCarga, ConfirmacionCarga.IdEstadoConfirmacionCarga, ConfirmacionCarga.Comentario ");
            a.Append("from ConfirmacionCarga left outer join Cuenta on ConfirmacionCarga.IdCuenta=Cuenta.IdCuenta ");
            a.Append("where 1=1 ");
            if (ConfirmacionCarga.IdTipoPlanilla != null)
            {
                a.Append("and ConfirmacionCarga.IdTipoPlanilla='" + ConfirmacionCarga.IdTipoPlanilla + "'");
            }
            if (ConfirmacionCarga.Cuenta.Id != null)
            {
                a.Append("and ConfirmacionCarga.IdCuenta='" + ConfirmacionCarga.Cuenta.Id + "'");
            }
            if (ConfirmacionCarga.IdPeriodo != null && ConfirmacionCarga.IdPeriodo != "")
            {
                a.Append("and ConfirmacionCarga.IdPeriodo = '" + ConfirmacionCarga.IdPeriodo + "'");
            }
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * TamañoPagina), OrderBy, (IndicePagina * TamañoPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
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
        public int CantidadDeFilas()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select count(*) from ConfirmacionCarga ");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            int cantidadFilas = 0;
            if (dt.Rows.Count != 0)
            {
                cantidadFilas = Convert.ToInt32(dt.Rows[0][0]);
            }
            return cantidadFilas;
        }
        public void UltimoRegistro(CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Max(FechaConfirmacionCarga) from ConfirmacionCarga where IdTipoPlanilla = '" + ConfirmacionCarga.IdTipoPlanilla + "' and IdPeriodo = '" + ConfirmacionCarga.IdPeriodo + "' and IdCuenta = '" + ConfirmacionCarga.IdCuenta + "'");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0][0] != System.DBNull.Value)
                {
                    ConfirmacionCarga.FechaConfirmacionCarga = Convert.ToDateTime(dt.Rows[0][0]);
                }
            }
        }
        public void Ejecutar(CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga, string EstadoActual)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            if (EstadoActual != "")
            {
                a.Append("select IdEstadoConfirmacionCarga from ConfirmacionCarga where IdTipoPlanilla = '" + ConfirmacionCarga.IdTipoPlanilla + "' and IdPeriodo = '" + ConfirmacionCarga.IdPeriodo + "' and IdCuenta = '" + ConfirmacionCarga.IdCuenta + "' and FechaConfirmacionCarga in (select Max(FechaConfirmacionCarga) from ConfirmacionCarga where IdTipoPlanilla = '" + ConfirmacionCarga.IdTipoPlanilla + "' and IdPeriodo = '" + ConfirmacionCarga.IdPeriodo + "' and IdCuenta = '" + ConfirmacionCarga.IdCuenta + "') and IdEstadoConfirmacionCarga='" + EstadoActual + "'");
                a.Append("if @@rowcount=0 ");
                a.Append("   raiserror ('Problemas para acceder los datos o contenido modificado por otro usuario', 16, 1) ");
                a.Append("else ");
                a.Append("   begin ");
                a.Append("      Insert ConfirmacionCarga values (");
                a.Append("      '" + ConfirmacionCarga.IdTipoPlanilla + "', ");
                a.Append("      '" + ConfirmacionCarga.IdPeriodo + "', ");
                a.Append("      '" + ConfirmacionCarga.Cuenta.Id + "', ");
                a.Append("      getdate(), ");
                a.Append("      '" + ConfirmacionCarga.IdEstadoConfirmacionCarga + "', ");
                a.Append("      '" + ConfirmacionCarga.Comentario + "' ");
                a.Append("      ) ");
                a.Append("   end ");
            }
            else
            {
                a.Append("Insert ConfirmacionCarga values (");
                a.Append("'" + ConfirmacionCarga.IdTipoPlanilla + "', ");
                a.Append("'" + ConfirmacionCarga.IdPeriodo + "', ");
                a.Append("'" + ConfirmacionCarga.Cuenta.Id + "', ");
                a.Append("'" + ConfirmacionCarga.FechaConfirmacionCarga.ToString("yyyyMMdd hh:mm:ss") + "', ");
                a.Append("'" + ConfirmacionCarga.IdEstadoConfirmacionCarga + "', ");
                a.Append("'" + ConfirmacionCarga.Comentario + "'");
                a.Append(") ");
            }
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}
