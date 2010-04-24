using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Flag
    {
        private bool modoDepuracion;
        private bool premiumSinCostoEnAltaCuenta;
        private bool creacionCuentaHabilitada;

        public Flag()
        {
        }
        public bool ModoDepuracion
        {
            set
            {
                modoDepuracion = value;
            }
            get
            {
                return modoDepuracion;
            }
        }
        public bool PremiumSinCostoEnAltaCuenta
        {
            set
            {
                premiumSinCostoEnAltaCuenta = value;
            }
            get
            {
                return premiumSinCostoEnAltaCuenta;
            }
        }
        public bool CreacionCuentaHabilitada
        {
            set
            {
                creacionCuentaHabilitada = value;
            }
            get
            {
                return creacionCuentaHabilitada;
            }
        }
    }
}