using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades
{
    [Serializable]
    public class Articulo
    {
        private string id;
        private string descr;
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
        public string IdFamilia
        {
            set
            {
                Familia.Id = value;
            }
            get
            {
                return Familia.Id;
            }
        }
        public string DescrFamilia
        {
            set
            {
                Familia.Descr = value;
            }
            get
            {
                return Familia.Descr;
            }
        }
    }
}