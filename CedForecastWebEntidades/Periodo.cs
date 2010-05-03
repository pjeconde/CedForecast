using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Periodo
    {
        private string idTipoPlanilla;
        private string idPeriodo;
        private DateTime fechaInhabilitacionCarga;
        private bool cargaHabilitada;

        public Periodo()
        {
        }
        public string IdTipoPlanilla
        {
            set
            {
                idTipoPlanilla = value;
            }
            get
            {
                return idTipoPlanilla;
            }
        }
        public string IdPeriodo
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
        public DateTime FechaInhabilitacionCarga
        {
            set
            {
                fechaInhabilitacionCarga = value;
            }
            get
            {
                return fechaInhabilitacionCarga;
            }
        }
        public bool CargaHabilitada
        {
            set
            {
                cargaHabilitada = value;
            }
            get
            {
                return cargaHabilitada;
            }
        }
    }
}

