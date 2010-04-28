using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Periodo
    {
        private DateTime idPeriodo;
        private DateTime fechaVtoConfirmacionCarga;
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
        public DateTime FechaVtoConfirmacionCarga
        {
            set
            {
                fechaVtoConfirmacionCarga = value;
            }
            get
            {
                return fechaVtoConfirmacionCarga;
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

