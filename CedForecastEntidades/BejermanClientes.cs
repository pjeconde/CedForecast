using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades.Bejerman
{
    [Serializable]
    public class Clientes
    {
        private string cli_Cod;
        private string cli_RazSoc;
        private string clizon_Cod;
        private bool cli_Habilitado;
        private DateTime cli_FecMod;

        public Clientes()
        {
        }
        public string Cli_Cod
        {
            set
            {
                cli_Cod = value;
            }
            get
            {
                return cli_Cod;
            }
        }
        public string Cli_RazSoc
        {
            set
            {
                cli_RazSoc = value;
            }
            get
            {
                return cli_RazSoc;
            }
        }
        public string Clizon_Cod
        {
            set
            {
                clizon_Cod = value;
            }
            get
            {
                return clizon_Cod;
            }
        }
        public bool Cli_Habilitado
        {
            set
            {
                cli_Habilitado = value;
            }
            get
            {
                return cli_Habilitado;
            }
        }
        public DateTime Cli_FecMod
        {
            set
            {
                cli_FecMod = value;
            }
            get
            {
                return cli_FecMod;
            }
        }
    }
}