using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    public  class OrdenCompraInfoRecepcionDocumentos
    {
        string nroConocimientoEmbarque;         //varchar(20)
        string factura;                         //varchar(20)
        DateTime fechaRecepcionDocumentos;

        public OrdenCompraInfoRecepcionDocumentos()
        { 
        }

        public string NroConocimientoEmbarque
        {
            get
            {
                return nroConocimientoEmbarque;
            }
            set
            {
                nroConocimientoEmbarque = value;
            }
        }
        public string Factura
        {
            get
            {
                return factura;
            }
            set
            {
                factura = value;
            }
        }
        public DateTime FechaRecepcionDocumentos
        {
            get
            {
                return fechaRecepcionDocumentos;
            }
            set
            {
                fechaRecepcionDocumentos = value;
            }
        }
    }
}
