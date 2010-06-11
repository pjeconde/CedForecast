using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastWebDB
{
    public class Forecast: db
    {
        public Forecast(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }

        public List<CedForecastWebEntidades.Forecast> ListaProyeccionAnual(string Año)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select Forecast.IdTipoPlanilla, Forecast.IdCuenta, Forecast.IdCliente, Forecast.IdArticulo, Forecast.IdPeriodo, Forecast.Cantidad ");
            a.Append("from Forecast ");
            a.Append("where Forecast.IdTipoPlanilla='Proyectado' ");
            a.Append("and Forecast.IdPeriodo >= '" + Año + "01' ");
            a.Append("and Forecast.IdPeriodo <= '" + Año + "99' ");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.Forecast> lista = new List<CedForecastWebEntidades.Forecast>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.Forecast elemento = new CedForecastWebEntidades.Forecast();
                    Copiar(dt.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        public List<CedForecastWebEntidades.Forecast> ListaRollingForecast(string Periodo)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select Forecast.IdTipoPlanilla, Forecast.IdCuenta, Forecast.IdCliente, Forecast.IdArticulo, Forecast.IdPeriodo, Forecast.Cantidad ");
            a.Append("from Forecast ");
            a.Append("where Forecast.IdTipoPlanilla='RollingForecast' and Forecast.IdPeriodo>='" + Periodo + "'");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.Forecast> lista = new List<CedForecastWebEntidades.Forecast>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.Forecast elemento = new CedForecastWebEntidades.Forecast();
                    Copiar(dt.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastWebEntidades.Forecast Hasta)
        {
            Hasta.IdTipoPlanilla = Convert.ToString(Desde["IdTipoPlanilla"]);
            Hasta.IdCuenta = Convert.ToString(Desde["IdCuenta"]);
            Hasta.Cliente = new CedForecastWebEntidades.Cliente();
            Hasta.Cliente.Id = Convert.ToString(Desde["IdCliente"]);
            Hasta.Articulo = new CedForecastWebEntidades.Articulo();
            Hasta.Articulo.Id = Convert.ToString(Desde["IdArticulo"]);
            Hasta.IdPeriodo = Convert.ToString(Desde["IdPeriodo"]);
            Hasta.Cantidad = Convert.ToDecimal(Desde["Cantidad"]);
        }
    }
}
