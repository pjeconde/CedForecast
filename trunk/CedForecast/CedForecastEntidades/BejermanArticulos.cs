using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades.Bejerman
{
    [Serializable]
    public class Articulos
    {
        private string art_CodGen;
        private string art_DescGen;
        private decimal art_PesoBruto;
        private string artcla_Cod;
        private string artda2_cod;
        private DateTime art_FecMod;
        private decimal lpr_Precio;

        public Articulos()
        {
        }
        public string Art_CodGen
        {
            set
            {
                art_CodGen = value;
            }
            get
            {
                return art_CodGen;
            }
        }
        public string Art_DescGen
        {
            set
            {
                art_DescGen = value;
            }
            get
            {
                return art_DescGen;
            }
        }
        public string Art_CodDescGen
        {
            get
            {
                return art_CodGen + "-" + art_DescGen;
            }
        }
        public decimal Art_PesoBruto
        {
            set
            {
                art_PesoBruto = value;
            }
            get
            {
                return art_PesoBruto;
            }
        }
        public string Artcla_Cod
        {
            set
            {
                artcla_Cod = value;
            }
            get
            {
                return artcla_Cod;
            }
        }
        public string Artda2_cod
        {
            set
            {
                artda2_cod = value;
            }
            get
            {
                return artda2_cod;
            }
        }
        public DateTime Art_FecMod
        {
            set
            {
                art_FecMod = value;
            }
            get
            {
                return art_FecMod;
            }
        }
        public decimal Lpr_Precio
        {
            set
            {
                lpr_Precio = value;
            }
            get
            {
                return lpr_Precio;
            }
        }
    }
}