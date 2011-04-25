using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB
{
    public class ArticuloInfoAdicional: db
    {
        public ArticuloInfoAdicional(CedEntidades.Sesion Sesion): base(Sesion)
        {
        }

        public List<CedForecastEntidades.ArticuloInfoAdicional> LeerLista()
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ArticuloInfoAdicional.IdArticulo, ArticuloInfoAdicional.IdFamiliaArticulo, FamiliaArticulo.DescrFamiliaArticulo, ArticuloInfoAdicional.IdArticuloOrigen, ArticuloInfoAdicional.IdRENAR, ArticuloInfoAdicional.DescrRENAR, ArticuloInfoAdicional.IdSENASA, ArticuloInfoAdicional.IdPresentacion, ArticuloInfoAdicional.CantidadXPresentacion, ArticuloInfoAdicional.CantidadXContenedor, ArticuloInfoAdicional.UnidadMedida, ArticuloInfoAdicional.Precio, ArticuloInfoAdicional.IdMoneda, ArticuloInfoAdicional.FechaVigenciaPrecio, ArticuloInfoAdicional.CoeficienteGastosNacionalizacion, ArticuloInfoAdicional.CantidadStockSeguridad, ArticuloInfoAdicional.PlazoAvisoStockSeguridad, ArticuloInfoAdicional.Comentario ");
            a.Append("from ArticuloInfoAdicional, FamiliaArticulo ");
            a.Append("where ArticuloInfoAdicional.IdFamiliaArticulo=FamiliaArticulo.IdFamiliaArticulo ");
            a.Append("order by IdArticulo ");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastEntidades.ArticuloInfoAdicional> lista = new List<CedForecastEntidades.ArticuloInfoAdicional>();
            if (dt.Rows.Count != 0)
            {
                List<CedForecastEntidades.Bejerman.Articulos> articulosBejerman = new CedForecastDB.Bejerman.Articulos(sesion).LeerLista();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastEntidades.ArticuloInfoAdicional elemento = new CedForecastEntidades.ArticuloInfoAdicional();
                    Copiar(dt.Rows[i], elemento);
                    CedForecastEntidades.Bejerman.Articulos articuloBejerman = articulosBejerman.Find(delegate(CedForecastEntidades.Bejerman.Articulos c) { return c.Art_CodGen == Convert.ToString(dt.Rows[i]["IdArticulo"]); });
                    if (articuloBejerman == null)
                    {
                        elemento.DescrArticulo = "<<<Desconocido>>>";
                    }
                    else
                    {
                        elemento.DescrArticulo = articuloBejerman.Art_DescGen;
                    }
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, CedForecastEntidades.ArticuloInfoAdicional Hasta)
        {
            Hasta.IdArticulo = Convert.ToString(Desde["IdArticulo"]);
            Hasta.IdFamiliaArticulo = Convert.ToString(Desde["IdFamiliaArticulo"]);
            Hasta.DescrFamiliaArticulo = Convert.ToString(Desde["DescrFamiliaArticulo"]);
            Hasta.IdArticuloOrigen = Convert.ToString(Desde["IdArticuloOrigen"]);
            Hasta.IdRENAR = Convert.ToString(Desde["IdRENAR"]);
            Hasta.DescrRENAR = Convert.ToString(Desde["DescrRENAR"]);
            Hasta.IdSENASA = Convert.ToString(Desde["IdSENASA"]);
            Hasta.IdPresentacion = Convert.ToString(Desde["IdPresentacion"]);
            Hasta.CantidadXPresentacion = Convert.ToInt32(Desde["CantidadXPresentacion"]);
            Hasta.CantidadXContenedor = Convert.ToInt32(Desde["CantidadXContenedor"]);
            Hasta.UnidadMedida = Convert.ToString(Desde["UnidadMedida"]);
            Hasta.Precio = Convert.ToDecimal(Desde["Precio"]);
            Hasta.IdMoneda = Convert.ToString(Desde["IdMoneda"]);
            Hasta.FechaVigenciaPrecio = Convert.ToDateTime(Desde["FechaVigenciaPrecio"]);
            Hasta.CoeficienteGastosNacionalizacion = Convert.ToDecimal(Desde["CoeficienteGastosNacionalizacion"]);
            Hasta.CantidadStockSeguridad = Convert.ToInt32(Desde["CantidadStockSeguridad"]);
            Hasta.PlazoAvisoStockSeguridad = Convert.ToInt32(Desde["PlazoAvisoStockSeguridad"]);
            Hasta.Comentario = Convert.ToString(Desde["Comentario"]);
        }
        public string ListaIdArticulos()
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar("select ArticuloInfoAdicional.IdArticulo from ArticuloInfoAdicional", TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastEntidades.ArticuloInfoAdicional> lista = new List<CedForecastEntidades.ArticuloInfoAdicional>();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("''");
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    a.Append(", '" + Convert.ToString(dt.Rows[i]["IdArticulo"]) + "'");
                }
            }
            return a.ToString();
        }
        public void Leer(CedForecastEntidades.ArticuloInfoAdicional ArticuloInfoAdicional)
        {
        }
        public void Crear(CedForecastEntidades.ArticuloInfoAdicional ArticuloInfoAdicional)
        {
        }
        public void Modificar(CedForecastEntidades.ArticuloInfoAdicional ArticuloInfoAdicional)
        {
            StringBuilder a = new StringBuilder(String.Empty);
            a.Append("update ArticuloInfoAdicional set ");
            a.Append("IdFamiliaArticulo='" + ArticuloInfoAdicional.IdFamiliaArticulo + "', ");
            a.Append("IdArticuloOrigen='" + ArticuloInfoAdicional.IdArticuloOrigen + "', ");
            a.Append("IdRENAR='" + ArticuloInfoAdicional.IdRENAR + "', ");
            a.Append("DescrRENAR='" + ArticuloInfoAdicional.DescrRENAR + "', ");
            a.Append("IdSENASA='" + ArticuloInfoAdicional.IdSENASA + "', ");
            a.Append("IdPresentacion='" + ArticuloInfoAdicional.IdPresentacion + "', ");
            a.Append("CantidadXPresentacion=" + ArticuloInfoAdicional.CantidadXPresentacion.ToString() + ", ");
            a.Append("CantidadXContenedor=" + ArticuloInfoAdicional.CantidadXContenedor.ToString() + ", ");
            a.Append("UnidadMedida='" + ArticuloInfoAdicional.UnidadMedida + "', ");
            a.Append("Precio=" + ArticuloInfoAdicional.Precio.ToString() + ", ");
            a.Append("IdMoneda='" + ArticuloInfoAdicional.IdMoneda + "', ");
            a.Append("FechaVigenciaPrecio='" + ArticuloInfoAdicional.FechaVigenciaPrecio.ToString("yyyyMMdd HH:mm") + "', ");
            a.Append("CoeficienteGastosNacionalizacion=" + ArticuloInfoAdicional.CoeficienteGastosNacionalizacion.ToString() + ", ");
            a.Append("CantidadStockSeguridad=" + ArticuloInfoAdicional.CantidadStockSeguridad.ToString() + ", ");
            a.Append("PlazoAvisoStockSeguridad=" + ArticuloInfoAdicional.PlazoAvisoStockSeguridad.ToString() + ", ");
            a.Append("Comentario='" + ArticuloInfoAdicional.Comentario + "' ");
            a.Append("where IdArticulo='" + ArticuloInfoAdicional.IdArticulo + "'");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Eliminar(CedForecastEntidades.ArticuloInfoAdicional ArticuloInfoAdicional)
        {
        }
    }
}
