using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastWebDB
{
    public class Cliente: db
    {
        public Cliente(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public void Leer(CedForecastWebEntidades.Cliente Cliente)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Cliente.IdCliente, Cliente.DescrCliente, Cliente.IdZona, Cliente.Habilitado, Cliente.FechaUltModif ");
            a.Append("from Cliente left outer join Zona on Cliente.IdZona=Zona.IdZona ");
            a.Append("where Cliente.IdCliente='" + Cliente.Id.ToString() + "'");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Cliente " + Cliente.Id.ToString());
            }
            else
            {
                Copiar(dt.Rows[0], Cliente);
            }
        }
        public List<CedForecastWebEntidades.Cliente> Lista(bool ConClienteSinInformar)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select Cliente.IdCliente, Cliente.DescrCliente, Cliente.IdZona, Cliente.Habilitado, Cliente.FechaUltModif, Zona.DescrZona ");
            a.Append("from Cliente left outer join Zona on Cliente.IdZona=Zona.IdZona");
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastWebEntidades.Cliente> lista = new List<CedForecastWebEntidades.Cliente>();
            if (dt.Rows.Count != 0)
            {
                if (ConClienteSinInformar)
                {
                    lista.Add(new CedForecastWebEntidades.Cliente());
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastWebEntidades.Cliente cliente = new CedForecastWebEntidades.Cliente();
                    Copiar(dt.Rows[i], cliente);
                    lista.Add(cliente);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastWebEntidades.Cliente Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdCliente"]);
            Hasta.Descr = Convert.ToString(Desde["DescrCliente"]);
            Hasta.Zona = new CedForecastWebEntidades.Zona(); 
            Hasta.Zona.Id = Convert.ToString(Desde["IdZona"]);
            Hasta.Zona.Descr = Convert.ToString(Desde["DescrZona"]);
            Hasta.Habilitado = Convert.ToBoolean(Desde["Habilitado"]);
            Hasta.FechaUltModif = Convert.ToDateTime(Desde["FechaUltModif"]);
        }
        public DateTime FechaUltimaSincronizacion()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select max(FechaUltModif) as FechaUltModif from Cliente ");
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
        public void Actualizar(CedForecastWebEntidades.Cliente Elemento)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("if exists (select IdCliente from Cliente where IdCliente='" + Elemento.Id + "') ");
            a.Append("update Cliente set ");
            a.Append("DescrCliente='" + Elemento.Descr + "', ");
            a.Append("IdZona='" + Elemento.Zona.Id + "', ");
            a.Append("Habilitado=" + Convert.ToInt16(Elemento.Habilitado).ToString() + ", ");
            a.Append("FechaUltModif='" + Elemento.FechaUltModif.ToString("yyyyMMdd HH:mm:ss.fff") + "' ");
            a.Append("where IdCliente='" + Elemento.Id + "' ");
            a.Append("else ");
            a.Append("insert Cliente values ( ");
            a.Append("'" + Elemento.Id + "', ");
            a.Append("'" + Elemento.Descr + "', ");
            a.Append("'" + Elemento.Zona.Id + "', ");
            a.Append(Convert.ToInt16(Elemento.Habilitado).ToString() + ", ");
            a.Append("'" + Elemento.FechaUltModif.ToString("yyyyMMdd HH:mm:ss.fff") + "' ");
            a.Append(") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}
