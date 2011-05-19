using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class OrdenCompraActualizacionInfoEmbarqueForm : Cedeira.UI.frmBase
    {
        public OrdenCompraActualizacionInfoEmbarqueForm(string Titulo)
            : base(Titulo)
        {
            InitializeComponent();
            DirectorioPlanillaInfoEmbarqueEditBox.Text = CedForecastRN.PlanillaInfoEmbarque.LeerDirectorio(Aplicacion.Sesion);
        }
        private void AceptarUiButton_Click(object sender, EventArgs e)
        {

        }
        private void ExaminarUiButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "Planillas Excel (*.xls)|*.xls|Todos (*.*)|*.*";
            oFD.FileName = "";
            if (oFD.ShowDialog() == DialogResult.OK)
            {
                DirectorioPlanillaInfoEmbarqueEditBox.Text = oFD.FileName;
                CedForecastRN.PlanillaInfoEmbarque.GuardarDirectorio(DirectorioPlanillaInfoEmbarqueEditBox.Text, Aplicacion.Sesion);
            }
        }
    }
}