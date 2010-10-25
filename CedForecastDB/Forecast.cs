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
        public DataSet LeerDatosParaResumenArgentinaXZonas(string IdPeriodo, string TipoReporte, string ListaArticulos, string ListaClientes)
        {
            System.Text.StringBuilder a = new StringBuilder();
            switch (TipoReporte)
            {
                case "Zona-Familia-Articulo":
                    a.Append("Select SBDAFERT.dbo.Clientes.clizon_Cod as Zona, IdFamiliaArticulo as Familia, Forecast.IdArticulo as Articulo, Forecast.IdPeriodo as Periodo, sum(Cantidad) as Cantidad into #ForecastAux ");
                    a.Append("from Forecast left outer join SBDAFERT.dbo.Clientes on Forecast.IdCliente = SBDAFERT.dbo.Clientes.cli_Cod collate SQL_Latin1_General_CP1_CS_AS ");
                    a.Append("left outer join FamiliaArticuloXArticulo on Forecast.IdArticulo=FamiliaArticuloXArticulo.IdArticulo ");
                    a.Append("where Forecast.IdTipoPlanilla='RollingForecast' and Forecast.IdArticulo in (" + ListaArticulos + ") and SBDAFERT.dbo.Clientes.cli_Cod in (" + ListaClientes + ") ");
                    a.Append("and IdPeriodo>='" + IdPeriodo + "01' and IdPeriodo<='" + IdPeriodo + "12' group by SBDAFERT.dbo.Clientes.clizon_Cod, IdFamiliaArticulo, Forecast.IdArticulo, Forecast.IdPeriodo ");
                    a.Append("select distinct Zona from #ForecastAux order by Zona ");
                    a.Append("select distinct Familia from #ForecastAux order by Familia ");
                    a.Append("select distinct Articulo from #ForecastAux order by Articulo ");
                    a.Append("select Zona, Familia, Articulo, Periodo, Cantidad from #ForecastAux order by Zona, Familia, Articulo, Periodo asc ");
                    a.Append("drop table #ForecastAux ");
                    break;
                default:
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.OpcionInvalida();
            }
            return (DataSet)Ejecutar(a.ToString(), TipoRetorno.DS, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public DataSet LeerDatosParaCrossTabArticulosClientes(string IdPeriodoDesde, string IdPeriodoHasta, string TipoReporte, string ListaArticulos, string ListaClientes, string ListaVendedores)
        {
            System.Text.StringBuilder a = new StringBuilder();
            switch (TipoReporte)
            {
                case "Artículos-Vendedores":
                case "Vendedores-Artículos":
                    a.Append("select IdArticulo as Articulo, IdCuenta as Vendedor, IdCliente as Cliente, sum(Cantidad) as Cantidad into #ForecastAux ");
                    a.Append("from Forecast ");
                    a.Append("where IdTipoPlanilla='RollingForecast' and IdArticulo in (" + ListaArticulos + ") and IdCliente in (" + ListaClientes + ") and IdCuenta in (" + ListaVendedores + ") ");
                    a.Append("and IdPeriodo>='" + IdPeriodoDesde + "'  and IdPeriodo<='" + IdPeriodoHasta + "' group by IdArticulo, IdCuenta, IdCliente ");
                    a.Append("select distinct Articulo from #ForecastAux order by Articulo ");
                    a.Append("select distinct Vendedor from #ForecastAux order by Vendedor ");
                    a.Append("select distinct Cliente from #ForecastAux order by Cliente ");
                    a.Append("select Articulo, Vendedor, Cliente, Cantidad from #ForecastAux order by Articulo, Vendedor ");
                    a.Append("drop table #ForecastAux ");
                    break;
                case "Sólo Artículos":
                    a.Append("select IdArticulo as Articulo, IdCliente as Cliente, sum(Cantidad) as Cantidad into #ForecastAux ");
                    a.Append("from Forecast ");
                    a.Append("where IdTipoPlanilla='RollingForecast' and IdArticulo in (" + ListaArticulos + ") and IdCliente in (" + ListaClientes + ") ");
                    a.Append("and IdPeriodo>='" + IdPeriodoDesde + "'  and IdPeriodo<='" + IdPeriodoHasta + "' group by IdArticulo, IdCliente ");
                    a.Append("select distinct Articulo from #ForecastAux order by Articulo ");
                    a.Append("select * from #ForecastAux where 1=2 ");
                    a.Append("select distinct Cliente from #ForecastAux order by Cliente ");
                    a.Append("select Articulo, Cliente, Cantidad from #ForecastAux order by Articulo ");
                    a.Append("drop table #ForecastAux ");
                    break;
                default:
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.OpcionInvalida();
            }
            return (DataSet)Ejecutar(a.ToString(), TipoRetorno.DS, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public List<CedForecastEntidades.Articulo> LeerArticulosSinFamilia()
        {
            List<CedForecastEntidades.Articulo> lista = new List<CedForecastEntidades.Articulo>();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select IdArticulo as Articulo from Forecast where IdArticulo not in (select IdArticulo from FamiliaArticuloXArticulo) and IdTipoPlanilla='RollingForecast' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastEntidades.Bejerman.Articulos> articulos = new CedForecastDB.Bejerman.Articulos(sesion).LeerLista(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CedForecastEntidades.Articulo elemento = new CedForecastEntidades.Articulo();
                elemento.Id = Convert.ToString(dt.Rows[i]["Articulo"]);
                CedForecastEntidades.Bejerman.Articulos articulo = articulos.Find(delegate(CedForecastEntidades.Bejerman.Articulos c) { return c.Art_CodGen == Convert.ToString(dt.Rows[i]["Articulo"]); });
                if (articulo == null)
                {
                    elemento.Descr = Convert.ToString(dt.Rows[i]["Articulo"]) + "-<<<Desconocido>>>";
                }
                else
                {
                    elemento.Descr = Convert.ToString(dt.Rows[i]["Articulo"]) + "-" + articulo.Art_DescGen;
                }
                lista.Add(elemento);
            }
            return lista;
        }
    }
}