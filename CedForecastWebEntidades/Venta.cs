using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Venta
    {
        private string idPeriodo;
        private string idArticulo;
        private string idCliente;
        private decimal cantidad;

        public Venta()
        {
        }
        public string IdPeriodo
        {
            set
            {
                idPeriodo = value;
            }
            get
            {
                return idPeriodo;
            }
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
        public decimal Cantidad
        {
            set
            {
                cantidad = value;
            }
            get
            {
                return cantidad;
            }
        }
    }
}