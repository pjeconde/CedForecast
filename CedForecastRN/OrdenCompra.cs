using System;
using System.Collections.Generic;
using System.Text;

namespace CedForecastRN
{
    public static class OrdenCompra
    {
        public static List<CedForecastEntidades.OrdenCompra> LeerLista(DateTime FechaDsd, DateTime FechaHst, string Estados, CedEntidades.Sesion Sesion)
        {
            return new CedForecastDB.OrdenCompra(Sesion).LeerLista(FechaDsd, FechaHst, Estados);
        }
        public static void ValidacionOrdenCompraAltaMinutaNueva(CedForecastEntidades.OrdenCompraInfoAlta OrdenCompra, CedForecastEntidades.OrdenCompraInfoAltaMinuta Minuta, CedEntidades.Sesion Sesion)
        {
            ValidacionOrdenCompraAltaMinutaExistente(OrdenCompra, Minuta, -1, Sesion);
        }
        public static void ValidacionOrdenCompraAltaMinutaExistente(CedForecastEntidades.OrdenCompraInfoAlta OrdenCompra, CedForecastEntidades.OrdenCompraInfoAltaMinuta Minuta, int IdMinuta, CedEntidades.Sesion Sesion)
        {
            if (Minuta.IdArticulo == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("IdArticulo");
            }
            if (Minuta.Cantidad == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Cantidad");
            }
            if (Minuta.IdMoneda == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("IdMoneda");
            }
            if (Minuta.Precio == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Precio");
            }
            if (Minuta.Importe == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Importe");
            }
            for (int i = 0; i < OrdenCompra.Minutas.Count; i++)
            {
                bool verificarDuplicacionDeArticulo = IdMinuta == -1 || i != IdMinuta;
                if (verificarDuplicacionDeArticulo && OrdenCompra.Minutas[i].IdArticulo == Minuta.IdArticulo)
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoExistente("Artículo " + Minuta.IdArticulo);
                }
            }
        }
        public static void ValidacionOrdenCompraAlta(CedForecastEntidades.OrdenCompraInfoAlta OrdenCompra, CedEntidades.Sesion Sesion)
        {
            if (OrdenCompra.IdProveedor == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Proveedor");
            }
            if (OrdenCompra.IdPaisOrigen == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("País de origen");
            }
            if (OrdenCompra.Minutas.Count == 0)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("DETALLE");
            }
            if (OrdenCompra.Fecha == OrdenCompra.FechaEstimadaArriboRequerida)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha estim.arribo req.");
            }
        }
        public static void Alta(CedForecastEntidades.OrdenCompraInfoAlta OrdenCompraInfoAlta, CedEntidades.Sesion Sesion)
        {
            ValidacionOrdenCompraAlta(OrdenCompraInfoAlta, Sesion);
            CedEntidades.WF wF = Cedeira.SV.WF.Nueva("OrdenCpra", "NA", 0, String.Empty, Sesion);
            CedEntidades.Evento eventoWF=new CedEntidades.Evento();
            eventoWF.Flow.IdFlow = wF.IdFlow;
            eventoWF.Id = "Alta";
            Cedeira.SV.WF.LeerEvento(eventoWF, Sesion);
            string handler = Cedeira.SV.WF.EjecutarEvento(wF, eventoWF, true);
            new CedForecastDB.OrdenCompra(Sesion).Alta(OrdenCompraInfoAlta, handler);
        }
        public static void IngresoADeposito(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedForecastEntidades.OrdenCompraInfoIngresoADeposito OrdenCompraInfoIngresoADeposito, CedEntidades.Sesion Sesion)
        {
            new CedForecastDB.OrdenCompra(Sesion).IngresoADeposito(ListaOrdenesCompra(OrdenesCompra), OrdenCompraInfoIngresoADeposito);
        }
        public static void IngresoInfoEmbarque(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedForecastEntidades.OrdenCompraInfoEmbarque OrdenCompraInfoEmbarque, CedEntidades.Sesion Sesion)
        {
            new CedForecastDB.OrdenCompra(Sesion).IngresoInfoEmbarque(ListaOrdenesCompra(OrdenesCompra), OrdenCompraInfoEmbarque);
        }
        public static void InspeccionRENAR(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedForecastEntidades.OrdenCompraInfoInspeccionRENAR OrdenCompraInfoInspeccionRENAR, CedEntidades.Sesion Sesion)
        {
            new CedForecastDB.OrdenCompra(Sesion).InspeccionRENAR(ListaOrdenesCompra(OrdenesCompra), OrdenCompraInfoInspeccionRENAR);
        }
        public static void RecepcionDocumentos(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedForecastEntidades.OrdenCompraInfoRecepcionDocumentos OrdenCompraInfoRecepcionDocumentos, CedEntidades.Sesion Sesion)
        {
            new CedForecastDB.OrdenCompra(Sesion).RecepcionDocumentos(ListaOrdenesCompra(OrdenesCompra), OrdenCompraInfoRecepcionDocumentos);
        }
        public static void RegistroDespacho(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedForecastEntidades.OrdenCompraInfoRegistroDespacho OrdenCompraInfoRegistroDespacho, CedEntidades.Sesion Sesion)
        {
            new CedForecastDB.OrdenCompra(Sesion).RegistroDespacho(ListaOrdenesCompra(OrdenesCompra), OrdenCompraInfoRegistroDespacho);
        }
        private static string ListaOrdenesCompra(List<CedForecastEntidades.OrdenCompra> OrdenesCompra)
        {
            StringBuilder a = new StringBuilder();
            for (int i = 0; i < OrdenesCompra.Count; i++)
            {
                if (i > 0) a.Append(", ");
                a.Append("'" + OrdenesCompra[i].Id.ToString() + OrdenesCompra[i].IdItem + "'");
            }
            return a.ToString();
        }
    }
}