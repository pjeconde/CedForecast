using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    public class OrdenCompra
    {
        string prefijo;                         //varchar(3)
        int id;
        string idItem;                          //varchar(1)
        string idProveedor;                     //varchar(3)
        string descrProveedor;                  //varchar(30)
        DateTime fecha;
        string idPaisOrigen;                    //varchar(3)
        string descrPaisOrigen;                 //varchar(30)
        string idArticulo;                      //varchar(20)
        string descrArticulo;                   //varchar(50)
        DateTime fechaEstimadaArriboRequerida;
        decimal cantidadContenedores;
        string comentarioContenedores;          //varchar(255)
        int cantidadPresentacion;
        int cantidad;
        string idMoneda;                        //varchar(3)
        decimal precio;                         //decimal(18, 0)
        decimal importe;                        //decimal(18, 0)
        string idReferenciaSAP;                 //varchar(20)
        DateTime fechaEstimadaSalida;
        string vapor;                           //varchar(20)
        DateTime fechaEstimadaArribo;
        string nroConocimientoEmbarque;         //varchar(20)
        string factura;                         //varchar(20)
        DateTime fechaRecepcionDocumentos;
        DateTime fechaIngresoAPuerto;
        string nroDespacho;                     //varchar(20)
        DateTime fechaOficializacion;
        DateTime fechaInspeccionRENAR;
        DateTime fechaIngresoDeposito;
        decimal importeGastosNacionalizacion;
        string comentario;                      //varchar(255)
        CedEntidades.WF wF;
        DateTime fechaNoInformada;

        public OrdenCompra()
        {
            wF = new CedEntidades.WF();
            fechaNoInformada = new DateTime(2000, 1, 1);
        }

        public string Prefijo
        {
            get
            {
                return prefijo;
            }
            set
            {
                prefijo = value;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
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
        public string IdProveedor
        {
            get
            {
                return idProveedor;
            }
            set
            {
                idProveedor = value;
            }
        }
        public string DescrProveedor
        {
            get
            {
                return descrProveedor;
            }
            set
            {
                descrProveedor = value;
            }
        }
        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
            }
        }
        public string IdPaisOrigen
        {
            get
            {
                return idPaisOrigen;
            }
            set
            {
                idPaisOrigen = value;
            }
        }
        public string DescrPaisOrigen
        {
            get
            {
                return descrPaisOrigen;
            }
            set
            {
                descrPaisOrigen = value;
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
        public DateTime FechaEstimadaArriboRequerida
        {
            get
            {
                return fechaEstimadaArriboRequerida;
            }
            set
            {
                fechaEstimadaArriboRequerida = value;
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
        public string FechaEstimadaSalidaFMT
        {
            get
            {
                if (!fechaEstimadaSalida.Equals(fechaNoInformada))
                {
                    return fechaEstimadaSalida.ToString("dd/MM/yyyy");
                }
                else
                {
                    return String.Empty;
                }
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
        public string FechaEstimadaArriboFMT
        {
            get
            {
                if (!fechaEstimadaArribo.Equals(fechaNoInformada))
                {
                    return fechaEstimadaArribo.ToString("dd/MM/yyyy");
                }
                else
                {
                    return String.Empty;
                }
            }
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
        public string FechaRecepcionDocumentosFMT
        {
            get
            {
                if (!fechaRecepcionDocumentos.Equals(fechaNoInformada))
                {
                    return fechaRecepcionDocumentos.ToString("dd/MM/yyyy");
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        public DateTime FechaIngresoAPuerto
        {
            get
            {
                return fechaIngresoAPuerto;
            }
            set
            {
                fechaIngresoAPuerto = value;
            }
        }
        public string FechaIngresoAPuertoFMT
        {
            get
            {
                if (!fechaIngresoAPuerto.Equals(fechaNoInformada))
                {
                    return fechaIngresoAPuerto.ToString("dd/MM/yyyy");
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        public string NroDespacho
        {
            get
            {
                return nroDespacho;
            }
            set
            {
                nroDespacho = value;
            }
        }
        public DateTime FechaOficializacion
        {
            get
            {
                return fechaOficializacion;
            }
            set
            {
                fechaOficializacion = value;
            }
        }
        public string FechaOficializacionFMT
        {
            get
            {
                if (!fechaOficializacion.Equals(fechaNoInformada))
                {
                    return fechaOficializacion.ToString("dd/MM/yyyy");
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        public DateTime FechaInspeccionRENAR
        {
            get
            {
                return fechaInspeccionRENAR;
            }
            set
            {
                fechaInspeccionRENAR = value;
            }
        }
        public string FechaInspeccionRENARFMT
        {
            get
            {
                if (!fechaInspeccionRENAR.Equals(fechaNoInformada))
                {
                    return fechaInspeccionRENAR.ToString("dd/MM/yyyy");
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        public DateTime FechaIngresoDeposito
        {
            get
            {
                return fechaIngresoDeposito;
            }
            set
            {
                fechaIngresoDeposito = value;
            }
        }
        public string FechaIngresoDepositoFMT
        {
            get
            {
                if (!fechaIngresoDeposito.Equals(fechaNoInformada))
                {
                    return fechaIngresoDeposito.ToString("dd/MM/yyyy");
                }
                else
                {
                    return String.Empty;
                }
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
        public string Comentario
        {
            get
            {
                return comentario;
            }
            set
            {
                comentario = value;
            }
        }
        public CedEntidades.WF WF
        {
            get
            {
                return wF;
            }
            set
            {
                wF = value;
            }
        }
        public string IdEstado
        {
            get
            {
                return wF.IdEstado;
            }
        }
        public string DescrEstado
            {
                get
            {
                return wF.DescrEstado;
            }
        }
    }
}
