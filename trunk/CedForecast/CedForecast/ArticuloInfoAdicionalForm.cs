using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class ArticuloInfoAdicionalForm : Cedeira.UI.frmBaseEnviarA
    {
        CedForecastEntidades.ArticuloInfoAdicional articuloInfoAdicional;
        string evento;

        public ArticuloInfoAdicionalForm(string Titulo) : base(Titulo)
        {
            articuloInfoAdicional = new CedForecastEntidades.ArticuloInfoAdicional();
            evento = "Alta"; 
            InitializeComponent();
            LlenarCombos(evento);
        }
        public ArticuloInfoAdicionalForm(string Titulo, string Evento, CedForecastEntidades.ArticuloInfoAdicional ArticuloInfoAdicional) : base(Titulo)
        {
            InitializeComponent();
            articuloInfoAdicional = ArticuloInfoAdicional;
            CedForecastRN.ArticuloInfoAdicional.Leer(articuloInfoAdicional, Aplicacion.Sesion);
            evento = Evento;
            LlenarCombos(evento);
            LlenarCampos();
            IdArticuloUiComboBox.Enabled = false;
            switch (evento)
            {
                case "Baja":
                    InhabilitarCampos();
                    AceptarUiButton.Focus();
                    break;
                case "Consulta":
                    InhabilitarCampos();
                    SalirUiButton.Text = "Salir";
                    AceptarUiButton.Visible = false;
                    SalirUiButton.Focus();
                    break;
                case "Modificacion":
                    IdFamiliaArticuloUiComboBox.Focus();
                    break;
            }
        }
        private void LlenarCombos(string Evento)
        {
            List<CedForecastEntidades.Bejerman.Articulos> articulos;
            if (Evento == "Alta")
            {
                articulos = new CedForecastDB.Bejerman.Articulos(Aplicacion.Sesion).LeerLista(new CedForecastDB.ArticuloInfoAdicional(Aplicacion.Sesion).ListaIdArticulos());
            }
            else
            {
                articulos = new CedForecastDB.Bejerman.Articulos(Aplicacion.Sesion).Leer(articuloInfoAdicional.IdArticulo);
            }
            IdArticuloUiComboBox.DataSource = articulos;
            IdArticuloUiComboBox.ValueMember = "Art_CodGen";
            IdArticuloUiComboBox.DisplayMember = "Art_CodDescGen";
            List<CedForecastEntidades.FamiliaArticulo> familiaArticulos = new CedForecastDB.FamiliaArticulo(Aplicacion.Sesion).LeerLista();
            IdFamiliaArticuloUiComboBox.DataSource = familiaArticulos;
            IdFamiliaArticuloUiComboBox.ValueMember = "Id";
            IdFamiliaArticuloUiComboBox.DisplayMember = "Descr";
            List<CedForecastEntidades.Codigo> monedas = CedForecastRN.Tabla.Leer("Moneda", Aplicacion.Sesion);
            IdMonedaUiComboBox.DataSource = familiaArticulos;
            IdMonedaUiComboBox.ValueMember = "Id";
            IdMonedaUiComboBox.DisplayMember = "Descr";
        }
        private void LlenarCampos()
        {
            IdArticuloUiComboBox.SelectedValue = articuloInfoAdicional.IdArticulo;
            IdFamiliaArticuloUiComboBox.SelectedValue = articuloInfoAdicional.IdFamiliaArticulo;
            IdArticuloOrigenEditBox.Text = articuloInfoAdicional.IdArticuloOrigen;
            IdRENAREditBox.Text = articuloInfoAdicional.IdRENAR;
            DescrRENAREditBox.Text = articuloInfoAdicional.DescrRENAR;
            IdSENASAEditBox.Text = articuloInfoAdicional.IdSENASA;
            IdPresentacionEditBox.Text = articuloInfoAdicional.IdPresentacion;
            CantidadXPresentacionNumericEditBox.Value = articuloInfoAdicional.CantidadXPresentacion;
            CantidadXContenedorNumericEditBox.Value = articuloInfoAdicional.CantidadXContenedor;
            UnidadMedidaEditBox.Text = articuloInfoAdicional.UnidadMedida;
            PrecioNumericEditBox.Value = articuloInfoAdicional.Precio;
            FechaVigenciaPrecioCalendarCombo.Value = articuloInfoAdicional.FechaVigenciaPrecio;
            IdMonedaUiComboBox.SelectedValue = articuloInfoAdicional.IdMoneda;
            CoeficienteGastosNacionalizacionNumericEditBox.Value = articuloInfoAdicional.CoeficienteGastosNacionalizacion;
            CantidadStockSeguridadNumericEditBox.Value = articuloInfoAdicional.CantidadStockSeguridad;
            PlazoAvisoStockSeguridadNumericEditBox.Value = articuloInfoAdicional.PlazoAvisoStockSeguridad;
            ComentarioEditBox.Text = articuloInfoAdicional.Comentario;
        }
        private void InhabilitarCampos()
        {
            IdArticuloUiComboBox.Enabled = false;
            IdFamiliaArticuloUiComboBox.Enabled = false;
            IdArticuloOrigenEditBox.Enabled = false;
            IdRENAREditBox.Enabled = false;
            DescrRENAREditBox.Enabled = false;
            IdSENASAEditBox.Enabled = false;
            IdPresentacionEditBox.Enabled = false;
            CantidadXPresentacionNumericEditBox.Enabled = false;
            CantidadXContenedorNumericEditBox.Enabled = false;
            UnidadMedidaEditBox.Enabled = false;
            PrecioNumericEditBox.Enabled = false;
            FechaVigenciaPrecioCalendarCombo.Enabled = false;
            IdMonedaUiComboBox.Enabled = false;
            CoeficienteGastosNacionalizacionNumericEditBox.Enabled = false;
            CantidadStockSeguridadNumericEditBox.Enabled = false;
            PlazoAvisoStockSeguridadNumericEditBox.Enabled = false;
            ComentarioEditBox.Enabled = false;
        }
        private void AceptarUiButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                articuloInfoAdicional.IdArticulo = IdArticuloUiComboBox.SelectedValue.ToString();
                articuloInfoAdicional.IdFamiliaArticulo = IdFamiliaArticuloUiComboBox.SelectedValue.ToString();
                articuloInfoAdicional.IdArticuloOrigen = IdArticuloOrigenEditBox.Text;
                articuloInfoAdicional.IdRENAR = IdRENAREditBox.Text;
                articuloInfoAdicional.DescrRENAR = DescrRENAREditBox.Text;
                articuloInfoAdicional.IdSENASA = IdSENASAEditBox.Text;
                articuloInfoAdicional.IdPresentacion = IdPresentacionEditBox.Text;
                articuloInfoAdicional.CantidadXPresentacion = Convert.ToInt32(CantidadXPresentacionNumericEditBox.Value);
                articuloInfoAdicional.CantidadXContenedor = Convert.ToInt32(CantidadXContenedorNumericEditBox.Value);
                articuloInfoAdicional.UnidadMedida = UnidadMedidaEditBox.Text;
                if (articuloInfoAdicional.Precio != Convert.ToDecimal(PrecioNumericEditBox.Value))
                {
                    FechaVigenciaPrecioCalendarCombo.Value = DateTime.Now;
                }
                articuloInfoAdicional.Precio = Convert.ToDecimal(PrecioNumericEditBox.Value);
                articuloInfoAdicional.FechaVigenciaPrecio = FechaVigenciaPrecioCalendarCombo.Value;
                articuloInfoAdicional.IdMoneda = IdMonedaUiComboBox.Text;
                articuloInfoAdicional.CoeficienteGastosNacionalizacion = Convert.ToDecimal(CoeficienteGastosNacionalizacionNumericEditBox.Value);
                articuloInfoAdicional.CantidadStockSeguridad = Convert.ToInt32(CantidadStockSeguridadNumericEditBox.Value);
                articuloInfoAdicional.PlazoAvisoStockSeguridad = Convert.ToInt32(PlazoAvisoStockSeguridadNumericEditBox.Value);
                articuloInfoAdicional.Comentario = ComentarioEditBox.Text; 
                switch (evento)
                {
                    case "Alta":
                        CedForecastRN.ArticuloInfoAdicional.Crear(articuloInfoAdicional, Aplicacion.Sesion);
                        break;
                    case "Baja":
                        CedForecastRN.ArticuloInfoAdicional.Eliminar(articuloInfoAdicional, Aplicacion.Sesion);
                        break;
                    case "Modificacion":
                        CedForecastRN.ArticuloInfoAdicional.Modificar(articuloInfoAdicional, Aplicacion.Sesion);
                        break;
                    case "Consulta":
                        break;
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }
    }
}