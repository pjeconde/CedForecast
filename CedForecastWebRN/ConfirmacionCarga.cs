using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace CedForecastWebRN
{
    public class ConfirmacionCarga
    {
        public ConfirmacionCarga()
        {
        }
        public static void Leer(CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.ConfirmacionCarga confirmacionCarga = new CedForecastWebDB.ConfirmacionCarga(Sesion);
            confirmacionCarga.Leer(ConfirmacionCarga);
        }
        public static List<CedForecastWebEntidades.ConfirmacionCarga> Lista(CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.ConfirmacionCarga confirmacionCarga = new CedForecastWebDB.ConfirmacionCarga(Sesion);
            return confirmacionCarga.Lista(ConfirmacionCarga);
        }
        public static List<CedForecastWebEntidades.ConfirmacionCarga> Lista(int IndicePagina, int TamañoPagina, string OrderBy, CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.ConfirmacionCarga confirmacionCarga = new CedForecastWebDB.ConfirmacionCarga(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "IdPeriodo desc";
            }
            return confirmacionCarga.Lista(IndicePagina, TamañoPagina, OrderBy, ConfirmacionCarga);
        }
        public static int CantidadDeFilas(CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.ConfirmacionCarga confirmacionCarga = new CedForecastWebDB.ConfirmacionCarga(Sesion);
            return confirmacionCarga.CantidadDeFilas();
        }
        public static void RegistrarAceptacionORechazo(CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga, string EstadoActual, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.ConfirmacionCarga confirmacionCarga = new CedForecastWebDB.ConfirmacionCarga(Sesion);
            confirmacionCarga.Ejecutar(ConfirmacionCarga, EstadoActual);
            EnviarMailRespuestaConfirmacionCarga("K+S Respuesta de la Confirmacion de Carga", ConfirmacionCarga);
        }
        private static void EnviarMailRespuestaConfirmacionCarga(string Asunto, CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga)
        {
            SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
            mail.To.Add(new MailAddress(ConfirmacionCarga.Cuenta.Email));
            mail.Subject = Asunto;
            mail.IsBodyHtml = true;
            StringBuilder a = new StringBuilder();
            a.Append("Vendedor " + ConfirmacionCarga.Cuenta.Nombre.Trim() + ":<br />");
            a.Append("<br />");
            a.Append("Se ha recibido la confimación de su carga de datos correspondiente al periodo.<br />");
            a.Append("<br />");
            a.Append("Estado: " + ConfirmacionCarga.IdEstadoConfirmacionCarga);
            if (ConfirmacionCarga.Comentario != "")
            {
                a.Append("<br />");
                a.Append("Comentario: " + ConfirmacionCarga.Comentario);
            }
            a.Append("<br />");
            a.Append("Saludos.<br />");
            a.Append("<br />");
            mail.Body = a.ToString();
            smtpClient.Credentials = new NetworkCredential("registrousuarios@cedeira.com.ar", "cedeira123");
            smtpClient.Send(mail);
        }
        public static void Confirmar(CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga, string EstadoActual, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.ConfirmacionCarga confirmacionCarga = new CedForecastWebDB.ConfirmacionCarga(Sesion);
            confirmacionCarga.Ejecutar(ConfirmacionCarga, EstadoActual);
        }
        public static void AnularConfirmacion(CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga, string EstadoActual, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.ConfirmacionCarga confirmacionCarga = new CedForecastWebDB.ConfirmacionCarga(Sesion);
            confirmacionCarga.Ejecutar(ConfirmacionCarga, EstadoActual);
        }
        public static void UltimoRegistro(CedForecastWebEntidades.ConfirmacionCarga ConfirmacionCarga, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.ConfirmacionCarga confirmacionCarga = new CedForecastWebDB.ConfirmacionCarga(Sesion);
            confirmacionCarga.UltimoRegistro(ConfirmacionCarga);
        }
    }
}
