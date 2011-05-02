using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class OrdenCompraIngresoADepositoForm : Cedeira.UI.frmBase
    {
        static string titulo = "Ingreso a Depósito";

        public OrdenCompraIngresoADepositoForm() : base(titulo)
        {
            InitializeComponent();
        }
    }
}