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
        public static void LeerParaActualizacionInfoEmbarque(CedForecastEntidades.OrdenCompra OrdenCompra, CedEntidades.Sesion Sesion)
        {
            new CedForecastDB.OrdenCompra(Sesion).LeerParaActualizacionInfoEmbarque(OrdenCompra, "'PteInfoEmb', 'PteRecepDocs', 'PteDesp'");
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
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha estimada de arribo requerida");
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

        private static void ValidacionIngresoInfoEmbarque(CedForecastEntidades.OrdenCompraInfoEmbarque InfoEmbarque, CedEntidades.Sesion Sesion)
        {
            if (InfoEmbarque.IdReferenciaSAP == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Referencia SAP");
            }
            if (InfoEmbarque.Vapor == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Vapor");
            }
            if (InfoEmbarque.FechaEstimadaSalida < DateTime.Today)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha estimada de salida");
            }
            if (InfoEmbarque.FechaEstimadaArribo < InfoEmbarque.FechaEstimadaSalida)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha estimada de arribo");
            }
        }
        public static void IngresoInfoEmbarque(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedForecastEntidades.OrdenCompraInfoEmbarque InfoEmbarque, CedEntidades.Sesion Sesion)
        {
            ValidacionIngresoInfoEmbarque(InfoEmbarque, Sesion);
            CedEntidades.Evento eventoWF=new CedEntidades.Evento();
            eventoWF.Flow.IdFlow = "OrdenCpra";
            eventoWF.Id = "IngInfoEmb";
            Cedeira.SV.WF.LeerEvento(eventoWF, Sesion);
            List<string> handlers = new List<string>();
            for (int i = 0; i<OrdenesCompra.Count; i++)
            {
                handlers.Add(Cedeira.SV.WF.EjecutarEvento(OrdenesCompra[i].WF, eventoWF, true));
            }
            new CedForecastDB.OrdenCompra(Sesion).IngresoInfoEmbarque(ListaOrdenesCompra(OrdenesCompra), InfoEmbarque, handlers);
        }

        private static void ValidacionRecepcionDocumentos(CedForecastEntidades.OrdenCompraInfoRecepcionDocumentos InfoRecepcionDocumentos, CedEntidades.Sesion Sesion)
        {
            if (InfoRecepcionDocumentos.NroConocimientoEmbarque == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Nº Conocimiento de Embarque");
            }
            if (InfoRecepcionDocumentos.Factura == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Factura");
            }
            if (InfoRecepcionDocumentos.FechaRecepcionDocumentos < DateTime.Today)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha de recepción de documentos");
            }
        }
        public static void RecepcionDocumentos(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedForecastEntidades.OrdenCompraInfoRecepcionDocumentos InfoRecepcionDocumentos, CedEntidades.Sesion Sesion)
        {
            ValidacionRecepcionDocumentos(InfoRecepcionDocumentos, Sesion);
            CedEntidades.Evento eventoWF = new CedEntidades.Evento();
            eventoWF.Flow.IdFlow = "OrdenCpra";
            eventoWF.Id = "RecepDocs";
            Cedeira.SV.WF.LeerEvento(eventoWF, Sesion);
            List<string> handlers = new List<string>();
            for (int i = 0; i < OrdenesCompra.Count; i++)
            {
                handlers.Add(Cedeira.SV.WF.EjecutarEvento(OrdenesCompra[i].WF, eventoWF, true));
            } 
            new CedForecastDB.OrdenCompra(Sesion).RecepcionDocumentos(ListaOrdenesCompra(OrdenesCompra), InfoRecepcionDocumentos, handlers);
        }

        private static void ValidacionRegistroDespacho(CedForecastEntidades.OrdenCompraInfoRegistroDespacho InfoRegistroDespacho, CedEntidades.Sesion Sesion)
        {
            //if (InfoRegistroDespacho.FechaIngresoAPuerto < OrdenCompra.Fecha)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha de ingreso a puerto");
            //}
            if (InfoRegistroDespacho.NroDespacho == String.Empty)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Nº Despacho");
            }
            if (InfoRegistroDespacho.FechaOficializacion < InfoRegistroDespacho.FechaIngresoAPuerto)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha de oficialización");
            }
        }
        public static void RegistroDespacho(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedForecastEntidades.OrdenCompraInfoRegistroDespacho InfoRegistroDespacho, CedEntidades.Sesion Sesion)
        {
            ValidacionRegistroDespacho(InfoRegistroDespacho, Sesion);
            CedEntidades.Evento eventoWF = new CedEntidades.Evento();
            eventoWF.Flow.IdFlow = "OrdenCpra";
            eventoWF.Id = "RegDesp";
            Cedeira.SV.WF.LeerEvento(eventoWF, Sesion);
            List<string> handlers = new List<string>();
            for (int i = 0; i < OrdenesCompra.Count; i++)
            {
                CedForecastEntidades.ArticuloInfoAdicional articuloInfoAdicional = new CedForecastEntidades.ArticuloInfoAdicional();
                articuloInfoAdicional.IdArticulo = OrdenesCompra[i].IdArticulo;
                CedForecastRN.ArticuloInfoAdicional.Leer(articuloInfoAdicional, Sesion);
                if (articuloInfoAdicional.IdRENAR == String.Empty)
                {
                    eventoWF.IdEstadoHst.IdEstado = "PteIngrADep";
                }
                else
                {
                    eventoWF.IdEstadoHst.IdEstado = "PteInspRenar";
                }
                handlers.Add(Cedeira.SV.WF.EjecutarEvento(OrdenesCompra[i].WF, eventoWF, true));
            } 
            new CedForecastDB.OrdenCompra(Sesion).RegistroDespacho(ListaOrdenesCompra(OrdenesCompra), InfoRegistroDespacho, handlers);
        }

        private static void ValidacionInspeccionRENAR(CedForecastEntidades.OrdenCompraInfoInspeccionRENAR InfoInspeccionRENAR, CedEntidades.Sesion Sesion)
        {
            if (InfoInspeccionRENAR.FechaInspeccionRENAR < DateTime.Today)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha inspección RENAR");
            }
        }
        public static void InspeccionRENAR(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedForecastEntidades.OrdenCompraInfoInspeccionRENAR InfoInspeccionRENAR, CedEntidades.Sesion Sesion)
        {
            ValidacionInspeccionRENAR(InfoInspeccionRENAR, Sesion);
            CedEntidades.Evento eventoWF = new CedEntidades.Evento();
            eventoWF.Flow.IdFlow = "OrdenCpra";
            eventoWF.Id = "InspRenar";
            Cedeira.SV.WF.LeerEvento(eventoWF, Sesion);
            List<string> handlers = new List<string>();
            for (int i = 0; i < OrdenesCompra.Count; i++)
            {
                handlers.Add(Cedeira.SV.WF.EjecutarEvento(OrdenesCompra[i].WF, eventoWF, true));
            }
            new CedForecastDB.OrdenCompra(Sesion).InspeccionRENAR(ListaOrdenesCompra(OrdenesCompra), InfoInspeccionRENAR, handlers);
        }

        private static void ValidacionIngresoADeposito(CedForecastEntidades.OrdenCompraInfoIngresoADeposito InfoIngresoADeposito, CedEntidades.Sesion Sesion)
        {
            if (InfoIngresoADeposito.FechaIngresoDeposito < DateTime.Today)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha estimada de salida");
            }
        }
        public static void IngresoADeposito(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedForecastEntidades.OrdenCompraInfoIngresoADeposito InfoIngresoADeposito, CedEntidades.Sesion Sesion)
        {
            ValidacionIngresoADeposito(InfoIngresoADeposito, Sesion);
            CedEntidades.Evento eventoWF = new CedEntidades.Evento();
            eventoWF.Flow.IdFlow = "OrdenCpra";
            eventoWF.Id = "IngrADep";
            Cedeira.SV.WF.LeerEvento(eventoWF, Sesion);
            List<string> handlers = new List<string>();
            for (int i = 0; i < OrdenesCompra.Count; i++)
            {
                handlers.Add(Cedeira.SV.WF.EjecutarEvento(OrdenesCompra[i].WF, eventoWF, true));
            }
            new CedForecastDB.OrdenCompra(Sesion).IngresoADeposito(ListaOrdenesCompra(OrdenesCompra), InfoIngresoADeposito, handlers);
        }

        public static void Anulacion(List<CedForecastEntidades.OrdenCompra> OrdenesCompra, CedEntidades.Sesion Sesion)
        {
            CedEntidades.Evento eventoWF = new CedEntidades.Evento();
            eventoWF.Flow.IdFlow = "OrdenCpra";
            eventoWF.Id = "Anul";
            Cedeira.SV.WF.LeerEvento(eventoWF, Sesion);
            List<string> handlers = new List<string>();
            for (int i = 0; i < OrdenesCompra.Count; i++)
            {
                handlers.Add(Cedeira.SV.WF.EjecutarEvento(OrdenesCompra[i].WF, eventoWF, true));
            }
            new CedForecastDB.OrdenCompra(Sesion).Anulacion(handlers);
        }

        private static void ValidacionModificacion(CedForecastEntidades.OrdenCompra OrdenCompra, CedEntidades.Sesion Sesion)
        {
            //if (OrdenCompra.IdProveedor == String.Empty)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Proveedor");
            //}
            //if (OrdenCompra.IdPaisOrigen == String.Empty)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("País de origen");
            //}
            //if (OrdenCompra.Fecha > OrdenCompra.FechaEstimadaArriboRequerida)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha");
            //}
            //if (OrdenCompra.FechaEstimadaArriboRequerida <= OrdenCompra.Fecha)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha estimada de arribo requerida");
            //}
            //if (OrdenCompra.IdReferenciaSAP == String.Empty)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Referencia SAP");
            //}
            //if (OrdenCompra.Vapor == String.Empty)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Vapor");
            //}
            //if (OrdenCompra.FechaEstimadaSalida < OrdenCompra.Fecha)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha estimada de salida");
            //}
            //if (OrdenCompra.FechaEstimadaArribo < OrdenCompra.FechaEstimadaSalida)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha estimada de arribo");
            //}
            //if (OrdenCompra.NroConocimientoEmbarque == String.Empty)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Nº Conocimiento de Embarque");
            //}
            //if (OrdenCompra.Factura == String.Empty)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Factura");
            //}
            //if (OrdenCompra.FechaRecepcionDocumentos < OrdenCompra.Fecha)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha de recepción de documentos");
            //}
            //if (OrdenCompra.FechaIngresoAPuerto < OrdenCompra.Fecha)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha de ingreso a puerto");
            //}
            //if (OrdenCompra.NroDespacho == String.Empty)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorNoInfo("Nº Despacho");
            //}
            //if (OrdenCompra.FechaOficializacion < OrdenCompra.FechaIngresoAPuerto)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha de oficialización");
            //}
            //if (OrdenCompra.FechaInspeccionRENAR < OrdenCompra.FechaOficializacion)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha inspección RENAR");
            //}
            //if (OrdenCompra.FechaIngresoDeposito < OrdenCompra.FechaOficializacion)
            //{
            //    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ValorInvalido("Fecha estimada de salida");
            //}
        }
        public static void Modificacion(CedForecastEntidades.OrdenCompra OrdenCompraOriginal, CedForecastEntidades.OrdenCompra OrdenCompraModificada, CedEntidades.Sesion Sesion)
        {
            ValidacionModificacion(OrdenCompraModificada, Sesion);
            CedEntidades.Evento eventoWF = new CedEntidades.Evento();
            eventoWF.Flow.IdFlow = "OrdenCpra";
            eventoWF.Id = "Modif";
            Cedeira.SV.WF.LeerEvento(eventoWF, Sesion);
            string handler = Cedeira.SV.WF.EjecutarEvento(OrdenCompraOriginal.WF, eventoWF, true);
            new CedForecastDB.OrdenCompra(Sesion).Modificacion(OrdenCompraOriginal, OrdenCompraModificada, handler);
        }

        private static void ValidacionCambioEstado(CedForecastEntidades.OrdenCompra OrdenCompraOriginal, CedForecastEntidades.OrdenCompra OrdenCompraModificada, CedEntidades.Sesion Sesion)
        {
            if (OrdenCompraOriginal.WF.IdEstado == OrdenCompraModificada.WF.IdEstado)
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.OpcionInvalida();
            }
        }
        public static void CambioEstado(CedForecastEntidades.OrdenCompra OrdenCompraOriginal, CedForecastEntidades.OrdenCompra OrdenCompraModificada, CedEntidades.Sesion Sesion)
        {
            ValidacionCambioEstado(OrdenCompraOriginal, OrdenCompraModificada, Sesion);
            CedEntidades.Evento eventoWF = new CedEntidades.Evento();
            eventoWF.Flow.IdFlow = "OrdenCpra";
            eventoWF.Id = "CambioEst";
            Cedeira.SV.WF.LeerEvento(eventoWF, Sesion);
            eventoWF.IdEstadoHst.IdEstado = OrdenCompraModificada.WF.IdEstado;
            string handler = Cedeira.SV.WF.EjecutarEvento(OrdenCompraOriginal.WF, eventoWF, true);
            new CedForecastDB.OrdenCompra(Sesion).CambioEstado(OrdenCompraOriginal, OrdenCompraModificada, handler);
        }

        public static void ActualizacionInfoEmbarque(CedForecastEntidades.OrdenCompra OrdenCompra, CedForecastEntidades.OrdenCompraInfoEmbarque InfoEmbarque, CedEntidades.Sesion Sesion)
        {
            CedEntidades.Evento eventoWF = new CedEntidades.Evento();
            if ((OrdenCompra.IdReferenciaSAP != InfoEmbarque.IdReferenciaSAP) ||
                (OrdenCompra.Vapor != InfoEmbarque.Vapor) ||
                (OrdenCompra.FechaEstimadaSalida != InfoEmbarque.FechaEstimadaSalida) ||
                (OrdenCompra.FechaEstimadaArribo != InfoEmbarque.FechaEstimadaArribo))
            {
                eventoWF.Flow.IdFlow = "OrdenCpra";
                eventoWF.Id = "ActInfoEmb";
                Cedeira.SV.WF.LeerEvento(eventoWF, Sesion);
                List<string> handlers = new List<string>();
                string handler = Cedeira.SV.WF.EjecutarEvento(OrdenCompra.WF, eventoWF, true);
                new CedForecastDB.OrdenCompra(Sesion).ActualizacionInfoEmbarque(OrdenCompra, InfoEmbarque, handler);
            }
        }

        private static string ListaOrdenesCompra(List<CedForecastEntidades.OrdenCompra> OrdenesCompra)
        {
            StringBuilder a = new StringBuilder();
            for (int i = 0; i < OrdenesCompra.Count; i++)
            {
                if (i > 0) a.Append(", ");
                a.Append(OrdenesCompra[i].Id.ToString() + OrdenesCompra[i].IdItem);
            }
            return a.ToString();
        }
    }
}