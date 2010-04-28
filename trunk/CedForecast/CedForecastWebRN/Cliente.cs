using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastWebRN
{
    public class Cliente
    {
        public Cliente()
        {
        }
        public static List<CedForecastWebEntidades.Cliente> Lista(bool ConArticuloSinInformar, CedEntidades.Sesion Sesion)
        {
            CedForecastWebDB.Cliente cliente = new CedForecastWebDB.Cliente(Sesion);
            return cliente.Lista(ConArticuloSinInformar);
        }
    }
}
