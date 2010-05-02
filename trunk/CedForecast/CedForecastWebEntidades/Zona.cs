using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Zona
    {
        private string id;
        private string descr;
        private bool habilitada;
        private DateTime fechaUltModif;

        public Zona()
        {
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
        public bool Habilitada
        {
            set
            {
                habilitada = value;
            }
            get
            {
                return habilitada;
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