using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Periodo
    {
        private DateTime idPeriodo;
        private DateTime fechaConfirmacionCarga;
        private bool habilitado;

        public Periodo()
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
        public bool Habilitado
        {
            set
            {
                habilitado = value;
            }
            get
            {
                return habilitado;
            }
        }
    }
}

