using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class OrdenCompraRegistroDespachoForm : Cedeira.UI.frmBase
    {
        static string titulo = "Registro de Despacho";

        public OrdenCompraRegistroDespachoForm() : base(titulo)
        {
            InitializeComponent();
        }
    }
}