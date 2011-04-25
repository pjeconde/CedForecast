using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    [Serializable]
    public class Opcion
    {
        protected string id;
        protected string descr;

        public Opcion()
        {
        }
        public Opcion(string Id, string Descr)
        {
            id = Id;
            descr = Descr;
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