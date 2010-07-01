using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastRN
{
    public static class Reporte
    {
        public static DataTable CrossTabArticulosClientes(string IdPeriodoDesde, string IdPeriodoHasta, bool IncluyeVendedor, CedEntidades.Sesion Sesion)
        {
            //Leer datos Forecast
            CedForecastDB.Forecast db = new CedForecastDB.Forecast(Sesion);
            DataSet ds = db.LeerDatosParaCrossTabArticulosClientes(IdPeriodoDesde, IdPeriodoHasta, IncluyeVendedor);
            DataTable dtArticulos = ds.Tables[0];
            DataTable dtVendedores = ds.Tables[1];
            DataTable dtClientes = ds.Tables[2];
            DataTable dtDatos = ds.Tables[3];
            //Leer datos Bejerman
            DateTime todos = new DateTime(1980, 1, 1);
            List<CedForecastEntidades.Bejerman.Articulos> articulos = new CedForecastDB.Bejerman.Articulos(Sesion).LeerLista(dtArticulos);
            List<CedForecastEntidades.Bejerman.Vendedor> vendedores = new CedForecastDB.Bejerman.Vendedor(Sesion).LeerLista(dtVendedores);
            List<CedForecastEntidades.Bejerman.Clientes> clientes = new CedForecastDB.Bejerman.Clientes(Sesion).LeerLista(dtClientes);
            //Crear crosstab
            DataTable dt = new DataTable();
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Articulo"]));
            if (IncluyeVendedor)
            {
                dt.Columns.Add(ClonarColumna(dtDatos.Columns["Vendedor"]));
            }
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Cantidad"], "Total", "Total"));
            dt.Columns.Add(new DataColumn("Uni", System.Type.GetType("System.String")));
            for (int i = 0; i < dtClientes.Rows.Count; i++)
            {
                string nombreColumna = Convert.ToString(dtClientes.Rows[i]["Cliente"]);
                string tituloColumna = nombreColumna;
                CedForecastEntidades.Bejerman.Clientes cliente = clientes.Find(delegate(CedForecastEntidades.Bejerman.Clientes c) { return c.Cli_Cod == nombreColumna; });
                if (cliente != null)
                {
                    tituloColumna += "-" + cliente.Cli_RazSoc;
                }
                dt.Columns.Add(ClonarColumna(dtDatos.Columns["Cantidad"], nombreColumna, tituloColumna));
            }
            //Llenar crosstab
            string claveAnterior = String.Empty;
            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                string claveActual=Convert.ToString(dtDatos.Rows[i]["Articulo"]);
                if (IncluyeVendedor)
                {
                    claveActual += Convert.ToString(dtDatos.Rows[i]["Vendedor"]);
                }
                if (claveAnterior != claveActual)
                {
                    DataRow dr=dt.NewRow();
                    CedForecastEntidades.Bejerman.Articulos articulo = articulos.Find(delegate(CedForecastEntidades.Bejerman.Articulos c) { return c.Art_CodGen==Convert.ToString(dtDatos.Rows[i]["Articulo"]); });
                    if (articulo == null)
                    {
                        dr["Articulo"] = Convert.ToString(dtDatos.Rows[i]["Articulo"]);
                        dr["Uni"] = String.Empty;
                    }
                    else
                    {
                        dr["Articulo"] = Convert.ToString(dtDatos.Rows[i]["Articulo"]) + "-" + articulo.Art_DescGen;
                        dr["Uni"] = articulo.Artcla_Cod;
                    }
                    if (IncluyeVendedor) 
                    {
                        CedForecastEntidades.Bejerman.Vendedor vendedor = vendedores.Find(delegate(CedForecastEntidades.Bejerman.Vendedor c) { return c.Ven_Cod == Convert.ToString(dtDatos.Rows[i]["Vendedor"]); });
                        if (vendedor == null)
                        {
                            dr["Vendedor"] = Convert.ToString(dtDatos.Rows[i]["Vendedor"]);
                        }
                        else
                        {
                            dr["Vendedor"] = Convert.ToString(dtDatos.Rows[i]["Vendedor"]) + "-" + vendedor.Ven_Desc;
                        }
                    }
                    dr["Total"] = 0;
                    dt.Rows.Add(dr);
                    claveAnterior = claveActual;
                }
                dt.Rows[dt.Rows.Count - 1][Convert.ToString(dtDatos.Rows[i]["Cliente"])] = Convert.ToDecimal(dtDatos.Rows[i]["Cantidad"]);
                dt.Rows[dt.Rows.Count - 1]["Total"] = Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1]["Total"]) + Convert.ToDecimal(dtDatos.Rows[i]["Cantidad"]);
                dt.AcceptChanges();
            }
            return dt;
        }
        private static DataColumn ClonarColumna(DataColumn Columna)
        {
            DataColumn nuevaColumna=new DataColumn(Columna.ColumnName, Columna.DataType);
            return nuevaColumna;
        }
        private static DataColumn ClonarColumna(DataColumn Columna, string NombreColumna, string TituloColumna)
        {
            DataColumn nuevaColumna = new DataColumn(NombreColumna, Columna.DataType);
            nuevaColumna.Caption = TituloColumna;
            return nuevaColumna;
        }
    }
}