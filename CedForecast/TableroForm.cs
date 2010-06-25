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
            TipoOpcion_Click(ProcesosUiButton, EventArgs.Empty);
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
                case "ConfigDBasicos":
                    break;
                case "Consultas":
                    break;
                case "Exploradores":
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
                        string aux;
                        switch (TipoOpcionLabel.Tag.ToString())
                        {
                            case "ConfigDBasicos":
                                break;
                            case "Consultas":
                                break;
                            case "Exploradores":
                                break;
                            case "Graficos":
                                break;
                            case "Interfaces":
                                break;
                            case "Procesos":
                                aux = ((List<CedForecastEntidades.Opcion>)OpcionGridEX.DataSource)[OpcionGridEX.Row].Id;
                                //aux = Convert.ToString(((DataTable)OpcionGridEX.DataSource).Rows[OpcionGridEX.Row]["IdOpcion"]);
                                switch (aux)
                                {
                                    case "Sincronizacion":
                                        //oFrm = new SincronizacionForm(Convert.ToString(((DataTable)OpcionGridEX.DataSource).Rows[OpcionGridEX.Row]["DescrOpcion"]));
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
