using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class TableroForm : Cedeira.UI.frmBase
    {
        public TableroForm(string Titulo) : base(Titulo)
        {
            InitializeComponent();
            VersionVerticalLabel.Text = "Versión " + Aplicacion.Version;
            TipoOpcion_Click(ConfigDBasicosUiButton, EventArgs.Empty);
        }
        private void SalirUiButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TipoOpcion_Click(object sender, EventArgs e)
        {
            List<CedForecastEntidades.Opcion> opciones = new List<CedForecastEntidades.Opcion>();
            switch (((Janus.Windows.EditControls.UIButton)sender).Tag.ToString())
            {
                case "Config.datos básicos":
                    opciones.Add(new CedForecastEntidades.Opcion("ArticuloInfoAdicional", "Artículos Info Adicional"));
                    opciones.Add(new CedForecastEntidades.Opcion("FamiliaArticulo", "Familias de artículos"));
                    opciones.Add(new CedForecastEntidades.Opcion("Moneda", "Tabla de Monedas"));
                    opciones.Add(new CedForecastEntidades.Opcion("PaisOrigen", "Tabla de Paises de origen"));
                    opciones.Add(new CedForecastEntidades.Opcion("Proveedor", "Tabla de Proveedores"));
                    break;
                case "Consultas":
                    opciones.Add(new CedForecastEntidades.Opcion("RFoPA", "Rolling Forecast - Proyectado Anual"));
                    opciones.Add(new CedForecastEntidades.Opcion("CrossTabArticulosClientes", "Crosstab Articulos-Clientes"));
                    opciones.Add(new CedForecastEntidades.Opcion("ResumenArgentinaXZonas", "Resumen Argentina por Zonas"));
                    opciones.Add(new CedForecastEntidades.Opcion("Financiero", "Financiero"));
                    opciones.Add(new CedForecastEntidades.Opcion("FamiliaArticuloXArticulo", "Familias de Artículos"));
                     break;
                case "Exploradores":
                    opciones.Add(new CedForecastEntidades.Opcion("OrdenCompra", "Órdenes de Compra"));
                    break;
                case "Graficos":
                    break;
                case "Interfaces":
                    break;
                case "Procesos":
                    opciones.Add(new CedForecastEntidades.Opcion("Sincronizacion", "Sincronización"));
                    break;
            }
            OpcionGridEX.DataSource=opciones;
            TipoOpcionLabel.Text = ((Janus.Windows.EditControls.UIButton)sender).Tag.ToString();
            TipoOpcionLabel.Tag = ((Janus.Windows.EditControls.UIButton)sender).Tag.ToString();
        }
        private void OpcionGridEX_Click(object sender, EventArgs e)
        {
            {
                Cursor = Cursors.WaitCursor;
                System.Windows.Forms.Form oFrm;
                try
                {
                    if (OpcionGridEX.Row >= 0)
                    {
                        string aux = ((List<CedForecastEntidades.Opcion>)OpcionGridEX.DataSource)[OpcionGridEX.Row].Id;
                        switch (TipoOpcionLabel.Tag.ToString())
                        {
                            case "Config.datos básicos":
                                switch (aux)
                                {
                                    case "ArticuloInfoAdicional":
                                        oFrm = new ArticuloInfoAdicionalGrillaForm(((List<CedForecastEntidades.Opcion>)OpcionGridEX.DataSource)[OpcionGridEX.Row].Descr);
                                        oFrm.ShowDialog();
                                        break;
                                    case "FamiliaArticulo":
                                        oFrm = new FamiliaArticuloGrillaForm(((List<CedForecastEntidades.Opcion>)OpcionGridEX.DataSource)[OpcionGridEX.Row].Descr);
                                        oFrm.ShowDialog();
                                        break;
                                    case "Moneda":
                                    case "PaisOrigen":
                                    case "Proveedor":
                                        oFrm = new TablaGrillaForm(((List<CedForecastEntidades.Opcion>)OpcionGridEX.DataSource)[OpcionGridEX.Row]);
                                        oFrm.ShowDialog();
                                        break;
                                    default:
                                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.OpcionInvalida();
                                }
                                break;
                            case "Consultas":
                                switch (aux)
                                {
                                    case "FamiliaArticuloXArticulo":
                                        oFrm = new FamiliaArticuloXArticuloForm(((List<CedForecastEntidades.Opcion>)OpcionGridEX.DataSource)[OpcionGridEX.Row].Descr);
                                        oFrm.ShowDialog();
                                        break;
                                    case "CrossTabArticulosClientes":
                                        oFrm = new CrossTabArticulosClientesForm(((List<CedForecastEntidades.Opcion>)OpcionGridEX.DataSource)[OpcionGridEX.Row].Descr);
                                        oFrm.ShowDialog();
                                        break;
                                    case "ResumenArgentinaXZonas":
                                        oFrm = new ResumenArgentinaXZonasForm(((List<CedForecastEntidades.Opcion>)OpcionGridEX.DataSource)[OpcionGridEX.Row].Descr);
                                        oFrm.ShowDialog();
                                        break;
                                    case "Financiero":
                                        oFrm = new FinancieroForm(((List<CedForecastEntidades.Opcion>)OpcionGridEX.DataSource)[OpcionGridEX.Row].Descr);
                                        oFrm.ShowDialog();
                                        break;
                                    case "RFoPA":
                                        oFrm = new RFoPAForm(((List<CedForecastEntidades.Opcion>)OpcionGridEX.DataSource)[OpcionGridEX.Row].Descr);
                                        oFrm.ShowDialog();
                                        break;
                                    default:
                                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.OpcionInvalida();
                                }
                                break;
                            case "Exploradores":
                                switch (aux)
                                {
                                    case "OrdenCompra":
                                        //oFrm = new FamiliaArticuloGrillaForm(((List<CedForecastEntidades.Opcion>)OpcionGridEX.DataSource)[OpcionGridEX.Row].Descr);
                                        //oFrm.ShowDialog();
                                        break;
                                    default:
                                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.OpcionInvalida();
                                }
                                break;
                            case "Graficos":
                                switch (aux)
                                {
                                    default:
                                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.OpcionInvalida();
                                }
                            case "Interfaces":
                                switch (aux)
                                {
                                    default:
                                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.OpcionInvalida();
                                }
                            case "Procesos":
                                aux = ((List<CedForecastEntidades.Opcion>)OpcionGridEX.DataSource)[OpcionGridEX.Row].Id;
                                switch (aux)
                                {
                                    case "Sincronizacion":
                                        oFrm = new SincronizacionForm(((List<CedForecastEntidades.Opcion>)OpcionGridEX.DataSource)[OpcionGridEX.Row].Descr);
                                        oFrm.ShowDialog();
                                        break;
                                    default:
                                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.OpcionInvalida();
                                }
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
                }
                finally
                {
                    oFrm = null;
                    Cursor = Cursors.Default;
                }
            }
        }
    }
}
