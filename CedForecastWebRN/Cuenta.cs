using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using CaptchaDotNet2.Security.Cryptography;
namespace CedForecastWebRN
{
    public class Cuenta
    {
        public static void Validar(CedForecastWebEntidades.Cuenta Cuenta, string ClaveCatpcha, string Clave, CedEntidades.Sesion Sesion)
        {
            if (Cuenta.Nombre == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Nombre y Apellido");
            }
            else
            {
                if (Cuenta.Telefono == String.Empty)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Teléfono");
                }
                else
                {
                    if (Cuenta.Email == String.Empty)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Email");
                    }
                    else
                    {
                        if (!Cedeira.SV.Fun.IsEmail(Cuenta.Email))
                        {
                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Email");
                        }
                        else
                        {
                            if (Cuenta.Id == String.Empty)
                            {
                                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Id.Usuario");
                            }
                            else
                            {
                                if (!IdCuentaDisponible(Cuenta, Sesion))
                                {
                                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.IdUsuarioNoDisponible();
                                }
                                else
                                {
                                    if (Cuenta.Password == String.Empty)
                                    {
                                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Contraseña");
                                    }
                                    else
                                    {
                                        if (Cuenta.ConfirmacionPassword == String.Empty)
                                        {
                                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Confirmación de Contraseña");
                                        }
                                        else
                                        {
                                            if (Cuenta.Password != Cuenta.ConfirmacionPassword)
                                            {
                                                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.PasswordYConfirmacionNoCoincidente();
                                            }
                                            else
                                            {
                                                if (Cuenta.Pregunta == String.Empty)
                                                {
                                                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Pregunta");
                                                }
                                                else
                                                {
                                                    if (Cuenta.Respuesta == String.Empty)
                                                    {
                                                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Respuesta");
                                                    }
                                                    else
                                                    {
                                                        if (!ClaveCatpcha.Equals(Clave.ToLower()))
                                                        {
                                                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Clave");
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void Registrar(CedForecastWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            Cuenta.TipoCuenta.Id = "OperForecast";
            Cuenta.EstadoCuenta.Id = "PteConf";
            Cuenta.PaginaDefault.Id = CedForecastWebRN.PaginaDefault.Predeterminada(Cuenta.TipoCuenta, Sesion).Id;
            CedForecastWebDB.Cuenta cuenta = new CedForecastWebDB.Cuenta(Sesion);
            cuenta.Crear(Cuenta);
            EnviarMailBienvenidaForecast("Ahora dispone de una nueva cuenta Forecast", Cuenta);
        }
        public static void ReenviarMail(CedForecastWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Cuenta cuenta = new CedForecastWebDB.Cuenta(Sesion);
            cuenta.RegistrarReenvioMail(Cuenta);
            EnviarMailBienvenidaForecast("Ahora dispone de una nueva cuenta Forecast (reenvio)", Cuenta);
        }
        private static void EnviarMailBienvenidaForecast(string Asunto, CedForecastWebEntidades.Cuenta Cuenta)
        {
            SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
            mail.To.Add(new MailAddress(Cuenta.Email));
            mail.Subject = Asunto;
            mail.IsBodyHtml = true;
            StringBuilder a = new StringBuilder();
            a.Append("Estimado/a " + Cuenta.Nombre.Trim() + ":<br />");
            a.Append("<br />");
            a.Append("Gracias por crear su cuenta Forecast.<br />");
            a.Append("<br />");
            a.Append("Para confirmar el alta, haga clic en el enlace que aparece a continuación:<br />");
            a.Append("<br />");
            string link = "http://www.cedeira.com.ar/CuentaConfirmacion.aspx?Id=" + Encryptor.Encrypt(Cuenta.Id, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
            char c = (char)34;
            a.Append("<a class=" + c + "link" + c + " href=" + c + link + c + ">" + link + "</a><br />");
            a.Append("<br />");
            a.Append("Si no puede acceder a la página, copie la URL y péguela en una ventana nueva del navegador.<br />");
            a.Append("<br />");
            a.Append("Si ha recibido este correo electrónico y no ha solicitado la creación de una cuenta Forecast, es probable que otro usuario haya introducido su dirección por error al intentar llevar a cabo este proceso. Si no ha solicitado la creación de una cuenta Forecast, no es necesario que realice ninguna acción, y puede ignorar este mensaje con total seguridad.<br />");
            a.Append("<br />");
            a.Append("Saludos.<br />");
            a.Append("<br />");
            a.Append("Cedeira Software Factory<br />");
            a.Append("<br />");
            a.Append("<br />");
            a.Append("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden.<br />");
            mail.Body = a.ToString();
            smtpClient.Credentials = new NetworkCredential("registrousuarios@cedeira.com.ar", "cedeira123");
            smtpClient.Send(mail);
        }
        public static void EnviarSMS(string Asunto, string Mensaje, List<CedForecastWebEntidades.Cuenta> Destinatarios)
        {
            if (Destinatarios.Count > 0)
            {
                SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
                for (int i = 0; i < Destinatarios.Count; i++)
                {
                    mail.To.Add(new MailAddress(Destinatarios[i].EmailSMS));
                }
                mail.Subject = Asunto;
                mail.Body = Mensaje;
                smtpClient.Credentials = new NetworkCredential("registrousuarios@cedeira.com.ar", "cedeira123");
                smtpClient.Send(mail);
            }
        }
        public static void Leer(CedForecastWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Cuenta cuenta = new CedForecastWebDB.Cuenta(Sesion);
            cuenta.Leer(Cuenta);
        }
       
        public static void Login(CedForecastWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            if (Cuenta.Id == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Id.Usuario");
            }
            else
            {
                if (Cuenta.Password == String.Empty)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Contraseña");
                }
                else
                {
                    string passwordIngresada = Cuenta.Password;
                    Leer(Cuenta, Sesion);
                    if (passwordIngresada != Cuenta.Password)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.LoginRechazadoXPasswordInvalida();
                    }
                    //Se impide el login a cuenta pendientes de confirmacion o dadas de baja
                    //(las cuentas "Prem" suspendidas se comportan como cuentas "OperForecast")
                    if (Cuenta.EstadoCuenta.Id != "Vigente" && Cuenta.EstadoCuenta.Id != "Suspend")
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.LoginRechazadoXEstadoCuenta();
                    }
                }
            }
        }
        public static void Confirmar(CedForecastWebEntidades.Cuenta Cuenta, CedForecastWebEntidades.Sesion Sesion)
        {
            Cuenta.Id = Encryptor.Decrypt(Cuenta.Id, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
            Leer(Cuenta, (CedEntidades.Sesion)Sesion);
            CedForecastWebDB.Cuenta cuenta = new CedForecastWebDB.Cuenta((CedEntidades.Sesion)Sesion);
            cuenta.Confirmar(Cuenta);
            //if (Sesion.Flag.PremiumSinCostoEnAltaCuenta)
            //{
            //    DateTime fechaVto = DateTime.Today.AddDays(Convert.ToDouble(Sesion.CantidadDiasPremiumSinCostoEnAltaCuenta));
            //    ActivarPremium(Cuenta, new DateTime(fechaVto.Year, fechaVto.Month, fechaVto.Day, 23, 59, 59), (CedEntidades.Sesion)Sesion);
            //    Leer(Cuenta, (CedEntidades.Sesion)Sesion);
            //    CedForecastWebRN.Cuenta.EnviarMailBienvenidaPremium(Cuenta, Sesion);
            //}
            EnviarSMS("Alta cuenta", Cuenta.Nombre, cuenta.DestinatariosAvisoAltaCuenta());  
        }
        public static bool IdCuentaDisponible(CedForecastWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            if (Cuenta.Id == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Id.Usuario");
            }
            else
            {
                try
                {
                    CedForecastWebDB.Cuenta cuenta = new CedForecastWebDB.Cuenta(Sesion);
                    return cuenta.IdCuentaDisponible(Cuenta);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static void CambiarPassword(CedForecastWebEntidades.Cuenta Cuenta, string PasswordActual, string PasswordNueva, string ConfirmacionPasswordNueva, CedEntidades.Sesion Sesion)
        {
            if (PasswordActual == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Contraseña actual");
            }
            else
            {
                if (PasswordNueva == String.Empty)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Contraseña nueva");
                }
                else
                {
                    if (ConfirmacionPasswordNueva == String.Empty)
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Confirmación de Contraseña nueva");
                    }
                    else
                    {
                        if (Cuenta.Password != PasswordActual)
                        {
                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.Login.PasswordNoMatch();
                        }
                        else
                        {
                            if (PasswordNueva != ConfirmacionPasswordNueva)
                            {
                                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.PasswordYConfirmacionNoCoincidente();
                            }
                            else
                            {
                                if (Cuenta.Password == PasswordNueva)
                                {
                                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.PasswordNuevaIgualAActual();
                                }
                                else
                                {
                                    CedForecastWebDB.Cuenta cuenta = new CedForecastWebDB.Cuenta(Sesion);
                                    cuenta.CambiarPassword(Cuenta, PasswordNueva);
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void ReportarIdCuentas(string Email, CedEntidades.Sesion Sesion)
        {
            //Alta en la base de datos
            CedForecastWebDB.Cuenta cuenta = new CedForecastWebDB.Cuenta(Sesion);
            List<CedForecastWebEntidades.Cuenta> cuentas = cuenta.Lista(Email);
            //Mail para confirmación
            SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
            mail.To.Add(new MailAddress(Email));
            mail.Subject = "Información de cuenta(s) Forecast";
            StringBuilder a = new StringBuilder();
            a.Append("Estimado/a " + cuentas[0].Nombre.Trim() + ":"); a.AppendLine();
            a.AppendLine();
            a.Append("Cumplimos en informarle cuáles son las cuentas Forecast vinculadas a esta cuenta de correo electrónico:"); a.AppendLine();
            a.AppendLine();
            for (int i = 0; i < cuentas.Count; i++)
            {
                a.Append("Cuenta '" + cuentas[i].Nombre + "' (Id.Usuario='" + cuentas[i].Id + "')"); a.AppendLine();
            }
            a.AppendLine();
            a.Append("Si ha recibido este correo electrónico y no ha solicitado información sobre su(s) cuenta(s) Forecast, es probable que otro usuario haya introducido su dirección por error. Si no ha solicitado esta información, no es necesario que realice ninguna acción, y puede ignorar este mensaje con total seguridad."); a.AppendLine();
            a.Append("Saludos."); a.AppendLine();
            a.AppendLine();
            a.Append("Cedeira Software Factory"); a.AppendLine();
            a.AppendLine();
            a.AppendLine();
            a.AppendLine("Este es sólo un servicio de envío de mensajes. Las respuestas no se supervisan ni se responden."); a.AppendLine();
            mail.Body = a.ToString();
            smtpClient.Credentials = new NetworkCredential("registrousuarios@cedeira.com.ar", "cedeira123");
            smtpClient.Send(mail);
        }
        public static List<CedForecastWebEntidades.Cuenta> Lista(int IndicePagina, int TamañoPagina, string OrderBy, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Cuenta cuenta = new CedForecastWebDB.Cuenta(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "FechaAlta desc, Nombre";
            }
            return cuenta.Lista(IndicePagina, TamañoPagina, OrderBy);
        }
        public static int CantidadDeFilas(CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Cuenta cuenta = new CedForecastWebDB.Cuenta(Sesion);
            return cuenta.CantidadDeFilas();
        }
        public static int CantidadDeFilas(bool IncluirAdministradores, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Cuenta cuenta = new CedForecastWebDB.Cuenta(Sesion);
            return cuenta.CantidadDeFilas(IncluirAdministradores);
        }
        public static void Configurar(CedForecastWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Cuenta cuenta = new CedForecastWebDB.Cuenta(Sesion);
            cuenta.Configurar(Cuenta);
        }
        private static void CambiarEstado(CedForecastWebEntidades.Cuenta Cuenta, CedForecastWebEntidades.EstadoCuenta NuevoEstadoCuenta, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Cuenta cuenta = new CedForecastWebDB.Cuenta(Sesion);
            cuenta.CambiarEstado(Cuenta, NuevoEstadoCuenta);
        }
        public static void DarDeBaja(CedForecastWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            CedForecastWebEntidades.EstadoCuenta nuevoEstado=new CedForecastWebEntidades.EstadoCuenta();
            nuevoEstado.Id = "Baja";
            CambiarEstado(Cuenta, nuevoEstado, Sesion);
        }        
        public static void AnularBaja(CedForecastWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            CedForecastWebEntidades.EstadoCuenta nuevoEstado=new CedForecastWebEntidades.EstadoCuenta();
            nuevoEstado.Id = "Vigente";
            CambiarEstado(Cuenta, nuevoEstado, Sesion);
        }        
        //public static void EnviarMailBienvenidaPremium(CedForecastWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        //{
        //    SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
        //    MailMessage mail = new MailMessage();
        //    mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
        //    mail.CC.Add(new MailAddress("facturaelectronica@cedeira.com.ar"));
        //    mail.To.Add(new MailAddress(Cuenta.Email));
        //    mail.Subject = "Facturación Electrónica - Bienvenida a productos Forecast (Ref. " + Cuenta.Id + ")";
        //    mail.IsBodyHtml = true;
        //    WebClient carta = new WebClient();
        //    mail.BodyEncoding = System.Text.Encoding.UTF8;
        //    string a = carta.DownloadString(System.Web.HttpContext.Current.Server.MapPath("EmailTemplates/FacturaElectronicaServicioPremiumBienvenida.htm"));
        //    mail.Body = a.Substring(a.IndexOf("<"));
        //    mail.Body = mail.Body.Replace("%usuario%", Cuenta.Nombre);
        //    mail.Body = mail.Body.Replace("%fechaVencimiento%", Cuenta.FechaVtoActivacion.ToString("dd/MM/yyyy"));
        //    smtpClient.Credentials = new NetworkCredential("registrousuarios@cedeira.com.ar", "cedeira123");
        //    smtpClient.Send(mail);
        //}
        //public static void EnviarMailSuspensionPremium(CedForecastWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        //{
        //    SmtpClient smtpClient = new SmtpClient("mail.cedeira.com.ar");
        //    MailMessage mail = new MailMessage();
        //    mail.From = new MailAddress("registrousuarios@cedeira.com.ar");
        //    mail.CC.Add(new MailAddress("facturaelectronica@cedeira.com.ar"));
        //    mail.To.Add(new MailAddress(Cuenta.Email));
        //    mail.Subject = "Facturación Electrónica - Aviso de suspensión del Servicio Premium (Ref. " + Cuenta.Id + ")";
        //    mail.IsBodyHtml = true;
        //    WebClient carta = new WebClient();
        //    mail.BodyEncoding = System.Text.Encoding.UTF8;
        //    string a = carta.DownloadString(System.Web.HttpContext.Current.Server.MapPath("EmailTemplates/FacturaElectronicaServicioPremiumSuspension.htm"));
        //    mail.Body = a.Substring(a.IndexOf("<"));
        //    mail.Body = mail.Body.Replace("%usuario%", Cuenta.Nombre);
        //    smtpClient.Credentials = new NetworkCredential("registrousuarios@cedeira.com.ar", "cedeira123");
        //    smtpClient.Send(mail);
        //}
        public static void Depurar(CedForecastWebEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Cuenta cuenta = new CedForecastWebDB.Cuenta(Sesion);
            List<CedForecastWebEntidades.Cuenta> cuentaSuspendida = cuenta.DepurarBajasYPtesConf();
        }
        public static void SetearRecibeAvisoAltaCuenta(CedForecastWebEntidades.Cuenta Cuenta, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Cuenta cuenta = new CedForecastWebDB.Cuenta(Sesion);
            cuenta.SetearRecibeAvisoAltaCuenta(Cuenta);
        }
    }
}