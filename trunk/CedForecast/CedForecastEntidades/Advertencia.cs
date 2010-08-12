using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    [Serializable]
    public class Advertencia
    {
        public enum TipoSeveridad { Aviso, Advertencia, Error }

        private string id;
        private string descr;
        private TipoSeveridad severidad;

        public Advertencia(string Id, string Descr, TipoSeveridad Severidad)
        {
            id = Id;
            descr = Descr;
            severidad = Severidad;
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
        public TipoSeveridad Severidad
        {
            set
            {
                severidad = value;
            }
            get
            {
                return severidad;
            }
        }
        public string Tipo
        {
            get
            {
                return severidad.ToString();
            }
        }
    }
}