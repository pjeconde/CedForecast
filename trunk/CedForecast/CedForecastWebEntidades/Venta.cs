using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Venta
    {
        private string idArticulo;
        private string idCliente;
        private DateTime fechaForecast;
        private decimal cantidadMesAnterior;
        private decimal cantidadUltimoA�o;

        public Venta()
        {
        }
        public string IdArticulo
        {
            set
            {
                idArticulo = value;
            }
            get
            {
                return idArticulo;
            }
        }
        public string IdCliente
        {
            set
            {
                idCliente = value;
            }
            get
            {
                return idCliente;
            }
        }
        public DateTime FechaForecast
        {
            set
            {
                fechaForecast = value;
            }
            get
            {
                return fechaForecast;
            }
        }
        public decimal CantidadMesAnterior
        {
            set
            {
                cantidadMesAnterior = value;
            }
            get
            {
                return cantidadMesAnterior;
            }
        }
        public decimal CantidadUltimoA�o
        {
            set
            {
                cantidadUltimoA�o = value;
            }
            get
            {
                return cantidadUltimoA�o;
            }
        }
    }
}