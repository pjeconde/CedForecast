using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class OrdenCompraDetalleCompletoForm : Cedeira.UI.frmBase
    {
        public OrdenCompraDetalleCompletoForm(string Evento, CedForecastEntidades.OrdenCompra OrdenCompra) : base(TituloForm(Evento, OrdenCompra))
        {
            InitializeComponent();
            //Llenar combos
            LlenarComboProveedor();
            LlenarComboPaisOrigen();
            LlenarComboArticulo();
            LlenarComboMoneda();
            List<CedEntidades.Estado> estados = Cedeira.SV.WF.IdEstadoCombo(Aplicacion.Sesion);
            IdEstadoUiComboBox.DataSource = estados;
            IdEstadoUiComboBox.ValueMember = "IdEstado";
            IdEstadoUiComboBox.DisplayMember = "DescrEstado";
            //Llenar campos
            FechaCalendarCombo.Value = OrdenCompra.Fecha;
            FechaEstimadaArriboRequeridaCalendarCombo.Value = OrdenCompra.FechaEstimadaArriboRequerida;
            IdProveedorUiComboBox.SelectedValue = OrdenCompra.IdProveedor;
            IdPaisOrigenUiComboBox.SelectedValue = OrdenCompra.IdPaisOrigen;
            PrefijoEditBox.Text = OrdenCompra.Prefijo;
            IdArticuloUiComboBox.SelectedValue = OrdenCompra.IdArticulo;
            CantidadContenedoresNumericEditBox.Value = OrdenCompra.CantidadContenedores;
            ComentarioContenedoresEditBox.Text = OrdenCompra.ComentarioContenedores;
            CantidadPresentacionNumericEditBox.Value = OrdenCompra.CantidadPresentacion;
            CantidadNumericEditBox.Value = OrdenCompra.Cantidad;
            IdMonedaUiComboBox.SelectedValue = OrdenCompra.IdMoneda;
            PrecioNumericEditBox.Value = OrdenCompra.Precio;
            ImporteNumericEditBox.Value = OrdenCompra.Importe;
            ImporteGastosNacionalizacionNumericEditBox.Value = OrdenCompra.ImporteGastosNacionalizacion;
            IdReferenciaSAPEditBox.Text = OrdenCompra.IdReferenciaSAP;
            FechaEstimadaSalidaCalendarCombo.Value = OrdenCompra.FechaEstimadaSalida;
            VaporEditBox.Text = OrdenCompra.Vapor;
            FechaEstimadaArriboCalendarCombo.Value = OrdenCompra.FechaEstimadaArribo;
            NroConocimientoEmbarqueEditBox.Text = OrdenCompra.NroConocimientoEmbarque;
            FacturaEditBox.Text = OrdenCompra.Factura;
            FechaRecepcionDocumentosCalendarCombo.Value = OrdenCompra.FechaRecepcionDocumentos;
            FechaIngresoAPuertoCalendarCombo.Value = OrdenCompra.FechaIngresoAPuerto;
            NroDespachoEditBox.Text = OrdenCompra.NroDespacho;
            FechaOficializacionCalendarCombo.Value = OrdenCompra.FechaOficializacion;
            FechaInspeccionRENARCalendarCombo.Value = OrdenCompra.FechaInspeccionRENAR;
            FechaIngresoDepositoCalendarCombo.Value = OrdenCompra.FechaIngresoDeposito;
            IdEstadoUiComboBox.SelectedValue = OrdenCompra.WF.IdEstado;
            //Inhabilitar campos
            if (Evento == "Consulta")
            {
                FechaCalendarCombo.Enabled = false;
                FechaEstimadaArriboRequeridaCalendarCombo.Enabled = false;
                IdProveedorUiComboBox.Enabled = false;
                IdPaisOrigenUiComboBox.Enabled = false;
                PrefijoEditBox.Enabled = false;
                IdArticuloUiComboBox.Enabled = false;
                CantidadContenedoresNumericEditBox.Enabled = false;
                ComentarioContenedoresEditBox.Enabled = false;
                CantidadPresentacionNumericEditBox.Enabled = false;
                CantidadNumericEditBox.Enabled = false;
                IdMonedaUiComboBox.Enabled = false;
                PrecioNumericEditBox.Enabled = false;
                ImporteNumericEditBox.Enabled = false;
                ImporteGastosNacionalizacionNumericEditBox.Enabled = false;
                IdReferenciaSAPEditBox.Enabled = false;
                FechaEstimadaSalidaCalendarCombo.Enabled = false;
                VaporEditBox.Enabled = false;
                FechaEstimadaArriboCalendarCombo.Enabled = false;
                NroConocimientoEmbarqueEditBox.Enabled = false;
                FacturaEditBox.Enabled = false;
                FechaRecepcionDocumentosCalendarCombo.Enabled = false;
                FechaIngresoAPuertoCalendarCombo.Enabled = false;
                NroDespachoEditBox.Enabled = false;
                FechaOficializacionCalendarCombo.Enabled = false;
                FechaInspeccionRENARCalendarCombo.Enabled = false;
                FechaIngresoDepositoCalendarCombo.Enabled = false;
                IdEstadoUiComboBox.Enabled = false;
            }
        }
        private void LlenarComboArticulo()
        {
            List<CedForecastEntidades.ArticuloInfoAdicional> articulos = CedForecastRN.ArticuloInfoAdicional.LeerLista(Aplicacion.Sesion);
            IdArticuloUiComboBox.DataSource = articulos;
            IdArticuloUiComboBox.ValueMember = "IdArticulo";
            IdArticuloUiComboBox.DisplayMember = "IdDescrArticulo";
        }
        private void LlenarComboProveedor()
        {
            List<CedForecastEntidades.Codigo> proveedores = CedForecastRN.Tabla.Leer("Proveedor", Aplicacion.Sesion);
            IdProveedorUiComboBox.DataSource = proveedores;
            IdProveedorUiComboBox.ValueMember = "Id";
            IdProveedorUiComboBox.DisplayMember = "Descr";
        }
        private void LlenarComboPaisOrigen()
        {
            List<CedForecastEntidades.Codigo> paisesOrigen = CedForecastRN.Tabla.Leer("PaisOrigen", Aplicacion.Sesion);
            IdPaisOrigenUiComboBox.DataSource = paisesOrigen;
            IdPaisOrigenUiComboBox.ValueMember = "Id";
            IdPaisOrigenUiComboBox.DisplayMember = "Descr";
        }
        private void LlenarComboMoneda()
        {
            List<CedForecastEntidades.Codigo> monedas = CedForecastRN.Tabla.Leer("Moneda", Aplicacion.Sesion);
            IdMonedaUiComboBox.DataSource = monedas;
            IdMonedaUiComboBox.ValueMember = "Id";
            IdMonedaUiComboBox.DisplayMember = "Descr";
        }
        private static string TituloForm(string Evento, CedForecastEntidades.OrdenCompra OrdenCompra)
        {
            if (OrdenCompra.IdItem != "0")
            {
                return Evento + " del Item " + OrdenCompra.IdItem.ToString() + " de la Orden de Compra Nº " + OrdenCompra.Id.ToString();
            }
            else
            {
                return Evento + " de la Orden de Compra Nº " + OrdenCompra.Id.ToString();
            }
        }
        private void IdArticuloUiButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form oFrm = new ArticuloInfoAdicionalGrillaForm("Artículos Info Adicional");
            oFrm.ShowDialog();
            LlenarComboArticulo();
        }
        private void IdProveedorUiButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form oFrm = new TablaGrillaForm(new CedForecastEntidades.Opcion("Proveedor", "Proveedor"));
            oFrm.ShowDialog();
            LlenarComboProveedor();
        }
        private void IdPaisOrigenUiButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form oFrm = new TablaGrillaForm(new CedForecastEntidades.Opcion("PaisOrigen", "Pais de Origen"));
            oFrm.ShowDialog();
            LlenarComboPaisOrigen();
        }
        private void IdMonedaUiButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form oFrm = new TablaGrillaForm(new CedForecastEntidades.Opcion("Moneda", "Monedas"));
            oFrm.ShowDialog();
            LlenarComboMoneda();
        }
    }
}