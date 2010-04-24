using System;
using System.Data;
using System.Runtime.Serialization;
using System.Web.Security;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
namespace Cedeira.SV
{
	/// <summary>
	/// Descripción breve de Funciones.
	/// </summary>
	public class Fun
	{
		public static void VerifCUIT(string CUIT)
		{
			if(CUIT.Length != 11 || !IsNumeric(CUIT) || CUIT == "00000000000")
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("CUIT/CUIL");
			}
			int sum = 0;
			for(int i = 0; i < CUIT.Length; i++)
			{
				sum += Convert.ToInt32(CUIT.Substring(i, 1)) * Convert.ToInt32("54327654321".Substring(i, 1));
			}
			if((sum % 11) != 0)
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("CUIT/CUIL");
			}
		}
		public static void VerifCBU(string CBU)
		{
			//             Bloque1   Bloque2
			//Formato CBU: 7-1       13-1      (22 digitos totales)
			if(CBU.Length != 22 || !IsNumeric(CBU) || CBU == "0000000000000000000000")
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("CBU");
			}
			string Bloque1 = "0" + CBU.Substring(0, 7);
			int Digito1 = Convert.ToInt32(CBU.Substring(7, 1));
			string Bloque2 = "000" + CBU.Substring(8, 13);
			int Digito2 = Convert.ToInt32(CBU.Substring(21, 1));
			int sum;
			string sumString;
			// Verifico Bloque 1
			sum = 0;
			for(int i = 0; i < Bloque1.Length; i++)
			{
				sum += Convert.ToInt32(Bloque1.Substring(i, 1)) * Convert.ToInt32("97139713".Substring(i, 1));
			}
			sumString = sum.ToString();
			sum = Convert.ToInt32(sumString.Substring(sumString.Length - 1, 1));
			sum = 10 - sum;
			sumString = sum.ToString();
			sum = Convert.ToInt32(sumString.Substring(sumString.Length - 1, 1));
			if(sum != Digito1)
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("CBU");
			}
			else
			{
				// Verifico Bloque 2
				sum = 0;
				for(int i = 0; i < Bloque2.Length; i++)
				{
					sum += Convert.ToInt32(Bloque2.Substring(i, 1)) * Convert.ToInt32("9713971397139713".Substring(i, 1));
				}
				sumString = sum.ToString();
				sum = Convert.ToInt32(sumString.Substring(sumString.Length - 1, 1));
				sum = 10 - sum;
				sumString = sum.ToString();
				sum = Convert.ToInt32(sumString.Substring(sumString.Length - 1, 1));
				if(sum != Digito2)
				{
					throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("CBU");
				}
			}
		}
        public static bool IsEmail(string value)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(value))
                return (true);
            else
                return (false);
        }
        public static bool IsNumeric(string value)
		{
			for(int i = 0; i < value.Length; i++)
			{
				if(char.Parse(value.Substring(i, 1)) < char.Parse("0") || char.Parse(value.Substring(i, 1)) > char.Parse("9"))
				{
					return false;
				}
			}
			return true;
		}
		public static void IsNumericCheck(string value)
		{
			for(int i = 0; i < value.Length; i++)
			{
				if(char.Parse(value.Substring(i, 1)) < char.Parse("0") || char.Parse(value.Substring(i, 1)) > char.Parse("9"))
				{
					throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNegativo(value);
				}
			}
		}
		public static DataTable Compl(DataTable dt)
		{
			try
			{
				DataRow dr = dt.NewRow();
				switch(dt.Columns[0].DataType.FullName)
				{
					case "System.Byte":
					case "System.Int32":
						dr[0] = 0;
						break;
					case "System.String":
						dr[0] = "";
						break;
					default:
						System.Diagnostics.Debugger.Break();
						dr[0] = "";
						break;
				}
				dr[1] = "(sin informar)";
				dt.Rows.InsertAt(dr, 0);
				dt.AcceptChanges();
				dt.DefaultView.Sort = dt.Columns[1].ColumnName;
				dr = null;
				return dt;
			}
			catch
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("CBU");
			}
		}

		public static DataTable NuevaFilaCombos(DataTable dt, int id, string descr)
		{
			DataRow dr = dt.NewRow();
			dr["Id"] = id;
			dr["Descr"] = descr;
			dt.Rows.InsertAt(dr, 0);
			dt.AcceptChanges();
			dr = null;
			return dt;
		}

		public static void VerifAladi(string cod)
		{
			if(cod.Trim().Length < 13 || cod.Trim().Length > 127)
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Codigo de reembolso Sicap-Aladi");
			}
			int suma = 0;
			System.String digitos = cod.Trim().Substring(0, (12) - (0));
			sbyte multi = 1;
			int resul = 0;
			for(int i = 0; i <= digitos.Length - 1; i++)
			{
				resul = System.Int32.Parse(digitos.Substring(i, (i + 1) - (i))) * multi;
				if(resul >= 10)
					resul = System.Int32.Parse(resul.ToString().Substring(0, (1) - (0))) + System.Int32.Parse(resul.ToString().Substring(1, (2) - (1)));
				suma += resul;
				if(multi == 1)
					multi = 2;
				else
					multi = 1;
			}

			resul = 10 - System.Int32.Parse(suma.ToString().Trim().Substring(suma.ToString().Trim().Length - 1, (suma.ToString().Trim().Length) - (suma.ToString().Trim().Length - 1)));

			if(!(resul.ToString().Equals(cod.Substring(12, (13) - (12))) || resul == 10))
			{
				throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Codigo de reembolso Sicap-Aladi");
			}
		}
		public static bool Habilitado(string IdCampo, DataTable CamposHabilitados)
		{
			try
			{
				string a = CamposHabilitados.Columns[IdCampo].ColumnName;
				return true;
			}
			catch
			{
				return false;
			}
		}
		public static void VerifLen(string NombrePropiedad, object Valor, DataTable InfoCamposHabilitados, object Clase)
		{
			VerifLen(NombrePropiedad, NombrePropiedad, Valor, InfoCamposHabilitados, Clase);
		}
		public static void VerifLen(string NombrePropiedad, string NombreColumna, object Valor, DataTable InfoCamposHabilitados, object Clase)
		{
			string propiedad;
			System.Globalization.CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"]);
			propiedad = Convert.ToString(Valor, cedeiraCultura);
			string Tipo = InfoCamposHabilitados.Select("Propiedad='" + NombreColumna + "'")[0]["Tipo"].ToString();
			switch(Tipo)
			{
				case "int":
					if(Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName != "System.Int32")
					{
						throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.TipoNoCoincidente(NombrePropiedad);
					}
					break;
				case "numeric":
					if(Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName != "System.Double" && Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName != "System.Int32" && Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName != "System.Decimal")
					{
						throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.TipoNoCoincidente(NombrePropiedad);
					}
					string dec;
					string ent;
					if(propiedad.IndexOf(".") == -1)
					{
						ent = propiedad;
						dec = "";
						if(Convert.ToInt32(InfoCamposHabilitados.Select("Propiedad='" + NombreColumna + "'")[0]["Enteros"]) <
							ent.Length)
						{
							throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.LenInvalida(NombrePropiedad);
						}
					}
					else
					{
						for(int i = propiedad.Length - 1; i > propiedad.IndexOf("."); i--)
						{
							if(propiedad.Substring(i, 1) == "0")
							{
								propiedad = propiedad.Substring(0, i);
							}
							else
							{
								break;
							}
						}
						ent = propiedad.Substring(0, propiedad.IndexOf("."));
						dec = propiedad.Substring(propiedad.IndexOf(".") + 1);
						if(Convert.ToInt32(InfoCamposHabilitados.Select("Propiedad='" + NombreColumna + "'")[0]["Enteros"]) <
							ent.Length)
						{
							throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.LenInvalida(NombrePropiedad);
						}
						if(Convert.ToInt32(InfoCamposHabilitados.Select("Propiedad='" + NombreColumna + "'")[0]["Decimales"]) <
							dec.Length)
						{
							throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.LenInvalida(NombrePropiedad);
						}
					}
					break;
				case "timestamp":
					if(Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName != "System.DateTime")
					{
						throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.TipoNoCoincidente(NombrePropiedad);
					}
					break;
				case "tinyint":
					if(Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName != "System.Byte")
					{
						throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.TipoNoCoincidente(NombrePropiedad);
					}
					break;
				case "varchar":
					if(Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName != "System.String")
					{
						throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.TipoNoCoincidente(NombrePropiedad);
					}
					if(Convert.ToInt32(InfoCamposHabilitados.Select("Propiedad='" + NombreColumna + "'")[0]["Long"]) <
						propiedad.Length)
					{
						throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.LenInvalida(NombrePropiedad);
					}
					break;
				case "datetime":
					if(Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName != "System.DateTime")
					{
						throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.TipoNoCoincidente(NombrePropiedad);
					}
					break;
				case "char":
					if(Clase.GetType().GetProperty(NombrePropiedad).PropertyType.FullName != "System.String")
					{
						throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.TipoNoCoincidente(NombrePropiedad);
					}
					if(Convert.ToInt32(InfoCamposHabilitados.Select("Propiedad='" + NombreColumna + "'")[0]["Long"]) <
						propiedad.Length)
					{
						throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.LenInvalida(NombrePropiedad);
					}
					break;
				default:
					throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.LenInvalida(NombrePropiedad);
			}
		}
		public static decimal TruncarACiertosDecimales(decimal D, int I)
		{
			double aux;
			aux = Math.Pow((double)10, (double)I);
			return (decimal)(Math.Floor((double)(D * (decimal)aux)) / aux);

		}
		public static double CorregirPrecision(double Numero, int LongitudIncluyendoSeparador)
		{
			string aux = Numero.ToString();
			if(aux.Length > LongitudIncluyendoSeparador)
			{
				//Busco decimales
				int auxIndice = aux.IndexOf(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
				if(auxIndice != -1)
				{
					int decimales = aux.Length - auxIndice - 1;
					int caracteresAQuitar = aux.Length - LongitudIncluyendoSeparador;

					if(decimales == caracteresAQuitar)
					{
						caracteresAQuitar++;
						aux = aux.Remove(aux.Length - caracteresAQuitar, caracteresAQuitar);
					}
					else if(decimales > caracteresAQuitar)
					{
						aux = aux.Remove(aux.Length - caracteresAQuitar, caracteresAQuitar);
					}
					else
					{
						throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.AjustePrecision(Numero, LongitudIncluyendoSeparador);
					}
					double auxRetorno = double.Parse(aux, System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat);
					return auxRetorno;
				}
			}
			return Numero;
		}
		public static string FechasParaColumnas(DateTime[] Fechas)
		{
			System.Text.StringBuilder a = new System.Text.StringBuilder();
			for(int i = 0; i <= Fechas.GetUpperBound(0); i++)
			{
				a.Append("0.00 as '");
				a.Append(Fechas[i].ToString("dddd"));
				a.Append(" ");
				a.Append(Fechas[i].Day);
				a.Append("/");
				a.Append(Fechas[i].Month);
				a.Append("'");
				a.Append(",");
			}
			a.Remove(a.Length - 1, 1);
			return a.ToString();
		}
		public static string FechaParaCashFlow(DateTime Fecha)
		{
			System.Text.StringBuilder a = new System.Text.StringBuilder();
			a.Append(Fecha.ToString("dddd"));
			a.Append(" ");
			a.Append(Fecha.Day);
			a.Append("/");
			a.Append(Fecha.Month);
			return a.ToString();
		}
		/// <summary>
		/// Agrega columnas para mostrar en gridviews
		/// </summary>
		/// <param name="grilla">Grilla a llenar</param>
		/// <param name="obj">Objeto para sacar las propiedades que van a ser las columnas de las grillas</param>
		public static void AgregarColumnas(System.Web.UI.WebControls.GridView grilla, Object obj)
		{
			grilla.Columns.Clear();

			System.ComponentModel.PropertyDescriptorCollection propiedades = System.ComponentModel.TypeDescriptor.GetProperties(obj);
			foreach(System.ComponentModel.PropertyDescriptor var in propiedades)
			{
				System.Web.UI.WebControls.BoundField bf = new System.Web.UI.WebControls.BoundField();
				bf.DataField = var.Name;
				bf.HeaderText = var.Description;
				if(var.Category.Equals("Incluida"))
				{
					grilla.Columns.Add(bf);
				}
			}
		}
		#region Impersonalización
		public const int LOGON32_LOGON_INTERACTIVE = 2;
		public const int LOGON32_LOGON_NETWORK = 3;
		public const int LOGON32_LOGON_BATCH = 4;
		public const int LOGON32_LOGON_SERVICE = 5;
		public const int LOGON32_PROVIDER_DEFAULT = 0;
		private const string DOMINIO = "BGCMZ";
		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint="LogonUserW")]
		public static extern int LogonUserA(String lpszUserName,
			String lpszDomain,
			String lpszPassword,
			int dwLogonType,
			int dwLogonProvider,
			ref IntPtr phToken);

		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern int DuplicateToken(IntPtr hToken,
			int impersonationLevel,
			ref IntPtr hNewToken);

		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern bool RevertToSelf();

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		public static extern bool CloseHandle(IntPtr handle);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		public static extern int GetLastError();

		public static void impersonarUsuario(String userName, String password)
		{
			
			
			WindowsImpersonationContext impersonationContext;
			WindowsIdentity tempWindowsIdentity;
			IntPtr token = IntPtr.Zero;
			IntPtr tokenDuplicate = IntPtr.Zero;


			if(RevertToSelf())
			{
				int login = LogonUserA(userName, DOMINIO, password, LOGON32_LOGON_INTERACTIVE,
					LOGON32_PROVIDER_DEFAULT, ref token);
				if( login != 0)
				{
					if(DuplicateToken(token, 2, ref tokenDuplicate) != 0)
					{
						tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
						impersonationContext = tempWindowsIdentity.Impersonate();
						if(impersonationContext != null)
						{
							CloseHandle(token);
							CloseHandle(tokenDuplicate);
						}
					}
				}
				else
				{
					throw new Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.Impersonalizado(userName+" Error:"+GetLastError());
				}
			}
			if(token != IntPtr.Zero)
				CloseHandle(token);
			if(tokenDuplicate != IntPtr.Zero)
				CloseHandle(tokenDuplicate);
		}

		public static void deshacerImpersonation(WindowsImpersonationContext impersonationContext)
		{
			impersonationContext.Undo();
		}
		#endregion
	}
}