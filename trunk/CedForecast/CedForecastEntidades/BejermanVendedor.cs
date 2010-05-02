using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades.Bejerman
{
    [Serializable]
    public class Vendedor
    {
        private string ven_Cod;
        private string ven_Desc;
        private string ven_Tel;
        private string ven_email;
        private string ven_Fax;
        private string ven_Password;
        private string ven_Activo;
        private DateTime ven_FecMod;

        public Vendedor()
        {
        }
        public string Ven_Cod
        {
            set
            {
                ven_Cod = value;
            }
            get
            {
                return ven_Cod;
            }
        }
        public string Ven_Desc
        {
            set
            {
                ven_Desc = value;
            }
            get
            {
                return ven_Desc;
            }
        }
        public string Ven_Tel
        {
            set
            {
                ven_Tel = value;
            }
            get
            {
                return ven_Tel;
            }
        }
        public string Ven_email
        {
            set
            {
                ven_email = value;
            }
            get
            {
                return ven_email;
            }
        }
        public string Ven_Fax
        {
            set
            {
                ven_Fax = value;
            }
            get
            {
                return ven_Fax;
            }
        }
        public string Ven_Password
        {
            set
            {
                ven_Password = value;
            }
            get
            {
                return ven_Password;
            }
        }
        public string Ven_Activo
        {
            set
            {
                ven_Activo = value;
            }
            get
            {
                return ven_Activo;
            }
        }
        public DateTime Ven_FecMod
        {
            set
            {
                ven_FecMod = value;
            }
            get
            {
                return ven_FecMod;
            }
        }
    }
}