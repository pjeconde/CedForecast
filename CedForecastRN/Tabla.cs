using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastRN
{
    public static class Tabla
    {
        public static List<CedForecastEntidades.Codigo> Leer(string Tabla, CedEntidades.Sesion Sesion)
        {
            return new CedForecastDB.Tabla(Sesion, Tabla).Leer();
        }
        public static void Crear(string Tabla, CedForecastEntidades.Codigo Codigo, CedEntidades.Sesion Sesion)
        {
            Validar(Codigo);
            new CedForecastDB.Tabla(Sesion, Tabla).Crear(Codigo);
        }
        public static void Eliminar(string Tabla, CedForecastEntidades.Codigo Codigo, CedEntidades.Sesion Sesion)
        {
            new CedForecastDB.Tabla(Sesion, Tabla).Eliminar(Codigo);
        }
        public static void Modificar(string Tabla, CedForecastEntidades.Codigo Codigo, CedEntidades.Sesion Sesion)
        {
            Validar(Codigo);
            new CedForecastDB.Tabla(Sesion, Tabla).Modificar(Codigo);
        }
        private static void Validar(CedForecastEntidades.Codigo Codigo)
        {
            if (Codigo.Id.Equals(String.Empty))
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Id");
            }
            if (Codigo.Descr.Equals(String.Empty))
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Descripción");
            }
        }
    }
}
