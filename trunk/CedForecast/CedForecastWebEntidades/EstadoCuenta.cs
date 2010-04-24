using System;
using System.Collections.Generic;
using System.Text;
namespace CedForecastWebEntidades
{
    [Serializable]
    public class EstadoCuenta
    {
        private string id;
        private string descr;

        public EstadoCuenta()
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
    }
}