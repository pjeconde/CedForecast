using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastWebDB
{
    public class TipoCuenta: db
    {
        public TipoCuenta(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public List<CedForecastWebEntidades.TipoCuenta> Lista(bool ConTipoCuentaSinInformar)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select TipoCuenta.IdTipoCuenta, TipoCuenta.DescrTipoCuenta ");
            a.Append("from TipoCuenta");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.TipoCuenta> lista = new List<CedForecastWebEntidades.TipoCuenta>();
            if (dt.Rows.Count != 0)
            {
                if (ConTipoCuentaSinInformar)
                {
                    lista.Add(new CedForecastWebEntidades.TipoCuenta());
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.TipoCuenta TipoCuenta = new CedForecastWebEntidades.TipoCuenta();
                    Copiar(dt.Rows[i], TipoCuenta);
                    lista.Add(TipoCuenta);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastWebEntidades.TipoCuenta Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdTipoCuenta"]);
            Hasta.Descr = Convert.ToString(Desde["DescrTipoCuenta"]);
        }
    }
}
