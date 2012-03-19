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
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["TipoDato"]));
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
                    dr["TipoDato"] = Convert.ToString(dtDatos.Rows[i]["TipoDato"]);
                    dr["Descr"] = Convert.ToString(dtDatos.Rows[i]["Descr"]);
                    dt.Rows.Add(dr);
                    //claveAnterior = claveActual;
                //}
                decimal valor = Convert.ToDecimal(dtDatos.Rows[i]["Saldo"]);
                string periodo = Convert.ToDateTime(dtDatos.Rows[i]["FecVto"]).ToString("MM-yyyy");
                if (Convert.ToInt32(Convert.ToDateTime(dtDatos.Rows[i]["FecVto"]).ToString("yyyyMM")) < Convert.ToInt32(fechaInicio.ToString("yyyyMM")))
                {
                    if (dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.ToString("MM-yyyy")].ToString() == "")
                    {
                        dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.ToString("MM-yyyy")] = "0";
                    }
                    dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.ToString("MM-yyyy")] = Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.ToString("MM-yyyy")]) + valor;
                }
                else if (Convert.ToInt32(Convert.ToDateTime(dtDatos.Rows[i]["FecVto"]).ToString("yyyyMM")) > Convert.ToInt32(fechaInicio.AddMonths(11).ToString("yyyyMM")))
                {
                    if (dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.AddMonths(11).ToString("MM-yyyy")].ToString() == "")
                    {
                        dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.AddMonths(11).ToString("MM-yyyy")] = "0";
                    }
                    dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.AddMonths(11).ToString("MM-yyyy")] = Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.AddMonths(11).ToString("MM-yyyy")]) + valor;
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
        public static DataSet FinancieroDs(string IdPeriodo, string TipoReporte, string ListaClientes, CedEntidades.Sesion Sesion, out List<CedForecastEntidades.Advertencia> Advertencias)
        {
            Advertencias = new List<CedForecastEntidades.Advertencia>();
            //Validacion de parámetros
            if (ListaClientes == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Cliente(s)");
            }
            //Leer datos Forecast
            CedForecastDB.Forecast db = new CedForecastDB.Forecast(Sesion);
            DataSet ds = db.LeerDatosParaFinancieroDs(IdPeriodo, TipoReporte, ListaClientes);
            DataTable dtZona = new DataTable();
            switch (TipoReporte)
            {
                case "Zona-Cliente":
                    dtZona = ds.Tables[0].Copy();
                    break;
            }
            DataTable dtClientes = ds.Tables[1].Copy();
            DataTable dtDatos = ds.Tables[2].Copy();
            DataTable dtDatosT = ds.Tables[3].Copy();

            //Creamos el DataSet con modificaciones de campos para la Grilla.
            ds = new DataSet();
            ds.Tables.Add(dtZona);
            ds.Tables[0].TableName = "Finan1";
            ds.Tables.Add(dtClientes);
            ds.Tables[1].TableName = "Finan2";
            
            //Leer datos Bejerman
            List<CedForecastEntidades.Bejerman.Zona> zonas = new CedForecastDB.Bejerman.Zona(Sesion).LeerLista();
            List<CedForecastEntidades.Bejerman.Clientes> clientes = new CedForecastDB.Bejerman.Clientes(Sesion).LeerLista();

            DataTable dt = new DataTable();
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Zona"]));     //Zona
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Cliente"]));
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["TipoDato"]));
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Descripcion"]));
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
                    dr["Cliente"] = Convert.ToString(dtDatos.Rows[i]["Cliente"]); // + "-" + cliente.Cli_RazSoc;
                }
                dr["FecVto"] = Convert.ToString(dtDatos.Rows[i]["FecVto"]);
                dr["TipoDato"] = Convert.ToString(dtDatos.Rows[i]["TipoDato"]);
                dr["Descripcion"] = Convert.ToString(dtDatos.Rows[i]["Descripcion"]);
                dt.Rows.Add(dr);

                decimal valor = Convert.ToDecimal(dtDatos.Rows[i]["Saldo"]);
                string periodo = Convert.ToDateTime(dtDatos.Rows[i]["FecVto"]).ToString("MM-yyyy");
                if (Convert.ToInt32(Convert.ToDateTime(dtDatos.Rows[i]["FecVto"]).ToString("yyyyMM")) < Convert.ToInt32(fechaInicio.ToString("yyyyMM")))
                {
                    if (dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.ToString("MM-yyyy")].ToString() == "")
                    {
                        dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.ToString("MM-yyyy")] = "0";
                    }
                    dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.ToString("MM-yyyy")] = Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.ToString("MM-yyyy")]) + valor;
                }
                else if (Convert.ToInt32(Convert.ToDateTime(dtDatos.Rows[i]["FecVto"]).ToString("yyyyMM")) > Convert.ToInt32(fechaInicio.AddMonths(11).ToString("yyyyMM")))
                {
                    if (dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.AddMonths(11).ToString("MM-yyyy")].ToString() == "")
                    {
                        dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.AddMonths(11).ToString("MM-yyyy")] = "0";
                    }
                    dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.AddMonths(11).ToString("MM-yyyy")] = Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1][" " + fechaInicio.AddMonths(11).ToString("MM-yyyy")]) + valor;
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
            ds.Tables.Add(dt);
            ds.Tables[2].TableName = "Finan3";

            //Agregar un fila por Zona / Cliente para informar el Forecast
            DateTime fechaHasta = fechaInicio.AddMonths(12).AddDays(-1);
            DataTable dtForecast = LeerDatosForecastParaFinancieroDS(fechaInicio.ToString("yyyyMM"), fechaHasta.ToString("yyyyMM"), ListaClientes, Advertencias, Sesion);
            
            //Buscar Cliente, para agregar los datos del forecast para el TipoDato = 'CtaCte'.
            for (int i = 0; i < dtForecast.Rows.Count; i++)
            {
                DataRow[] drFind = dt.Select("Zona = '" + dtForecast.Rows[i]["Zona"] + "' and Cliente = '" + dtForecast.Rows[i]["Cliente"] + "' and TipoDato = '" + "CtaCte" + "' and Descripcion = '" + "Forecast" + "'");
                if (drFind.Length == 0)
                {
                    DataRow nuevoRegistro = dt.NewRow();   
                    nuevoRegistro["Zona"] = dtForecast.Rows[i]["Zona"];
                    nuevoRegistro["Cliente"] = dtForecast.Rows[i]["Cliente"];
                    nuevoRegistro["TipoDato"] = "CtaCte";
                    nuevoRegistro["Descripcion"] = "Forecast";
                    string periodo = dtForecast.Rows[i]["Periodo"].ToString().Substring(4, 2) + "-" + dtForecast.Rows[i]["Periodo"].ToString().Substring(0, 4);
                    nuevoRegistro[" " + periodo] = dtForecast.Rows[i]["Valor"];
                    dt.Rows.Add(nuevoRegistro);
                    //Buscar si existe la zona
                    DataRow[] drFindFinan1 = ds.Tables[0].Select("Zona = '" + dtForecast.Rows[i]["Zona"] + "'");
                    if (drFindFinan1.Length == 0)
                    {
                        DataRow nuevoRegistroFinan1 = ds.Tables[0].NewRow();
                        nuevoRegistroFinan1["Zona"] = dtForecast.Rows[i]["Zona"].ToString();
                        ds.Tables[0].Rows.Add(nuevoRegistroFinan1);
                    }
                    //Buscar si existe el zona / cliente
                    DataRow[] drFindFinan2 = ds.Tables[1].Select("Zona = '" + dtForecast.Rows[i]["Zona"] + "' and Cliente = '" + dtForecast.Rows[i]["Cliente"] + "'");
                    if (drFindFinan2.Length == 0)
                    {
                        DataRow nuevoRegistroFinan2 = ds.Tables[1].NewRow();
                        nuevoRegistroFinan2["Zona"] = dtForecast.Rows[i]["Zona"].ToString();
                        nuevoRegistroFinan2["Cliente"] = dtForecast.Rows[i]["Cliente"].ToString();
                        nuevoRegistroFinan2["Nombre"] = dtForecast.Rows[i]["Nombre"].ToString();
                        ds.Tables[1].Rows.Add(nuevoRegistroFinan2);
                    }
                }
                else if (drFind.Length == 1)
                {
                    drFind[0]["Zona"] = dtForecast.Rows[i]["Zona"];
                    drFind[0]["Cliente"] = dtForecast.Rows[i]["Cliente"];
                    drFind[0]["TipoDato"] = "CtaCte";
                    drFind[0]["Descripcion"] = "Forecast";
                    string periodo = dtForecast.Rows[i]["Periodo"].ToString().Substring(4, 2) + "-" + dtForecast.Rows[i]["Periodo"].ToString().Substring(0, 4);
                    if (drFind[0][" " + periodo].ToString() != "")
                    {
                        drFind[0][" " + periodo] = Convert.ToDecimal(drFind[0][" " + periodo]) + Convert.ToDecimal(dtForecast.Rows[i]["Valor"]);
                    }
                    else
                    {
                        drFind[0][" " + periodo] = Convert.ToDecimal(dtForecast.Rows[i]["Valor"]);
                    }
                    dt.AcceptChanges();
                }
            }
            DataTable dtCopy = ds.Tables[1].Copy();
            DataRow[] drows = dtCopy.Select("", "CLIENTE ASC");
            ds.Tables[1].Clear();
            for (int i = 0; i < drows.Length; i++)
            {
                DataRow drow = ds.Tables[1].NewRow();
                drow[0] = drows[i][0].ToString();
                drow[1] = drows[i][1].ToString();
                drow[2] = drows[i][2].ToString();
                ds.Tables[1].Rows.Add(drow);
            }

            ds.Tables.Add(dtDatosT);
            ds.Tables[3].TableName = "Finan4";

            ds.Relations.Add("Finan1_Finan2", ds.Tables["Finan1"].Columns["Zona"], ds.Tables["Finan2"].Columns["Zona"]);
            ds.Relations.Add("Finan2_Finan3", ds.Tables["Finan2"].Columns["Cliente"], ds.Tables["Finan3"].Columns["Cliente"]);
            ds.Relations.Add("Finan2_Finan4", ds.Tables["Finan2"].Columns["Cliente"], ds.Tables["Finan4"].Columns["Cliente"]);
            return ds;
        }
        private static DataTable LeerDatosForecastParaFinancieroDS(string PeriodoDesde, string PeriodoHasta, string ListaClientes, List<CedForecastEntidades.Advertencia> Advertencias, CedEntidades.Sesion Sesion)
        {
            if (ListaClientes == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Cliente(s)");
            }
            //Leer datos Forecast
            CedForecastDB.Forecast db = new CedForecastDB.Forecast(Sesion);
            DataSet ds = db.LeerDatosForecastParaFinancieroDS(PeriodoDesde, PeriodoHasta, ListaClientes);
            DataTable dtDatos = ds.Tables[0];
            //Leer datos Bejerman
            List<CedForecastEntidades.Bejerman.Zona> zonas = new CedForecastDB.Bejerman.Zona(Sesion).LeerLista();
            List<CedForecastEntidades.Bejerman.Clientes> clientes = new CedForecastDB.Bejerman.Clientes(Sesion).LeerLista();
            List<CedForecastEntidades.Bejerman.Articulos> articulos = new CedForecastDB.Bejerman.Articulos(Sesion).LeerListaConPrecios();
            //Crear datos de forecast para FinancieroDS
            DataTable dt = new DataTable();
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Zona"])); 
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Cliente"]));
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Nombre"])); 
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["CondVta"])); 
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Articulo"]));
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Periodo"]));
            dt.Columns.Add(ClonarColumna(dtDatos.Columns["Cantidad"], "Valor", "Valor"));
            for (int i = 0; i < dtDatos.Rows.Count; i++)
            {
                decimal precio = 0;
                //Ajustar Periodo en funcion a la condicion de pago.
                //POR AHORA CONDICION DE PAGO FIJA (90 dias = 3 meses).
                DateTime fechaAux = Convert.ToDateTime("01/" + dtDatos.Rows[i]["Periodo"].ToString().Substring(4, 2) + "/" + dtDatos.Rows[i]["Periodo"].ToString().Substring(0, 4));
                string nuevoPeriodo = fechaAux.AddMonths(3).ToString("yyyyMM");
                //
                if (Convert.ToInt32(nuevoPeriodo) <= Convert.ToInt32(PeriodoHasta))
                {
                    DataRow dr = dt.NewRow();
                    dr["Periodo"] = nuevoPeriodo;
                    CedForecastEntidades.Bejerman.Articulos articulo = articulos.Find(delegate(CedForecastEntidades.Bejerman.Articulos c) { return c.Art_CodGen == Convert.ToString(dtDatos.Rows[i]["Articulo"]); });
                    if (articulo == null)
                    {
                        dr["Articulo"] = Convert.ToString(dtDatos.Rows[i]["Articulo"]) + "-<<<Desconocido>>>";
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-Forecast-01", "Descripción no encontrada para el artículo " + Convert.ToString(dtDatos.Rows[i]["Articulo"]), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                        precio = 0;
                    }
                    else
                    {
                        dr["Articulo"] = Convert.ToString(dtDatos.Rows[i]["Articulo"]) + "-" + articulo.Art_DescGen;
                        precio = articulo.Lpr_Precio;
                    }
                    if (precio == 0)
                    {
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-Forecast-02", "Precio no encontrado para el artículo " + Convert.ToString(dtDatos.Rows[i]["Articulo"]), CedForecastEntidades.Advertencia.TipoSeveridad.Error));
                    }
                    //Zona
                    CedForecastEntidades.Bejerman.Zona zona = zonas.Find(delegate(CedForecastEntidades.Bejerman.Zona c) { return c.Zon_Cod == Convert.ToString(dtDatos.Rows[i]["Zona"]); });
                    if (zona == null)
                    {
                        dr["Zona"] = Convert.ToString(dtDatos.Rows[i]["Zona"]) + "-<<<Desconocido>>>";
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-Forecast-03", "Descripción no encontrada para la zona " + Convert.ToString(dtDatos.Rows[i]["Zona"]), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                    }
                    else
                    {
                        dr["Zona"] = Convert.ToString(dtDatos.Rows[i]["Zona"]); // +"-" + zona.Zon_Desc;
                    }
                    //Cliente
                    CedForecastEntidades.Bejerman.Clientes cliente = clientes.Find(delegate(CedForecastEntidades.Bejerman.Clientes c) { return c.Cli_Cod == Convert.ToString(dtDatos.Rows[i]["Cliente"]); });
                    if (cliente == null)
                    {
                        dr["Cliente"] = Convert.ToString(dtDatos.Rows[i]["Cliente"]);
                        dr["Nombre"] = "<<<Desconocido>>>";
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-Forecast-04", "Descripción no encontrada para el cliente " + Convert.ToString(dtDatos.Rows[i]["Cliente"]) + "-" + dr["Nombre"].ToString(), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                    }
                    else
                    {
                        dr["Cliente"] = Convert.ToString(dtDatos.Rows[i]["Cliente"]); // + "-" + cliente.Cli_RazSoc;
                        dr["Nombre"] = Convert.ToString(dtDatos.Rows[i]["Nombre"]);
                    }
                    if (articulo == null)
                    {
                        precio = 0;
                    }
                    else
                    {
                        precio = articulo.Lpr_Precio;
                    }
                    decimal valor = Convert.ToDecimal(dtDatos.Rows[i]["Cantidad"]) * precio;
                    dr["Valor"] = valor;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
        public static DataSet StockXArticulo(string PeriodoDesde, string TipoReporte, string ListaArticulos, bool Valorizado, CedEntidades.Sesion Sesion, out List<CedForecastEntidades.Advertencia> Advertencias)
        {
            List<CedForecastEntidades.Advertencia> advertencias = new List<CedForecastEntidades.Advertencia>();
            //Validacion de parámetros
            if (ListaArticulos == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Articulo(s)");
            }
            //(1) Buscar Articulos que están en Bejerman ( que tengan STOCK cargado o Nota de Pedido en Bj ) y esos artículos no estén ingresados en la aplicación CedForecast.
            //Emitir advertencia.
            //(2) Leer lista de artículos CedForecast de ArticuloInfoAdicional, Verificar que todos tengan la Familia ingresada, 
            //de lo contrario emitir advertencia.
            //(3) Leer Stock Real de Tabla de Stock (B) (+) 
            //    Leer Notas de Pedido (NPA = Autorizadas) (B) (-)
            //    Leer Embarques (L) (+)
            //    Leer Forecast (L) (-)

            //Leer datos Forecast
            CedForecastDB.Forecast db = new CedForecastDB.Forecast(Sesion);
            DataSet ds = db.LeerDatosParaStockXArticulo(PeriodoDesde, TipoReporte, ListaArticulos);

            DataTable dtArticulos = ds.Tables[0].Copy();
            DataTable dtFamilias = ds.Tables[1].Copy();
            //Forecast
            DataTable dtForecast = ds.Tables[2].Copy();
            //Embarques
            DataTable dtOrdenesDeCompra = ds.Tables[3].Copy();
            //Stock
            DataTable dtStock = ds.Tables[4];
            //Notas de Pedido Ptes de remitir
            DataTable dtNotasDePedidoPtes = ds.Tables[5].Copy();
            //Notas de Pedido (del mes remitidas disminuye el forecast)
            DataTable dtNotasDePedido = ds.Tables[6].Copy();
            //Baja de Remitos de Notas de Pedido 
            DataTable dtNotasDePedidoBaja = ds.Tables[7].Copy();

            //Crear nuevo dataset
            //Creamos el DataSet con modificaciones de campos para la Grilla.
            ds = new DataSet();
            ds.Tables.Add(dtFamilias);
            ds.Tables[0].TableName = "Nivel1";
            ds.Tables.Add(dtArticulos);
            ds.Tables[1].TableName = "Nivel2";

            //Crear crosstab
            DataTable dt = new DataTable();
            dt.Columns.Add(ClonarColumna(dtForecast.Columns["Orden"]));
            dt.Columns.Add(ClonarColumna(dtForecast.Columns["TipoDato"]));
            dt.Columns.Add(ClonarColumna(dtForecast.Columns["Descr"]));
            dt.Columns.Add(ClonarColumna(dtForecast.Columns["Familia"]));
            dt.Columns.Add(ClonarColumna(dtForecast.Columns["IdArticulo"]));
            dt.Columns.Add(ClonarColumna(dtForecast.Columns["DescrArticulo"]));
            string idPeriodo = "";
            DateTime periodoDesde = Convert.ToDateTime("01/" + PeriodoDesde.Substring(4, 2) + "/" + PeriodoDesde.Substring(0, 4));
            idPeriodo = periodoDesde.ToString("yyyyMM");
            for (int i = 1; i <= 12; i++)
            {
                dt.Columns.Add(ClonarColumna(dtForecast.Columns["Cantidad"], "_" + idPeriodo, "_" + idPeriodo));
                idPeriodo = periodoDesde.AddMonths(i).ToString("yyyyMM");
            }
            //dt.Columns.Add(ClonarColumna(dtForecast.Columns["Cantidad"], "Total", "Total"));

            //--- Para cálculo del Saldo de Arrastre ---
            for (int i = 0; i < dtArticulos.Rows.Count; i++)
            {
                dt.Rows.Add("1", "Stock", "_Saldo", dtArticulos.Rows[i]["Familia"].ToString(), dtArticulos.Rows[i]["IdArticulo"].ToString(), dtArticulos.Rows[i]["DescrArticulo"].ToString(), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }
            //------------------------------------------

            //Stock
            for (int i = 0; i < dtStock.Rows.Count; i++)
            {
                DataRow[] drv;
                switch (TipoReporte)
                {
                    case "Familia-Articulo":
                        drv = dtArticulos.Select("IdArticulo = '" + dtStock.Rows[i]["IdArticulo"].ToString() + "'");
                        if (drv.Length > 0)
                        {
                            dt.Rows.Add(dtStock.Rows[i]["Orden"].ToString(), dtStock.Rows[i]["TipoDato"].ToString(), dtStock.Rows[i]["Descr"].ToString(), dtArticulos.Rows[0]["Familia"].ToString(), dtStock.Rows[i]["IdArticulo"].ToString(), dtArticulos.Rows[0]["DescrArticulo"].ToString(), dtStock.Rows[i]["Cantidad"].ToString());
                            //--- Para cálculo del Saldo de Arrastre ---
                            DataRow[] dr = dt.Select("TipoDato = 'Stock' and Descr = '_Saldo' and IdArticulo = '" + dtStock.Rows[i]["IdArticulo"].ToString() + "'");
                            if (dr.Length > 0)
                            {
                                string periodoAux = periodoDesde.AddMonths(1).ToString("yyyyMM");
                                dr[0]["_" + periodoAux] = Convert.ToDecimal(dr[0]["_" + periodoAux].ToString()) + Convert.ToDecimal(dtStock.Rows[i]["Cantidad"].ToString());
                                for (int p = 2; p <= 11; p++)
                                {
                                    periodoAux = periodoDesde.AddMonths(p).ToString("yyyyMM");
                                    dr[0]["_" + periodoAux] = Convert.ToDecimal(dtStock.Rows[i]["Cantidad"].ToString());
                                }
                            }
                            //------------------------------------------
                        }
                        break;
                }
            }

            //Ordenes de Compra
            for (int i = 0; i < dtOrdenesDeCompra.Rows.Count; i++)
            {
                DataRow[] drv;
                switch (TipoReporte)
                {
                    case "Familia-Articulo":
                        drv = dtArticulos.Select("IdArticulo = '" + dtOrdenesDeCompra.Rows[i]["IdArticulo"].ToString() + "'");
                        if (drv.Length > 0)
                        {
                            dt.Rows.Add(dtOrdenesDeCompra.Rows[i]["Orden"].ToString(), dtOrdenesDeCompra.Rows[i]["TipoDato"].ToString(), dtOrdenesDeCompra.Rows[i]["Descr"], drv[0]["Familia"].ToString(), dtOrdenesDeCompra.Rows[i]["IdArticulo"].ToString(), drv[0]["DescrArticulo"].ToString());
                            dt.Rows[dt.Rows.Count - 1]["_" + dtOrdenesDeCompra.Rows[i]["Periodo"].ToString()] = dtOrdenesDeCompra.Rows[i]["Cantidad"].ToString();
                        }
                        break;
                }
            }
            
            //Forecast
            for (int i = 0; i < dtForecast.Rows.Count; i++)
            {
                DataRow[] drv;
                switch (TipoReporte)
                {
                    case "Familia-Articulo":
                        drv = dtArticulos.Select("IdArticulo = '" + dtForecast.Rows[i]["IdArticulo"].ToString() + "'");
                        if (drv.Length > 0)
                        {
                            DataRow[] drAux = dt.Select("TipoDato = '" + dtForecast.Rows[i]["TipoDato"] + "' and IdArticulo = '" + dtForecast.Rows[i]["IdArticulo"].ToString() + "'");
                            if (drAux.Length == 0)
                            {
                                dt.Rows.Add(dtForecast.Rows[i]["Orden"].ToString(), dtForecast.Rows[i]["TipoDato"].ToString(), dtForecast.Rows[i]["Descr"], drv[0]["Familia"].ToString(), dtForecast.Rows[i]["IdArticulo"].ToString(), drv[0]["DescrArticulo"].ToString());
                                dt.Rows[dt.Rows.Count - 1]["_" + dtForecast.Rows[i]["Periodo"].ToString()] = Convert.ToDecimal(dtForecast.Rows[i]["Cantidad"].ToString()) * -1;
                            }
                            else
                            {
                                drAux[0]["_" + dtForecast.Rows[i]["Periodo"].ToString()] = Convert.ToDecimal(dtForecast.Rows[i]["Cantidad"].ToString()) * -1;
                            }
                        }
                        break;
                }
            }

            //Notas de Pedido (Remitos Ptes)
            for (int i = 0; i < dtNotasDePedidoPtes.Rows.Count; i++)
            {
                DataRow[] drv;
                switch (TipoReporte)
                {
                    case "Familia-Articulo":
                        drv = dtArticulos.Select("IdArticulo = '" + dtNotasDePedidoPtes.Rows[i]["IdArticulo"].ToString() + "'");
                        if (drv.Length > 0)
                        {
                            dt.Rows.Add(dtNotasDePedidoPtes.Rows[i]["Orden"].ToString(), dtNotasDePedidoPtes.Rows[i]["TipoDato"].ToString(), dtNotasDePedidoPtes.Rows[i]["Descr"].ToString(), drv[0]["Familia"].ToString(), dtNotasDePedidoPtes.Rows[i]["IdArticulo"].ToString(), drv[0]["DescrArticulo"].ToString());
                            dt.Rows[dt.Rows.Count - 1]["_" + periodoDesde.ToString("yyyyMM")] = Convert.ToDecimal(dtNotasDePedidoPtes.Rows[i]["Cantidad_Pend_RT"]) * -1;

                            //--- Para cálculo del Saldo de Arrastre ---
                            DataRow[] dr = dt.Select("TipoDato = 'Stock' and Descr = '_Saldo' and IdArticulo = '" + dtNotasDePedidoPtes.Rows[i]["IdArticulo"].ToString() + "'");
                            if (dr.Length > 0)
                            {
                                string periodoAux = periodoDesde.AddMonths(1).ToString("yyyyMM");
                                dr[0]["_" + periodoAux] = Convert.ToDecimal(dr[0]["_" + periodoAux].ToString()) + Convert.ToDecimal(dtNotasDePedidoPtes.Rows[i]["Cantidad_Pend_RT"]) * -1;
                            }
                            //------------------------------------------

                            //Verificar si no fue dado de BAJA el articulo de la NP.
                            DataRow[] drAuxNPB = dtNotasDePedidoBaja.Select("IdArticulo = '" + dtNotasDePedidoPtes.Rows[i]["IdArticulo"].ToString() + "' and TipoComprobante = 'REM' and NroComprobante = '" + dtNotasDePedidoPtes.Rows[i]["NroComprobante"].ToString() + "'");
                            if (drAuxNPB.Length != 0)
                            {
                                dt.Rows.Add(drAuxNPB[0]["Orden"].ToString(), drAuxNPB[0]["TipoDato"].ToString(), drAuxNPB[0]["Descr"].ToString(), drv[0]["Familia"].ToString(), drAuxNPB[0]["IdArticulo"].ToString(), drv[0]["DescrArticulo"].ToString());
                                dt.Rows[dt.Rows.Count - 1]["_" + periodoDesde.ToString("yyyyMM")] = Convert.ToDecimal(drAuxNPB[0]["Cantidad_Total"]) * -1;
                                
                                //--- Para cálculo del Saldo de Arrastre ---
                                dr = dt.Select("TipoDato = 'Stock' and Descr = '_Saldo' and IdArticulo = '" + dtNotasDePedidoPtes.Rows[i]["IdArticulo"].ToString() + "'");
                                if (dr.Length > 0)
                                {
                                    string periodoAux = periodoDesde.AddMonths(1).ToString("yyyyMM");
                                    dr[0]["_" + periodoAux] = Convert.ToDecimal(dr[0]["_" + periodoAux].ToString()) + Convert.ToDecimal(drAuxNPB[0]["Cantidad_Total"]) * -1;
                                }
                                //------------------------------------------
                            }
                        }
                        break;
                }
            }

            //Resumen del Forecast (del Mes)
            DataTable dtResumenXArticulo = new DataTable();
            dtResumenXArticulo.Columns.Add(ClonarColumna(dtForecast.Columns["Orden"]));
            dtResumenXArticulo.Columns.Add(ClonarColumna(dtForecast.Columns["TipoDato"]));
            dtResumenXArticulo.Columns.Add(ClonarColumna(dtForecast.Columns["Descr"]));
            dtResumenXArticulo.Columns.Add(ClonarColumna(dtForecast.Columns["IdArticulo"]));
            dtResumenXArticulo.Columns.Add(ClonarColumna(dtForecast.Columns["Cantidad"]));

            DataRow[] dtForecastDelMes = dtForecast.Select("Periodo = '" + periodoDesde.ToString("yyyyMM") + "'");
            for (int i = 0; i < dtForecastDelMes.Length; i++)
            {
                DataRow[] drv;
                switch (TipoReporte)
                {
                    case "Familia-Articulo":
                        drv = dtArticulos.Select("IdArticulo = '" + dtForecastDelMes[i]["IdArticulo"].ToString() + "'");
                        if (drv.Length > 0)
                        {
                            dtResumenXArticulo.Rows.Add(dtForecastDelMes[i]["Orden"].ToString(), dtForecastDelMes[i]["TipoDato"].ToString() + " del mes", dtForecastDelMes[i]["Descr"].ToString() + " del " + periodoDesde.ToString("MM/yyyy"), dtForecastDelMes[i]["IdArticulo"].ToString(), Convert.ToDecimal(dtForecastDelMes[i]["Cantidad"]) * -1);
                        }
                        break;
                }
            }
            for (int i = 0; i < dtNotasDePedido.Rows.Count; i++)
            {
                DataRow[] drv;
                switch (TipoReporte)
                {
                    case "Familia-Articulo":
                        drv = dtArticulos.Select("IdArticulo = '" + dtNotasDePedido.Rows[i]["IdArticulo"].ToString() + "'");
                        if (drv.Length > 0)
                        {
                            dtResumenXArticulo.Rows.Add(dtNotasDePedido.Rows[i]["Orden"].ToString(), dtNotasDePedido.Rows[i]["TipoDato"].ToString(), dtNotasDePedido.Rows[i]["Descr"].ToString(), dtNotasDePedido.Rows[i]["IdArticulo"].ToString(), dtNotasDePedido.Rows[i]["Cantidad_Total"].ToString());
                            //Verivicar si no fue dada de BAJA la NP.
                            DataRow[] drAuxNPB = dtNotasDePedidoBaja.Select("IdArticulo = '" + dtNotasDePedido.Rows[i]["IdArticulo"].ToString() + "' and TipoComprobante = 'REM' and NroComprobante = '" + dtNotasDePedido.Rows[i]["NroComprobante"].ToString() + "'");
                            if (drAuxNPB.Length != 0)
                            {
                                dtResumenXArticulo.Rows.Add(dtNotasDePedidoBaja.Rows[i]["Orden"].ToString(), dtNotasDePedidoBaja.Rows[i]["TipoDato"].ToString(), dtNotasDePedidoBaja.Rows[i]["Descr"].ToString(), dtNotasDePedidoBaja.Rows[i]["IdArticulo"].ToString(), Convert.ToDecimal(dtNotasDePedidoBaja.Rows[i]["Cantidad_Total"]) * -1);
                            }

                            //----- Para el periodo actual del Forecast se le descuentan las NP remitidas y se suman las anulaciones del las NP.
                            //----- para NP sin remitos Ptes.
                            DataRow[] drAuxForecast = dt.Select("TipoDato = 'Forecast' and IdArticulo = '" + dtNotasDePedido.Rows[i]["IdArticulo"].ToString() + "'");
                            if (drAuxForecast.Length != 0)
                            {
                                decimal valorForecast = 0;
                                if (drAuxForecast[0]["_" + periodoDesde.ToString("yyyyMM")] != System.DBNull.Value)
                                {
                                    valorForecast = Convert.ToDecimal(drAuxForecast[0]["_" + periodoDesde.ToString("yyyyMM")]);
                                }
                                decimal valorNP = Convert.ToDecimal(dtNotasDePedido.Rows[i]["Cantidad_Total"].ToString());
                                drAuxForecast[0]["_" + periodoDesde.ToString("yyyyMM")] = valorForecast + valorNP;
                                //Verificar si no fue dado de BAJA el articulo de la NP.
                                DataRow[] drAuxForecastNPB = dtNotasDePedidoBaja.Select("IdArticulo = '" + dtNotasDePedido.Rows[i]["IdArticulo"].ToString() + "' and TipoComprobante = 'REM' and NroComprobante = '" + dtNotasDePedido.Rows[i]["NroComprobante"].ToString() + "'");
                                if (drAuxForecastNPB.Length != 0)
                                {
                                    valorForecast = 0;
                                    if (drAuxForecast[0]["_" + periodoDesde.ToString("yyyyMM")] != System.DBNull.Value)
                                    {
                                        valorForecast = Convert.ToDecimal(drAuxForecast[0]["_" + periodoDesde.ToString("yyyyMM")]);
                                    }
                                    valorNP = Convert.ToDecimal(drAuxForecastNPB[0]["Cantidad_Total"]);
                                    drAuxForecast[0]["_" + periodoDesde.ToString("yyyyMM")] = valorForecast - valorNP;
                                }
                            }
                            //-----
                        }
                        break;
                }
            }
            for (int i = 0; i < dtNotasDePedidoPtes.Rows.Count; i++)
            {
                DataRow[] drv;
                switch (TipoReporte)
                {
                    case "Familia-Articulo":
                        drv = dtArticulos.Select("IdArticulo = '" + dtNotasDePedidoPtes.Rows[i]["IdArticulo"].ToString() + "'");
                        if (drv.Length > 0)
                        {
                            if (Convert.ToDateTime(dtNotasDePedidoPtes.Rows[i]["Fecha_Emision"]).ToString("yyyyMM") == periodoDesde.ToString("yyyyMM"))
                            {
                                dtResumenXArticulo.Rows.Add(dtNotasDePedidoPtes.Rows[i]["Orden"].ToString(), dtNotasDePedidoPtes.Rows[i]["TipoDato"].ToString() + " del mes", dtNotasDePedidoPtes.Rows[i]["Descr"].ToString(), dtNotasDePedidoPtes.Rows[i]["IdArticulo"].ToString(), dtNotasDePedidoPtes.Rows[i]["Cantidad_Pend_RT"].ToString());
                                //Verificar si no fue dada de BAJA la NP.
                                DataRow[] drAuxNPB = dtNotasDePedidoBaja.Select("IdArticulo = '" + dtNotasDePedidoPtes.Rows[i]["IdArticulo"].ToString() + "' and TipoComprobante = 'REM' and NroComprobante = '" + dtNotasDePedidoPtes.Rows[i]["NroComprobante"].ToString() + "'");
                                if (drAuxNPB.Length != 0)
                                {
                                    dtResumenXArticulo.Rows.Add(dtNotasDePedidoBaja.Rows[i]["Orden"].ToString(), dtNotasDePedidoBaja.Rows[i]["TipoDato"].ToString(), dtNotasDePedidoBaja.Rows[i]["Descr"].ToString(), dtNotasDePedidoBaja.Rows[i]["IdArticulo"].ToString(), Convert.ToDecimal(dtNotasDePedidoBaja.Rows[i]["Cantidad_Total"]));
                                }
                                
                                ////----- Para el periodo actual del Forecast se le descuentan las NP Ptes de remito y se suman las anulaciones del las NP.
                                ////----- para NP sin remitos Ptes.
                                //DataRow[] drAuxForecast = dt.Select("TipoDato = 'Forecast' and IdArticulo = '" + dtNotasDePedidoPtes.Rows[i]["IdArticulo"].ToString() + "'");
                                //if (drAuxForecast.Length != 0)
                                //{
                                //    decimal valorForecast = Convert.ToDecimal(drAuxForecast[0]["_" + periodoDesde.ToString("yyyyMM")]);
                                //    decimal valorNP = Convert.ToDecimal(dtNotasDePedido.Rows[i]["Cantidad_Total"].ToString());
                                //    drAuxForecast[0]["_" + periodoDesde.ToString("yyyyMM")] = valorForecast + valorNP;
                                //    //Verificar si no fue dado de BAJA el articulo de la NP.
                                //    DataRow[] drAuxForecastNPB = dtNotasDePedidoBaja.Select("IdArticulo = '" + dtNotasDePedidoPtes.Rows[i]["IdArticulo"].ToString() + "' and TipoComprobante = 'REM' and NroComprobante = '" + dtNotasDePedido.Rows[i]["NroComprobante"].ToString() + "'");
                                //    if (drAuxForecastNPB.Length != 0)
                                //    {
                                //        valorForecast = Convert.ToDecimal(drAuxForecast[0]["_" + periodoDesde.ToString("yyyyMM")]);
                                //        valorNP = Convert.ToDecimal(drAuxForecastNPB[0]["Cantidad_Total"]);
                                //        drAuxForecast[0]["_" + periodoDesde.ToString("yyyyMM")] = valorForecast - valorNP;
                                //    }
                                //}
                                //-----
                            }
                        }
                        break;
                }
            }
            //(A) - Recorrer el Forecast y si hay importes negativos informar cero.
            dtForecastDelMes = dt.Select("TipoDato = 'Forecast'");
            for (int i = 0; i < dtForecastDelMes.Length; i++)
            {
                DataRow[] drv;
                switch (TipoReporte)
                {
                    case "Familia-Articulo":
                        drv = dtArticulos.Select("IdArticulo = '" + dtForecastDelMes[i]["IdArticulo"].ToString() + "'");
                        if (drv.Length > 0)
                        {
                            DataRow[] drAuxForecast = dt.Select("TipoDato = 'Forecast' and IdArticulo = '" + dtForecastDelMes[i]["IdArticulo"].ToString() + "'");
                            if (drAuxForecast.Length > 0)
                            {
                                if (drAuxForecast[0]["_" + periodoDesde.ToString("yyyyMM")].GetType() != typeof(System.DBNull) && Convert.ToDecimal(drAuxForecast[0]["_" + periodoDesde.ToString("yyyyMM")]) > 0)
                                {
                                    drAuxForecast[0]["_" + periodoDesde.ToString("yyyyMM")] = 0;
                                }
                            }
                        }
                        break;
                }
            }

            idPeriodo = periodoDesde.ToString("yyyyMM");
            for (int p = 1; p <= 11; p++)
            {
                DataRow[] drGrilla = dt.Select("TipoDato = 'Forecast'");
                for (int i = 0; i < drGrilla.Length; i++)
                {
                    //--- Para cálculo del Saldo de Arrastre ---
                    DataRow[] dr = dt.Select("TipoDato = 'Stock' and Descr = '_Saldo' and IdArticulo = '" + drGrilla[i]["IdArticulo"].ToString() + "'");
                    if (dr.Length > 0)
                    {
                        string periodoAux = periodoDesde.AddMonths(p).ToString("yyyyMM");
                        decimal cantidad = 0;
                        if (drGrilla[i]["_" + idPeriodo] != System.DBNull.Value)
                        {
                            cantidad = Convert.ToDecimal(drGrilla[i]["_" + idPeriodo]);
                        }
                        if (p == 1)
                        {
                            dr[0]["_" + periodoAux] = Convert.ToDecimal(dr[0]["_" + idPeriodo].ToString()) + Convert.ToDecimal(dr[0]["_" + periodoAux].ToString()) + cantidad;
                        }
                        else
                        {
                            dr[0]["_" + periodoAux] = Convert.ToDecimal(dr[0]["_" + idPeriodo].ToString()) + cantidad;
                        }
                    }
                    //------------------------------------------
                }
                DataRow[] drOrdenesDeCompra = dtOrdenesDeCompra.Select("Periodo = '" + idPeriodo + "'");
                for (int i = 0; i < drOrdenesDeCompra.Length; i++)
                {
                    //--- Para cálculo del Saldo de Arrastre ---
                    DataRow[] dr = dt.Select("TipoDato = 'Stock' and Descr = '_Saldo' and IdArticulo = '" + drOrdenesDeCompra[i]["IdArticulo"].ToString() + "'");
                    if (dr.Length > 0)
                    {
                        string periodoAux = periodoDesde.AddMonths(1).ToString("yyyyMM");
                        decimal cantidad = 0;
                        if (drOrdenesDeCompra[i]["Cantidad"] != System.DBNull.Value)
                        {
                            cantidad = Convert.ToDecimal(drOrdenesDeCompra[i]["Cantidad"]);
                        }
                        dr[0]["_" + periodoAux] = Convert.ToDecimal(dr[0]["_" + periodoAux].ToString()) + cantidad;
                    }
                    //------------------------------------------
                }
                idPeriodo = periodoDesde.AddMonths(p).ToString("yyyyMM");
            }

            ds.Tables.Add(dt);
            ds.Tables[2].TableName = "Nivel3";

            ds.Tables.Add(dtResumenXArticulo);
            ds.Tables[3].TableName = "Nivel4";

            ds.Relations.Add("Nivel1_Nivel2", ds.Tables["Nivel1"].Columns["Familia"], ds.Tables["Nivel2"].Columns["Familia"]);
            ds.Relations.Add("Nivel2_Nivel3", ds.Tables["Nivel2"].Columns["IdArticulo"], ds.Tables["Nivel3"].Columns["IdArticulo"]);
            ds.Relations.Add("Nivel2_Nivel4", ds.Tables["Nivel2"].Columns["IdArticulo"], ds.Tables["Nivel4"].Columns["IdArticulo"]);

            Advertencias = advertencias;
            return ds;
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
            List<CedForecastEntidades.ArticuloInfoAdicional> familiaXArticulos = new CedForecastDB.ArticuloInfoAdicional(Sesion).LeerLista();
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
                string familia = "";
                CedForecastEntidades.ArticuloInfoAdicional articuloInfoAdicional = familiaXArticulos.Find(delegate(CedForecastEntidades.ArticuloInfoAdicional c) { return c.IdArticulo == Convert.ToString(ventas[i].Sdvart_CodGen); });
                if (articuloInfoAdicional != null)
                {
                    familia = articuloInfoAdicional.IdFamiliaArticulo;
                }
                DataRow[] drv;
                switch (TipoReporte)
                {
                    case "Zona-Familia-Articulo":
                        drv = dtDatos.Select("Zona = '" + ventas[i].Zona + "' and Articulo = '" + ventas[i].Sdvart_CodGen + "' and Periodo = '" + ventas[i].Periodo + "'");
                        if (drv.Length == 0)
                        {

                            dtDatos.Rows.Add("Empresa", ventas[i].Zona, familia, ventas[i].Sdvart_CodGen, ventas[i].Sdvart_CodGen, ventas[i].Periodo, 0);
                        }
                        break;
                    case "Vendedor-Familia-Articulo":
                        drv = dtDatos.Select("Vendedor = '" + ventas[i].Vendedor + "' and Articulo = '" + ventas[i].Sdvart_CodGen + "' and Periodo = '" + ventas[i].Periodo + "'");
                        if (drv.Length == 0)
                        {
                            dtDatos.Rows.Add("Empresa", ventas[i].Vendedor, familia, ventas[i].Sdvart_CodGen, ventas[i].Sdvart_CodGen, ventas[i].Periodo, 0);
                        }
                        break;
                }
            }
            //Ordenar datos
            switch (TipoReporte)
            {
                case "Zona-Familia-Articulo":
                    dtDatos.DefaultView.Sort = "Zona ASC, Familia ASC, Articulo ASC";
                    break;
                case "Vendedor-Familia-Articulo":
                    dtDatos.DefaultView.Sort = "Vendedor ASC, Familia ASC, Articulo ASC";
                    break;
            }
            
            for (int i = 0; i < dtDatos.DefaultView.Count; i++)
            {
                string claveActual = Convert.ToString(dtDatos.DefaultView[i][1]) + Convert.ToString(dtDatos.DefaultView[i]["Familia"]) + Convert.ToString(dtDatos.DefaultView[i]["Articulo"]);
                if (claveAnterior != claveActual)
                {
                    DataRow dr = dt.NewRow();
                    dr["Empresa"] = "Empresa";
                    CedForecastEntidades.ArticuloInfoAdicional familiaXArticulo = familiaXArticulos.Find(delegate(CedForecastEntidades.ArticuloInfoAdicional c) { return c.IdArticulo == Convert.ToString(dtDatos.DefaultView[i]["Articulo"]); });
                    if (familiaXArticulo == null)
                    {
                        dr["Familia"] = "<<<Desconocida>>>";
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-01", "Artículo " + Convert.ToString(dtDatos.DefaultView[i]["Articulo"]) + " sin familia definida", CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                    }
                    else
                    {
                        dr["Familia"] = familiaXArticulo.DescrFamiliaArticulo;
                    }
                    CedForecastEntidades.Bejerman.Articulos articulo = articulos.Find(delegate(CedForecastEntidades.Bejerman.Articulos c) { return c.Art_CodGen == Convert.ToString(dtDatos.DefaultView[i]["Articulo"]); });
                    if (articulo == null)
                    {
                        dr["Articulo"] = Convert.ToString(dtDatos.DefaultView[i]["Articulo"]) + "-<<<Desconocido>>>";
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-02", "Descripción no encontrada para el artículo " + Convert.ToString(dtDatos.DefaultView[i]["Articulo"]), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                        precio = 0;
                    }
                    else
                    {
                        dr["Articulo"] = Convert.ToString(dtDatos.DefaultView[i]["Articulo"]) + "-" + articulo.Art_DescGen;
                        precio = articulo.Lpr_Precio;
                    }
                    if (precio == 0)
                    {
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-03", "Precio no encontrado para el artículo " + Convert.ToString(dtDatos.DefaultView[i]["Articulo"]), CedForecastEntidades.Advertencia.TipoSeveridad.Error));
                    }
                    switch (TipoReporte)
                    {
                        case "Zona-Familia-Articulo":
                            CedForecastEntidades.Bejerman.Zona zona = zonas.Find(delegate(CedForecastEntidades.Bejerman.Zona c) { return c.Zon_Cod == Convert.ToString(dtDatos.DefaultView[i]["Zona"]); });
                            if (zona == null)
                            {
                                dr["Zona"] = Convert.ToString(dtDatos.DefaultView[i]["Zona"]) + "-<<<Desconocido>>>";
                                Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-04", "Descripción no encontrada para la zona " + Convert.ToString(dtDatos.DefaultView[i]["Zona"]), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                            }
                            else
                            {
                                dr["Zona"] = Convert.ToString(dtDatos.DefaultView[i]["Zona"]) + "-" + zona.Zon_Desc;
                            }
                            break;
                        case "Vendedor-Familia-Articulo":
                            CedForecastEntidades.Bejerman.Vendedor vendedor = vendedores.Find(delegate(CedForecastEntidades.Bejerman.Vendedor c) { return c.Ven_Cod == Convert.ToString(dtDatos.DefaultView[i]["Vendedor"]); });
                            if (vendedor == null)
                            {
                                dr["Vendedor"] = Convert.ToString(dtDatos.DefaultView[i]["Vendedor"]) + "-<<<Desconocido>>>";
                                Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-04", "Descripción no encontrada para el vendedor " + Convert.ToString(dtDatos.DefaultView[i]["Vendedor"]), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                            }
                            else
                            {
                                dr["Vendedor"] = Convert.ToString(dtDatos.DefaultView[i]["Vendedor"]) + "-" + vendedor.Ven_Desc;
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
                decimal valor = Convert.ToDecimal(dtDatos.DefaultView[i]["Cantidad"]) * precio;
                dt.Rows[dt.Rows.Count - 1]["Plan-" + dtDatos.DefaultView[i]["Periodo"].ToString()] = valor;
                //Completo ventas
                CedForecastEntidades.Bejerman.Ventas venta = new CedForecastEntidades.Bejerman.Ventas();
                switch (TipoReporte)
                {
                    case "Zona-Familia-Articulo":
                        venta = ventas.Find((delegate(CedForecastEntidades.Bejerman.Ventas e) { return e.Zona == dtDatos.DefaultView[i]["Zona"].ToString() && e.Sdvart_CodGen == dtDatos.DefaultView[i]["Articulo"].ToString() && e.Periodo == dtDatos.DefaultView[i]["Periodo"].ToString(); }));
                        break;
                    case "Vendedor-Familia-Articulo":
                        venta = ventas.Find((delegate(CedForecastEntidades.Bejerman.Ventas e) { return e.Vendedor == dtDatos.DefaultView[i]["Vendedor"].ToString() && e.Sdvart_CodGen == dtDatos.DefaultView[i]["Articulo"].ToString() && e.Periodo == dtDatos.DefaultView[i]["Periodo"].ToString(); }));
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
                    dt.Rows[dt.Rows.Count - 1]["Real-" + dtDatos.DefaultView[i]["Periodo"].ToString()] = valorReal;
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
            List<CedForecastEntidades.ArticuloInfoAdicional> familiaXArticulos = new CedForecastDB.ArticuloInfoAdicional(Sesion).LeerLista();
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
                    CedForecastEntidades.ArticuloInfoAdicional articuloConFamilia = familiaXArticulos.Find(delegate(CedForecastEntidades.ArticuloInfoAdicional c) { return c.IdArticulo == Convert.ToString(dtDatos.Rows[i]["Articulo"]); });
                    if (articuloConFamilia == null)
                    {
                        dr["Familia"] = "<<<Desconocida>>>";
                        Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-01", "Artículo " + Convert.ToString(dtDatos.Rows[i]["Articulo"]) + " sin familia definida", CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                    }
                    else
                    {
                        dr["Familia"] = articuloConFamilia.DescrFamiliaArticulo;
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