using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class OrdenCompraAltaMinutaForm : Cedeira.UI.frmBase
    {
        string evento;
        CedForecastEntidades.ArticuloInfoAdicional articuloInfoAdicionalSeleccionado = new CedForecastEntidades.ArticuloInfoAdicional();

        public OrdenCompraAltaMinutaForm(string Titulo) : base(Titulo)
        {
            InitializeComponent();
            LlenarCombos();
            evento = "Alta";
            Inhabilitarcontroles();
        }
        private void Inhabilitarcontroles()
        {
            CantidadContenedoresNumericEditBox.Enabled = false;
            ComentarioContenedoresEditBox.Enabled = false;
            CantidadPresentacionNumericEditBox.Enabled = false;
            CantidadNumericEditBox.Enabled = false;
            IdMonedaUiComboBox.Enabled = false;
            PrecioNumericEditBox.Enabled = false;
            ImporteNumericEditBox.Enabled = false;
            ImporteGastosNacionalizacionNumericEditBox.Enabled = false;
        }
        private void Habilitarcontroles()
        {
            CantidadContenedoresNumericEditBox.Enabled = true;
            ComentarioContenedoresEditBox.Enabled = true;
            CantidadPresentacionNumericEditBox.Enabled = true;
            CantidadNumericEditBox.Enabled = true;
            IdMonedaUiComboBox.Enabled = true;
            PrecioNumericEditBox.Enabled = true;
            ImporteNumericEditBox.Enabled = true;
            ImporteGastosNacionalizacionNumericEditBox.Enabled = true;
        }
        private void LlenarCombos()
        {
            LlenarComboArticulo();
            LlenarComboMoneda();
        }
        private void LlenarComboArticulo()
        {
            List<CedForecastEntidades.ArticuloInfoAdicional> datos = CedForecastRN.ArticuloInfoAdicional.LeerLista(Aplicacion.Sesion);
            IdArticuloUiComboBox.DataSource = datos;
            IdArticuloUiComboBox.ValueMember = "IdArticulo";
            IdArticuloUiComboBox.DisplayMember = "IdDescrArticulo";
            IdArticuloUiComboBox.Tag = datos;
        }
        private void LlenarComboMoneda()
        {
            List<CedForecastEntidades.Codigo> datos = CedForecastRN.Tabla.Leer("Moneda", Aplicacion.Sesion);
            IdMonedaUiComboBox.DataSource = datos;
            IdMonedaUiComboBox.ValueMember = "Id";
            IdMonedaUiComboBox.DisplayMember = "Descr";
        }
        private void IdMonedaUiButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form oFrm = new TablaGrillaForm(new CedForecastEntidades.Opcion("Moneda", "Monedas"));
            oFrm.ShowDialog();
            LlenarComboMoneda();
        }
        private void IdArticuloUiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            articuloInfoAdicionalSeleccionado = ((List<CedForecastEntidades.ArticuloInfoAdicional>)IdArticuloUiComboBox.Tag)[IdArticuloUiComboBox.SelectedIndex];
            IdMonedaUiComboBox.SelectedValue = articuloInfoAdicionalSeleccionado.IdMoneda;
            PrecioNumericEditBox.Value = articuloInfoAdicionalSeleccionado.Precio;
            PresentacionLabel.Text = articuloInfoAdicionalSeleccionado.IdPresentacion;
            UnidadMedidaLabel.Text = articuloInfoAdicionalSeleccionado.IdUnidadMedida;
            if (evento == "Alta")
            {
                Habilitarcontroles();
            }
        }
        private void IdArticuloUiButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form oFrm = new ArticuloInfoAdicionalGrillaForm("Artículos Info Adicional");
            oFrm.ShowDialog();
            LlenarComboArticulo();
        }
    }
}