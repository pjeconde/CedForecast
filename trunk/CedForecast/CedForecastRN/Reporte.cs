using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastRN
{
    public static class Reporte
    {
        public static DataTable CrossTabArticulosClientes(string IdPeriodoDesde, string IdPeriodoHasta, string TipoReporte, string ListaArticulos, string ListaClientes, string ListaVendedores, bool Valorizado, CedEntidades.Sesion Sesion, out List<CedForecastEntidades.Advertencia> Advertencias)
        {
            Advertencias = new List<CedForecastEntidades.Advertencia>();
            //Validacion de par�metros
            if (ListaArticulos == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Articulo(s)");
            }
            if (ListaClientes == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Cliente(s)");
            }
            switch (TipoReporte)
            {
                case "Art�culos-Vendedores":
                case "Vendedores-Art�culos":
                    if (ListaVendedores == String.Empty)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Vendedor(es)");
                    }
                    break;
            } 
            //Leer datos Forecast
            CedForecastDB.Forecast db = new CedForecastDB.Forecast(Sesion);
            DataSet ds = db.LeerDatosParaCrossTabArticulosClientes(IdPeriodoDesde, IdPeriodoHasta, TipoReporte, ListaArticulos, ListaClientes, ListaVendedores);
            DataTable dtArticulos = ds.Tables[0];
            DataTable dtVendedores = ds.Tables[1];
            DataTable dtClientes = ds.Tables[2];
            DataTable dtDatos = ds.Tables[3];
            //Leer datos Bejerman
            List<CedForecastEntidades.Bejerman.Articulos> articulos = new CedForecastDB.Bejerman.Articulos(Sesion).LeerLista(dtArticulos);
            List<CedForecastEntidades.Bejerman.Vendedor> vendedores = new CedForecastDB.Bejerman.Vendedor(Sesion).LeerLista(dtVendedores);
            List<CedForecastEntidades.Bejerman.Clientes> clientes = new CedForecastDB.Bejerman.Clientes(Sesion).LeerLista(dtClientes);
            List<CedForecastEntidades.Articulo> familiaXArticulos = new CedForecastDB.Articulo(Sesion).LeerLista();
            //Crear crosstab
            DataTable dt = new DataTable();
            bool incluyeVendedor = false;
            switch (TipoReporte)
            {
                case "Art�culos-Vendedores":
                    dt.Columns.Add(ClonarColumna(dtDatos.Columns["Articulo"], "Familia", "Familia"));
                    dt.Columns.Add(ClonarColumna(dtDatos.Columns["Articulo"]));
                    dt.Columns.Add(ClonarColumna(dtDatos.Columns["Vendedor"]));
                    incluyeVendedor = true;
                    break;
                case "Vendedores-Art�culos":
                    dt.Columns.Add(ClonarColumna(dtDatos.Columns["Vendedor"]));
                    dt.Columns.Add(ClonarColumna(dtDatos.Columns["Articulo"], "Familia", "Familia"));
                    dt.Columns.Add(ClonarColumna(dtDatos.Columns["Articulo"]));
                    incluyeVendedor = true;
                    break;
                case "S�lo Art�culos":
                    dt.Columns.Add(ClonarColumna(dtDatos.Columns["Articulo"], "Familia", "Familia"));
                    dt.Columns.Add(ClonarColumna(dtDatos.Columns["Articulo"]));
                    break;
            }
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Cantidad"], "Total", "Total"));
            for (int i = 0; i < dtClientes.Rows.Count; i++)
            {
                string nombreColumna = Convert.ToString(dtClientes.Rows[i]["Cliente"]);
                string tituloColumna = nombreColumna;
                CedForecastEntidades.Bejerman.Clientes cliente = clientes.Find(delegate(CedForecastEntidades.Bejerman.Clientes c) { return c.Cli_Cod == nombreColumna; });
                if (cliente != null)
                {
                    tituloColumna += "-" + cliente.Cli_RazSoc;
                }
                dt.Columns.Add(ClonarColumna(dtDatos.Columns["Cantidad"], nombreColumna, " " + tituloColumna));
            }
            //Llenar crosstab
            string claveAnterior = String.Empty;
            decimal precio = -1;
            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                string claveActual=Convert.ToString(dtDatos.Rows[i]["Articulo"]);
                if (incluyeVendedor)
                {
                    claveActual += Convert.ToString(dtDatos.Rows[i]["Vendedor"]);
                }
                if (claveAnterior != claveActual)
                {
                    if (precio == 0)
                    {
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-03", "Precio no encontrado para el art�culo " + Convert.ToString(dt.Rows[dt.Rows.Count - 1]["Articulo"]), CedForecastEntidades.Advertencia.TipoSeveridad.Error));
                    }
                    DataRow dr = dt.NewRow();
                    CedForecastEntidades.Articulo familiaXArticulo = familiaXArticulos.Find(delegate(CedForecastEntidades.Articulo c) { return c.Id == Convert.ToString(dtDatos.Rows[i]["Articulo"]); });
                    if (familiaXArticulo == null)
                    {
                        dr["Familia"] = "<<<Desconocida>>>";
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-01", "Art�culo " + Convert.ToString(dtDatos.Rows[i]["Articulo"]) + " sin familia definida", CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                    }
                    else
                    {
                        dr["Familia"] = familiaXArticulo.Familia.Descr;
                    }
                    CedForecastEntidades.Bejerman.Articulos articulo = articulos.Find(delegate(CedForecastEntidades.Bejerman.Articulos c) { return c.Art_CodGen==Convert.ToString(dtDatos.Rows[i]["Articulo"]); });
                    if (articulo == null)
                    {
                        dr["Articulo"] = Convert.ToString(dtDatos.Rows[i]["Articulo"]) + "-<<<Desconocido>>>";
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-02", "Descripci�n no encontrada para el art�culo " + Convert.ToString(dtDatos.Rows[i]["Articulo"]), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                        precio = 0;
                    }
                    else
                    {
                        dr["Articulo"] = Convert.ToString(dtDatos.Rows[i]["Articulo"]) + "-" + articulo.Art_DescGen + " ("+articulo.Artcla_Cod+")";
                        precio = articulo.Lpr_Precio;
                    }
                    if (!Valorizado)
                    {
                        precio = 1;
                    }
                    else
                    {
                        if (articulo == null)
                        {
                            precio = 0;
                        }
                        else
                        {
                            precio = articulo.Lpr_Precio;
                        }
                    }
                    if (incluyeVendedor) 
                    {
                        CedForecastEntidades.Bejerman.Vendedor vendedor = vendedores.Find(delegate(CedForecastEntidades.Bejerman.Vendedor c) { return c.Ven_Cod == Convert.ToString(dtDatos.Rows[i]["Vendedor"]); });
                        if (vendedor == null)
                        {
                            dr["Vendedor"] = Convert.ToString(dtDatos.Rows[i]["Vendedor"]) + "-<<<Desconocido>>>";
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
                decimal valor = Convert.ToDecimal(dtDatos.Rows[i]["Cantidad"]) * precio;
                dt.Rows[dt.Rows.Count - 1][Convert.ToString(dtDatos.Rows[i]["Cliente"])] = valor;
                dt.Rows[dt.Rows.Count - 1]["Total"] = Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1]["Total"]) + valor;
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