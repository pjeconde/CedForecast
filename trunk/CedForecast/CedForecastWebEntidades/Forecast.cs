using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    /// <comentarios/>
    [Serializable]
    [FileHelpers.DelimitedRecord(";")]
    public class Forecast
    {
        [FileHelpers.FieldIgnored()]
        private string idTipoPlanilla;
        [FileHelpers.FieldIgnored()]
        private string idCuenta;
        [FileHelpers.FieldIgnored()]
        private CedForecastWebEntidades.Cliente cliente;
        [FileHelpers.FieldIgnored()]
        private CedForecastWebEntidades.Articulo articulo;
        
        private string idClienteExportar;
        private string descrClienteExportar;
        private string descrFamiliaArticuloExportar;
        private string idArticuloExportar;
        private string descrArticuloExportar;
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
        public string IdCliente
        {
            get
            {
                idClienteExportar = cliente.Id;
                return cliente.Id;
            }
        }
        public string DescrCliente
        {
            get
            {
                descrClienteExportar = cliente.Descr;
                return cliente.Descr;
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
        public string IdArticulo
        {
            get
            {
                idArticuloExportar = articulo.Id;
                return articulo.Id;
            }
        }
        public string DescrArticulo
        {
            get
            {
                descrArticuloExportar = articulo.Descr;
                return articulo.Descr;
            }
        }
        public string IdFamiliaArticulo
        {
            get
            {
                return articulo.FamiliaArticulo.Id;
            }
        }        
        public string DescrFamiliaArticulo
        {
            get
            {
                descrFamiliaArticuloExportar = articulo.FamiliaArticulo.Descr;
                return articulo.FamiliaArticulo.Descr;
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
