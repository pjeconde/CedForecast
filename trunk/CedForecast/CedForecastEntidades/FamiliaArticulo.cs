using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    [Serializable]
    public class FamiliaArticulo
    {
        private string id = String.Empty;
        private string descr = String.Empty;
        private List<Articulo> articulos;

        public FamiliaArticulo()
        {
            articulos = new List<Articulo>();
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
        public List<Articulo> Articulos
        {
            set
            {
                articulos = value;
            }
            get
            {
                return articulos;
            }
        }
    }
}