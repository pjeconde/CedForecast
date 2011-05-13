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

        public static void ValidacionAltaMinutaNueva(CedForecastEntidades.OrdenCompraInfoAlta OrdenCompra, CedForecastEntidades.OrdenCompraInfoAltaMinuta Minuta, CedEntidades.Sesion Sesion)
        {
            ValidacionAltaMinutaExistente(OrdenCompra, Minuta, -1, Sesion);
        }
        public static void ValidacionAltaMinutaExistente(CedForecastEntidades.OrdenCompraInfoAlta OrdenCompra, CedForecastEntidades.OrdenCompraInfoAltaMinuta Minuta, int IdMinuta, CedEntidades.Sesion Sesion)
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
        private static void ValidacionAlta(CedForecastEntidades.OrdenCompraInfoAlta OrdenCompra, CedEntidades.Sesion Sesion)
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
            if (OrdenCompra.Fecha > DateTime.Today)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha");
            }
            if (OrdenCompra.FechaEstimadaArriboRequerida <= OrdenCompra.Fecha)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha estim.arribo req.");
            }
        }
        public static void Alta(CedForecastEntidades.OrdenCompraInfoAlta OrdenCompraInfoAlta, CedEntidades.Sesion Sesion)
        {
            ValidacionAlta(OrdenCompraInfoAlta, Sesion);
            CedEntidades.WF wF = Cedeira.SV.WF.Nueva("OrdenCpra", "NA", 0, String.Empty, Sesion);
            CedEntidades.Evento eventoWF=new CedEntidades.Evento();
            eventoWF.Flow.IdFlow = wF.IdFlow;
            eventoWF.Id = "Alta";
            Cedeira.SV.WF.LeerEvento(eventoWF, Sesion);
            string handler = Cedeira.SV.WF.EjecutarEvento(wF, eventoWF, true);
            new CedForecastDB.OrdenCompra(Sesion).Alta(OrdenCompraInfoAlta, handler);
        }

        private static void ValidacionIngresoADeposito(CedForecastEntidades.OrdenCompraInfoIngresoADeposito InfoIngresoADeposito, CedEntidades.Sesion Sesion)
        {
        }
        public static void IngresoADeposito(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedForecastEntidades.OrdenCompraInfoIngresoADeposito InfoIngresoADeposito, CedEntidades.Sesion Sesion)
        {
            ValidacionIngresoADeposito(InfoIngresoADeposito, Sesion);
            new CedForecastDB.OrdenCompra(Sesion).IngresoADeposito(ListaOrdenesCompra(OrdenesCompra), InfoIngresoADeposito);
        }

        private static void ValidacionIngresoInfoEmbarque(CedForecastEntidades.OrdenCompraInfoEmbarque InfoEmbarque, CedEntidades.Sesion Sesion)
        {
        }
        public static void IngresoInfoEmbarque(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedForecastEntidades.OrdenCompraInfoEmbarque InfoEmbarque, CedEntidades.Sesion Sesion)
        {
            ValidacionIngresoInfoEmbarque(InfoEmbarque, Sesion);
            new CedForecastDB.OrdenCompra(Sesion).IngresoInfoEmbarque(ListaOrdenesCompra(OrdenesCompra), InfoEmbarque);
        }

        public static void ValidacionInspeccionRENAR(CedForecastEntidades.OrdenCompraInfoInspeccionRENAR InfoInspeccionRENAR, CedEntidades.Sesion Sesion)
        {
        }
        public static void InspeccionRENAR(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedForecastEntidades.OrdenCompraInfoInspeccionRENAR InfoInspeccionRENAR, CedEntidades.Sesion Sesion)
        {
            ValidacionInspeccionRENAR(InfoInspeccionRENAR, Sesion);
            new CedForecastDB.OrdenCompra(Sesion).InspeccionRENAR(ListaOrdenesCompra(OrdenesCompra), InfoInspeccionRENAR);
        }

        public static void ValidacionRecepcionDocumentos(CedForecastEntidades.OrdenCompraInfoRecepcionDocumentos InfoRecepcionDocumentos, CedEntidades.Sesion Sesion)
        {
        }
        public static void RecepcionDocumentos(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedForecastEntidades.OrdenCompraInfoRecepcionDocumentos InfoRecepcionDocumentos, CedEntidades.Sesion Sesion)
        {
            ValidacionRecepcionDocumentos(InfoRecepcionDocumentos, Sesion);
            new CedForecastDB.OrdenCompra(Sesion).RecepcionDocumentos(ListaOrdenesCompra(OrdenesCompra), InfoRecepcionDocumentos);
        }

        public static void ValidacionRegistroDespacho(CedForecastEntidades.OrdenCompraInfoRegistroDespacho InfoRegistroDespacho, CedEntidades.Sesion Sesion)
        {
        }
        public static void RegistroDespacho(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedForecastEntidades.OrdenCompraInfoRegistroDespacho InfoRegistroDespacho, CedEntidades.Sesion Sesion)
        {
            ValidacionRegistroDespacho(InfoRegistroDespacho, Sesion);
            new CedForecastDB.OrdenCompra(Sesion).RegistroDespacho(ListaOrdenesCompra(OrdenesCompra), InfoRegistroDespacho);
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