using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Cliente
    {
        private string id;
        private string descr;
        private CedForecastWebEntidades.Zona zona;
        private bool habilitado;
        private DateTime fechaUltModif;

        public Cliente()
        {
            zona = new CedForecastWebEntidades.Zona();
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
        public CedForecastWebEntidades.Zona Zona
        {
            set
            {
                zona = value;
            }
            get
            {
                return zona;
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
    }
}

