using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    public class OrdenCompraInfoRegistroDespacho
    {
        DateTime fechaIngresoAPuerto;
        string nroDespacho;                     //varchar(20)
        DateTime fechaOficializacion;

        public OrdenCompraInfoRegistroDespacho()
        { 
        }

        public DateTime FechaIngresoAPuerto
        {
            get
            {
                return fechaIngresoAPuerto;
            }
            set
            {
                fechaIngresoAPuerto = value;
            }
        }
        public string NroDespacho
        {
            get
            {
                return nroDespacho;
            }
            set
            {
                nroDespacho = value;
            }
        }
        public DateTime FechaOficializacion
        {
            get
            {
                return fechaOficializacion;
            }
            set
            {
                fechaOficializacion = value;
            }
        }
    }
}
