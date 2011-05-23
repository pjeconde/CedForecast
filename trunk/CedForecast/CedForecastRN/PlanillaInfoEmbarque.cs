using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace CedForecastRN
{
    public static class PlanillaInfoEmbarque
    {
        public static string LeerDirectorio(CedEntidades.Sesion Sesion)
        {
            return new CedForecastDB.PlanillaInfoEmbarque(Sesion).Leer();
        }
        public static void GuardarDirectorio(string Directorio, CedEntidades.Sesion Sesion)
        {
            new CedForecastDB.PlanillaInfoEmbarque(Sesion).Guardar(Directorio);
        }
        public static void Procesar(string Directorio, CedEntidades.Sesion Sesion)
        {
            try
            {
                //new CedForecastDB.PlanillaInfoEmbarque(Sesion).Guardar(Directorio);
                //FileHelpers.DataLink.ExcelStorage planilla = new FileHelpers.DataLink.ExcelStorage(typeof(CedForecastEntidades.PlanillaInfoEmbarque)); 
                //planilla.StartRow = 1; 
                //planilla.StartColumn = 1;
                //planilla.FileName = Directorio;
                //CedForecastEntidades.PlanillaInfoEmbarque[] filas = (CedForecastEntidades.PlanillaInfoEmbarque[])planilla.ExtractRecords();
                for (int i = 0; i < 1; i++)
                {
                    CedForecastEntidades.OrdenCompra ordenCompra = new CedForecastEntidades.OrdenCompra();
                    ordenCompra.Id = 1;
                    ordenCompra.IdItem = "0";
                    try
                    {
                        CedForecastEntidades.OrdenCompraInfoEmbarque infoEmbarque = new CedForecastEntidades.OrdenCompraInfoEmbarque();
                        infoEmbarque.IdReferenciaSAP = "";
                        infoEmbarque.FechaEstimadaSalida = DateTime.Today;
                        infoEmbarque.Vapor = "";
                        infoEmbarque.FechaEstimadaArribo = DateTime.Today;
                        CedForecastRN.OrdenCompra.LeerParaActualizacionInfoEmbarque(ordenCompra, Sesion);
                        CedForecastRN.OrdenCompra.ActualizacionInfoEmbarque(ordenCompra, infoEmbarque, Sesion);
                    }
                    catch (Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente)
                    {
                    }
                    catch { throw; }
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
    }
}
