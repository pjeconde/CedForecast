using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebEntidades
{
    [Serializable]
    public class Cuenta
    {
        private string id;
        private string nombre;
        private string telefono;
        private string email;
        private string password;
        private string confirmacionPassword;
        private string pregunta;
        private string respuesta;
        private TipoCuenta tipoCuenta;
        private EstadoCuenta estadoCuenta;
        private DateTime fechaAlta;
        private int cantidadEnviosMail;
        private DateTime fechaUltimoReenvioMail;
        private string nroSerieDisco;
        private string emailSMS;
        private bool recibeAvisoAltaCuenta;
        private PaginaDefault paginaDefault;

        public Cuenta()
        {
            tipoCuenta = new TipoCuenta();
            estadoCuenta = new EstadoCuenta();
            paginaDefault = new PaginaDefault();
        }

        public string Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public string Nombre
        {
            set
            {
                nombre = value;
            }
            get
            {
                return nombre;
            }
        }
        public string Telefono
        {
            set
            {
                telefono = value;
            }
            get
            {
                return telefono;
            }
        }
        public string Email
        {
            set
            {
                email = value;
            }
            get
            {
                return email;
            }
        }
        public string Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }
        public string ConfirmacionPassword
        {
            set
            {
                confirmacionPassword = value;
            }
            get
            {
                return confirmacionPassword;
            }
        }
        public string Pregunta
        {
            set
            {
                pregunta = value;
            }
            get
            {
                return pregunta;
            }
        }
        public string Respuesta
        {
            set
            {
                respuesta = value;
            }
            get
            {
                return respuesta;
            }
        }
        public TipoCuenta TipoCuenta
        {
            set
            {
                tipoCuenta = value;
            }
            get
            {
                return tipoCuenta;
            }
        }
        public EstadoCuenta EstadoCuenta
        {
            set
            {
                estadoCuenta = value;
            }
            get
            {
                return estadoCuenta;
            }
        }
        public string IdTipoCuenta
        {
            get
            {
                return tipoCuenta.Id;
            }
        }
        public string DescrTipoCuenta
        {
            get
            {
                return tipoCuenta.Descr;
            }
        }
        public string IdEstadoCuenta
        {
            get
            {
                return EstadoCuenta.Id;
            }
        }
        public string DescrEstadoCuenta
        {
            get
            {
                return EstadoCuenta.Descr;
            }
        }
        public DateTime FechaAlta
        {
            set
            {
                fechaAlta = value;
            }
            get
            {
                return fechaAlta;
            }
        }
        public int CantidadEnviosMail
        {
            set
            {
                cantidadEnviosMail = value;
            }
            get
            {
                return cantidadEnviosMail;
            }
        }
        public DateTime FechaUltimoReenvioMail
        {
            set
            {
                fechaUltimoReenvioMail = value;
            }
            get
            {
                return fechaUltimoReenvioMail;
            }
        }
         public string EmailSMS
        {
            set
            {
                emailSMS = value;
            }
            get
            {
                return emailSMS;
            }
        }
        public bool RecibeAvisoAltaCuenta
        {
            set
            {
                recibeAvisoAltaCuenta = value;
            }
            get
            {
                return recibeAvisoAltaCuenta;
            }
        }
        public PaginaDefault PaginaDefault
        {
            set
            {
                paginaDefault = value;
            }
            get
            {
                return paginaDefault;
            }
        }
	}
}