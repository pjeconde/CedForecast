using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastWebDB
{
    public class Venta : db
    {
        public Venta(CedEntidades.Sesion Sesion)
            : base(Sesion)
        {
        }
        public void IniciarEnvioVenta()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete VentaAux ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void AgregarEnAux(CedForecastWebEntidades.Venta Elemento)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("insert VentaAux values ( ");
            a.Append("'" + Elemento.IdPeriodo + "', ");
            a.Append("'" + Elemento.IdArticulo + "', ");
            a.Append("'" + Elemento.IdCliente + "', ");
            a.Append(Convert.ToString(Elemento.Cantidad, cedeiraCultura));
            a.Append(") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Confirmar()
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete Venta where IdPeriodo in (select distinct IdPeriodo from VentaAux) ");
            a.Append("insert Venta select * from VentaAux ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
    }
}