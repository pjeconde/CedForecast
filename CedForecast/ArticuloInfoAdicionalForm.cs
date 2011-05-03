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
            evento = Evento;
            LlenarCombos(evento);
            LlenarCampos();
            InhabilitarCampos();
            switch (evento)
            {
                case "Baja":
                    AceptarUiButton.Focus();
                    break;
                case "Consulta":
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
            LlenarComboFamilias();
            LlenarComboMonedas();
            LlenarComboUnidadesMedida();
        }
        private void LlenarComboFamilias()
        {
            List<CedForecastEntidades.FamiliaArticulo> familiaArticulos = new CedForecastDB.FamiliaArticulo(Aplicacion.Sesion).LeerLista();
            IdFamiliaArticuloUiComboBox.DataSource = familiaArticulos;
            IdFamiliaArticuloUiComboBox.ValueMember = "Id";
            IdFamiliaArticuloUiComboBox.DisplayMember = "Descr";
        }
        private void LlenarComboMonedas()
        {
            List<CedForecastEntidades.Codigo> monedas = CedForecastRN.Tabla.Leer("Moneda", Aplicacion.Sesion);
            IdMonedaUiComboBox.DataSource = monedas;
            IdMonedaUiComboBox.ValueMember = "Id";
            IdMonedaUiComboBox.DisplayMember = "Descr";
        }
        private void LlenarComboUnidadesMedida()
        {
            List<CedForecastEntidades.Codigo> unidadesMedida = CedForecastRN.Tabla.Leer("UnidadMedida", Aplicacion.Sesion);
            IdUnidadMedidaUiComboBox.DataSource = unidadesMedida;
            IdUnidadMedidaUiComboBox.ValueMember = "Id";
            IdUnidadMedidaUiComboBox.DisplayMember = "Descr";
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
            IdUnidadMedidaUiComboBox.SelectedValue = articuloInfoAdicional.IdUnidadMedida;
            PrecioNumericEditBox.Value = articuloInfoAdicional.Precio;
            FechaVigenciaPrecioEditBox.Text = articuloInfoAdicional.FechaVigenciaPrecio.ToString("dd/MM/yyyy HH:mm:ss");
            IdMonedaUiComboBox.SelectedValue = articuloInfoAdicional.IdMoneda;
            CoeficienteGastosNacionalizacionNumericEditBox.Value = articuloInfoAdicional.CoeficienteGastosNacionalizacion;
            CantidadStockSeguridadNumericEditBox.Value = articuloInfoAdicional.CantidadStockSeguridad;
            PlazoAvisoStockSeguridadNumericEditBox.Value = articuloInfoAdicional.PlazoAvisoStockSeguridad;
            ComentarioEditBox.Text = articuloInfoAdicional.Comentario;
        }
        private void InhabilitarCampos()
        {
            IdArticuloUiComboBox.Enabled = false;
            if (evento != "Modificacion")
            {
                IdFamiliaArticuloUiComboBox.Enabled = false;
                IdArticuloOrigenEditBox.Enabled = false;
                IdRENAREditBox.Enabled = false;
                DescrRENAREditBox.Enabled = false;
                IdSENASAEditBox.Enabled = false;
                IdPresentacionEditBox.Enabled = false;
                CantidadXPresentacionNumericEditBox.Enabled = false;
                CantidadXContenedorNumericEditBox.Enabled = false;
                IdUnidadMedidaUiComboBox.Enabled = false;
                PrecioNumericEditBox.Enabled = false;
                IdMonedaUiComboBox.Enabled = false;
                CoeficienteGastosNacionalizacionNumericEditBox.Enabled = false;
                CantidadStockSeguridadNumericEditBox.Enabled = false;
                PlazoAvisoStockSeguridadNumericEditBox.Enabled = false;
                ComentarioEditBox.Enabled = false;
            }
        }
        private void AceptarUiButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                switch (evento)
                {
                    case "Alta":
                    case "Modificacion":
                        articuloInfoAdicional.DescrArticulo = ((CedForecastEntidades.Bejerman.Articulos)IdArticuloUiComboBox.SelectedItem.DataRow).Art_DescGen.ToString();
                        articuloInfoAdicional.IdFamiliaArticulo = IdFamiliaArticuloUiComboBox.SelectedValue.ToString();
                        articuloInfoAdicional.IdArticuloOrigen = IdArticuloOrigenEditBox.Text;
                        articuloInfoAdicional.IdRENAR = IdRENAREditBox.Text;
                        articuloInfoAdicional.DescrRENAR = DescrRENAREditBox.Text;
                        articuloInfoAdicional.IdSENASA = IdSENASAEditBox.Text;
                        articuloInfoAdicional.IdPresentacion = IdPresentacionEditBox.Text;
                        articuloInfoAdicional.CantidadXPresentacion = Convert.ToInt32(CantidadXPresentacionNumericEditBox.Value);
                        articuloInfoAdicional.CantidadXContenedor = Convert.ToInt32(CantidadXContenedorNumericEditBox.Value);
                        articuloInfoAdicional.IdUnidadMedida = IdUnidadMedidaUiComboBox.SelectedValue.ToString();
                        if (articuloInfoAdicional.Precio != Convert.ToDecimal(PrecioNumericEditBox.Value))
                        {
                            FechaVigenciaPrecioEditBox.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        }
                        articuloInfoAdicional.Precio = Convert.ToDecimal(PrecioNumericEditBox.Value);
                        articuloInfoAdicional.FechaVigenciaPrecio = FechaHora(FechaVigenciaPrecioEditBox.Text);
                        articuloInfoAdicional.IdMoneda = IdMonedaUiComboBox.SelectedValue.ToString();
                        articuloInfoAdicional.CoeficienteGastosNacionalizacion = Convert.ToDecimal(CoeficienteGastosNacionalizacionNumericEditBox.Value);
                        articuloInfoAdicional.CantidadStockSeguridad = Convert.ToInt32(CantidadStockSeguridadNumericEditBox.Value);
                        articuloInfoAdicional.PlazoAvisoStockSeguridad = Convert.ToInt32(PlazoAvisoStockSeguridadNumericEditBox.Value);
                        articuloInfoAdicional.Comentario = ComentarioEditBox.Text;
                        if (evento == "Alta")
                        {
                            articuloInfoAdicional.IdArticulo = IdArticuloUiComboBox.SelectedValue.ToString();
                            CedForecastRN.ArticuloInfoAdicional.Crear(articuloInfoAdicional, Aplicacion.Sesion);
                        }
                        else
                        {
                            CedForecastRN.ArticuloInfoAdicional.Modificar(articuloInfoAdicional, Aplicacion.Sesion);
                        }
                        break;
                    case "Baja":
                        CedForecastRN.ArticuloInfoAdicional.Eliminar(articuloInfoAdicional, Aplicacion.Sesion);
                        break;
                    default:
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
        private DateTime FechaHora(string FechaStr)
        {
            DateTime fechaHora = new DateTime(Convert.ToInt32(FechaStr.Substring(6, 4)), Convert.ToInt32(FechaStr.Substring(3, 2)), Convert.ToInt32(FechaStr.Substring(0, 2)), Convert.ToInt32(FechaStr.Substring(11, 2)), Convert.ToInt32(FechaStr.Substring(14, 2)), Convert.ToInt32(FechaStr.Substring(17, 2)));
            return fechaHora;
        }
        private void IdMonedaUiButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form oFrm = new TablaGrillaForm(new CedForecastEntidades.Opcion("Moneda", "Monedas"));
            oFrm.ShowDialog();
            LlenarComboMonedas();
        }
        private void IdFamiliaArticuloUiButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form oFrm = new FamiliaArticuloGrillaForm(new CedForecastEntidades.Opcion("FamiliaArticulo", "Familias de artículos").Descr);
            oFrm.ShowDialog();
            LlenarComboFamilias();
        }
        private void IdUnidadMedidaUiButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form oFrm = new TablaGrillaForm(new CedForecastEntidades.Opcion("UnidadMedida", "Unidades de medidas"));
            oFrm.ShowDialog();
            LlenarComboUnidadesMedida();
        }
    }
}