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
        private string idEstadoConfirmacionCarga;
        private string comentario;

        public ConfirmacionCarga()
        {
            cuenta = new Cuenta();
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
        public string IdCuenta
        {
            get
            {
                return cuenta.Id;
            }
        }
        public string Nombre
        {
            get
            {
                return cuenta.Nombre;
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
        public string IdEstadoConfirmacionCarga
        {
            set
            {
                idEstadoConfirmacionCarga = value;
            }
            get
            {
                return idEstadoConfirmacionCarga;
            }
        }
        public string Comentario
        {
            set
            {
                comentario = value;
            }
            get
            {
                return comentario;
            }
        }
    }
}

