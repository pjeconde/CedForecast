using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB
{
    public class Forecast: db
    {
        public Forecast(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }

        public void EliminarProyectadoAnual(string Año)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete Forecast where Forecast.IdTipoPlanilla='Proyectado' and Forecast.IdPeriodo='" + Año + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void EliminarRollingForecast(string Periodo)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete Forecast where Forecast.IdTipoPlanilla='RollingForecast' and Forecast.IdPeriodo>='" + Periodo + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Crear(CedForecastEntidades.Forecast Elemento)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("insert Forecast values ( ");
            a.Append("'" + Elemento.IdTipoPlanilla + "', ");
            a.Append("'" + Elemento.IdCuenta + "', ");
            a.Append("'" + Elemento.IdCliente + "', ");
            a.Append("'" + Elemento.IdArticulo + "', ");
            a.Append("'" + Elemento.IdPeriodo + "', ");
            a.Append(Convert.ToString(Elemento.Cantidad, cedeiraCultura) + " ");
            a.Append(") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public DataSet LeerDatosParaCrossTabArticulosClientes(string IdPeriodoDesde, string IdPeriodoHasta, string TipoReporte)
        {
            System.Text.StringBuilder a = new StringBuilder();
            switch (TipoReporte)
            {
                case "Artículos-Vendedores":
                case "Vendedores-Artículos":
                    a.Append("select IdArticulo as Articulo, IdCuenta as Vendedor, IdCliente as Cliente, sum(Cantidad) as Cantidad into #ForecastAux ");
                    a.Append("from Forecast where IdTipoPlanilla='RollingForecast' ");
                    a.Append("and IdPeriodo>='" + IdPeriodoDesde + "'  and IdPeriodo<='" + IdPeriodoHasta + "' group by IdArticulo, IdCuenta, IdCliente ");
                    a.Append("select distinct Articulo from #ForecastAux order by Articulo ");
                    a.Append("select distinct Vendedor from #ForecastAux order by Vendedor ");
                    a.Append("select distinct Cliente from #ForecastAux order by Cliente ");
                    a.Append("select Articulo, Vendedor, Cliente, Cantidad from #ForecastAux order by Articulo, Vendedor ");
                    a.Append("drop table #ForecastAux ");
                    break;
                case "Sólo Artículos":
                    a.Append("select IdArticulo as Articulo, IdCliente as Cliente, sum(Cantidad) as Cantidad into #ForecastAux ");
                    a.Append("from Forecast where IdTipoPlanilla='RollingForecast' ");
                    a.Append("and IdPeriodo>='" + IdPeriodoDesde + "'  and IdPeriodo<='" + IdPeriodoHasta + "' group by IdArticulo, IdCliente ");
                    a.Append("select distinct Articulo from #ForecastAux order by Articulo ");
                    a.Append("select * from #ForecastAux where 1=2 ");
                    a.Append("select distinct Cliente from #ForecastAux order by Cliente ");
                    a.Append("select Articulo, Cliente, Cantidad from #ForecastAux order by Articulo ");
                    a.Append("drop table #ForecastAux ");
                    break;
                default:
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.OpcionInvalida();
                    break;
            }
            return (DataSet)Ejecutar(a.ToString(), TipoRetorno.DS, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}