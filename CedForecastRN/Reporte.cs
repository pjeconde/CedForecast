using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastRN
{
    public static class Reporte
    {
        public static DataTable Financiero(string IdPeriodo, string TipoReporte, string ListaClientes, CedEntidades.Sesion Sesion, out List<CedForecastEntidades.Advertencia> Advertencias)
        {
            Advertencias = new List<CedForecastEntidades.Advertencia>();
            //Validacion de parámetros
            if (ListaClientes == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Cliente(s)");
            }
            //Leer datos Forecast
            CedForecastDB.Forecast db = new CedForecastDB.Forecast(Sesion);
            DataSet ds = db.LeerDatosParaFinanciero(IdPeriodo, TipoReporte, ListaClientes);
            DataTable dtZona;
            switch (TipoReporte)
            {
                case "Zona-Cliente":
                    dtZona = ds.Tables[0];
                    break;
            }
            DataTable dtClientes = ds.Tables[1];
            DataTable dtDatos = ds.Tables[2];
            //Leer datos Bejerman
            List<CedForecastEntidades.Bejerman.Zona> zonas = new CedForecastDB.Bejerman.Zona(Sesion).LeerLista();
            List<CedForecastEntidades.Bejerman.Clientes> clientes = new CedForecastDB.Bejerman.Clientes(Sesion).LeerLista();
            
            //Crear crosstab
            DataTable dt = new DataTable();
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Zona"]));     //Zona
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Cliente"]));
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Descr"]));
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["FecVto"]));
            DateTime fechaInicio = Convert.ToDateTime("01/" + IdPeriodo.Substring(4, 2) + "/" + IdPeriodo.Substring(0, 4));
            DateTime periodoColumna = fechaInicio;
            for (int i = 0; i < 12; i++)
            {
                dt.Columns.Add(ClonarColumna(dtDatos.Columns["Saldo"], " " + periodoColumna.ToString("MM-yyyy"), " " + periodoColumna.ToString("MM-yyyy")));
                periodoColumna = periodoColumna.AddMonths(1);
            }
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Saldo"], "Total Saldo", "Total Saldo"));
            
            //Llenar crosstab
            string claveAnterior = String.Empty;
            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                //string claveActual = Convert.ToString(dtDatos.Rows[i]["Zona"]) + Convert.ToString(dtDatos.Rows[i]["Cliente"]);
                //if (claveAnterior != claveActual)
                //{
                    //Zona
                    DataRow dr = dt.NewRow();
                    CedForecastEntidades.Bejerman.Zona zona = zonas.Find(delegate(CedForecastEntidades.Bejerman.Zona c) { return c.Zon_Cod == Convert.ToString(dtDatos.Rows[i]["Zona"]); });
                    if (zona == null)
                    {
                        dr["Zona"] = Convert.ToString(dtDatos.Rows[i]["Zona"]) + "-<<<Desconocido>>>";
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-01", "Descripción no encontrada para la zona " + Convert.ToString(dtDatos.Rows[i]["Zona"]), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                    }
                    else
                    {
                        dr["Zona"] = Convert.ToString(dtDatos.Rows[i]["Zona"]) + "-" + zona.Zon_Desc;
                    }
                    //Cliente
                    CedForecastEntidades.Bejerman.Clientes cliente = clientes.Find(delegate(CedForecastEntidades.Bejerman.Clientes c) { return c.Cli_Cod == Convert.ToString(dtDatos.Rows[i]["Cliente"]); });
                    if (cliente == null)
                    {
                        dr["Cliente"] = Convert.ToString(dtDatos.Rows[i]["Cliente"]) + "-<<<Desconocido>>>";
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-02", "Descripción no encontrada para el cliente " + Convert.ToString(dtDatos.Rows[i]["Cliente"]), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                    }
                    else
                    {
                        dr["Cliente"] = Convert.ToString(dtDatos.Rows[i]["Cliente"]) + "-" + cliente.Cli_RazSoc;
                    }
                    dr["FecVto"] = Convert.ToString(dtDatos.Rows[i]["FecVto"]);
                    dr["Descr"] = Convert.ToString(dtDatos.Rows[i]["Descr"]);
                    dt.Rows.Add(dr);
                    //claveAnterior = claveActual;
                //}
                decimal valor = Convert.ToDecimal(dtDatos.Rows[i]["Saldo"]);
                string periodo = Convert.ToDateTime(dtDatos.Rows[i]["FecVto"]).ToString("MM-yyyy");
                if (Convert.ToDateTime(dtDatos.Rows[i]["FecVto"]) < fechaInicio)
                {
                    if (dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.ToString("MM-yyyy")].ToString() == "")
                    {
                        dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.ToString("MM-yyyy")] = "0";
                    }
                    dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.ToString("MM-yyyy")] = Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.ToString("MM-yyyy")]) + valor;
                }
                else
                {
                    if (dt.Rows[dt.Rows.Count - 1][" " + periodo].ToString() == "")
                    {
                        dt.Rows[dt.Rows.Count - 1][" " + periodo] = "0";
                    }
                    dt.Rows[dt.Rows.Count - 1][" " + periodo] = Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1][" " + periodo]) + valor;
                }
                if (dt.Rows[dt.Rows.Count - 1]["Total Saldo"].ToString() == "")
                {
                    dt.Rows[dt.Rows.Count - 1]["Total Saldo"] = "0";
                }
                dt.Rows[dt.Rows.Count - 1]["Total Saldo"] = Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1]["Total Saldo"]) + valor;
                dt.AcceptChanges();
            }
            return dt;
        }

        public static DataTable ResumenArgentinaXZonas(string PeriodoDesde, string PeriodoHasta, string TipoReporte, string ListaArticulos, string ListaClientes, string ListaVendedores, bool Valorizado, CedEntidades.Sesion Sesion, out List<CedForecastEntidades.Advertencia> Advertencias)
        {
            Advertencias = new List<CedForecastEntidades.Advertencia>();
            //Validacion de parámetros
            if (ListaArticulos == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Articulo(s)");
            }
            if (ListaClientes == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Cliente(s)");
            }
            //Leer datos Forecast
            CedForecastDB.Forecast db = new CedForecastDB.Forecast(Sesion);
            DataSet ds = db.LeerDatosParaResumenArgentinaXZonas(PeriodoDesde, PeriodoHasta, TipoReporte, ListaArticulos, ListaClientes, ListaVendedores);
            DataTable dtZona;
            DataTable dtVendedor;
            switch (TipoReporte)
            {
                case "Zona-Familia-Articulo":
                    dtZona = ds.Tables[0];
                    break;
                case "Vendedor-Familia-Articulo":
                    dtVendedor = ds.Tables[0];
                    break;
            }
            DataTable dtFamilia = ds.Tables[1];
            DataTable dtArticulos = ds.Tables[2];
            DataTable dtDatos = ds.Tables[3];
            //Leer datos Bejerman
            List<CedForecastEntidades.Bejerman.Zona> zonas = new CedForecastDB.Bejerman.Zona(Sesion).LeerLista();
            List<CedForecastEntidades.Bejerman.Vendedor> vendedores = new CedForecastDB.Bejerman.Vendedor(Sesion).LeerLista();
            List<CedForecastEntidades.Bejerman.Articulos> articulos = new CedForecastDB.Bejerman.Articulos(Sesion).LeerListaConPrecios();
            List<CedForecastEntidades.Articulo> familiaXArticulos = new CedForecastDB.Articulo(Sesion).LeerLista();
            //Crear crosstab
            DataTable dt = new DataTable();
            dt.Columns.Add(ClonarColumna(dtDatos.Columns[0])); //Empresa
            dt.Columns.Add(ClonarColumna(dtDatos.Columns[1])); //Zona o Vendedor
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Familia"]));
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Articulo"]));
            string idPeriodo = "";
            DateTime periodoDesde = Convert.ToDateTime("01/" + PeriodoDesde.Substring(4, 2) + "/" + PeriodoDesde.Substring(0, 4));
            DateTime periodoHasta = Convert.ToDateTime("01/" + PeriodoHasta.Substring(4, 2) + "/" + PeriodoHasta.Substring(0, 4));
            int meses = periodoHasta.Month - periodoDesde.Month + 1;
            int años = periodoHasta.Year - periodoDesde.Year;
            meses += años * 12;
            idPeriodo = periodoDesde.ToString("yyyyMM");
            for (int i = 1; i <= meses; i++)
            {
                dt.Columns.Add(ClonarColumna(dtDatos.Columns["Cantidad"], "Plan-" + idPeriodo, "Plan-" + idPeriodo));
                dt.Columns.Add(ClonarColumna(dtDatos.Columns["Cantidad"], "Real-" + idPeriodo, "Real-" + idPeriodo));
                idPeriodo = periodoDesde.AddMonths(i).ToString("yyyyMM");
            }
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Cantidad"], "Total Plan", "Total Plan"));
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Cantidad"], "Total Real", "Total Real"));
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Cantidad"], "Desvio Plan", "Desvio Plan"));
            //Llenar crosstab
            string claveAnterior = String.Empty;
            //Buscar Ventas
            CedForecastDB.Bejerman.Ventas dbVentas = new CedForecastDB.Bejerman.Ventas(Sesion);
            List<CedForecastEntidades.Bejerman.Ventas> ventas = dbVentas.LeerParaResumenArgentinaXZonas(TipoReporte, PeriodoDesde, PeriodoHasta, ListaArticulos, ListaClientes, ListaVendedores);
            decimal precio = 0;
            for (int i = 0; i < ventas.Count; i++)
            {
                DataRow[] drv;
                switch (TipoReporte)
                {
                    case "Zona-Familia-Articulo":
                        drv = dtDatos.Select("Zona = '" + ventas[i].Zona + "' and Articulo = '" + ventas[i].Sdvart_CodGen + "' and Periodo = '" + ventas[i].Periodo + "'");
                        if (drv.Length == 0)
                        {
                            dtDatos.Rows.Add("Empresa", ventas[i].Zona, "", "", ventas[i].Sdvart_CodGen, ventas[i].Periodo, 0);
                        }
                        break;
                    case "Vendedor-Familia-Articulo":
                        drv = dtDatos.Select("Vendedor = '" + ventas[i].Vendedor + "' and Articulo = '" + ventas[i].Sdvart_CodGen + "' and Periodo = '" + ventas[i].Periodo + "'");
                        if (drv.Length == 0)
                        {
                            dtDatos.Rows.Add("Empresa", ventas[i].Vendedor, "", "", ventas[i].Sdvart_CodGen, ventas[i].Periodo, 0);
                        }
                        break;
                }
            }
            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                string claveActual = Convert.ToString(dtDatos.Rows[i][1]) + Convert.ToString(dtDatos.Rows[i]["Familia"]) + Convert.ToString(dtDatos.Rows[i]["Articulo"]);
                if (claveAnterior != claveActual)
                {
                    DataRow dr = dt.NewRow();
                    dr["Empresa"] = "Empresa";
                    CedForecastEntidades.Articulo familiaXArticulo = familiaXArticulos.Find(delegate(CedForecastEntidades.Articulo c) { return c.Id == Convert.ToString(dtDatos.Rows[i]["Articulo"]); });
                    if (familiaXArticulo == null)
                    {
                        dr["Familia"] = "<<<Desconocida>>>";
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-01", "Artículo " + Convert.ToString(dtDatos.Rows[i]["Articulo"]) + " sin familia definida", CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                    }
                    else
                    {
                        dr["Familia"] = familiaXArticulo.Familia.Descr;
                    }
                    CedForecastEntidades.Bejerman.Articulos articulo = articulos.Find(delegate(CedForecastEntidades.Bejerman.Articulos c) { return c.Art_CodGen == Convert.ToString(dtDatos.Rows[i]["Articulo"]); });
                    if (articulo == null)
                    {
                        dr["Articulo"] = Convert.ToString(dtDatos.Rows[i]["Articulo"]) + "-<<<Desconocido>>>";
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-02", "Descripción no encontrada para el artículo " + Convert.ToString(dtDatos.Rows[i]["Articulo"]), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                        precio = 0;
                    }
                    else
                    {
                        dr["Articulo"] = Convert.ToString(dtDatos.Rows[i]["Articulo"]) + "-" + articulo.Art_DescGen;
                        precio = articulo.Lpr_Precio;
                    }
                    if (precio == 0)
                    {
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-03", "Precio no encontrado para el artículo " + Convert.ToString(dtDatos.Rows[i]["Articulo"]), CedForecastEntidades.Advertencia.TipoSeveridad.Error));
                    }
                    switch (TipoReporte)
                    {
                        case "Zona-Familia-Articulo":
                            CedForecastEntidades.Bejerman.Zona zona = zonas.Find(delegate(CedForecastEntidades.Bejerman.Zona c) { return c.Zon_Cod == Convert.ToString(dtDatos.Rows[i]["Zona"]); });
                            if (zona == null)
                            {
                                dr["Zona"] = Convert.ToString(dtDatos.Rows[i]["Zona"]) + "-<<<Desconocido>>>";
                                Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-04", "Descripción no encontrada para la zona " + Convert.ToString(dtDatos.Rows[i]["Zona"]), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                            }
                            else
                            {
                                dr["Zona"] = Convert.ToString(dtDatos.Rows[i]["Zona"]) + "-" + zona.Zon_Desc;
                            }
                            break;
                        case "Vendedor-Familia-Articulo":
                            CedForecastEntidades.Bejerman.Vendedor vendedor = vendedores.Find(delegate(CedForecastEntidades.Bejerman.Vendedor c) { return c.Ven_Cod == Convert.ToString(dtDatos.Rows[i]["Vendedor"]); });
                            if (vendedor == null)
                            {
                                dr["Vendedor"] = Convert.ToString(dtDatos.Rows[i]["Vendedor"]) + "-<<<Desconocido>>>";
                                Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-04", "Descripción no encontrada para el vendedor " + Convert.ToString(dtDatos.Rows[i]["Vendedor"]), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                            }
                            else
                            {
                                dr["Vendedor"] = Convert.ToString(dtDatos.Rows[i]["Vendedor"]) + "-" + vendedor.Ven_Desc;
                            }
                            break;
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
                    dr["Total Plan"] = 0;
                    dr["Total Real"] = 0;
                    dt.Rows.Add(dr);
                    claveAnterior = claveActual;
                }
                decimal valor = Convert.ToDecimal(dtDatos.Rows[i]["Cantidad"]) * precio;
                dt.Rows[dt.Rows.Count - 1]["Plan-" + dtDatos.Rows[i]["Periodo"].ToString()] = valor;
                //Completo ventas
                CedForecastEntidades.Bejerman.Ventas venta = new CedForecastEntidades.Bejerman.Ventas();
                switch (TipoReporte)
                {
                    case "Zona-Familia-Articulo":
                        venta = ventas.Find((delegate(CedForecastEntidades.Bejerman.Ventas e) { return e.Zona == dtDatos.Rows[i]["Zona"].ToString() && e.Sdvart_CodGen == dtDatos.Rows[i]["Articulo"].ToString() && e.Periodo == dtDatos.Rows[i]["Periodo"].ToString(); }));
                        break;
                    case "Vendedor-Familia-Articulo":
                        venta = ventas.Find((delegate(CedForecastEntidades.Bejerman.Ventas e) { return e.Vendedor == dtDatos.Rows[i]["Vendedor"].ToString() && e.Sdvart_CodGen == dtDatos.Rows[i]["Articulo"].ToString() && e.Periodo == dtDatos.Rows[i]["Periodo"].ToString(); }));
                        break;
                }
                
                decimal valorReal = 0;
                if (venta != null)
                {
                    if (Valorizado)
                    {
                        valorReal = venta.Sdv_ImpTot;
                    }
                    else
                    {
                        valorReal = venta.Sdv_CantUM1;
                    }
                    dt.Rows[dt.Rows.Count - 1]["Real-" + dtDatos.Rows[i]["Periodo"].ToString()] = valorReal;
                }
                //Sumar a Total
                dt.Rows[dt.Rows.Count - 1]["Total Plan"] = Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1]["Total Plan"]) + valor;
                dt.Rows[dt.Rows.Count - 1]["Total Real"] = Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1]["Total Real"]) + valorReal;
                dt.Rows[dt.Rows.Count - 1]["Desvio Plan"] = 0;
                if (Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1]["Total Plan"]) > 0)
                {
                    dt.Rows[dt.Rows.Count - 1]["Desvio Plan"] = (Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1]["Total Real"]) / Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1]["Total Plan"]) - 1) * 100;
                }
                dt.AcceptChanges();
            }
            return dt;
        }
        public static DataTable CrossTabArticulosClientes(string IdPeriodoDesde, string IdPeriodoHasta, string TipoReporte, string ListaArticulos, string ListaClientes, string ListaVendedores, bool Valorizado, CedEntidades.Sesion Sesion, out List<CedForecastEntidades.Advertencia> Advertencias)
        {
            Advertencias = new List<CedForecastEntidades.Advertencia>();
            //Validacion de parámetros
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
                case "Artículos-Vendedores":
                case "Vendedores-Artículos":
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
            List<CedForecastEntidades.Bejerman.Articulos> articulos = new CedForecastDB.Bejerman.Articulos(Sesion).LeerListaConPrecios(dtArticulos);
            List<CedForecastEntidades.Bejerman.Vendedor> vendedores = new CedForecastDB.Bejerman.Vendedor(Sesion).LeerLista(dtVendedores);
            List<CedForecastEntidades.Bejerman.Clientes> clientes = new CedForecastDB.Bejerman.Clientes(Sesion).LeerLista(dtClientes);
            List<CedForecastEntidades.Articulo> familiaXArticulos = new CedForecastDB.Articulo(Sesion).LeerLista();
            //Crear crosstab
            DataTable dt = new DataTable();
            bool incluyeVendedor = false;
            switch (TipoReporte)
            {
                case "Artículos-Vendedores":
                    dt.Columns.Add(ClonarColumna(dtDatos.Columns["Articulo"], "Familia", "Familia"));
                    dt.Columns.Add(ClonarColumna(dtDatos.Columns["Articulo"]));
                    dt.Columns.Add(ClonarColumna(dtDatos.Columns["Vendedor"]));
                    incluyeVendedor = true;
                    break;
                case "Vendedores-Artículos":
                    dt.Columns.Add(ClonarColumna(dtDatos.Columns["Vendedor"]));
                    dt.Columns.Add(ClonarColumna(dtDatos.Columns["Articulo"], "Familia", "Familia"));
                    dt.Columns.Add(ClonarColumna(dtDatos.Columns["Articulo"]));
                    incluyeVendedor = true;
                    break;
                case "Sólo Artículos":
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
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-03", "Precio no encontrado para el artículo " + Convert.ToString(dt.Rows[dt.Rows.Count - 1]["Articulo"]), CedForecastEntidades.Advertencia.TipoSeveridad.Error));
                    }
                    DataRow dr = dt.NewRow();
                    CedForecastEntidades.Articulo familiaXArticulo = familiaXArticulos.Find(delegate(CedForecastEntidades.Articulo c) { return c.Id == Convert.ToString(dtDatos.Rows[i]["Articulo"]); });
                    if (familiaXArticulo == null)
                    {
                        dr["Familia"] = "<<<Desconocida>>>";
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-01", "Artículo " + Convert.ToString(dtDatos.Rows[i]["Articulo"]) + " sin familia definida", CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                    }
                    else
                    {
                        dr["Familia"] = familiaXArticulo.Familia.Descr;
                    }
                    CedForecastEntidades.Bejerman.Articulos articulo = articulos.Find(delegate(CedForecastEntidades.Bejerman.Articulos c) { return c.Art_CodGen==Convert.ToString(dtDatos.Rows[i]["Articulo"]); });
                    if (articulo == null)
                    {
                        dr["Articulo"] = Convert.ToString(dtDatos.Rows[i]["Articulo"]) + "-<<<Desconocido>>>";
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-02", "Descripción no encontrada para el artículo " + Convert.ToString(dtDatos.Rows[i]["Articulo"]), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
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