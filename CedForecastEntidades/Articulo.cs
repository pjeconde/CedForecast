using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    [Serializable]
    public class Articulo
    {
        private string id;
        private FamiliaArticulo familia;

        public Articulo()
        {
            familia = new FamiliaArticulo();
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
        public FamiliaArticulo Familia
        {
            set
            {
                familia = value;
            }
            get
            {
                return familia;
            }
        }
    }
}