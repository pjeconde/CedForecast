using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace CedForecastWSTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                CedForecastRN.WS.Sincronizacion ws = new CedForecastRN.WS.Sincronizacion();
                ws.Url = "http://190.220.128.12:80/sincronizacion.asmx";
                DateTime fechaUltimaSincronizacion = ws.FechaUltimaSincronizacionZonas();
                textBox1.Text = Convert.ToString(fechaUltimaSincronizacion);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                textBox2.Text = CedForecastRN.SMN.Tiempo();
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