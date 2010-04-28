using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Articulo
    {
        private string idArticulo;
        private string descrArticulo;
        private string unidadMedida;
        private decimal pesoBruto;
        private bool habilitado; 
        private DateTime fechaUltModif;
        private CedForecastWebEntidades.GrupoArticulo grupoArticulo;

        public Articulo()
        {
            grupoArticulo = new GrupoArticulo();
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
        public decimal PesoBruto
        {
            set
            {
                pesoBruto = value;
            }
            get
            {
                return pesoBruto;
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
        public bool Habilitado
        {
            set
            {
                habilitado = value;
            }
            get
            {
                return habilitado;
            }
        }
        public DateTime FechaUltModif
        {
            set
            {
                fechaUltModif = value;
            }
            get
            {
                return fechaUltModif;
            }
        }
        public CedForecastWebEntidades.GrupoArticulo GrupoArticulo
        {
            set
            {
                grupoArticulo = value;
            }
            get
            {
                return grupoArticulo;
            }
        }
    }
}

