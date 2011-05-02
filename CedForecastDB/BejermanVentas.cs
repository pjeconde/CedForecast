using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB.Bejerman
{
    public class Ventas : db
    {
        public Ventas(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public List<CedForecastEntidades.Bejerman.Ventas> LeerNovedades(string Periodo)
        {
            DateTime fechaDsd = new DateTime(Convert.ToInt32(Periodo.Substring(0, 4)), Convert.ToInt32(Periodo.Substring(4, 2)), 1);
            DateTime fechaHst = fechaDsd.AddMonths(1).AddDays(-1);
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("SELECT ltrim(rtrim(SegDetV.sdvart_CodGen)) as sdvart_CodGen, ltrim(rtrim(CabVenta.cve_CodCli)) as cve_CodCli, sum(SegDetV.sdv_CantUM1) as sdv_CantUM1 ");
            a.Append("FROM CabVenta, SegCabV, SegDetV ");
            a.Append("WHERE CabVenta.cveemp_CodigoSCV=SegCabV.scvemp_Codigo ");
            a.Append("and CabVenta.cvesuc_CodSCV=SegCabV.scvsuc_Cod ");
            a.Append("and CabVenta.cvescv_ID=SegCabV.scv_ID ");
            a.Append("and SegCabV.scvemp_Codigo =SegDetV.sdvemp_Codigo ");
            a.Append("and SegCabV.scvsuc_Cod =SegDetV.sdvsuc_Cod ");
            a.Append("and SegCabV.scv_ID =SegDetV.sdvscv_id ");
            a.Append("and (CabVenta.cve_FEmision between '" + fechaDsd.ToString("yyyyMMdd") + "' and '" + fechaHst.ToString("yyyyMMdd") + "') ");
            a.Append("and SegDetV.sdvart_CodGen is not NULL ");
            a.Append("and sdvart_CodGen!='50000004' ");
            a.Append("group by sdvart_CodGen, cve_CodCli ");
            a.Append("having sum(SegDetV.sdv_CantUM1)<>0 ");
            a.Append("order by sdvart_CodGen, cve_CodCli ");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            List<CedForecastEntidades.Bejerman.Ventas> lista = new List<CedForecastEntidades.Bejerman.Ventas>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastEntidades.Bejerman.Ventas elemento = new CedForecastEntidades.Bejerman.Ventas();
                    Copiar(dt.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastEntidades.Bejerman.Ventas Hasta)
        {
            Hasta.Sdvart_CodGen = Convert.ToString(Desde["sdvart_CodGen"]);
            Hasta.Cve_CodCli = Convert.ToString(Desde["cve_CodCli"]);
            Hasta.Sdv_CantUM1 = Convert.ToDecimal(Desde["sdv_CantUM1"]);
        }
        public List<CedForecastEntidades.Bejerman.Ventas> LeerParaRF(string Periodo, string TipoReporte)
        {
            List<CedForecastEntidades.Bejerman.Ventas> lista = new List<CedForecastEntidades.Bejerman.Ventas>();
            switch (TipoReporte)
            {
                case "FamArtCli":
                case "FamArt":
                    DateTime fechaDsd = new DateTime(Convert.ToInt32(Periodo.Substring(0, 4)), 1, 1);
                    DateTime fechaHst = new DateTime(Convert.ToInt32(Periodo.Substring(0, 4)), Convert.ToInt32(Periodo.Substring(4, 2)), 1);
                    DateTime fechaAux = fechaHst.AddMonths(-1);
                    if (fechaAux.Year == fechaHst.Year)
                    {
                        fechaHst = fechaAux.AddMonths(1).AddDays(-1);
                        DataTable dt = new DataTable();
                        System.Text.StringBuilder a = new StringBuilder();
                        switch (TipoReporte)
                        {
                            case "FamArtCli":
                                a.Append("SELECT ltrim(rtrim(SegDetV.sdvart_CodGen)) as sdvart_CodGen, ltrim(rtrim(CabVenta.cve_CodCli)) as cve_CodCli, sum(SegDetV.sdv_CantUM1) as sdv_CantUM1 ");
                                break;
                            case "FamArt":
                                a.Append("SELECT ltrim(rtrim(SegDetV.sdvart_CodGen)) as sdvart_CodGen, sum(SegDetV.sdv_CantUM1) as sdv_CantUM1 ");
                                break;
                        }
                        a.Append("FROM CabVenta, SegCabV, SegDetV ");
                        a.Append("WHERE CabVenta.cveemp_CodigoSCV=SegCabV.scvemp_Codigo ");
                        a.Append("and CabVenta.cvesuc_CodSCV=SegCabV.scvsuc_Cod ");
                        a.Append("and CabVenta.cvescv_ID=SegCabV.scv_ID ");
                        a.Append("and SegCabV.scvemp_Codigo =SegDetV.sdvemp_Codigo ");
                        a.Append("and SegCabV.scvsuc_Cod =SegDetV.sdvsuc_Cod ");
                        a.Append("and SegCabV.scv_ID =SegDetV.sdvscv_id ");
                        a.Append("and (CabVenta.cve_FEmision between '" + fechaDsd.ToString("yyyyMMdd") + "' and '" + fechaHst.ToString("yyyyMMdd") + "') ");
                        a.Append("and SegDetV.sdvart_CodGen is not NULL ");
                        a.Append("and sdvart_CodGen!='50000004' ");
                        switch (TipoReporte)
                        {
                            case "FamArtCli":
                                a.Append("group by sdvart_CodGen, cve_CodCli ");
                                break;
                            case "FamArt":
                                a.Append("group by sdvart_CodGen ");
                                break;
                        }
                        a.Append("having sum(SegDetV.sdv_CantUM1)<>0 ");
                        switch (TipoReporte)
                        {
                            case "FamArtCli":
                                a.Append("order by sdvart_CodGen, cve_CodCli ");
                                break;
                            case "FamArt":
                                a.Append("order by sdvart_CodGen ");
                                break;
                        }
                        dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
                        if (dt.Rows.Count != 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                CedForecastEntidades.Bejerman.Ventas elemento = new CedForecastEntidades.Bejerman.Ventas();
                                CopiarRF(dt.Rows[i], elemento, TipoReporte);
                                lista.Add(elemento);
                            }
                        }
                    }
                    break;
            }
            return lista;
        }
        private void CopiarRF(DataRow Desde, CedForecastEntidades.Bejerman.Ventas Hasta, string TipoReporte)
        {
            Hasta.Sdvart_CodGen = Convert.ToString(Desde["sdvart_CodGen"]);
            switch (TipoReporte)
            {
                case "FamArtCli":
                    Hasta.Cve_CodCli = Convert.ToString(Desde["cve_CodCli"]);
                    break;
            }
            Hasta.Sdv_CantUM1 = Convert.ToDecimal(Desde["sdv_CantUM1"]);
        }
        public List<CedForecastEntidades.Bejerman.Ventas> LeerParaResumenArgentinaXZonas(string TipoReporte, string PeriodoDesde, string PeriodoHasta, string ListaArticulos, string ListaClientes, string ListaVendedores)
        {
            DateTime fechaDsd = new DateTime(Convert.ToInt32(PeriodoDesde.Substring(0, 4)), Convert.ToInt32(PeriodoDesde.Substring(4, 2)), 1);
            DateTime fechaHst = new DateTime(Convert.ToInt32(PeriodoHasta.Substring(0, 4)), Convert.ToInt32(PeriodoHasta.Substring(4, 2)), 1);
            fechaHst = fechaHst.AddMonths(1).AddDays(-1);  
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            switch (TipoReporte)
            {
                case "Zona-Familia-Articulo":
                    a.Append("SELECT clizon_cod as Zona, cvemon_codigo, ltrim(rtrim(SegDetV.sdvart_CodGen)) as sdvart_CodGen, CabVenta.cve_FEmision, Convert(varchar(6), CabVenta.cve_FEmision, 112) as Periodo, sum(SegDetV.sdv_CantUM1) as sdv_CantUM1, Sum(SegDetV.sdv_ImpTot) as sdv_ImpTot ");
                    a.Append("FROM CabVenta, SegCabV, SegDetV, Clientes ");
                    a.Append("WHERE CabVenta.cveemp_CodigoSCV=SegCabV.scvemp_Codigo ");
                    a.Append("and CabVenta.cvesuc_CodSCV=SegCabV.scvsuc_Cod ");
                    a.Append("and CabVenta.cvescv_ID=SegCabV.scv_ID ");
                    a.Append("and SegCabV.scvemp_Codigo =SegDetV.sdvemp_Codigo ");
                    a.Append("and SegCabV.scvsuc_Cod =SegDetV.sdvsuc_Cod ");
                    a.Append("and SegCabV.scv_ID =SegDetV.sdvscv_id ");
                    a.Append("and CabVenta.cve_CodCli = Clientes.cli_Cod ");
                    a.Append("and (CabVenta.cve_FEmision between '" + fechaDsd.ToString("yyyyMMdd") + "' and '" + fechaHst.ToString("yyyyMMdd") + "') ");
                    a.Append("and (cve_NroCuota=1 or cve_NroCuota='') ");
                    a.Append("and SegDetV.sdvart_CodGen is not NULL ");
                    a.Append("and SegDetV.sdvart_CodGen!='50000004' ");
                    a.Append("and SegDetV.sdvart_CodGen in (" + ListaArticulos + ") and Clientes.cli_Cod in (" + ListaClientes + ") ");
                    a.Append("and CabVenta.cveven_Cod in (" + ListaVendedores + ") ");
                    a.Append("group by clizon_cod, sdvart_CodGen, cve_FEmision, cvemon_codigo ");
                    a.Append("having sum(SegDetV.sdv_CantUM1)<>0 ");
                    a.Append("order by clizon_cod, sdvart_CodGen, cve_FEmision, cvemon_Codigo ");
                    break;
                case "Vendedor-Familia-Articulo":
                    a.Append("SELECT cveven_Cod as Vendedor, cvemon_Codigo, ltrim(rtrim(SegDetV.sdvart_CodGen)) as sdvart_CodGen, CabVenta.cve_FEmision, Convert(varchar(6), CabVenta.cve_FEmision, 112) as Periodo, sum(SegDetV.sdv_CantUM1) as sdv_CantUM1, Sum(SegDetV.sdv_ImpTot) as sdv_ImpTot ");
                    a.Append("FROM CabVenta, SegCabV, SegDetV, Clientes ");
                    a.Append("WHERE CabVenta.cveemp_CodigoSCV=SegCabV.scvemp_Codigo ");
                    a.Append("and CabVenta.cvesuc_CodSCV=SegCabV.scvsuc_Cod ");
                    a.Append("and CabVenta.cvescv_ID=SegCabV.scv_ID ");
                    a.Append("and SegCabV.scvemp_Codigo =SegDetV.sdvemp_Codigo ");
                    a.Append("and SegCabV.scvsuc_Cod =SegDetV.sdvsuc_Cod ");
                    a.Append("and SegCabV.scv_ID =SegDetV.sdvscv_id ");
                    a.Append("and CabVenta.cve_CodCli = Clientes.cli_Cod ");
                    a.Append("and SegDetV.sdvart_CodGen in (" + ListaArticulos + ") and Clientes.cli_Cod in (" + ListaClientes + ") ");
                    a.Append("and CabVenta.cveven_Cod in (" + ListaVendedores + ") ");
                    a.Append("and (CabVenta.cve_FEmision between '" + fechaDsd.ToString("yyyyMMdd") + "' and '" + fechaHst.ToString("yyyyMMdd") + "') ");
                    a.Append("and (cve_NroCuota=1 or cve_NroCuota='') ");
                    a.Append("and SegDetV.sdvart_CodGen is not NULL ");
                    a.Append("and sdvart_CodGen!='50000004' ");
                    a.Append("group by cveven_Cod, sdvart_CodGen, cve_FEmision, cvemon_Codigo ");
                    a.Append("having sum(SegDetV.sdv_CantUM1)<>0 ");
                    a.Append("order by cveven_Cod, sdvart_CodGen, cve_FEmision, cvemon_Codigo ");
                    break;
            }
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            List<CedForecastEntidades.Bejerman.Ventas> lista = new List<CedForecastEntidades.Bejerman.Ventas>();
            if (dt.Rows.Count != 0)
            {
                List<CedForecastEntidades.Bejerman.Cotizacion> cotizaciones = new List<CedForecastEntidades.Bejerman.Cotizacion>();
                CedForecastDB.Bejerman.Cotizacion dbCotiz = new Cotizacion(sesion);
                cotizaciones = dbCotiz.LeerLista("DVT");

                CedForecastEntidades.Bejerman.Ventas elemento = new CedForecastEntidades.Bejerman.Ventas();
                string ClaveAnterior = "";
                switch (TipoReporte)
                {
                    case "Zona-Familia-Articulo":
                        ClaveAnterior = dt.Rows[0]["Zona"].ToString() + dt.Rows[0]["sdvart_CodGen"].ToString() + dt.Rows[0]["Periodo"].ToString(); 
                        break;
                    case "Vendedor-Familia-Articulo":
                        ClaveAnterior = dt.Rows[0]["Vendedor"].ToString() + dt.Rows[0]["sdvart_CodGen"].ToString() + dt.Rows[0]["Periodo"].ToString();
                        break;
                }
                string ClaveActual = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    switch (TipoReporte)
                    {
                        case "Zona-Familia-Articulo":
                            ClaveActual = dt.Rows[i]["Zona"].ToString() + dt.Rows[i]["sdvart_CodGen"].ToString() + dt.Rows[i]["Periodo"].ToString(); 
                            break;
                        case "Vendedor-Familia-Articulo":
                            ClaveActual = dt.Rows[i]["Vendedor"].ToString() + dt.Rows[i]["sdvart_CodGen"].ToString() + dt.Rows[i]["Periodo"].ToString();
                            break;
                    }
                    if (ClaveAnterior != ClaveActual)
                    {
                        lista.Add(elemento);
                        elemento = new CedForecastEntidades.Bejerman.Ventas();
                        ClaveAnterior = ClaveActual;
                    }
                    CopiarResumenArgentinaXZonas(TipoReporte, cotizaciones, dt.Rows[i], elemento);
                }
                lista.Add(elemento);
            }
            return lista;
        }
        private void CopiarResumenArgentinaXZonas(string TipoReporte, List<CedForecastEntidades.Bejerman.Cotizacion> cotizaciones, DataRow Desde, CedForecastEntidades.Bejerman.Ventas Hasta)
        {
            Hasta.Sdvart_CodGen = Convert.ToString(Desde["sdvart_CodGen"]);
            Hasta.Cve_FEmision = Convert.ToDateTime(Desde["cve_FEmision"]);
            Hasta.Periodo = Convert.ToString(Desde["Periodo"]);
            Hasta.Sdv_CantUM1 += Convert.ToDecimal(Desde["sdv_CantUM1"]);
            Hasta.Cvemon_Codigo = Convert.ToString(Desde["cvemon_Codigo"]);
            decimal cotiz = 1;
            if (Hasta.Cvemon_Codigo == "1")
            {
                List<CedForecastEntidades.Bejerman.Cotizacion> cotizacionesPeriodo = new List<CedForecastEntidades.Bejerman.Cotizacion>();
                cotizacionesPeriodo = cotizaciones.FindAll((delegate(CedForecastEntidades.Bejerman.Cotizacion e) { return Convert.ToInt32(e.Mcot_fecha.ToString("yyyyMMdd")) <= Convert.ToInt32(Hasta.Cve_FEmision.ToString("yyyyMMdd")) && e.Mon_codigo == "DVT"; }));
                cotiz = cotizacionesPeriodo[0].Mcot_cotiza;
            }
            Hasta.Sdv_ImpTot += Convert.ToDecimal(Desde["sdv_ImpTot"]) * cotiz;
            switch (TipoReporte)
            {
                case "Zona-Familia-Articulo":
                    Hasta.Zona = Convert.ToString(Desde["Zona"]);
                    break;
                case "Vendedor-Familia-Articulo":
                    Hasta.Vendedor = Convert.ToString(Desde["Vendedor"]);
                    break;
            }
        }
    }
}