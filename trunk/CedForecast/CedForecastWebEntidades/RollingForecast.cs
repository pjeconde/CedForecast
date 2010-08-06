using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    /// <comentarios/>
    [Serializable]
    [FileHelpers.DelimitedRecord(";")]
    public class RollingForecast
    {
        [FileHelpers.FieldIgnored()]
        protected string idTipoPlanilla;
        [FileHelpers.FieldIgnored()]
        protected string idCuenta;
        protected string idCliente;
        protected string descrCliente;
        [FileHelpers.FieldIgnored()]
        protected CedForecastWebEntidades.Cliente cliente;
        protected string idArticulo;
        protected string descrArticulo;
        [FileHelpers.FieldIgnored()]
        private CedForecastWebEntidades.Articulo articulo;
        [FileHelpers.FieldIgnored()]
        protected string idPeriodo;
        protected decimal proyectado;
        protected decimal ventas;
        protected decimal desvio;
        protected decimal cantidad1;
        protected decimal cantidad2;
        protected decimal cantidad3;
        protected decimal cantidad4;
        protected decimal cantidad5;
        protected decimal cantidad6;
        protected decimal cantidad7;
        protected decimal cantidad8;
        protected decimal cantidad9;
        protected decimal cantidad10;
        protected decimal cantidad11;
        protected decimal cantidad12;

        public RollingForecast()
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
        public string IdDivision
        {
            get
            {
                return articulo.GrupoArticulo.Division.Id;
            }
        }
        public CedForecastWebEntidades.Cliente Cliente
        {
            set
            {
                cliente = value;
                idCliente = cliente.Id;
                descrCliente = cliente.Descr;
            }
            get
            {
                return cliente;
            }
        }
        public string IdCliente
        {
            get
            {
                return idCliente;
            }
        }
        public string DescrCliente
        {
            get
            {
                return descrCliente;
            }
        }
        public CedForecastWebEntidades.Articulo Articulo
        {
            set
            {
                articulo = value;
                idArticulo = articulo.Id;
                descrArticulo = articulo.Descr;
            }
            get
            {
                return articulo;
            }
        }
        public string IdArticulo
        {
            get
            {
                return idArticulo;
            }
        }
        public string DescrArticulo
        {
            get
            {
                return descrArticulo;
            }
        }
        public string DescrArticuloCombo
        {
            get
            {
                return Articulo.DescrCombo;
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
        public decimal CantidadTotal
        {
            get
            {
                decimal suma = cantidad1 + cantidad2 + cantidad3 + cantidad4 + cantidad5 + cantidad6 + cantidad7 + cantidad8 + cantidad9 + cantidad10 + cantidad11 + cantidad12;
                return suma;
            }
        }

        public decimal Ventas
        {
            set
            {
                ventas = value;
            }
            get
            {
                return ventas;
            }
        }
        public decimal Proyectado
        {
            set
            {
                proyectado = value;
            }
            get
            {
                return proyectado;
            }
        }
        public decimal Desvio
        {
            get
            {
                decimal suma = 0;
                int cantidadMesesParaDesvio = 0;
                if (idPeriodo != null && idPeriodo != "")
                {
                    cantidadMesesParaDesvio = 13 - Convert.ToInt32(idPeriodo.Substring(4, 2));
                }
                for (int i = 1; i <= cantidadMesesParaDesvio; i++)
                {
                    switch (i)
                    {
                        case 1:
                            suma += cantidad1;
                            break;
                        case 2:
                            suma += cantidad2;
                            break;
                        case 3:
                            suma += cantidad3;
                            break;
                        case 4:
                            suma += cantidad4;
                            break;
                        case 5:
                            suma += cantidad5;
                            break;
                        case 6:
                            suma += cantidad6;
                            break;
                        case 7:
                            suma += cantidad7;
                            break;
                        case 8:
                            suma += cantidad8;
                            break;
                        case 9:
                            suma += cantidad9;
                            break;
                        case 10:
                            suma += cantidad10;
                            break;
                        case 11:
                            suma += cantidad11;
                            break;
                        case 12:
                            suma += cantidad12;
                            break;
                    }
                }
                desvio = (proyectado - ventas - suma) * -1;
                return desvio;
            }
        }
    }
}
