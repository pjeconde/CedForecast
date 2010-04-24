using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Division
    {
        private string idDivision;
        private string descrDivision;

        public Division()
        {
        }
        public string IdDivision
        {
            set
            {
                idDivision = value;
            }
            get
            {
                return idDivision;
            }
        }
        public string DescrDivision
        {
            set
            {
                descrDivision = value;
            }
            get
            {
                return descrDivision;
            }
        }
    }
}