using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Microsoft.ApplicationBlocks.ExceptionManagement
{
	/// <summary>
	/// Descripción breve de Excepciones.
	/// </summary>
	namespace Usuario
	{
		[Serializable]
		public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			public BaseApplicationException(string TextoError)
				: base(TextoError)
			{
			}
			public BaseApplicationException(string TextoError, Exception inner)
				: base(TextoError, inner)
			{
			}
			public BaseApplicationException(SerializationInfo info, StreamingContext context)
				: base(info, context)
			{
			}
		}
		[Serializable]
		public class Inexistente : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
		{
			static string TextoError = "Usuario inexistente";
			public Inexistente() : base(TextoError)
			{
			}
			public Inexistente(Exception inner) : base(TextoError, inner)
			{
			}
			public Inexistente(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class Impersonalizado : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
		{
			static string TextoError = "No se pudo impersonalizar a ";
			public Impersonalizado(string Usuario)
				: base(TextoError + Usuario)
			{
			}
			public Impersonalizado(Exception inner)
				: base(TextoError, inner)
			{
			}
			public Impersonalizado(SerializationInfo info, StreamingContext context)
				: base(info, context)
			{
			}
		}
	}
    namespace Cuenta
    {
        [Serializable]
        public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
        {
            public BaseApplicationException(string TextoError)
                : base(TextoError)
            {
            }
            public BaseApplicationException(string TextoError, Exception inner)
                : base(TextoError, inner)
            {
            }
            public BaseApplicationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class PasswordYConfirmacionNoCoincidente : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
        {
            static string TextoError = "La Contraseña no coincide con su Confirmación";
            public PasswordYConfirmacionNoCoincidente()
                : base(TextoError)
            {
            }
            public PasswordYConfirmacionNoCoincidente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public PasswordYConfirmacionNoCoincidente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class PasswordNuevaIgualAActual : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
        {
            static string TextoError = "La Contraseña nueva no debe ser igual a la actual";
            public PasswordNuevaIgualAActual()
                : base(TextoError)
            {
            }
            public PasswordNuevaIgualAActual(Exception inner)
                : base(TextoError, inner)
            {
            }
            public PasswordNuevaIgualAActual(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class IdUsuarioNoDisponible : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
        {
            static string TextoError = "El IdUsuario, que ingresó, ya ha sido usado por otra persona.  Modifiquelo hasta encontrar un valor único.";
            public IdUsuarioNoDisponible()
                : base(TextoError)
            {
            }
            public IdUsuarioNoDisponible(Exception inner)
                : base(TextoError, inner)
            {
            }
            public IdUsuarioNoDisponible(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class CuentaConfFormatoMsgErroneo : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
        {
            static string TextoError = "El mensaje de confirmación (de creación de la cuenta Forecast) tiene un formato erróneo.  Por favor, póngase en contacto con Cedeira Software Factory, para solucionar el inconveniente.  Muchas gracias.";
            public CuentaConfFormatoMsgErroneo()
                : base(TextoError)
            {
            }
            public CuentaConfFormatoMsgErroneo(Exception inner)
                : base(TextoError, inner)
            {
            }
            public CuentaConfFormatoMsgErroneo(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class ParametrosAccionCompradorErroneo : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
        {
            static string TextoError = "Acción inválida sobre Comprador.  Por favor, póngase en contacto con Cedeira Software Factory, para solucionar el inconveniente.  Muchas gracias.";
            public ParametrosAccionCompradorErroneo()
                : base(TextoError)
            {
            }
            public ParametrosAccionCompradorErroneo(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ParametrosAccionCompradorErroneo(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class CuentaConfUpdateErroneo : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
        {
            static string TextoError = "El evento de confirmación (de creación de la cuenta Forecast) no puede ejecutarse.  Es probable que la confirmación ya haya sido registrada.  Verifique si puede identificarse.  En paso contrario, póngase en contacto con Cedeira Software Factory, para solucionar el inconveniente.  Muchas gracias.";
            public CuentaConfUpdateErroneo()
                : base(TextoError)
            {
            }
            public CuentaConfUpdateErroneo(Exception inner)
                : base(TextoError, inner)
            {
            }
            public CuentaConfUpdateErroneo(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class LoginRechazadoXEstadoCuenta : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
        {
            static string TextoError = "Login inválido (la cuenta está pendiente de confirmación o dada de baja)";
            public LoginRechazadoXEstadoCuenta()
                : base(TextoError)
            {
            }
            public LoginRechazadoXEstadoCuenta(Exception inner)
                : base(TextoError, inner)
            {
            }
            public LoginRechazadoXEstadoCuenta(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class LoginRechazadoXPasswordInvalida : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
        {
            static string TextoError = "Contraseña inválida";
            public LoginRechazadoXPasswordInvalida()
                : base(TextoError)
            {
            }
            public LoginRechazadoXPasswordInvalida(Exception inner)
                : base(TextoError, inner)
            {
            }
            public LoginRechazadoXPasswordInvalida(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class NoHayCuentasAsociadasAEmail : Microsoft.ApplicationBlocks.ExceptionManagement.Usuario.BaseApplicationException
        {
            static string TextoError = "No hay cuentas Forecast asociadas a la dirección de correo electrónico especificada";
            public NoHayCuentasAsociadasAEmail()
                : base(TextoError)
            {
            }
            public NoHayCuentasAsociadasAEmail(Exception inner)
                : base(TextoError, inner)
            {
            }
            public NoHayCuentasAsociadasAEmail(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
    namespace WF
	{
        [Serializable]
        public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
        {
            public BaseApplicationException(string TextoError)
                : base(TextoError)
            {
            }
            public BaseApplicationException(string TextoError, Exception inner)
                : base(TextoError, inner)
            {
            }
            public BaseApplicationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
		public class OpInexistente : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "Operacion inexistente (WF)";
			public OpInexistente() : base(TextoError)
			{
			}
			public OpInexistente(Exception inner) : base(TextoError, inner)
			{
			}
			public OpInexistente(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
        [Serializable]
        public class EventoInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
        {
            static string TextoError = "Evento invalido (WF)";
            public EventoInvalido()
                : base(TextoError)
            {
            }
            public EventoInvalido(Exception inner)
                : base(TextoError, inner)
            {
            }
            public EventoInvalido(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class EstadoHstInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
        {
            static string TextoError = "Seleccion inválida de EstadoHst (WF)";
            public EstadoHstInvalido()
                : base(TextoError)
            {
            }
            public EstadoHstInvalido(Exception inner)
                : base(TextoError, inner)
            {
            }
            public EstadoHstInvalido(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class EstadoHstNoDefinido : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
        {
            static string TextoError = "EstadoHst no definido (WF)";
            public EstadoHstNoDefinido()
                : base(TextoError)
            {
            }
            public EstadoHstNoDefinido(Exception inner)
                : base(TextoError, inner)
            {
            }
            public EstadoHstNoDefinido(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class FlowInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "Flow invalido (WF)";
			public FlowInvalido() : base(TextoError)
			{
			}
			public FlowInvalido(Exception inner) : base(TextoError, inner)
			{
			}
			public FlowInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class CircuitoInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "Circuito invalido (WF)";
			public CircuitoInvalido() : base(TextoError)
			{
			}
			public CircuitoInvalido(Exception inner) : base(TextoError, inner)
			{
			}
			public CircuitoInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class NivSegInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "Nivel de seguridad invalido (WF)";
			public NivSegInvalido() : base(TextoError)
			{
			}
			public NivSegInvalido(Exception inner) : base(TextoError, inner)
			{
			}
			public NivSegInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class EventoSinSeg : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "Evento sin esquema de seguridad asociado (WF)";
			public EventoSinSeg() : base(TextoError)
			{
			}
			public EventoSinSeg(Exception inner) : base(TextoError, inner)
			{
			}
			public EventoSinSeg(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class UsuarioNoCumpleSeg : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "Usuario no cumple con el esquema de seguridad del evento (WF)";
			public UsuarioNoCumpleSeg() : base(TextoError)
			{
			}
			public UsuarioNoCumpleSeg(Exception inner) : base(TextoError, inner)
			{
			}
			public UsuarioNoCumpleSeg(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class EventoIniMalConfigurado : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "El esquema de seguridad del evento inicial esta configurado de manera incorrecta.  Los eventos iniciales no deben requerir mas de una intervencion (WF)";
			public EventoIniMalConfigurado() : base(TextoError)
			{
			}
			public EventoIniMalConfigurado(Exception inner) : base(TextoError, inner)
			{
			}
			public EventoIniMalConfigurado(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class EstadoVirtualMalConfigurado : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "No es posible encontrar el valor del estado (virtual) de destino, definido en el evento (WF)";
			public EstadoVirtualMalConfigurado() : base(TextoError)
			{
			}
			public EstadoVirtualMalConfigurado(Exception inner) : base(TextoError, inner)
			{
			}
			public EstadoVirtualMalConfigurado(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class CXO : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "Usuario no cumple con el esquema de control por oposicion (WF)";
			public CXO() : base(TextoError)
			{
			}
			public CXO(Exception inner) : base(TextoError, inner)
			{
			}
			public CXO(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class FechaProcesoNoMatch : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "La fecha de proceso no coincide con la fecha de la base de datos";
			public FechaProcesoNoMatch() : base(TextoError)
			{
			}
			public FechaProcesoNoMatch(Exception inner) : base(TextoError, inner)
			{
			}
			public FechaProcesoNoMatch(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
        public class FechaNoMatch : Microsoft.ApplicationBlocks.ExceptionManagement.WF.BaseApplicationException
		{
			static string TextoError = "La fecha no coincide con la fecha de proceso";
			public FechaNoMatch() : base(TextoError)
			{
			}
			public FechaNoMatch(Exception inner) : base(TextoError, inner)
			{
			}
			public FechaNoMatch(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
	}
    namespace Engine
    {
        [Serializable]
        public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
        {
            public BaseApplicationException(string TextoError)
                : base(TextoError)
            {
            }
            public BaseApplicationException(string TextoError, Exception inner)
                : base(TextoError, inner)
            {
            }
            public BaseApplicationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class EntidadInexistente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Cuentas.BaseApplicationException
        {
            static string TextoError = "Entidad inexistente.";
            public EntidadInexistente()
                : base(TextoError)
            {
            }
            public EntidadInexistente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public EntidadInexistente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
    namespace Tablero
    {
        [Serializable]
        public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
        {
            public BaseApplicationException(string TextoError)
                : base(TextoError)
            {
            }
            public BaseApplicationException(string TextoError, Exception inner)
                : base(TextoError, inner)
            {
            }
            public BaseApplicationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
	namespace db
	{
		[Serializable]
		public class Conexion : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Problema de conexión a base de datos";
			public Conexion() : base(TextoError)
			{
			}
			public Conexion(Exception inner) : base(TextoError, inner)
			{
			}
			public Conexion(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class Ejecucion : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Problema en ejecución de script de SQL";
			public Ejecucion() : base(TextoError)
			{
			}
			public Ejecucion(Exception inner) : base(TextoError, inner)
			{
			}
			public Ejecucion(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class EjecucionConRollback : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Problema en ejecución de script de SQL ( Se deshizo la operacion )";
			public EjecucionConRollback() : base(TextoError)
			{
			}
			public EjecucionConRollback(Exception inner) : base(TextoError, inner)
			{
			}
			public EjecucionConRollback(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class Rollback : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Problema al tratar de deshacer la ejecución de un script de SQL";
			public Rollback() : base(TextoError)
			{
			}
			public Rollback(Exception inner) : base(TextoError, inner)
			{
			}
			public Rollback(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class FlowEventoInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Combinación Flow-Evento invalida";
			public FlowEventoInvalido() : base(TextoError)
			{
			}
			public FlowEventoInvalido(Exception inner) : base(TextoError, inner)
			{
			}
			public FlowEventoInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
	}
	namespace Validaciones
	{
		[Serializable]
		public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			public BaseApplicationException(string TextoError) : base(TextoError)
			{
			}
			public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner)
			{
			}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ConexionInactiva : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "Conexión inactiva con ";
			public ConexionInactiva(string Sistema) : base(TextoError + Sistema)
			{
			}
			public ConexionInactiva(Exception inner) : base(TextoError, inner)
			{
			}
			public ConexionInactiva(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
        [Serializable]
        public class ElementoInexistente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
        {
            static string TextoError = "Inexistente";
            public ElementoInexistente(IDescrClase Elemento)
                : base(Elemento._Descripcion + " " + TextoError)
            {
            }
            public ElementoInexistente(IDescrClase Elemento, string Valor)
                : base(Elemento._Descripcion + " " + Valor + " " + TextoError)
            {
            }
            public ElementoInexistente(string Descripcion)
                : base(Descripcion + " " + TextoError)
            {
            }
            public ElementoInexistente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ElementoInexistente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class ElementoExistente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
        {
            static string TextoError = "ya existente";
            public ElementoExistente(IDescrClase Elemento)
                : base(Elemento._Descripcion + " " + TextoError)
            {
            }
            public ElementoExistente(IDescrClase Elemento, string Valor)
                : base(Elemento._Descripcion + " " + Valor + " " + TextoError)
            {
            }
            public ElementoExistente(string Descripcion)
                : base(Descripcion + " " + TextoError)
            {
            }
            public ElementoExistente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ElementoExistente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
		public class AjustePrecision : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "No se puede ajustar ";
			public AjustePrecision(double Numero, int LongitudIncluyendoSeparador) : base(TextoError + Numero + " a " + LongitudIncluyendoSeparador + " posiciones")
			{
			}
			public AjustePrecision(Exception inner) : base(TextoError, inner)
			{
			}
			public AjustePrecision(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ValorInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "valor inválido";
			public ValorInvalido(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public ValorInvalido(Exception inner) : base(TextoError, inner)
			{
			}
			public ValorInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ValorNoInfo : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "sin informar";
			public ValorNoInfo(string descrProp) : base(descrProp + " " + TextoError)
			{
			}
			public ValorNoInfo(Exception inner) : base(TextoError, inner)
			{
			}
			public ValorNoInfo(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ReadOnly : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "modificación inhabilitada";
			public ReadOnly(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public ReadOnly(Exception inner) : base(TextoError, inner)
			{
			}
			public ReadOnly(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ValorNoMatch : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "no coincide, debe ser";
			public ValorNoMatch(string descrProp, string descrPropMatch) : base(descrProp + " " + TextoError + " " + descrPropMatch)
			{
			}
			public ValorNoMatch(Exception inner) : base(TextoError, inner)
			{
			}
			public ValorNoMatch(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ValorNegativo : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "debe ser mayor a cero";
			public ValorNegativo(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public ValorNegativo(Exception inner) : base(TextoError, inner)
			{
			}
			public ValorNegativo(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ValorNoNumerico : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "debe ser numerico";
			public ValorNoNumerico(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public ValorNoNumerico(Exception inner) : base(TextoError, inner)
			{
			}
			public ValorNoNumerico(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ValorNoCombo : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "opción inválida";
			public ValorNoCombo(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public ValorNoCombo(Exception inner) : base(TextoError, inner)
			{
			}
			public ValorNoCombo(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class OpcionInvalida : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "Opción inválida";
			public OpcionInvalida() : base(TextoError)
			{
			}
			public OpcionInvalida(Exception inner) : base(TextoError, inner)
			{
			}
			public OpcionInvalida(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class LenInvalida : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "longitud inválida";
			public LenInvalida(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public LenInvalida(Exception inner) : base(TextoError, inner)
			{
			}
			public LenInvalida(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class TipoNoCoincidente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "el tipo de la base de datos no coincide con la propiedad";
			public TipoNoCoincidente(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public TipoNoCoincidente(Exception inner) : base(TextoError, inner)
			{
			}
			public TipoNoCoincidente(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
        [Serializable]
        public class NoHayDatos : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
        {
            static string TextoError = "No hay datos.";
            public NoHayDatos() : base(TextoError)
            {
            }
            public NoHayDatos(Exception inner)
                : base(TextoError, inner)
            {
            }
            public NoHayDatos(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
		[Serializable]
		public class NoEsMultiploDe24 : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
		{
			static string TextoError = "debe ser multiplo de 24";
			public NoEsMultiploDe24(string descrProp) : base(descrProp + ": " + TextoError)
			{
			}
			public NoEsMultiploDe24(Exception inner) : base(TextoError, inner)
			{
			}
			public NoEsMultiploDe24(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
        [Serializable]
        public class ListaDeExcepciones : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
        {
            static string TextoError = "Lista de errores: ";
            private List<System.Exception> listaE;
            public ListaDeExcepciones(List<System.Exception> l) : base(TextoError)
            {
                listaE = l;
            }
            public List<System.Exception> ListaE
            {
                get
                {
                    return listaE;
                }
            }
        }
		namespace Lote
		{
			[Serializable]
            public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
			{
				public BaseApplicationException(string TextoError) : base(TextoError)
				{
				}
				public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner)
				{
				}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
            [Serializable]
            public class Existente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
            {
                static string TextoError = "Lote existente.";
                public Existente(string Descr)
                    : base(TextoError + "\r\n\r\n" + Descr)
                {
                }
                public Existente(Exception inner)
                    : base(TextoError, inner)
                {
                }
                public Existente(SerializationInfo info, StreamingContext context)
                    : base(info, context)
                {
                }
            }
            [Serializable]
            public class Inexistente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
            {
                static string TextoError = "Lote inexistente.";
                public Inexistente(string Descr)
                    : base(TextoError + "\r\n\r\n" + Descr)
                {
                }
                public Inexistente(Exception inner)
                    : base(TextoError, inner)
                {
                }
                public Inexistente(SerializationInfo info, StreamingContext context)
                    : base(info, context)
                {
                }
            }
            [Serializable]
            public class ProblemasEnvio : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
            {
                static string TextoError = "Problemas al enviar el lote.";
                public ProblemasEnvio(string Descr)
                    : base(TextoError + "\r\n\r\n" + Descr)
                {
                }
                public ProblemasEnvio(Exception inner)
                    : base(TextoError, inner)
                {
                }
                public ProblemasEnvio(SerializationInfo info, StreamingContext context)
                    : base(info, context)
                {
                }
            }
            [Serializable]
            public class ProblemasConsulta : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
            {
                static string TextoError = "Problemas al consultar el lote.";
                public ProblemasConsulta(string Descr)
                    : base(TextoError + "\r\n\r\n" + Descr)
                {
                }
                public ProblemasConsulta(Exception inner)
                    : base(TextoError, inner)
                {
                }
                public ProblemasConsulta(SerializationInfo info, StreamingContext context)
                    : base(info, context)
                {
                }
            }
            [Serializable]
            public class HayEnviosPosteriores : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
            {
                static string TextoError = "No es posible realizar la operación. Hay envios posteriores del lote.";
                public HayEnviosPosteriores(string Descr)
                    : base(TextoError + "\r\n\r\n" + Descr)
                {
                }
                public HayEnviosPosteriores(Exception inner)
                    : base(TextoError, inner)
                {
                }
                public HayEnviosPosteriores(SerializationInfo info, StreamingContext context)
                    : base(info, context)
                {
                }
            }
            [Serializable]
            public class HayEnviosPendientes : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
            {
                static string TextoError = "No es posible realizar la operación. Hay un lote pendiente de envío.";
                public HayEnviosPendientes(string Descr)
                    : base(TextoError + "\r\n\r\n" + Descr)
                {
                }
                public HayEnviosPendientes(Exception inner)
                    : base(TextoError, inner)
                {
                }
                public HayEnviosPendientes(SerializationInfo info, StreamingContext context)
                    : base(info, context)
                {
                }
            }
            [Serializable]
            public class ImposibleAsignarNuevoNroEnvio : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
            {
                static string TextoError = "Es imposible realizar un nuevo envio del lote.";
                public ImposibleAsignarNuevoNroEnvio(string Descr)
                    : base(TextoError + "\r\n\r\n" + Descr)
                {
                }
                public ImposibleAsignarNuevoNroEnvio(Exception inner)
                    : base(TextoError, inner)
                {
                }
                public ImposibleAsignarNuevoNroEnvio(SerializationInfo info, StreamingContext context)
                    : base(info, context)
                {
                }
            }
        }
        namespace Comprobante
        {
            [Serializable]
            public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
            {
                public BaseApplicationException(string TextoError)
                    : base(TextoError)
                {
                }
                public BaseApplicationException(string TextoError, Exception inner)
                    : base(TextoError, inner)
                {
                }
                public BaseApplicationException(SerializationInfo info, StreamingContext context)
                    : base(info, context)
                {
                }
            }
            [Serializable]
            public class Existente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
            {
                static string TextoError = "Comprobante existente.";
                public Existente(string Descr)
                    : base(TextoError + "\r\n\r\n" + Descr)
                {
                }
                public Existente(Exception inner)
                    : base(TextoError, inner)
                {
                }
                public Existente(SerializationInfo info, StreamingContext context)
                    : base(info, context)
                {
                }
            }
            [Serializable]
            public class Inexistente : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
            {
                static string TextoError = "Comprobante inexistente.";
                public Inexistente(string Descr)
                    : base(TextoError + "\r\n\r\n" + Descr)
                {
                }
                public Inexistente(Exception inner)
                    : base(TextoError, inner)
                {
                }
                public Inexistente(SerializationInfo info, StreamingContext context)
                    : base(info, context)
                {
                }
            }
        }
		namespace Fechas
		{
			[Serializable]
			public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
			{
				public BaseApplicationException(string TextoError) : base(TextoError)
				{
				}
				public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner)
				{
				}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class FechaNoHabil : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "Según host la fecha no es un día hábil.";
				public FechaNoHabil(string DescrProp) : base(DescrProp + ":" + TextoError)
				{
				}
				public FechaNoHabil(Exception inner) : base(TextoError, inner)
				{
				}
				public FechaNoHabil(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class FechaDsdCashFlow : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "La fecha desde debe ser siempre la del día hábil anterior.";
				public FechaDsdCashFlow(string DescrProp) : base(DescrProp + ":" + TextoError)
				{
				}
				public FechaDsdCashFlow(Exception inner) : base(TextoError, inner)
				{
				}
				public FechaDsdCashFlow(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class FechaFormatoNoValido : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "Formato incorrecto en: ";
				public FechaFormatoNoValido(string Nombre)
					: base(TextoError + Nombre)
				{
				}
				public FechaFormatoNoValido(Exception inner)
					: base(TextoError, inner)
				{
				}
				public FechaFormatoNoValido(SerializationInfo info, StreamingContext context)
					: base(info, context)
				{
				}
			}
			[Serializable]
			public class FechaAñoInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "Año incorrecto en";
				public FechaAñoInvalido(string Nombre)
					: base(TextoError+Nombre)
				{
				}
				public FechaAñoInvalido(Exception inner)
					: base(TextoError, inner)
				{
				}
				public FechaAñoInvalido(SerializationInfo info, StreamingContext context)
					: base(info, context)
				{
				}
			}

			[Serializable]
			public class FechaMesInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "Mes incorrecto en ";
				public FechaMesInvalido(string Nombre)
					: base(TextoError+ Nombre)
				{
				}
				public FechaMesInvalido(Exception inner)
					: base(TextoError, inner)
				{
				}
				public FechaMesInvalido(SerializationInfo info, StreamingContext context)
					: base(info, context)
				{
				}
			}
			[Serializable]
			public class FechaDiaInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Fechas.BaseApplicationException
			{
				static string TextoError = "Dia Incorrecto en ";
				public FechaDiaInvalido(string Nombre)
					: base(TextoError + Nombre)
				{
				}
				public FechaDiaInvalido(Exception inner)
					: base(TextoError, inner)
				{
				}
				public FechaDiaInvalido(SerializationInfo info, StreamingContext context)
					: base(info, context)
				{
				}
			}
		}
		namespace Cuentas
		{
			[Serializable]
			public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.BaseApplicationException
			{
				public BaseApplicationException(string TextoError) : base(TextoError)
				{
				}
				public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner)
				{
				}
				public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class Duplicada : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Cuentas.BaseApplicationException
			{
				static string TextoError = "No se pudo dar de alta esa cuenta porque ya está cargada.";
				public Duplicada() : base(TextoError)
				{
				}
				public Duplicada(Exception inner) : base(TextoError, inner)
				{
				}
				public Duplicada(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			public class IdCuentaDuplicado : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Cuentas.BaseApplicationException
			{
				static string TextoError = "El nuevo Id. de cuenta generaría valores duplicados";
				public IdCuentaDuplicado() : base(TextoError)
				{
				}
				public IdCuentaDuplicado(Exception inner) : base(TextoError, inner)
				{
				}
				public IdCuentaDuplicado(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class TasaDuplicada : Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.Cuentas.BaseApplicationException
			{
				static string TextoError = "Esa tasa ya existe en el sistema.";
				public TasaDuplicada() : base(TextoError)
				{
				}
				public TasaDuplicada(Exception inner) : base(TextoError, inner)
				{
				}
				public TasaDuplicada(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
		}
	}
	namespace Sesion
	{
		[Serializable]
		public class BaseApplicationException : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			public BaseApplicationException(string TextoError) : base(TextoError)
			{
			}
			public BaseApplicationException(string TextoError, Exception inner) : base(TextoError, inner)
			{
			}
			public BaseApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class Crear : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "No se puede crear una sesión de trabajo";
			public Crear() : base(TextoError)
			{
			}
			public Crear(Exception inner) : base(TextoError, inner)
			{
			}
			public Crear(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class AplicInvalida : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Codigo de aplicación inválido";
			public AplicInvalida() : base(TextoError)
			{
			}
			public AplicInvalida(Exception inner) : base(TextoError, inner)
			{
			}
			public AplicInvalida(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ParametroInexistente : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Parámetro AppConfig inexistente: ";
			public ParametroInexistente(string NombreParametro) : base(TextoError + NombreParametro)
			{
			}
			public ParametroInexistente(Exception inner) : base(TextoError, inner)
			{
			}
			public ParametroInexistente(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		namespace Usuario
		{
			[Serializable]
			public class NoHabilitado : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
			{
				static string TextoError = "Usuario no habilitado";
				public NoHabilitado() : base(TextoError)
				{
				}
				public NoHabilitado(Exception inner) : base(TextoError, inner)
				{
				}
				public NoHabilitado(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class NoActivo : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
			{
				static string TextoError = "Usuario no activo";
				public NoActivo() : base(TextoError)
				{
				}
				public NoActivo(Exception inner) : base(TextoError, inner)
				{
				}
				public NoActivo(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
			[Serializable]
			public class DeBaja : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
			{
				static string TextoError = "Usuario dado de baja";
				public DeBaja() : base(TextoError)
				{
				}
				public DeBaja(Exception inner) : base(TextoError, inner)
				{
				}
				public DeBaja(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
		}
	}
    namespace Vendedor
    {
        [Serializable]
        public class Inexistente : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
        {
            static string TextoError = "Vendedor inexistente";
            public Inexistente()
                : base(TextoError)
            {
            }
            public Inexistente(string msg)
                : base(TextoError + ": " + msg)
            {
            }
            public Inexistente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public Inexistente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
	namespace Archivo
	{
		[Serializable]
		public class ProcesarArchivo : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Problema procesando archivo";
			public ProcesarArchivo() : base(TextoError)
			{
			}
			public ProcesarArchivo(string msg) : base(TextoError + ": " + msg)
			{
			}
			public ProcesarArchivo(Exception inner) : base(TextoError, inner)
			{
			}
			public ProcesarArchivo(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
        public class CUITNoHabilitadoParaElUsuario: Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
        {
            static string TextoError = "El usuario no puede procesar archivos del siguiente CUIT";
            public CUITNoHabilitadoParaElUsuario()
                : base(TextoError)
            {
            }
            public CUITNoHabilitadoParaElUsuario(string Cuit)
                : base(TextoError + ": " + Cuit)
            {
            }
            public CUITNoHabilitadoParaElUsuario(Exception inner)
                : base(TextoError, inner)
            {
            }
            public CUITNoHabilitadoParaElUsuario(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
		[Serializable]
		public class ArchivoInconsistente : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Archivo inconsistente";
			public ArchivoInconsistente() : base(TextoError)
			{
			}
			public ArchivoInconsistente(string msg) : base(TextoError + ": " + msg)
			{
			}
			public ArchivoInconsistente(Exception inner) : base(TextoError, inner)
			{
			}
			public ArchivoInconsistente(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class ArchivoInexistente : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Archivo inexistente";
			public ArchivoInexistente() : base(TextoError)
			{
			}
			public ArchivoInexistente(string NombreArchivo) : base(TextoError + ": " + NombreArchivo)
			{
			}
			public ArchivoInexistente(Exception inner) : base(TextoError, inner)
			{
			}
			public ArchivoInexistente(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
        [Serializable]
        public class TipoDeArchivoIncorrecto: Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
        {
            static string TextoError = "Tipo de archivo incorrecto.";
            public TipoDeArchivoIncorrecto()
                : base(TextoError)
            {
            }
            public TipoDeArchivoIncorrecto(string NombreArchivo)
                : base(TextoError + ": " + NombreArchivo)
            {
            }
            public TipoDeArchivoIncorrecto(Exception inner)
                : base(TextoError, inner)
            {
            }
            public TipoDeArchivoIncorrecto(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
	}
	namespace XML
	{
		[Serializable]
		public class Transformacion : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Transformación fallida";
			public Transformacion() : base(TextoError)
			{
			}
			public Transformacion(Exception inner) : base(TextoError, inner)
			{
			}
			public Transformacion(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
	}
	namespace Login
	{
		[Serializable]
		public class AutenticacionInvalida : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Tipo de autenticacion invalida.  Corrija el archivo de configuración.";
			public AutenticacionInvalida() : base(TextoError)
			{
			}
			public AutenticacionInvalida(Exception inner) : base(TextoError, inner)
			{
			}
			public AutenticacionInvalida(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class IdUsuarioNoInfo : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Nombre del usuario no informado";
			public IdUsuarioNoInfo() : base(TextoError)
			{
			}
			public IdUsuarioNoInfo(Exception inner) : base(TextoError, inner)
			{
			}
			public IdUsuarioNoInfo(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class PasswordNoInfo : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Contraseña no informada";
			public PasswordNoInfo() : base(TextoError)
			{
			}
			public PasswordNoInfo(Exception inner) : base(TextoError, inner)
			{
			}
			public PasswordNoInfo(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class PasswordNoMatch : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Contraseña incorrecta";
			public PasswordNoMatch() : base(TextoError)
			{
			}
			public PasswordNoMatch(Exception inner) : base(TextoError, inner)
			{
			}
			public PasswordNoMatch(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class UsuarioRevocado : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "El código de usuario ha sido revocado";
			public UsuarioRevocado() : base(TextoError)
			{
			}
			public UsuarioRevocado(Exception inner) : base(TextoError, inner)
			{
			}
			public UsuarioRevocado(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class Indefinido : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Problema en el login";
			public Indefinido()
				: base(TextoError)
			{
			}
			public Indefinido(int CodError)
				: base(TextoError + ":" + CodError)
			{
			}
			public Indefinido(Exception inner)
				: base(TextoError, inner)
			{
			}
			public Indefinido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class NoInformado : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Usuario no informado";
			public NoInformado()
				: base(TextoError)
			{
			}
			public NoInformado(Exception inner)
				: base(TextoError, inner)
			{
			}
			public NoInformado(SerializationInfo info, StreamingContext context)
				: base(info, context)
			{
			}
		}
		[Serializable]
		public class UsuarioInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "El código de usuario es inválido";
			public UsuarioInvalido() : base(TextoError)
			{
			}
			public UsuarioInvalido(Exception inner) : base(TextoError, inner)
			{
			}
			public UsuarioInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class UsuarioExpirado : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "El código de usuario ha expirado";
			public UsuarioExpirado() : base(TextoError)
			{
			}
			public UsuarioExpirado(Exception inner) : base(TextoError, inner)
			{
			}
			public UsuarioExpirado(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class DestinoInvalido : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "El destino es inválido";
			public DestinoInvalido() : base(TextoError)
			{
			}
			public DestinoInvalido(Exception inner) : base(TextoError, inner)
			{
			}
			public DestinoInvalido(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
	}
	namespace Aplicacion
	{
		[Serializable]
		public class AssemblyVersionInvalida : Microsoft.ApplicationBlocks.ExceptionManagement.Sesion.BaseApplicationException
		{
			static string TextoError = "Versión desactualizada";
			public AssemblyVersionInvalida(string VersionNoActualizada, string VersionVigente)
				: base("La versión que se esta ejecutando (" + VersionNoActualizada + ") no está actualizada.\r\nSolicite la instalación del release más actualizado de la  versión " + VersionVigente + " en el servidor " + System.Net.Dns.GetHostName())
			{
			}
			public AssemblyVersionInvalida(Exception inner) : base(TextoError, inner)
			{
			}
			public AssemblyVersionInvalida(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
	}
	namespace WS
	{
		[Serializable]
		public class MensajeErrorWSCP : Microsoft.ApplicationBlocks.ExceptionManagement.BaseApplicationException
		{
			static string TextoError = "Error en WS: ";
			public MensajeErrorWSCP()
				: base(TextoError)
			{
			}
			public MensajeErrorWSCP(string Elemento): base(TextoError + Elemento)
			{
			}
			public MensajeErrorWSCP(Exception inner)
				: base(TextoError, inner)
			{
			}
			public MensajeErrorWSCP(SerializationInfo info, StreamingContext context)
				: base(info, context)
			{
			}
		}
	}
}
