using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    public class OrdenCompraInfoInspeccionRENAR
    {
        DateTime fechaInspeccionRENAR;

        public OrdenCompraInfoInspeccionRENAR()
        { 
        }

        public DateTime FechaInspeccionRENAR
        {
            get
            {
                return fechaInspeccionRENAR;
            }
            set
            {
                fechaInspeccionRENAR = value;
            }
        }
    }
}
