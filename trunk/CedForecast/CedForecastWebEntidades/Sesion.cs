using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Sesion : CedEntidades.Sesion
    {
        #region Atributos
        private CedForecastWebEntidades.Cuenta cuenta;
        private string mensajeGeneral;
        private CedForecastWebEntidades.Flag flag;
        private Int32 cantidadDiasPremiumSinCostoEnAltaCuenta;
        #endregion

        #region Constructor
        public Sesion()
        {
            cuenta = new CedForecastWebEntidades.Cuenta();
            flag = new CedForecastWebEntidades.Flag();
        }
        #endregion

        #region Propiedades
        public CedForecastWebEntidades.Cuenta Cuenta
        {
            get
            {
                return cuenta;
            }
            set
            {
                cuenta = value;
            }
        }
        public CedForecastWebEntidades.Flag Flag
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
            }
        }
        public string MensajeGeneral
        {
            get
            {
                return mensajeGeneral;
            }
            set
            {
                mensajeGeneral = value;
            }
        }
        #endregion
    }
}