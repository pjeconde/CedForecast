using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Zona
    {
        private string idZona;
        private string descrZona;

        public Zona()
        {
        }
        public string IdZona
        {
            set
            {
                idZona = value;
            }
            get
            {
                return idZona;
            }
        }
        public string DescrZona
        {
            set
            {
                descrZona = value;
            }
            get
            {
                return descrZona;
            }
        }
    }
}