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
                new CedForecastDB.PlanillaInfoEmbarque(Sesion).Guardar(Directorio);
                //Lectura planilla excel
                FileHelpers.DataLink.ExcelStorage planilla = new FileHelpers.DataLink.ExcelStorage(typeof(CedForecastEntidades.PlanillaInfoEmbarque));
                planilla.StartRow = 9;
                planilla.StartColumn = 1;
                planilla.FileName = Directorio;
                CedForecastEntidades.PlanillaInfoEmbarque[] filas = (CedForecastEntidades.PlanillaInfoEmbarque[])planilla.ExtractRecords();
                //Actualizar items de la orden de compra
                for (int i = 0; i < filas.Length; i++)
                {
                    try
                    {
                        //Determino info de embarque
                        CedForecastEntidades.OrdenCompraInfoEmbarque infoEmbarque = new CedForecastEntidades.OrdenCompraInfoEmbarque();
                        infoEmbarque.IdReferenciaSAP = filas[i].IdReferenciaSAP;
                        infoEmbarque.FechaEstimadaSalida = FormatearFechaOADate(filas[i].FechaEstimadaSalida);
                        infoEmbarque.Vapor = filas[i].Vapor;
                        infoEmbarque.FechaEstimadaArribo = FormatearFechaOADate(filas[i].FechaEstimadaArribo);
                        //Leo orden de compra
                        CedForecastEntidades.OrdenCompra ordenCompra = new CedForecastEntidades.OrdenCompra();
                        string itemOrdenCompra = QuitarPrefijo(filas[i].ItemOrdenCompra);
                        ordenCompra.Id = Convert.ToInt32(itemOrdenCompra.Substring(0, itemOrdenCompra.Length - 1));
                        ordenCompra.IdItem = itemOrdenCompra.Substring(itemOrdenCompra.Length - 1, 1);
                        CedForecastRN.OrdenCompra.LeerParaActualizacionInfoEmbarque(ordenCompra, Sesion);
                        //Actualizo info embarque
                        CedForecastRN.OrdenCompra.ActualizacionInfoEmbarque(ordenCompra, infoEmbarque, Sesion);
                    }
                    catch (Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente)
                    {
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                Microsoft.ApplicationBlocks.ExceptionManagement.ExceptionManager.Publish(ex);
            }
        }
        private static string QuitarPrefijo(string Valor)
        {
            StringBuilder valorSinPrefijo = new StringBuilder();
            string [] a = Valor.Split(' ');
            for (int i = 0; i < a.Length; i++)
            {
                try
                {
                    int numero = int.Parse(a[i]);
                    valorSinPrefijo.Append(a[i]);
                }
                catch
                {
                }
            }
            return valorSinPrefijo.ToString();
        }
        private static DateTime FormatearFecha(string Valor)
        {
            string [] a = Valor.Split('/');
            return new DateTime(Convert.ToInt32(a[2]), Convert.ToInt32(a[1]), Convert.ToInt32(a[0]));
        }
        private static DateTime FormatearFechaOADate(string Valor)
        {
            // We must have a double to convert the OA date to a real date.
            double d = double.Parse(Valor);
            // Get the converted date from the OLE automation date.
            DateTime conv = DateTime.FromOADate(d);
            return conv;
        }
    }
}
