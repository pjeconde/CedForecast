using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace CedForecastWebDB
{
    public abstract class db : Cedeira.SV.db
    {
        #region Atributos
        protected CultureInfo cedeiraCultura;
        #endregion
        #region Constructor
        public db(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
            cedeiraCultura = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"]);
        }
        #endregion
    }
}
