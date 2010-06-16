using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CedForecastWebDB
{
    public class Cuenta : db
    {
        public Cuenta(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Leer(CedForecastWebEntidades.Cuenta Cuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Cuenta.IdCuenta, Cuenta.Nombre, Cuenta.Telefono, Cuenta.Email, Cuenta.IdDivision, Division.DescrDivision, Cuenta.Password, Cuenta.Pregunta, Cuenta.Respuesta, Cuenta.IdTipoCuenta, TipoCuenta.DescrTipoCuenta, Cuenta.IdEstadoCuenta, EstadoCuenta.DescrEstadoCuenta, Cuenta.FechaAlta, Cuenta.CantidadEnviosMail, Cuenta.FechaUltimoReenvioMail, Cuenta.EmailSMS, Cuenta.RecibeAvisoAltaCuenta, Cuenta.IdPaginaDefault, PaginaDefault.DescrPaginaDefault, PaginaDefault.URL ");
            a.Append("from Cuenta left outer join Division on Cuenta.IdDivision = Division.IdDivision, TipoCuenta, EstadoCuenta, PaginaDefault ");
            a.Append("where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' and Cuenta.IdTipoCuenta=TipoCuenta.IdTipoCuenta and Cuenta.IdEstadoCuenta=EstadoCuenta.IdEstadoCuenta and Cuenta.IdPaginaDefault=PaginaDefault.IdPaginaDefault ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Cuenta " + Cuenta.Id.ToString());
            }
            else
            {
                Copiar(dt.Rows[0], Cuenta);
            }
        }
        private void Copiar(DataRow Desde, CedForecastWebEntidades.Cuenta Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdCuenta"]);
            Hasta.Nombre = Convert.ToString(Desde["Nombre"]);
            Hasta.Telefono = Convert.ToString(Desde["Telefono"]);
            Hasta.Email = Convert.ToString(Desde["Email"]);
            Hasta.Division.Id = Convert.ToString(Desde["IdDivision"]);
            Hasta.Division.Descr = Convert.ToString(Desde["DescrDivision"]);
            Hasta.Password = Convert.ToString(Desde["Password"]);
            Hasta.Pregunta = Convert.ToString(Desde["Pregunta"]);
            Hasta.Respuesta = Convert.ToString(Desde["Respuesta"]);
            Hasta.TipoCuenta.Id = Convert.ToString(Desde["IdTipoCuenta"]);
            Hasta.TipoCuenta.Descr = Convert.ToString(Desde["DescrTipoCuenta"]);
            Hasta.EstadoCuenta.Id = Convert.ToString(Desde["IdEstadoCuenta"]);
            Hasta.EstadoCuenta.Descr = Convert.ToString(Desde["DescrEstadoCuenta"]);
            Hasta.FechaAlta = Convert.ToDateTime(Desde["FechaAlta"]);
            Hasta.CantidadEnviosMail = Convert.ToInt32(Desde["CantidadEnviosMail"]);
            Hasta.FechaUltimoReenvioMail = Convert.ToDateTime(Desde["FechaUltimoReenvioMail"]);
            Hasta.EmailSMS = Convert.ToString(Desde["EmailSMS"]);
            Hasta.RecibeAvisoAltaCuenta = Convert.ToBoolean(Desde["RecibeAvisoAltaCuenta"]);
            Hasta.PaginaDefault.Id = Convert.ToString(Desde["IdPaginaDefault"]);
            Hasta.PaginaDefault.Descr = Convert.ToString(Desde["DescrPaginaDefault"]);
            Hasta.PaginaDefault.URL = Convert.ToString(Desde["URL"]);
        }
        public void Crear(CedForecastWebEntidades.Cuenta Cuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("Insert Cuenta values (");
            a.Append("'"+Cuenta.Id+"', ");
            a.Append("'"+Cuenta.Nombre+"', ");
            a.Append("'"+Cuenta.Telefono+"', ");
            a.Append("'"+Cuenta.Email+"', ");
            a.Append("'"+Cuenta.Division.Id + "', ");
            a.Append("'"+Cuenta.Password+"', ");
            a.Append("'"+Cuenta.Pregunta+"', ");
            a.Append("'"+Cuenta.Respuesta+"', ");
            a.Append("'"+Cuenta.TipoCuenta.Id+"', ");
            a.Append("'" + Cuenta.EstadoCuenta.Id + "', ");
            a.Append("'" + Cuenta.PaginaDefault.Id + "', ");
            a.Append("getdate(), ");    //FechaAlta
            a.Append("1, ");            //CantidadEnviosMail
            a.Append("getdate(), ");    //FechaUltimoReenvioMail
            a.Append("'', ");           //EmailSMS
            a.Append("0, ");            //RecibeAvisoAltaCuenta
            a.Append("getdate(), ");    //FechaULtModif
            a.Append(")");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Confirmar(CedForecastWebEntidades.Cuenta Cuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set IdEstadoCuenta='Vigente' where IdCuenta='" + Cuenta.Id + "' and IdEstadoCuenta='PteConf' ");
            int cantReg = (int)Ejecutar(a.ToString(), TipoRetorno.CantReg, Transaccion.NoAcepta, sesion.CnnStr);
            if (cantReg != 1)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.CuentaConfUpdateErroneo();
            }
        }
        public bool IdCuentaDisponible(CedForecastWebEntidades.Cuenta Cuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("IF EXISTS(select * from Cuenta where IdCuenta='" + Cuenta.Id + "') ");
            a.Append("  BEGIN ");
            a.Append("	select convert(bit, 0) as Disponible ");
            a.Append("  END ");
            a.Append("ELSE IF EXISTS(select * from CuentaDepurada where IdCuenta='" + Cuenta.Id + "') ");
            a.Append("  BEGIN ");
            a.Append("	select convert(bit, 0) as Disponible ");
            a.Append("  END ");
            a.Append("ELSE ");
            a.Append("  BEGIN ");
            a.Append("	select convert(bit, 1) as Disponible ");
            a.Append("  END ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            return Convert.ToBoolean(dt.Rows[0]["Disponible"]);
        }
        public void CambiarPassword(CedForecastWebEntidades.Cuenta Cuenta, string PasswordNueva)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set Password='" + PasswordNueva + "' where IdCuenta='" + Cuenta.Id + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public List<CedForecastWebEntidades.Cuenta> Lista(string Email)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Cuenta.IdCuenta, Cuenta.Nombre, Cuenta.Telefono, Cuenta.Email, Cuenta.IdDivision, Division.DescrDivision, Cuenta.Password, Cuenta.Pregunta, Cuenta.Respuesta, Cuenta.IdTipoCuenta, TipoCuenta.DescrTipoCuenta, Cuenta.IdEstadoCuenta, EstadoCuenta.DescrEstadoCuenta, Cuenta.FechaAlta, Cuenta.CantidadEnviosMail, Cuenta.FechaUltimoReenvioMail, Cuenta.EmailSMS, Cuenta.RecibeAvisoAltaCuenta, Cuenta.IdPaginaDefault, PaginaDefault.DescrPaginaDefault, PaginaDefault.URL ");
            a.Append("from Cuenta, TipoCuenta, EstadoCuenta, PaginaDefault, Division ");
            a.Append("where Cuenta.Email='" + Email + "' and Cuenta.IdTipoCuenta=TipoCuenta.IdTipoCuenta and Cuenta.IdEstadoCuenta=EstadoCuenta.IdEstadoCuenta and Cuenta.IdPaginaDefault=PaginaDefault.IdPaginaDefault and Cuenta.IdDivision = Division.IdDivision ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Cuenta.NoHayCuentasAsociadasAEmail();
            }
            else
            {
                List<CedForecastWebEntidades.Cuenta> lista = new List<CedForecastWebEntidades.Cuenta>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.Cuenta cuenta = new CedForecastWebEntidades.Cuenta();
                    Copiar(dt.Rows[i], cuenta);
                    lista.Add(cuenta);
                }
                return lista;
            }
        }
        public List<CedForecastWebEntidades.Cuenta> Lista(int IndicePagina, int TamañoPagina, string OrderBy)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("Cuenta.IdCuenta, Cuenta.Nombre, Cuenta.Telefono, Cuenta.Email, Cuenta.IdDivision, Division.DescrDivision, Cuenta.Password, Cuenta.Pregunta, Cuenta.Respuesta, Cuenta.IdTipoCuenta, TipoCuenta.DescrTipoCuenta, Cuenta.IdEstadoCuenta, EstadoCuenta.DescrEstadoCuenta, Cuenta.FechaAlta, Cuenta.CantidadEnviosMail, Cuenta.FechaUltimoReenvioMail, Cuenta.EmailSMS, Cuenta.RecibeAvisoAltaCuenta, Cuenta.IdPaginaDefault, PaginaDefault.DescrPaginaDefault, PaginaDefault.URL ");
            a.Append("from Cuenta, TipoCuenta, EstadoCuenta, PaginaDefault, Division ");
            a.Append("where Cuenta.IdTipoCuenta=TipoCuenta.IdTipoCuenta and Cuenta.IdEstadoCuenta=EstadoCuenta.IdEstadoCuenta and Cuenta.IdPaginaDefault=PaginaDefault.IdPaginaDefault and Cuenta.IdDivision = Division.IdDivision ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * TamañoPagina), OrderBy, (IndicePagina * TamañoPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.Cuenta> lista = new List<CedForecastWebEntidades.Cuenta>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.Cuenta cuenta = new CedForecastWebEntidades.Cuenta();
                    Copiar(dt.Rows[i], cuenta);
                    lista.Add(cuenta);
                }
            }
            return lista;
        }
        public int CantidadDeFilas()
        {
            return CantidadDeFilas(true);
        }
        public int CantidadDeFilas(bool IncluirAdministradores)
        {
            string commandText;
            if (IncluirAdministradores)
            {
                commandText = "select count(*) from Cuenta ";
            }
            else
            {
                commandText = "select count(*) from Cuenta where IdTipoCuenta<>'Admin' ";
            }
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
        public void Configurar(CedForecastWebEntidades.Cuenta Cuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set ");
            a.Append("Nombre='" + Cuenta.Nombre + "', ");
            a.Append("Telefono='" + Cuenta.Telefono + "', ");
            a.Append("IdDivision='" + Cuenta.Division.Id + "', ");
            a.Append("EmailSMS='" + Cuenta.EmailSMS + "', ");
            a.Append("IdPaginaDefault='" + Cuenta.PaginaDefault.Id + "' ");
            a.Append("where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void CambiarEstado(CedForecastWebEntidades.Cuenta Cuenta, CedForecastWebEntidades.EstadoCuenta NuevoEstadoCuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set ");
            a.Append("IdEstadoCuenta='" + NuevoEstadoCuenta.Id + "' ");
            a.Append("where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void CambiarTipo(CedForecastWebEntidades.Cuenta Cuenta, CedForecastWebEntidades.TipoCuenta NuevoTipoCuenta, DateTime FechaVtoActivacion)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set ");
            a.Append("IdTipoCuenta='" + NuevoTipoCuenta.Id + "', ");
            a.Append("FechaVtoActivacion='" + FechaVtoActivacion.ToString("yyyyMMdd HH:mm:ss") + "' ");
            a.Append("where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void CambiarTipo(CedForecastWebEntidades.Cuenta Cuenta, CedForecastWebEntidades.TipoCuenta NuevoTipoCuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set ");
            a.Append("IdTipoCuenta='" + NuevoTipoCuenta.Id + "', ");
            a.Append("FechaVtoActivacion='99991231' ");
            a.Append("where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public List<CedForecastWebEntidades.Cuenta> DepurarBajasYPtesConf()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            //Depurar cuentas dadas de baja y ptes de confirmacion.
            a.Append("insert CuentaDepurada select * from Cuenta where IdEstadoCuenta in ('Baja', 'PteConf') ");
            a.Append("delete Cuenta where IdEstadoCuenta in ('Baja', 'PteConf') ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.Cuenta> lista = new List<CedForecastWebEntidades.Cuenta>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CedForecastWebEntidades.Cuenta cuenta = new CedForecastWebEntidades.Cuenta();
                Copiar(dt.Rows[i], cuenta);
                lista.Add(cuenta);
            }
            return lista;
        }
        public void RegistrarReenvioMail(CedForecastWebEntidades.Cuenta Cuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set Cuenta.CantidadEnviosMail=Cuenta.CantidadEnviosMail+1, FechaUltimoReenvioMail=getdate() where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void SetearRecibeConfirmacionCargaViaMail(CedForecastWebEntidades.Cuenta Cuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuenta set Cuenta.RecibeAvisoAltaCuenta=" + Convert.ToInt32(Cuenta.RecibeAvisoAltaCuenta) + " where Cuenta.IdCuenta='" + Cuenta.Id.ToString() + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public List<CedForecastWebEntidades.Cuenta> DestinatariosAvisoAltaCuenta()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Cuenta.IdCuenta, Cuenta.Nombre, Cuenta.Telefono, Cuenta.Email, Cuenta.IdDivision, Division.DescrDivision, Cuenta.Password, Cuenta.Pregunta, Cuenta.Respuesta, Cuenta.IdTipoCuenta, TipoCuenta.DescrTipoCuenta, Cuenta.IdEstadoCuenta, EstadoCuenta.DescrEstadoCuenta, Cuenta.UltimoNroLote, Cuenta.FechaAlta, Cuenta.CantidadEnviosMail, Cuenta.FechaUltimoReenvioMail, Cuenta.Activar, Cuenta.NroSerieDisco, Cuenta.IdMedio, Medio.DescrMedio, Cuenta.EmailSMS, Cuenta.RecibeAvisoAltaCuenta, Cuenta.CantidadComprobantes, Cuenta.FechaUltimoComprobante, Cuenta.FechaVtoActivacion, Cuenta.IdPaginaDefault, Cuenta.NroSerieCertificado, PaginaDefault.DescrPaginaDefault, PaginaDefault.URL ");
            a.Append("from Cuenta, TipoCuenta, EstadoCuenta, Medio, PaginaDefault, Division ");
            a.Append("where RecibeAvisoAltaCuenta=1 and EmailSMS<>'' ");
            a.Append("and Cuenta.IdTipoCuenta=TipoCuenta.IdTipoCuenta and Cuenta.IdEstadoCuenta=EstadoCuenta.IdEstadoCuenta and Cuenta.IdMedio=Medio.IdMedio and Cuenta.IdPaginaDefault=PaginaDefault.IdPaginaDefault and Cuenta.IdDivision = Division.IdDivision ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.Cuenta> lista = new List<CedForecastWebEntidades.Cuenta>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CedForecastWebEntidades.Cuenta cuenta = new CedForecastWebEntidades.Cuenta();
                Copiar(dt.Rows[i], cuenta);
                lista.Add(cuenta);
            }
            return lista;
        }
        public DateTime FechaUltimaSincronizacion()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select max(FechaUltModif) as FechaUltModif from Cuenta where IdTipoCuenta='OperForecast' ");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows[0]["FechaUltModif"] != DBNull.Value)
            {
                return Convert.ToDateTime(dt.Rows[0]["FechaUltModif"]);
            }
            else
            {
                return new DateTime(1980, 1, 1);
            }
        }
        public void Actualizar(CedForecastWebEntidades.Cuenta Elemento)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("if exists (select IdCuenta from Cuenta where IdCuenta='" + Elemento.Id + "') ");
            a.Append("update Cuenta set ");
            a.Append("Nombre='" + Elemento.Nombre + "', ");
            a.Append("Telefono='" + Elemento.Telefono + "', ");
            a.Append("Email='" + Elemento.Email + "', ");
            a.Append("IdDivision='" + Elemento.Division.Id + "', ");
            //La Password ya no se vuelve a modificar (sólo se la considera en el alta de una Cuenta desde Bejerman)
            a.Append("IdEstadoCuenta='" + Elemento.EstadoCuenta.Id + "', ");
            a.Append("FechaUltModif='" + Elemento.FechaUltModif.ToString("yyyyMMdd HH:mm:ss.fff") + "' ");
            a.Append("where IdCuenta='" + Elemento.Id + "' ");
            a.Append("else ");
            a.Append("if not exists (select IdCuenta from CuentaDepurada where IdCuenta='" + Elemento.Id + "') ");
            a.Append("insert Cuenta values ( ");
            a.Append("'" + Elemento.Id + "', ");
            a.Append("'" + Elemento.Nombre + "', ");
            a.Append("'" + Elemento.Telefono + "', ");
            a.Append("'" + Elemento.Email + "', ");
            a.Append("'" + Elemento.Division.Id + "', ");
            a.Append("'" + Elemento.Password + "', ");
            a.Append("'" + Elemento.Pregunta + "', ");
            a.Append("'" + Elemento.Respuesta + "', ");
            a.Append("'" + Elemento.TipoCuenta.Id + "', ");
            a.Append("'" + Elemento.EstadoCuenta.Id + "', ");
            a.Append("'" + Elemento.PaginaDefault.Id + "', ");
            a.Append("'" + Elemento.FechaAlta.ToString("yyyyMMdd HH:mm:ss.fff") + "', ");
            a.Append(Elemento.CantidadEnviosMail + ", ");
            a.Append("'" + Elemento.FechaUltimoReenvioMail.ToString("yyyyMMdd HH:mm:ss.fff") + "', ");
            a.Append("'" + Elemento.EmailSMS+ "', ");
            a.Append(Convert.ToInt16(Elemento.RecibeAvisoAltaCuenta).ToString() + ", ");
            a.Append("'" + Elemento.FechaUltModif.ToString("yyyyMMdd HH:mm:ss.fff") + "' ");
            a.Append(") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}