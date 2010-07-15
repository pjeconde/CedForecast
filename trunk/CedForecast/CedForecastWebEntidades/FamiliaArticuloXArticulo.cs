using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class FamiliaArticuloXArticulo
    {
        private string id;
        private FamiliaArticulo familia;

        public FamiliaArticuloXArticulo()
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