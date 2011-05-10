using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    public class OrdenCompraInfoAltaMinuta
    {
        string idItem;                          //varchar(1)
        string idArticulo;                      //varchar(20)
        string descrArticulo;                   //varchar(50)
        decimal cantidadContenedores;
        string comentarioContenedores;          //varchar(255)
        int cantidadPresentacion;
        int cantidad;
        string idMoneda;                        //varchar(3)
        decimal precio;                         //decimal(18, 0)
        decimal importe;                        //decimal(18, 0)
        decimal importeGastosNacionalizacion;

        public OrdenCompraInfoAltaMinuta()
        { 
        }

        public string IdItem
        {
            get
            {
                return idItem;
            }
            set
            {
                idItem = value;
            }
        }
        public string IdArticulo
        {
            get
            {
                return idArticulo;
            }
            set
            {
                idArticulo = value;
            }
        }
        public string DescrArticulo
        {
            get
            {
                return descrArticulo;
            }
            set
            {
                descrArticulo = value;
            }
        }
        public decimal CantidadContenedores
        {
            get
            {
                return cantidadContenedores;
            }
            set
            {
                cantidadContenedores = value;
            }
        }
        public string ComentarioContenedores
        {
            get
            {
                return comentarioContenedores;
            }
            set
            {
                comentarioContenedores = value;
            }
        }
        public int CantidadPresentacion
        {
            get
            {
                return cantidadPresentacion;
            }
            set
            {
                cantidadPresentacion = value;
            }
        }
        public int Cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                cantidad = value;
            }
        }
        public string IdMoneda
        {
            get
            {
                return idMoneda;
            }
            set
            {
                idMoneda = value;
            }
        }
        public decimal Precio
        {
            get
            {
                return precio;
            }
            set
            {
                precio = value;
            }
        }
        public decimal Importe
        {
            get
            {
                return importe;
            }
            set
            {
                importe = value;
            }
        }
        public decimal ImporteGastosNacionalizacion
        {
            get
            {
                return importeGastosNacionalizacion;
            }
            set
            {
                importeGastosNacionalizacion = value;
            }
        }
    }
}
