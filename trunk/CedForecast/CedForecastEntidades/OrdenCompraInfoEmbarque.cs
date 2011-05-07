using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    public class OrdenCompraInfoEmbarque
    {
        string idReferenciaSAP;                 //varchar(20)
        DateTime fechaEstimadaSalida;
        string vapor;                           //varchar(20)
        DateTime fechaEstimadaArribo;

        public OrdenCompraInfoEmbarque()
        { 
        }

        public string IdReferenciaSAP
        {
            get
            {
                return idReferenciaSAP;
            }
            set
            {
                idReferenciaSAP = value;
            }
        }
        public DateTime FechaEstimadaSalida
        {
            get
            {
                return fechaEstimadaSalida;
            }
            set
            {
                fechaEstimadaSalida = value;
            }
        }
        public string Vapor
        {
            get
            {
                return vapor;
            }
            set
            {
                vapor = value;
            }
        }
        public DateTime FechaEstimadaArribo
        {
            get
            {
                return fechaEstimadaArribo;
            }
            set
            {
                fechaEstimadaArribo = value;
            }
        }
    }
}
