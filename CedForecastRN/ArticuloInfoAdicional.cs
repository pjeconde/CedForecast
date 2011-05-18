using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastRN
{
    public static class ArticuloInfoAdicional
    {
        public static List<CedForecastEntidades.ArticuloInfoAdicional> LeerLista(CedEntidades.Sesion Sesion)
        {
            return new CedForecastDB.ArticuloInfoAdicional(Sesion).LeerLista();
        }
        public static void Leer(CedForecastEntidades.ArticuloInfoAdicional ArticuloInfoAdicional, CedEntidades.Sesion Sesion)
        {
            new CedForecastDB.ArticuloInfoAdicional(Sesion).Leer(ArticuloInfoAdicional);
        }
        public static void Crear(CedForecastEntidades.ArticuloInfoAdicional ArticuloInfoAdicional, CedEntidades.Sesion Sesion)
        {
            Validar(ArticuloInfoAdicional);
            new CedForecastDB.ArticuloInfoAdicional(Sesion).Crear(ArticuloInfoAdicional);
        }
        public static void Eliminar(CedForecastEntidades.ArticuloInfoAdicional ArticuloInfoAdicional, CedEntidades.Sesion Sesion)
        {
            new CedForecastDB.ArticuloInfoAdicional(Sesion).Eliminar(ArticuloInfoAdicional);
        }
        public static void Modificar(CedForecastEntidades.ArticuloInfoAdicional ArticuloInfoAdicional, CedEntidades.Sesion Sesion)
        {
            Validar(ArticuloInfoAdicional);
            new CedForecastDB.ArticuloInfoAdicional(Sesion).Modificar(ArticuloInfoAdicional);
        }
        private static void Validar(CedForecastEntidades.ArticuloInfoAdicional ArticuloInfoAdicional)
        {
            if (ArticuloInfoAdicional.IdArticulo.Equals(String.Empty))
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Id");
            }
            if (ArticuloInfoAdicional.DescrArticulo.Equals(String.Empty))
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Descripción");
            }
        }
    }
}