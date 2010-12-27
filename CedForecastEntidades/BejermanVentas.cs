using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastEntidades.Bejerman
{
    [Serializable]
    public class Ventas
    {
        private string sdvart_CodGen;
        private string cve_CodCli;
        private decimal sdv_CantUM1;
        private decimal sdv_ImpTot;
        private DateTime cve_FEmision;
        private string periodo;
        private string cvemon_Codigo;
        private string zona;            //clizon_Cod
        private string vendedor;        //cveven_Cod

        public Ventas()
        {
        }
        public string Sdvart_CodGen
        {
            set
            {
                sdvart_CodGen = value;
            }
            get
            {
                return sdvart_CodGen;
            }
        }
        public string Cve_CodCli
        {
            set
            {
                cve_CodCli = value;
            }
            get
            {
                return cve_CodCli;
            }
        }
        public decimal Sdv_CantUM1
        {
            set
            {
                sdv_CantUM1 = value;
            }
            get
            {
                return sdv_CantUM1;
            }
        }
        public decimal Sdv_ImpTot
        {
            set
            {
                sdv_ImpTot = value;
            }
            get
            {
                return sdv_ImpTot;
            }
        }

        public DateTime Cve_FEmision
        {
            set
            {
                cve_FEmision = value;
            }
            get
            {
                return cve_FEmision;
            }
        }
        public string Periodo
        {
            set
            {
                periodo = value;
            }
            get
            {
                return periodo;
            }
        }
        public string Cvemon_Codigo
        {
            set
            {
                cvemon_Codigo = value;
            }
            get
            {
                return cvemon_Codigo;
            }
        }
        public string Zona
        {
            set
            {
                zona = value;
            }
            get
            {
                return zona;
            }
        }
        public string Vendedor
        {
            set
            {
                vendedor = value;
            }
            get
            {
                return vendedor;
            }
        }
    }
}