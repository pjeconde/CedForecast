using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class PaginaDefault
    {
        private string id;
        private string descr;
        private string uRL;

        public PaginaDefault()
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
        public string URL
        {
            set
            {
                uRL = value;
            }
            get
            {
                return uRL;
            }
        }
    }
}