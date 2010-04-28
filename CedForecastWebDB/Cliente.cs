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
            a.Append("where Cliente.IdCliente='" + Cliente.IdCliente.ToString() + "'");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Cliente " + Cliente.IdCliente.ToString());
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
            Hasta.IdCliente = Convert.ToString(Desde["IdCliente"]);
            Hasta.DescrCliente = Convert.ToString(Desde["DescrCliente"]);
            Hasta.Zona = new CedForecastWebEntidades.Zona(); 
            Hasta.Zona.IdZona = Convert.ToString(Desde["IdZona"]);
            Hasta.Zona.DescrZona = Convert.ToString(Desde["DescrZona"]);
            Hasta.Habilitado = Convert.ToBoolean(Desde["Habilitado"]);
            Hasta.FechaUltModif = Convert.ToDateTime(Desde["FechaUltModif"]);
        }
    }
}
