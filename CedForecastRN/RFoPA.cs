using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastRN
{
    public class RFoPA
    {
        public RFoPA()
        {
        }
        public static List<CedForecastEntidades.RFoPA> Lista(CedForecastEntidades.RFoPA Forecast, string TipoReporte, string ListaArticulos, string ListaClientes, string ListaVendedores, CedEntidades.Sesion Sesion, out List<CedForecastEntidades.Advertencia> Advertencias)
        {
            Advertencias = new List<CedForecastEntidades.Advertencia>();
            CedForecastDB.RFoPA forecast = new CedForecastDB.RFoPA(Sesion);
            List<CedForecastEntidades.RFoPA> lista = forecast.Lista(Forecast, TipoReporte, ListaArticulos, ListaClientes, ListaVendedores);
            List<CedForecastEntidades.Bejerman.Articulos> articulos = new CedForecastDB.Bejerman.Articulos(Sesion).LeerLista();
            List<CedForecastEntidades.Bejerman.Vendedor> vendedores = new CedForecastDB.Bejerman.Vendedor(Sesion).LeerLista();
            List<CedForecastEntidades.Bejerman.Clientes> clientes = new CedForecastDB.Bejerman.Clientes(Sesion).LeerLista();
            for (int r = 0; r < lista.Count; r++)
            {
                CedForecastEntidades.Bejerman.Articulos articulo = articulos.Find(delegate(CedForecastEntidades.Bejerman.Articulos c) { return c.Art_CodGen == lista[r].Articulo.Art_CodGen; });
                if (articulo != null)
                {
                    lista[r].Articulo.Art_DescGen = articulo.Art_DescGen;
                    lista[r].Articulo.Artda2_cod = articulo.Artda2_cod;
                }
                else
                {
                    lista[r].Articulo.Art_DescGen = "<<<Desconocida>>>";
                    lista[r].Articulo.Artda2_cod = "";
                    Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-01", "Descripci�n no encontrada para el art�culo " + Convert.ToString(lista[r].Articulo.Art_CodGen), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                }
            }
            for (int r = 0; r < lista.Count; r++)
            {
                CedForecastEntidades.Bejerman.Vendedor vendedor = vendedores.Find(delegate(CedForecastEntidades.Bejerman.Vendedor c) { return c.Ven_Cod == lista[r].Vendedor.Ven_Cod; });
                if (vendedor != null)
                {
                    lista[r].Vendedor.Ven_Desc = vendedor.Ven_Desc;
                }
                else
                {
                    lista[r].Vendedor.Ven_Desc = "<<<Desconocida>>>";
                    Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-02", "Descripci�n no encontrada para el vendedor " + Convert.ToString(lista[r].Vendedor.Ven_Cod), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                }
            }
            for (int r = 0; r < lista.Count; r++)
            {
                CedForecastEntidades.Bejerman.Clientes cliente = clientes.Find(delegate(CedForecastEntidades.Bejerman.Clientes c) { return c.Cli_Cod == lista[r].IdCliente; });
                if (cliente != null)
                {
                    lista[r].Cliente.Cli_RazSoc = cliente.Cli_RazSoc;
                }
                else
                {
                    lista[r].Cliente.Cli_RazSoc = "<<<Desconocida>>>";
                    Advertencias.Add(new CedForecastEntidades.Advertencia("CTabAC-03", "Descripci�n no encontrada para el vendedor " + Convert.ToString(lista[r].IdCliente), CedForecastEntidades.Advertencia.TipoSeveridad.Advertencia));
                }
            }
            return lista;
        }
    }
}
