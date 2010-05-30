using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    [Serializable]
    public class Forecast
    {
        private string idTipoPlanilla;
        private string idCuenta;
        private string idCliente;
        private string idArticulo;
        private string idPeriodo;
        private decimal cantidad;

        public Forecast()
        {
        }
        public string IdTipoPlanilla
        {
            set
            {
                idTipoPlanilla = value;
            }
            get
            {
                return idTipoPlanilla;
            }
        }
        public string IdCuenta
        {
            set
            {
                idCuenta = value;
            }
            get
            {
                return idCuenta;
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
