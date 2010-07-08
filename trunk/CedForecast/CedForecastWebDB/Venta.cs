using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastWebDB
{
    public class Venta : db
    {
        public Venta(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }
        public void IniciarEnvioVenta()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete VentaAux ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void AgregarEnAux(CedForecastWebEntidades.Venta Elemento)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("insert VentaAux values ( ");
            a.Append("'" + Elemento.IdPeriodo + "', ");
            a.Append("'" + Elemento.IdArticulo + "', ");
            a.Append("'" + Elemento.IdCliente + "', ");
            a.Append(Convert.ToString(Elemento.Cantidad, cedeiraCultura));
            a.Append(") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Confirmar()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete Venta where IdPeriodo in (select distinct IdPeriodo from VentaAux) ");
            a.Append("insert Venta select * from VentaAux ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public List<CedForecastWebEntidades.Venta> ConsultarTotales(string PeriodoDsd, string PeriodoHst)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("Select Rtrim(Ltrim(IdArticulo)) as IdArticulo, IdCliente, Sum(Cantidad) as Cantidad from Venta where IdPeriodo >= '" + PeriodoDsd + "' and IdPeriodo < '" + PeriodoHst + "' group by IdArticulo, IdCliente");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.Venta> lista = new List<CedForecastWebEntidades.Venta>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.Venta venta = new CedForecastWebEntidades.Venta();
                    CopiarVentaTotal(dt.Rows[i], venta);
                    lista.Add(venta);
                }
            }
            return lista;
        }
        private void CopiarVentaTotal(DataRow Desde, CedForecastWebEntidades.Venta Hasta)
        {
            Hasta.IdArticulo = Convert.ToString(Desde["IdArticulo"]);
            Hasta.IdCliente = Convert.ToString(Desde["IdCliente"]);
            Hasta.Cantidad = Convert.ToDecimal(Desde["Cantidad"]);
        }
    }
}