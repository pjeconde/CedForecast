using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades.Bejerman
{
    [Serializable]
    public class Cotizacion
    {
        private string mon_codigo;
        private string mtca_codigo;
        private DateTime mcot_fecha;
        private decimal mcot_cotiza;

        public Cotizacion()
        {
        }
        public string Mon_codigo
        {
            set
            {
                mon_codigo = value;
            }
            get
            {
                return mon_codigo;
            }
        }
        public string Mtca_codigo
        {
            set
            {
                mtca_codigo = value;
            }
            get
            {
                return mtca_codigo;
            }
        }
        public DateTime Mcot_fecha
        {
            set
            {
                mcot_fecha = value;
            }
            get
            {
                return mcot_fecha;
            }
        }
        public decimal Mcot_cotiza
        {
            set
            {
                mcot_cotiza = value;
            }
            get
            {
                return mcot_cotiza;
            }
        }
    }
}