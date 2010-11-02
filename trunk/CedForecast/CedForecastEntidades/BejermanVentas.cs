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
        private string periodoEmision;

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
        public string PeriodoEmision
        {
            set
            {
                periodoEmision = value;
            }
            get
            {
                return periodoEmision;
            }
        }
    }
}