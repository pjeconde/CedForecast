using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    public class OrdenCompraInfoAlta
    {
        string prefijo;                         //varchar(3)
        int id;
        string idProveedor;                     //varchar(3)
        string descrProveedor;                  //varchar(30)
        DateTime fecha;
        string idPaisOrigen;                    //varchar(3)
        string descrPaisOrigen;                 //varchar(30)
        DateTime fechaEstimadaArriboRequerida;
        string comentario;                      //varchar(255)
        List<CedForecastEntidades.OrdenCompraInfoAltaMinuta> minutas;
        int idOpWF;

        public OrdenCompraInfoAlta()
        {
            minutas = new List<OrdenCompraInfoAltaMinuta>();
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
        public List<CedForecastEntidades.OrdenCompraInfoAltaMinuta> Minutas
        {
            get
            {
                return minutas;
            }
            set
            {
                minutas = value;
            }
        }
        public int IdOpWF
        {
            get
            {
                return idOpWF;
            }
            set
            {
                idOpWF = value;
            }
        }
    }
}
