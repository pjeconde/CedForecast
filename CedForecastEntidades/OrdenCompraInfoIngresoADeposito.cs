using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    public class OrdenCompraInfoIngresoADeposito
    {
        DateTime fechaIngresoDeposito;

        public OrdenCompraInfoIngresoADeposito()
        { 
        }

        public DateTime FechaIngresoDeposito
        {
            get
            {
                return fechaIngresoDeposito;
            }
            set
            {
                fechaIngresoDeposito = value;
            }
        }
    }
}
