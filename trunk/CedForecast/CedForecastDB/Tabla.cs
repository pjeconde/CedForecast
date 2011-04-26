using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB
{
    public class Tabla : db
    {
        string nombreTabla;

        public Tabla(CedEntidades.Sesion Sesion, string NombreTabla) : base(Sesion)
        {
            nombreTabla = NombreTabla;
        }
        public List<CedForecastEntidades.Codigo> Leer()
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select * from Tabla where Tabla='"+nombreTabla+"' order by Descr");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastEntidades.Codigo> lista = new List<CedForecastEntidades.Codigo>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastEntidades.Codigo elemento = new CedForecastEntidades.Codigo();
                    Copiar(dt.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastEntidades.Codigo Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["Id"]);
            Hasta.Descr = Convert.ToString(Desde["Descr"]);
        }
        public void Crear(CedForecastEntidades.Codigo Codigo)
        {
            StringBuilder a = new StringBuilder(String.Empty);
            a.Append("insert Tabla (Tabla, Id, Descr) values (");
            a.Append("'" + nombreTabla + "', ");
            a.Append("'" + Codigo.Id + "', ");
            a.Append("'" + Codigo.Descr + "') ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Modificar(CedForecastEntidades.Codigo Codigo)
        {
            StringBuilder a = new StringBuilder(String.Empty);
            a.Append("update Tabla set ");
            a.Append("Descr='" + Codigo.Descr + "' ");
            a.Append("where Tabla='" + nombreTabla + "' and Id='" + Codigo.Id + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Eliminar(CedForecastEntidades.Codigo Codigo)
        {
            StringBuilder a = new StringBuilder(String.Empty);
            a.Append("delete Tabla ");
            a.Append("where Tabla='" + nombreTabla + "' and Id='" + Codigo.Id + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}
