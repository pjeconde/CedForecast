using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastRN
{
    public class Cuenta : Proceso
    {
        private CedEntidades.Sesion sesion;
        private string cedForecastWSRUL;

        public Cuenta(CedEntidades.Sesion Sesion, string CedForecastWSRUL)
            : base()
        {
            sesion = Sesion;
            cedForecastWSRUL = CedForecastWSRUL;
        }
        public void EnviarNovedades()
        {
            try
            {
                WS.Sincronizacion ws = new WS.Sincronizacion();
                ws.Url = cedForecastWSRUL;
                DateTime fechaUltimaSincronizacion = ws.FechaUltimaSincronizacionCuentas();
                CedForecastDB.Bejerman.Vendedor datos = new CedForecastDB.Bejerman.Vendedor(sesion);
                List<CedForecastEntidades.Bejerman.Vendedor> lista = datos.LeerNovedades(fechaUltimaSincronizacion);
                contador = 0;
                contadorTope = lista.Count;
                for (contador = 0; contador < contadorTope; contador++)
                {
                    WS.Cuenta elemento = new WS.Cuenta();
                    elemento.Id = lista[contador].Ven_Cod;
                    elemento.Nombre = lista[contador].Ven_Desc;
                    elemento.Telefono = lista[contador].Ven_Tel;
                    elemento.Email = lista[contador].Ven_email;
                    elemento.Division = new CedForecastRN.WS.Division();
                    elemento.Division.Id = lista[contador].Ven_Fax;
                    elemento.Password = lista[contador].Ven_Password;
                    elemento.Pregunta = "1+39 ? (en letras minúsculas)";
                    elemento.Respuesta = "cuarenta";
                    elemento.TipoCuenta = new CedForecastRN.WS.TipoCuenta();
                    elemento.TipoCuenta.Id = "OperForecast";
                    elemento.EstadoCuenta = new CedForecastRN.WS.EstadoCuenta();
                    if (lista[contador].Ven_Activo == "S")
                    {
                        elemento.EstadoCuenta.Id = "Vigente";
                    }
                    else
                    {
                        elemento.EstadoCuenta.Id = "Baja";
                    }
                    elemento.PaginaDefault = new CedForecastRN.WS.PaginaDefault();
                    elemento.PaginaDefault.Id = "Forecast";
                    elemento.FechaAlta = DateTime.Now;
                    elemento.CantidadEnviosMail = 0;
                    elemento.FechaUltimoReenvioMail = DateTime.Now;
                    elemento.EmailSMS = String.Empty;
                    elemento.RecibeAvisoAltaCuenta = false;
                    elemento.FechaUltModif = lista[contador].Ven_FecMod;
                    ws.EnviarCuenta(elemento);
                }
            }
            catch (Exception Ex)
            {
                errores.Add(Ex);
            }
        }
    }
}