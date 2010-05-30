using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB
{
    public class Forecast: db
    {
        public Forecast(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }

        public void EliminarProyectadoAnual(string Año)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete Forecast where Forecast.IdTipoPlanilla='Proyectado' and Forecast.IdPeriodo='" + Año + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Crear(CedForecastEntidades.Forecast Elemento)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("insert Forecast values ( ");
            a.Append("'" + Elemento.IdTipoPlanilla + "', ");
            a.Append("'" + Elemento.IdCuenta + "', ");
            a.Append("'" + Elemento.IdCliente + "', ");
            a.Append("'" + Elemento.IdArticulo + "', ");
            a.Append("'" + Elemento.IdPeriodo + "', ");
            a.Append(Convert.ToString(Elemento.Cantidad, cedeiraCultura) + " ");
            a.Append(") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}