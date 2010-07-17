using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CedForecast
{
    public partial class FamiliaArticuloForm : Cedeira.UI.frmBaseEnviarA
    {
        string evento;
        public FamiliaArticuloForm(string Titulo, string Evento) : base(Titulo)
        {
            evento = Evento;
            InitializeComponent();
            switch (evento)
            {
                case "Alta":
                    break;
                case "Baja":
                    break;
                case "Modificacion":
                    break;
                case "Consulta":
                    break;
            }
        }
    }
}

