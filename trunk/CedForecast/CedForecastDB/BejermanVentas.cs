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
        public List<CedForecastEntidades.Bejerman.Ventas> LeerParaResumenArgentinaXZonas(string Periodo)
        {
            DateTime fechaDsd = new DateTime(Convert.ToInt32(Periodo.Substring(0, 4)), 1, 1);
            DateTime fechaHst = new DateTime(Convert.ToInt32(fechaDsd.ToString("yyyy")), 12, 31);
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("SELECT ltrim(rtrim(SegDetV.sdvart_CodGen)) as sdvart_CodGen, Convert(varchar(6), CabVenta.cve_FEmision, 112) as PeriodoEmision, sum(SegDetV.sdv_CantUM1) as sdv_CantUM1 ");
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
            a.Append("group by sdvart_CodGen, Convert(varchar(6), CabVenta.cve_FEmision, 112) ");
            a.Append("having sum(SegDetV.sdv_CantUM1)<>0 ");
            a.Append("order by sdvart_CodGen, PeriodoEmision ");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            List<CedForecastEntidades.Bejerman.Ventas> lista = new List<CedForecastEntidades.Bejerman.Ventas>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastEntidades.Bejerman.Ventas elemento = new CedForecastEntidades.Bejerman.Ventas();
                    CopiarResumenArgentinaXZonas(dt.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        private void CopiarResumenArgentinaXZonas(DataRow Desde, CedForecastEntidades.Bejerman.Ventas Hasta)
        {
            Hasta.Sdvart_CodGen = Convert.ToString(Desde["sdvart_CodGen"]);
            Hasta.PeriodoEmision = Convert.ToString(Desde["PeriodoEmision"]);
            Hasta.Sdv_CantUM1 = Convert.ToDecimal(Desde["sdv_CantUM1"]);
        }
    }
}