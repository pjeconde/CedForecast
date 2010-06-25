using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    [Serializable]
    public class Opcion
    {
        private string id;
        private string descr;

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