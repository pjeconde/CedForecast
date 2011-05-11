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
        CedForecastEntidades.OrdenCompraInfoAlta ordenCompraInfoAlta;
        int idMinuta;
        public OrdenCompraAltaMinutaForm(CedForecastEntidades.OrdenCompraInfoAlta OrdenCompraInfoAlta, string Titulo) : base(Titulo)
        {
            InitializeComponent();
            LlenarCombos();
            evento = "Alta";
            InhabilitarControles();
            IdArticuloUiComboBox.Enabled = true;
            AceptarUiButton.Enabled = false;
            ordenCompraInfoAlta = OrdenCompraInfoAlta;
        }
        public OrdenCompraAltaMinutaForm(CedForecastEntidades.OrdenCompraInfoAlta OrdenCompraInfoAlta, int IdMinuta, string Evento) : base(Evento + " de minuta de Orden de Compra")
        {
            InitializeComponent();
            LlenarCombos();
            evento = Evento;
            if (evento == "Baja" || evento == "Consulta")
            {
                InhabilitarControles();
            }
            if (evento == "Consulta")
            {
                AceptarUiButton.Visible = false;
                SalirUiButton.Text = "Salir";
            }
            ordenCompraInfoAlta = OrdenCompraInfoAlta;
            idMinuta = IdMinuta;
            AsignarCampos();
        }
        private void AsignarCampos()
        {
            CedForecastEntidades.OrdenCompraInfoAltaMinuta minuta = ordenCompraInfoAlta.Minutas[idMinuta];
            IdArticuloUiComboBox.SelectedValue = minuta.IdArticulo;
            articuloInfoAdicionalSeleccionado = ((List<CedForecastEntidades.ArticuloInfoAdicional>)IdArticuloUiComboBox.Tag)[IdArticuloUiComboBox.SelectedIndex];
            CantidadContenedoresNumericEditBox.Value = minuta.CantidadContenedores;
            ComentarioContenedoresEditBox.Text = minuta.ComentarioContenedores;
            CantidadPresentacionNumericEditBox.Value = minuta.CantidadPresentacion;
            CantidadNumericEditBox.Value = minuta.Cantidad;
            IdMonedaUiComboBox.SelectedValue = minuta.IdMoneda;
            PrecioNumericEditBox.Value = minuta.Precio;
            ImporteNumericEditBox.Value = minuta.Importe;
            ImporteGastosNacionalizacionNumericEditBox.Value = minuta.ImporteGastosNacionalizacion;
        }
        private void InhabilitarControles()
        {
            IdArticuloUiComboBox.Enabled = false;
            CantidadContenedoresNumericEditBox.Enabled = false;
            ComentarioContenedoresEditBox.Enabled = false;
            CantidadPresentacionNumericEditBox.Enabled = false;
            CantidadNumericEditBox.Enabled = false;
            IdMonedaUiComboBox.Enabled = false;
            PrecioNumericEditBox.Enabled = false;
            ImporteNumericEditBox.Enabled = false;
            ImporteGastosNacionalizacionNumericEditBox.Enabled = false;
        }
        private void HabilitarControles()
        {
            IdArticuloUiComboBox.Enabled = true;
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
                HabilitarControles();
                AceptarUiButton.Enabled = true;
            }
        }
        private void IdArticuloUiButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form oFrm = new ArticuloInfoAdicionalGrillaForm("Artículos Info Adicional");
            oFrm.ShowDialog();
            LlenarComboArticulo();
        }
        private void AceptarUiButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (evento)
                {
                    case "Alta":
                    case "Modificación":
                        CedForecastEntidades.OrdenCompraInfoAltaMinuta minuta;
                        minuta = new CedForecastEntidades.OrdenCompraInfoAltaMinuta();
                        minuta.IdArticulo = articuloInfoAdicionalSeleccionado.IdArticulo;
                        minuta.DescrArticulo = articuloInfoAdicionalSeleccionado.DescrArticulo;
                        minuta.CantidadContenedores = Convert.ToDecimal(CantidadContenedoresNumericEditBox.Value);
                        minuta.ComentarioContenedores = ComentarioContenedoresEditBox.Text;
                        minuta.CantidadPresentacion = Convert.ToInt32(CantidadPresentacionNumericEditBox.Value);
                        minuta.Cantidad = Convert.ToInt32(CantidadNumericEditBox.Value);
                        minuta.IdMoneda = IdMonedaUiComboBox.SelectedValue.ToString();
                        minuta.Precio = Convert.ToDecimal(PrecioNumericEditBox.Value);
                        minuta.Importe = Convert.ToDecimal(ImporteNumericEditBox.Value);
                        minuta.ImporteGastosNacionalizacion = Convert.ToDecimal(ImporteGastosNacionalizacionNumericEditBox.Value);
                        if (evento == "Alta")
                        {
                            CedForecastRN.OrdenCompra.ValidacionMinutaNueva(ordenCompraInfoAlta, minuta, Aplicacion.Sesion);
                            ordenCompraInfoAlta.Minutas.Add(minuta);
                        }
                        else
                        {
                            CedForecastRN.OrdenCompra.ValidacionMinutaExistente(ordenCompraInfoAlta, minuta, idMinuta, Aplicacion.Sesion);
                            ordenCompraInfoAlta.Minutas[idMinuta].IdArticulo = minuta.IdArticulo;
                            ordenCompraInfoAlta.Minutas[idMinuta].DescrArticulo = minuta.DescrArticulo;
                            ordenCompraInfoAlta.Minutas[idMinuta].CantidadContenedores = minuta.CantidadContenedores;
                            ordenCompraInfoAlta.Minutas[idMinuta].ComentarioContenedores = minuta.ComentarioContenedores;
                            ordenCompraInfoAlta.Minutas[idMinuta].CantidadPresentacion = minuta.CantidadPresentacion;
                            ordenCompraInfoAlta.Minutas[idMinuta].Cantidad = minuta.Cantidad;
                            ordenCompraInfoAlta.Minutas[idMinuta].IdMoneda = minuta.IdMoneda;
                            ordenCompraInfoAlta.Minutas[idMinuta].Precio = minuta.Precio;
                            ordenCompraInfoAlta.Minutas[idMinuta].Importe = minuta.Importe;
                            ordenCompraInfoAlta.Minutas[idMinuta].ImporteGastosNacionalizacion = minuta.ImporteGastosNacionalizacion;
                        }
                        break;
                    case "Baja":
                        ordenCompraInfoAlta.Minutas.Remove(ordenCompraInfoAlta.Minutas[idMinuta]);
                        break;
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
        private void CantidadContenedoresNumericEditBox_Leave(object sender, EventArgs e)
        {
            try
            {
                CantidadNumericEditBox.Value = Convert.ToInt32(Convert.ToDecimal(CantidadContenedoresNumericEditBox.Value) * articuloInfoAdicionalSeleccionado.CantidadXContenedor);
                if (articuloInfoAdicionalSeleccionado.CantidadXPresentacion != 0)
                {
                    CantidadPresentacionNumericEditBox.Value = Math.Round(Convert.ToDecimal(Convert.ToInt32(CantidadNumericEditBox.Value) / articuloInfoAdicionalSeleccionado.CantidadXPresentacion), 0);
                }
                else
                {
                    CantidadPresentacionNumericEditBox.Value = 0;
                }
                ImporteNumericEditBox.Value = Convert.ToDecimal(Convert.ToInt32(CantidadNumericEditBox.Value) * Convert.ToDecimal(PrecioNumericEditBox.Value));
                ImporteGastosNacionalizacionNumericEditBox.Value = Convert.ToDecimal(ImporteNumericEditBox.Value) * articuloInfoAdicionalSeleccionado.CoeficienteGastosNacionalizacion;
            }
            catch
            {
            }
        }
        private void CantidadNumericEditBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (articuloInfoAdicionalSeleccionado.CantidadXContenedor != 0)
                {
                    CantidadContenedoresNumericEditBox.Value = Math.Round(Convert.ToDecimal(Convert.ToInt32(CantidadNumericEditBox.Value) / articuloInfoAdicionalSeleccionado.CantidadXContenedor), 4);
                }
                else
                {
                    CantidadContenedoresNumericEditBox.Value = 0;
                }
                if (articuloInfoAdicionalSeleccionado.CantidadXPresentacion != 0)
                {
                    CantidadPresentacionNumericEditBox.Value = Math.Round(Convert.ToDecimal(Convert.ToInt32(CantidadNumericEditBox.Value) / articuloInfoAdicionalSeleccionado.CantidadXPresentacion), 0);
                }
                else
                {
                    CantidadPresentacionNumericEditBox.Value = 0;
                }
                ImporteNumericEditBox.Value = Convert.ToDecimal(Convert.ToInt32(CantidadNumericEditBox.Value) * Convert.ToDecimal(PrecioNumericEditBox.Value));
                ImporteGastosNacionalizacionNumericEditBox.Value = Convert.ToDecimal(ImporteNumericEditBox.Value) * articuloInfoAdicionalSeleccionado.CoeficienteGastosNacionalizacion;
            }
            catch
            {
            }
        }
        private void PrecioNumericEditBox_Leave(object sender, EventArgs e)
        {
            try
            {
                ImporteNumericEditBox.Value = Convert.ToDecimal(Convert.ToInt32(CantidadNumericEditBox.Value) * Convert.ToDecimal(PrecioNumericEditBox.Value));
                ImporteGastosNacionalizacionNumericEditBox.Value = Convert.ToDecimal(ImporteNumericEditBox.Value) * articuloInfoAdicionalSeleccionado.CoeficienteGastosNacionalizacion;
            }
            catch
            {
            }
        }
        private void CantidadPresentacionNumericEditBox_Leave(object sender, EventArgs e)
        {
            try
            {
                CantidadNumericEditBox.Value = Convert.ToInt32(Convert.ToDecimal(CantidadPresentacionNumericEditBox.Value) * articuloInfoAdicionalSeleccionado.CantidadXPresentacion);
                if (articuloInfoAdicionalSeleccionado.CantidadXContenedor != 0)
                {
                    CantidadContenedoresNumericEditBox.Value = Math.Round(Convert.ToDecimal(Convert.ToInt32(CantidadNumericEditBox.Value) / articuloInfoAdicionalSeleccionado.CantidadXContenedor), 4);
                }
                else
                {
                    CantidadContenedoresNumericEditBox.Value = 0;
                }
                ImporteNumericEditBox.Value = Convert.ToDecimal(Convert.ToInt32(CantidadNumericEditBox.Value) * Convert.ToDecimal(PrecioNumericEditBox.Value));
                ImporteGastosNacionalizacionNumericEditBox.Value = Convert.ToDecimal(ImporteNumericEditBox.Value) * articuloInfoAdicionalSeleccionado.CoeficienteGastosNacionalizacion;
            }
            catch
            {
            }
        }
    }
}