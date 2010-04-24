using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace CedForecastWebDB
{
    public class Texto : db
    {
        public Texto(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Leer(CedForecastWebEntidades.Texto Texto)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select IdTexto, DescrTexto from Texto ");
            a.Append("where IdTexto='" + Texto.Id.ToString() + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Texto " + Texto.Id.ToString());
            }
            else
            {
                Texto.Descr = Convert.ToString(dt.Rows[0]["DescrTexto"]);
            }
        }
    }
}