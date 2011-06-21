using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace CedForecastEntidades
{
    [DelimitedRecord("|")]
    public class PlanillaInfoEmbarque
    {
        public string A;
        public string B;
        public string IdReferenciaSAP;
        public string ItemOrdenCompra;
        public string E;
        public string F;
        public string G;
        public string H;
        public string I;
        public string J;
        public string K;
        public string L;
        public string M;
        public string N;
        public string FechaEstimadaSalida;
        public string Vapor;
        public string FechaEstimadaArribo;
    }
}
