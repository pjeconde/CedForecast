using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Cliente
    {
        private string idCliente;
        private string descrCliente;
        private CedForecastWebEntidades.Zona zona;
        private bool habilitado;
        private DateTime fechaUltModif;

        public Cliente()
        {
            zona = new CedForecastWebEntidades.Zona();
        }
        public string IdCliente
        {
            set
            {
                idCliente = value;
            }
            get
            {
                return idCliente;
            }
        }
        public string DescrCliente
        {
            set
            {
                descrCliente = value;
            }
            get
            {
                return descrCliente;
            }
        }
        public CedForecastWebEntidades.Zona Zona
        {
            set
            {
                zona = value;
            }
            get
            {
                return zona;
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
        public DateTime FechaUltModif
        {
            set
            {
                fechaUltModif = value;
            }
            get
            {
                return fechaUltModif;
            }
        }
    }
}

