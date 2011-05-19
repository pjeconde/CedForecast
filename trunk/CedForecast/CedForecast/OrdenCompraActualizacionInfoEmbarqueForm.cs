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
        public OrdenCompraActualizacionInfoEmbarqueForm(string Titulo) : base(Titulo)
        {
            InitializeComponent();
            DirectorioPlanillaInfoEmbarqueEditBox.Text = CedForecastRN.PlanillaInfoEmbarque.LeerDirectorio(Aplicacion.Sesion);
        }
        private void AceptarUiButton_Click(object sender, EventArgs e)
        {

        }
    }
}