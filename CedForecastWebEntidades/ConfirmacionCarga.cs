using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class ConfirmacionCarga
    {
        private DateTime idPeriodo;
        private CedForecastWebEntidades.Cuenta cuenta;
        private DateTime fechaConfirmacionCarga;

        public ConfirmacionCarga()
        {
        }
        public DateTime IdPeriodo
        {
            set
            {
                idPeriodo = value;
            }
            get
            {
                return idPeriodo;
            }
        }
        public CedForecastWebEntidades.Cuenta Cuenta
        {
            set
            {
                cuenta = value;
            }
            get
            {
                return cuenta;
            }
        }
        public DateTime FechaConfirmacionCarga
        {
            set
            {
                fechaConfirmacionCarga = value;
            }
            get
            {
                return fechaConfirmacionCarga;
            }
        }
    }
}

