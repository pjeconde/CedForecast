using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using Cedeira.SV;

namespace CedForecast
{
    public class Aplicacion
    {
        public static CedEntidades.Sesion Sesion;
        public static string Titulo = "";
        public static string Codigo = "";
        public static string Version = "";
        public static Color CampoHabilitadoBackColor;
        public static Color LabelCampoHabilitadoForeColor;
        public static Color CampoDesHabilitadoBackColor;
        public static Color LabelCampoDesHabilitadoForeColor;

        [STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new TableroForm());
        //}
        static void Main()
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                //seteo cultura thread
                CultureInfo cedeiraCultura = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                cedeiraCultura.DateTimeFormat = new CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                Thread.CurrentThread.CurrentCulture = cedeiraCultura;
                // Determino el path de la aplicacion
                string AppPath = @Application.StartupPath;
                AppPath = AppPath.ToLower().Replace(@"\bin\debug", "") + @"\";
                // Parametros varios
                CampoHabilitadoBackColor = System.Drawing.Color.FromName(System.Configuration.ConfigurationManager.AppSettings["CampoHabilitadoBackColor"]);
                LabelCampoHabilitadoForeColor = System.Drawing.Color.FromName(System.Configuration.ConfigurationManager.AppSettings["LabelCampoHabilitadoForeColor"]);
                CampoDesHabilitadoBackColor = System.Drawing.Color.FromName(System.Configuration.ConfigurationManager.AppSettings["CampoDesHabilitadoBackColor"]);
                LabelCampoDesHabilitadoForeColor = System.Drawing.Color.FromName(System.Configuration.ConfigurationManager.AppSettings["LabelCampoDesHabilitadoForeColor"]);
                // Creo una sesion de trabajo
                Titulo = ((AssemblyDescriptionAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0]).Description;
                Codigo = ((AssemblyTitleAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;
                Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build;
                Cedeira.UI.Mostrar.Acerca(Titulo, "(" + Codigo + ")", "Versión " + Version, 3);
                string idUsuarioWindows = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split(@"\".ToCharArray())[1].ToString();
                string idUsuario = String.Empty;
                string password = String.Empty;
                switch (System.Configuration.ConfigurationManager.AppSettings["Autenticacion"].ToUpper())
                {
                    case "NONE":
                        idUsuario = idUsuarioWindows;
                        break;
                    default:
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.Login.AutenticacionInvalida();
                }
                Cursor.Current = System.Windows.Forms.Cursors.Default;
                if (!idUsuario.Equals(string.Empty))
                {
                    System.Configuration.ConnectionStringSettingsCollection connections = System.Configuration.ConfigurationManager.ConnectionStrings;
                    string cnnStr = connections["CnnStr"].ConnectionString;
                    string cnnStrBejerman = connections["CnnStrBejerman"].ConnectionString;
                    string versionParaControl = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
                    Sesion = new CedEntidades.Sesion();
                    Cedeira.SV.Sesion.Crear(
                        idUsuario,
                        password,
                        "Windows",
                        cnnStr,
                        cnnStrBejerman,
                        "FrontEnd",
                        Version,
                        versionParaControl,
                        Sesion);

                    Cedeira.RecursoIncrustado r = new Cedeira.RecursoIncrustado();
                    r.GuardarRecursoIncrustado();

                    // Levanto el Front-End de la aplicacion
                    SingleInstance.SingleApplication.Run(new TableroForm(Titulo));
                }
                Cedeira.UI.Mostrar.Acerca(Aplicacion.Titulo, "Gracias", "por utilizar " + Codigo, 2);
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }
    }
}