using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Articulo
    {
        private string id;
        private string descr;
        private string unidadMedida;
        private decimal pesoBruto;
        private bool habilitado; 
        private DateTime fechaUltModif;
        private CedForecastWebEntidades.GrupoArticulo grupoArticulo;

        public Articulo()
        {
            grupoArticulo = new GrupoArticulo();
        }
        public string Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public string Descr
        {
            set
            {
                descr = value;
            }
            get
            {
                return descr;
            }
        }
        public string DescrCombo
        {
            get
            {
                string descripcion = "";
                if (descr != null && descr != "")
                {
                    descripcion = descr + " (" + grupoArticulo.IdGrupoArticulo + " " + id + ")";
                }
                return descripcion;
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

