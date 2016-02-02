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

        public List<CedForecastWebEntidades.Forecast> ListaProyeccionAnual(string Periodo)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select Forecast.IdTipoPlanilla, Forecast.IdCuenta, Forecast.IdCliente, Forecast.IdArticulo, Forecast.IdPeriodo, Forecast.Cantidad ");
            a.Append("from Forecast ");
            a.Append("where Forecast.IdTipoPlanilla='Proyectado' and Forecast.IdPeriodo >= '" + Periodo + "' ");
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

        // Entidad Forecast ( completando: 1 -  Bejerman.Clientes cliente / 2 - Bejerman.Articulos articulo / 3 - CedForecastEntidades.Articulo familiaArticulo
        public List<CedForecastWebEntidades.Forecast> Lista(CedForecastWebEntidades.Forecast Forecast)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select Forecast.IdTipoPlanilla, Forecast.IdCuenta, Forecast.IdCliente, Cliente.DescrCliente, Forecast.IdPeriodo, Forecast.IdArticulo, Articulo.DescrArticulo, Articulo.IdGrupoArticulo, GrupoArticulo.DescrGrupoArticulo, Division.IdDivision, Division.DescrDivision, FamiliaArticulo.IdFamiliaArticulo, FamiliaArticulo.DescrFamiliaArticulo, Forecast.Cantidad ");
            a.Append("from Forecast inner join Articulo on Forecast.IdArticulo=Articulo.IdArticulo ");
            a.Append("inner join Cliente on Forecast.IdCliente=Cliente.IdCliente ");
            a.Append("inner join GrupoArticulo on Articulo.IdGrupoArticulo=GrupoArticulo.IdGrupoArticulo ");
            a.Append("inner join Division on GrupoArticulo.IdDivision=Division.IdDivision ");
            a.Append("left outer join FamiliaArticuloXArticulo on Forecast.IdArticulo=FamiliaArticuloXArticulo.IdArticulo ");
            a.Append("left outer join FamiliaArticulo on FamiliaArticuloXArticulo.IdFamiliaArticulo=FamiliaArticulo.IdFamiliaArticulo ");
            a.Append("where Forecast.IdTipoPlanilla='" + Forecast.IdTipoPlanilla + "' ");
            if (Forecast.IdCliente != null && Forecast.IdCliente != "")
            {
                a.Append("and Forecast.IdCliente='" + Forecast.IdCliente + "' ");
            }
            if (Forecast.IdCuenta != null && Forecast.IdCuenta != "")
            {
                a.Append("and Forecast.IdCuenta='" + Forecast.IdCuenta + "' ");
            }
            if (Forecast.Articulo.FamiliaArticulo.Id != null && Forecast.Articulo.FamiliaArticulo.Id != "")
            {
                a.Append("and FamiliaArticulo.IdFamiliaArticulo='" + Forecast.Articulo.FamiliaArticulo.Id + "' ");
            }
            string periodo = "";
            periodo = UltimoMesForecast(Forecast.IdPeriodo);
            a.Append("and IdPeriodo >= '" + Forecast.IdPeriodo + "' ");
            a.Append("and IdPeriodo <= '" + periodo + "' ");
            a.Append("order by IdCuenta asc, IdCliente asc, IdArticulo asc, IdPeriodo asc ");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.Forecast> lista = new List<CedForecastWebEntidades.Forecast>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.Forecast elemento = new CedForecastWebEntidades.Forecast();
                    Copiar2(dt.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        public static string UltimoMesForecast(string Periodo)
        {
            DateTime fechaUltimoMesForecast = new DateTime(Convert.ToInt32(Periodo.Substring(0, 4)), Convert.ToInt32(Periodo.Substring(4, 2)), 1);
            fechaUltimoMesForecast = fechaUltimoMesForecast.AddMonths(11);
            return fechaUltimoMesForecast.ToString("yyyyMM");
        }
        private void Copiar2(DataRow Desde, CedForecastWebEntidades.Forecast Hasta)
        {
            Hasta.IdTipoPlanilla = Convert.ToString(Desde["IdTipoPlanilla"]);
            Hasta.IdCuenta = Convert.ToString(Desde["IdCuenta"]);
            Hasta.Cliente = new CedForecastWebEntidades.Cliente();
            Hasta.Cliente.Id = Convert.ToString(Desde["IdCliente"]);
            Hasta.Cliente.Descr = Convert.ToString(Desde["DescrCliente"]);
            Hasta.IdPeriodo = Convert.ToString(Desde["IdPeriodo"]);
            Hasta.Cantidad = Convert.ToDecimal(Desde["Cantidad"]);
            Hasta.Articulo.Id = Convert.ToString(Desde["IdArticulo"]);
            Hasta.Articulo.Descr = Convert.ToString(Desde["DescrArticulo"]);
            Hasta.Articulo.GrupoArticulo.IdGrupoArticulo = Convert.ToString(Desde["IdGrupoArticulo"]);
            Hasta.Articulo.GrupoArticulo.DescrGrupoArticulo = Convert.ToString(Desde["DescrGrupoArticulo"]);
            Hasta.Articulo.GrupoArticulo.Division.Id = Convert.ToString(Desde["idDivision"]);
            Hasta.Articulo.GrupoArticulo.Division.Descr = Convert.ToString(Desde["DescrDivision"]);
            Hasta.Articulo.FamiliaArticulo.Id = Convert.ToString(Desde["IdFamiliaArticulo"]);
            Hasta.Articulo.FamiliaArticulo.Descr = Convert.ToString(Desde["DescrFamiliaArticulo"]);
            Console.WriteLine(Hasta.IdCliente);
            Console.WriteLine(Hasta.DescrCliente);
            Console.WriteLine(Hasta.DescrFamiliaArticulo);
            Console.WriteLine(Hasta.IdArticulo);
            Console.WriteLine(Hasta.DescrArticulo);
        }
    }
}
