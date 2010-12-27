using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB.Bejerman
{
    public class Cotizacion : db
    {
        public Cotizacion(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }
        public List<CedForecastEntidades.Bejerman.Cotizacion> LeerLista(string Mon_codigo)
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select mon_codigo, mtca_codigo, mcot_fecha, mcot_cotiza from manager.dbo.mon_cam ");
            if (Mon_codigo != "")
            {
                a.Append("where mon_codigo = '" + Mon_codigo + "' ");
            }
            a.Append("order by mon_codigo, mcot_fecha desc, mtca_codigo ");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStrAplicExterna);
            return Lista(dt);
        }
        private List<CedForecastEntidades.Bejerman.Cotizacion> Lista(DataTable Datos)
        {
            List<CedForecastEntidades.Bejerman.Cotizacion> lista = new List<CedForecastEntidades.Bejerman.Cotizacion>();
            if (Datos.Rows.Count != 0)
            {
                for (int i = 0; i < Datos.Rows.Count; i++)
                {
                    CedForecastEntidades.Bejerman.Cotizacion elemento = new CedForecastEntidades.Bejerman.Cotizacion();
                    Copiar(Datos.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastEntidades.Bejerman.Cotizacion Hasta)
        {
            Hasta.Mon_codigo = Convert.ToString(Desde["Mon_codigo"]);
            Hasta.Mtca_codigo = Convert.ToString(Desde["Mtca_codigo"]);
            Hasta.Mcot_fecha = Convert.ToDateTime(Desde["Mcot_fecha"]);
            Hasta.Mcot_cotiza = Convert.ToDecimal(Desde["Mcot_cotiza"]);
        }
    }
}
