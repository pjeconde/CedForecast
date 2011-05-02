using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class OrdenCompraRecepcionDocumentosForm : Cedeira.UI.frmBase
    {
        static string titulo = "Recepción de Documentos";

        public OrdenCompraRecepcionDocumentosForm() : base(titulo)
        {
            InitializeComponent();
        }
    }
}