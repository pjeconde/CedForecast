using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Forecast
    {
        private string idTipoPlanilla;
        private string idCuenta;
        private CedForecastWebEntidades.Cliente cliente;
        private CedForecastWebEntidades.Articulo articulo;
        private string idPeriodo;
        private decimal cantidad;

        public Forecast()
        {
            articulo = new Articulo();
            cliente = new Cliente();
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
        public CedForecastWebEntidades.Cliente Cliente
        {
            set
            {
                cliente = value;
            }
            get
            {
                return cliente;
            }
        }
        public CedForecastWebEntidades.Articulo Articulo
        {
            set
            {
                articulo = value;
            }
            get
            {
                return articulo;
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
