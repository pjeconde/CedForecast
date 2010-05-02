using System.Collections.Generic;

/* En el caso que una clase que herede de Proceso y utilice cedeiraCultura
 * se deberá asignar a la cultura del Thread 
 * System.Globalization.CultureInfo cedeiraCultura=new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"]);
 * y al usar:
 * System.Globalization.NumberFormatInfo.CurrentInfo    (la actual cultura del Thread), NumberFormatInfo en el caso que se necesite el formato númerico.
 */

namespace CedForecastRN
{
	public class Proceso
	{
		protected int contadorTope;
		protected int contador;
        protected List<System.Exception> errores = new List<System.Exception>();

		public Proceso()
		{
		}
        public virtual List<System.Exception> Errores()
		{
			return errores;
		}
		public int ContadorTope 
		{
			get
            {
                return contadorTope;
            }
			set 
			{
                contadorTope = value;
			}
		}
		public int Contador
		{
			get
			{
				if (contadorTope<=0)
				{
					return 0;
				}
				else
				{
					if (contador+1>contadorTope)
					{
						return contadorTope;
					}
					else
					{
						return contador+1;
					}
				}
			} 
			set 
			{
                contador = value;
			}
		}
	}
}