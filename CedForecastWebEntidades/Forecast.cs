using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Forecast
    {
        private string idCuenta;
        private string idDivision;
        private string idCliente;
        private CedForecastWebEntidades.Articulo articulo;
        private DateTime fecha;
        private decimal cantidad1;
        private decimal cantidad2;
        private decimal cantidad3;
        private decimal cantidad4;
        private decimal cantidad5;
        private decimal cantidad6;
        private decimal cantidad7;
        private decimal cantidad8;
        private decimal cantidad9;
        private decimal cantidad10;
        private decimal cantidad11;
        private decimal cantidad12;

        public Forecast()
        {
            articulo = new Articulo();
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
        public string IdDivision
        {
            set
            {
                idDivision = value;
            }
            get
            {
                return idDivision;
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
        public string DescrArticulo
        {
            get
            {
                return articulo.DescrArticulo;
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
        public DateTime Fecha
        {
            set
            {
                fecha = value;
            }
            get
            {
                return fecha;
            }
        }
        public decimal Cantidad1
        {
            set
            {
                cantidad1 = value;
            }
            get
            {
                return cantidad1;
            }
        }
        public decimal Cantidad2
        {
            set
            {
                cantidad2 = value;
            }
            get
            {
                return cantidad2;
            }
        }
        public decimal Cantidad3
        {
            set
            {
                cantidad3 = value;
            }
            get
            {
                return cantidad3;
            }
        }
        public decimal Cantidad4
        {
            set
            {
                cantidad4 = value;
            }
            get
            {
                return cantidad4;
            }
        }
        public decimal Cantidad5
        {
            set
            {
                cantidad5 = value;
            }
            get
            {
                return cantidad5;
            }
        }
        public decimal Cantidad6
        {
            set
            {
                cantidad6 = value;
            }
            get
            {
                return cantidad6;
            }
        }
        public decimal Cantidad7
        {
            set
            {
                cantidad7 = value;
            }
            get
            {
                return cantidad7;
            }
        }
        public decimal Cantidad8
        {
            set
            {
                cantidad8 = value;
            }
            get
            {
                return cantidad8;
            }
        }
        public decimal Cantidad9
        {
            set
            {
                cantidad9 = value;
            }
            get
            {
                return cantidad9;
            }
        }
        public decimal Cantidad10
        {
            set
            {
                cantidad10 = value;
            }
            get
            {
                return cantidad10;
            }
        }
        public decimal Cantidad11
        {
            set
            {
                cantidad11 = value;
            }
            get
            {
                return cantidad11;
            }
        }
        public decimal Cantidad12
        {
            set
            {
                cantidad12 = value;
            }
            get
            {
                return cantidad12;
            }
        }
    }
}
