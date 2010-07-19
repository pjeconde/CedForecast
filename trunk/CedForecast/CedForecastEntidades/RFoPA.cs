using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    [Serializable]
    public class RFoPA
    {
        private string idTipoPlanilla;
        private string idCuenta;
        private Bejerman.Vendedor vendedor;
        private string idCliente;
        private Bejerman.Clientes cliente;
        private Bejerman.Articulos articulo;
        private CedForecastEntidades.Articulo familiaArticulo;
        private string idPeriodo;
        private decimal ventas;
        private decimal proyectado;
        private int cantidadMesesParaDesvio;
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
        private decimal cantidad13;
        private decimal cantidad14;

        public RFoPA()
        {
            articulo = new Bejerman.Articulos();
            vendedor = new Bejerman.Vendedor();
            cliente = new Bejerman.Clientes();
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
            get
            {
                return vendedor.Ven_Cod;
            }
        }
        public Bejerman.Vendedor Vendedor
        {
            set
            {
                vendedor = value;
            }
            get
            {
                return vendedor;
            }
        }
        public string IdDivision
        {
            get
            {
                return articulo.Artda2_cod;
            }
        }
        public Bejerman.Clientes Cliente
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
        public string IdCliente
        {
            get
            {
                return cliente.Cli_Cod;
            }
        }
        public string DescrCliente
        {
            get
            {
                return cliente.Cli_RazSoc;
            }
        }
        public Bejerman.Articulos Articulo
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
        public string IdArticulo
        {
            get
            {
                return articulo.Art_CodGen;
            }
        }
        public string DescrArticulo
        {
            get
            {
                return articulo.Art_DescGen;
            }
        }
        public CedForecastEntidades.Articulo FamiliaArticulo
        {
            set
            {
                familiaArticulo = value;
            }
            get
            {
                return familiaArticulo;
            }
        }
        public string IdFamiliaArticulo
        {
            get
            {
                return familiaArticulo.Familia.Id;
            }
        }
        public string DescrFamiliaArticulo
        {
            get
            {
                return familiaArticulo.Familia.Descr;
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
        public int CantidadMesesParaDesvio
        {
            get
            {
                if (idPeriodo != null && idPeriodo != "" && idTipoPlanilla != null && idTipoPlanilla == "RollingForecast")
                {
                    cantidadMesesParaDesvio = 13 - Convert.ToInt32(idPeriodo.Substring(4, 2));
                }
                else
                {
                    cantidadMesesParaDesvio = 0;
                }
                return cantidadMesesParaDesvio;
            }
        }
        public decimal Desvio
        {
            get
            {
                decimal suma = 0;
                for (int i = 1; i <= CantidadMesesParaDesvio; i++)
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
                return (proyectado - ventas - suma) * -1;
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
        public decimal Cantidad13
        {
            set
            {
                cantidad13 = value;
            }
            get
            {
                return cantidad13;
            }
        }
        public decimal Cantidad14
        {
            set
            {
                cantidad14 = value;
            }
            get
            {
                return cantidad14;
            }
        }
    }
}
