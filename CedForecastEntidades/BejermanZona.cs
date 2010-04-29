using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades.Bejerman
{
    [Serializable]
    public class Zona
    {
        private string zon_Cod;
        private string zon_Desc;
        private DateTime zon_FecMod;

        public Zona()
        {
        }
        public string Zon_Cod
        {
            set
            {
                zon_Cod = value;
            }
            get
            {
                return zon_Cod;
            }
        }
        public string Zon_Desc
        {
            set
            {
                zon_Desc = value;
            }
            get
            {
                return zon_Desc;
            }
        }
        public DateTime Zon_FecMod
        {
            set
            {
                zon_FecMod = value;
            }
            get
            {
                return zon_FecMod;
            }
        }
    }
}