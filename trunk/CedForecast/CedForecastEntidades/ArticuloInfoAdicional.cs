using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    public class ArticuloInfoAdicional
    {
        private string idArticulo;
        private string descrArticulo;
        private string idFamiliaArticulo;
        private string descrFamiliaArticulo;
        private string idArticuloOrigen;
        private string idRENAR;
        private string descrRENAR;
        private string idSENASA;
        private string idPresentacion;
        private int cantidadXPresentacion;
        private int cantidadXContenedor;
        private string unidadMedida;
        private decimal precio;
        private string idMoneda;
        private DateTime fechaVigenciaPrecio;
        private decimal coeficienteGastosNacionalizacion;
        private int cantidadStockSeguridad;
        private int plazoAvisoStockSeguridad;
        private string comentario;

        public ArticuloInfoAdicional()
        { 
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
        public string DescrArticulo
        {
            set
            {
                descrArticulo = value;
            }
            get
            {
                return descrArticulo;
            }
        }
        public string IdFamiliaArticulo
        {
            set
            {
                idFamiliaArticulo = value;
            }
            get
            {
                return idFamiliaArticulo;
            }
        }
        public string DescrFamiliaArticulo
        {
            set
            {
                descrFamiliaArticulo = value;
            }
            get
            {
                return descrFamiliaArticulo;
            }
        }
        public string IdArticuloOrigen
        {
            set
            {
                idArticuloOrigen = value;
            }
            get
            {
                return idArticuloOrigen;
            }
        }
        public string IdRENAR
        {
            set
            {
                idRENAR = value;
            }
            get
            {
                return idRENAR;
            }
        }
        public string DescrRENAR
        {
            set
            {
                descrRENAR = value;
            }
            get
            {
                return descrRENAR;
            }
        }
        public string IdSENASA
        {
            set
            {
                idSENASA = value;
            }
            get
            {
                return idSENASA;
            }
        }
        public string IdPresentacion
        {
            set
            {
                idPresentacion = value;
            }
            get
            {
                return idPresentacion;
            }
        }
        public int CantidadXPresentacion
        {
            set
            {
                cantidadXPresentacion = value;
            }
            get
            {
                return cantidadXPresentacion;
            }
        }
        public int CantidadXContenedor
        {
            set
            {
                cantidadXContenedor = value;
            }
            get
            {
                return cantidadXContenedor;
            }
        }
        public string UnidadMedida
        {
            set
            {
                unidadMedida = value;
            }
            get
            {
                return unidadMedida;
            }
        }
        public decimal Precio
        {
            set
            {
                precio = value;
            }
            get
            {
                return precio;
            }
        }
        public string IdMoneda
        {
            set
            {
                idMoneda = value;
            }
            get
            {
                return idMoneda;
            }
        }
        public DateTime FechaVigenciaPrecio
        {
            set
            {
                fechaVigenciaPrecio = value;
            }
            get
            {
                return fechaVigenciaPrecio;
            }
        }
        public decimal CoeficienteGastosNacionalizacion
        {
            set
            {
                coeficienteGastosNacionalizacion = value;
            }
            get
            {
                return coeficienteGastosNacionalizacion;
            }
        }
        public int CantidadStockSeguridad
        {
            set
            {
                cantidadStockSeguridad = value;
            }
            get
            {
                return cantidadStockSeguridad;
            }
        }
        public int PlazoAvisoStockSeguridad
        {
            set
            {
                plazoAvisoStockSeguridad = value;
            }
            get
            {
                return plazoAvisoStockSeguridad;
            }
        }
        public string Comentario
        {
            set
            {
                comentario = value;
            }
            get
            {
                return comentario;
            }
        }
    }
}
