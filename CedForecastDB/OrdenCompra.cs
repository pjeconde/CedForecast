using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB
{
    public class OrdenCompra: db
    {
        public OrdenCompra(CedEntidades.Sesion Sesion): base(Sesion)
        {
        }

        public List<CedForecastEntidades.OrdenCompra> LeerLista(DateTime FechaDsd, DateTime FechaHst, string Estados)
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("SELECT OrdenCompra.Prefijo, OrdenCompra.Id, OrdenCompra.IdItem, OrdenCompra.IdProveedor, OrdenCompra.DescrProveedor, OrdenCompra.Fecha, OrdenCompra.IdPaisOrigen, OrdenCompra.DescrPaisOrigen, OrdenCompra.IdArticulo, OrdenCompra.DescrArticulo, OrdenCompra.FechaEstimadaArriboRequerida, OrdenCompra.CantidadContenedores, OrdenCompra.ComentarioContenedores, OrdenCompra.CantidadPresentacion, OrdenCompra.Cantidad, OrdenCompra.IdMoneda, OrdenCompra.Precio, OrdenCompra.Importe, OrdenCompra.IdReferenciaSAP, OrdenCompra.FechaEstimadaSalida, OrdenCompra.Vapor, OrdenCompra.FechaEstimadaArribo, OrdenCompra.NroConocimientoEmbarque, OrdenCompra.Factura, OrdenCompra.FechaRecepcionDocumentos, OrdenCompra.FechaIngresoAPuerto, OrdenCompra.NroDespacho, OrdenCompra.FechaOficializacion, OrdenCompra.FechaInspeccionRENAR, OrdenCompra.FechaIngresoDeposito, OrdenCompra.ImporteGastosNacionalizacion, OrdenCompra.Comentario, OrdenCompra.IdOpWF, ");
            a.Append("WF_Op.IdEstado, WF_Estado.DescrEstado ");
            a.Append("FROM OrdenCompra, WF_Op, WF_Estado ");
            a.Append("where OrdenCompra.Fecha >= '" + FechaDsd.ToString("yyyyMMdd") + "' and OrdenCompra.Fecha <='" + FechaHst.ToString("yyyyMMdd") + "' ");
            a.Append("and OrdenCompra.IdOpWF=WF_Op.IdOp ");
            a.Append("and WF_Op.IdEstado in (" + Estados + ") ");
            a.Append("and WF_Op.IdEstado=WF_Estado.IdEstado ");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<CedForecastEntidades.OrdenCompra> lista = new List<CedForecastEntidades.OrdenCompra>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CedForecastEntidades.OrdenCompra elemento = new CedForecastEntidades.OrdenCompra();
                    Copiar(dt.Rows[i], elemento);
                    lista.Add(elemento);
                }
            }
            return lista;
        }
        public void LeerParaActualizacionInfoEmbarque(CedForecastEntidades.OrdenCompra OrdenCompra, string Estados)
        {
            DataTable dt = new DataTable();
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("SELECT OrdenCompra.Prefijo, OrdenCompra.Id, OrdenCompra.IdItem, OrdenCompra.IdProveedor, OrdenCompra.DescrProveedor, OrdenCompra.Fecha, OrdenCompra.IdPaisOrigen, OrdenCompra.DescrPaisOrigen, OrdenCompra.IdArticulo, OrdenCompra.DescrArticulo, OrdenCompra.FechaEstimadaArriboRequerida, OrdenCompra.CantidadContenedores, OrdenCompra.ComentarioContenedores, OrdenCompra.CantidadPresentacion, OrdenCompra.Cantidad, OrdenCompra.IdMoneda, OrdenCompra.Precio, OrdenCompra.Importe, OrdenCompra.IdReferenciaSAP, OrdenCompra.FechaEstimadaSalida, OrdenCompra.Vapor, OrdenCompra.FechaEstimadaArribo, OrdenCompra.NroConocimientoEmbarque, OrdenCompra.Factura, OrdenCompra.FechaRecepcionDocumentos, OrdenCompra.FechaIngresoAPuerto, OrdenCompra.NroDespacho, OrdenCompra.FechaOficializacion, OrdenCompra.FechaInspeccionRENAR, OrdenCompra.FechaIngresoDeposito, OrdenCompra.ImporteGastosNacionalizacion, OrdenCompra.Comentario, OrdenCompra.IdOpWF, ");
            a.Append("WF_Op.IdEstado, WF_Estado.DescrEstado ");
            a.Append("FROM OrdenCompra, WF_Op, WF_Estado ");
            a.Append("where OrdenCompra.IdOpWF=WF_Op.IdOp ");
            a.Append("and WF_Op.IdEstado in (" + Estados + ") ");
            a.Append("and WF_Op.IdEstado=WF_Estado.IdEstado ");
            a.Append("and convert(varchar, Id) + IdItem = " + OrdenCompra.Id.ToString() + OrdenCompra.IdItem + " ");
            dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 1)
            {
                Copiar(dt.Rows[0], OrdenCompra);
            }
            else
            {
                throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.ElementoInexistente("Item " + OrdenCompra.IdItem + " de Orden de Compra N� " + OrdenCompra.Id.ToString());
            }
        }
        private void Copiar(DataRow Desde, CedForecastEntidades.OrdenCompra Hasta)
        {
            Hasta.Prefijo = Convert.ToString(Desde["Prefijo"]);
            Hasta.Id = Convert.ToInt32(Desde["Id"]);
            Hasta.IdItem = Convert.ToString(Desde["IdItem"]);
            Hasta.IdProveedor = Convert.ToString(Desde["IdProveedor"]);
            Hasta.DescrProveedor = Convert.ToString(Desde["DescrProveedor"]);
            Hasta.Fecha = Convert.ToDateTime(Desde["Fecha"]);
            Hasta.IdPaisOrigen = Convert.ToString(Desde["IdPaisOrigen"]);
            Hasta.DescrPaisOrigen = Convert.ToString(Desde["DescrPaisOrigen"]);
            Hasta.IdArticulo = Convert.ToString(Desde["IdArticulo"]);
            Hasta.DescrArticulo = Convert.ToString(Desde["DescrArticulo"]);
            Hasta.FechaEstimadaArriboRequerida = Convert.ToDateTime(Desde["FechaEstimadaArriboRequerida"]);
            Hasta.CantidadContenedores = Convert.ToInt32(Desde["CantidadContenedores"]);
            Hasta.ComentarioContenedores = Convert.ToString(Desde["ComentarioContenedores"]);
            Hasta.CantidadPresentacion = Convert.ToInt32(Desde["CantidadPresentacion"]);
            Hasta.Cantidad = Convert.ToInt32(Desde["Cantidad"]);
            Hasta.IdMoneda = Convert.ToString(Desde["IdMoneda"]);
            Hasta.Precio = Convert.ToDecimal(Desde["Precio"]);
            Hasta.Importe = Convert.ToDecimal(Desde["Importe"]);
            Hasta.IdReferenciaSAP = Convert.ToString(Desde["IdReferenciaSAP"]);
            Hasta.FechaEstimadaSalida = Convert.ToDateTime(Desde["FechaEstimadaSalida"]);
            Hasta.Vapor = Convert.ToString(Desde["Vapor"]);
            Hasta.FechaEstimadaArribo = Convert.ToDateTime(Desde["FechaEstimadaArribo"]);
            Hasta.NroConocimientoEmbarque = Convert.ToString(Desde["NroConocimientoEmbarque"]);
            Hasta.Factura = Convert.ToString(Desde["Factura"]);
            Hasta.FechaRecepcionDocumentos = Convert.ToDateTime(Desde["FechaRecepcionDocumentos"]);
            Hasta.FechaIngresoAPuerto = Convert.ToDateTime(Desde["FechaIngresoAPuerto"]);
            Hasta.NroDespacho = Convert.ToString(Desde["NroDespacho"]);
            Hasta.FechaOficializacion = Convert.ToDateTime(Desde["FechaOficializacion"]);
            Hasta.FechaInspeccionRENAR = Convert.ToDateTime(Desde["FechaInspeccionRENAR"]);
            Hasta.FechaIngresoDeposito = Convert.ToDateTime(Desde["FechaIngresoDeposito"]);
            Hasta.ImporteGastosNacionalizacion = Convert.ToDecimal(Desde["ImporteGastosNacionalizacion"]);
            Hasta.Comentario = Convert.ToString(Desde["Comentario"]);
            Hasta.WF.IdOp = Convert.ToInt32(Desde["IdOpWF"]);
            Hasta.WF.Sesion = sesion;
            Cedeira.SV.WF.Leer(Hasta.WF);
        }
        public void Alta(CedForecastEntidades.OrdenCompraInfoAlta InfoAlta, string HandlerWF)
        {
            StringBuilder a = new StringBuilder("declare @IdOp int ");
            a.Append("declare @IdOrdenCompra int ");
            a.Append("update WF_Parm set @IdOrdenCompra=ValorInt=ValorInt+1 where IdParm='UltNroOrdenCompra' ");
            string handlerWF = HandlerWF.Replace("declare @IdOp int ", String.Empty);
            for (int i = 0; i < InfoAlta.Minutas.Count; i++)
            {
                //Cambiar UltimaOrdenCompra y guardarla en @IdOrdenCompra
                a.Append(handlerWF + " ");
                a.Append("INSERT OrdenCompra ");
                a.Append("           (Prefijo ");
                a.Append("           ,Id ");
                a.Append("           ,IdItem ");
                a.Append("           ,IdProveedor ");
                a.Append("           ,DescrProveedor ");
                a.Append("           ,Fecha ");
                a.Append("           ,IdPaisOrigen ");
                a.Append("           ,DescrPaisOrigen ");
                a.Append("           ,IdArticulo ");
                a.Append("           ,DescrArticulo ");
                a.Append("           ,FechaEstimadaArriboRequerida ");
                a.Append("           ,CantidadContenedores ");
                a.Append("           ,ComentarioContenedores ");
                a.Append("           ,CantidadPresentacion ");
                a.Append("           ,Cantidad ");
                a.Append("           ,IdMoneda ");
                a.Append("           ,Precio ");
                a.Append("           ,Importe ");
                a.Append("           ,IdReferenciaSAP ");
                a.Append("           ,FechaEstimadaSalida ");
                a.Append("           ,Vapor ");
                a.Append("           ,FechaEstimadaArribo ");
                a.Append("           ,NroConocimientoEmbarque ");
                a.Append("           ,Factura ");
                a.Append("           ,FechaRecepcionDocumentos ");
                a.Append("           ,FechaIngresoAPuerto ");
                a.Append("           ,NroDespacho ");
                a.Append("           ,FechaOficializacion ");
                a.Append("           ,FechaInspeccionRENAR ");
                a.Append("           ,FechaIngresoDeposito ");
                a.Append("           ,ImporteGastosNacionalizacion ");
                a.Append("           ,Comentario ");
                a.Append("           ,IdOpWF) ");
                a.Append("     VALUES (");
                a.Append("           '" + InfoAlta.Prefijo + "' ");
                a.Append("           ,@IdOrdenCompra ");
                if (InfoAlta.Minutas.Count == 1)
                {
                    a.Append("           ,'0' ");
                }
                else
                {
                    a.Append("           ," + i.ToString() + " ");
                }
                a.Append("           ,'" + InfoAlta.IdProveedor + "' ");
                a.Append("           ,'" + InfoAlta.DescrProveedor + "' ");
                a.Append("           ,'" + InfoAlta.Fecha.ToString("yyyyMMdd") + "' ");
                a.Append("           ,'" + InfoAlta.IdPaisOrigen + "' ");
                a.Append("           ,'" + InfoAlta.DescrPaisOrigen + "' ");
                a.Append("           ,'" + InfoAlta.Minutas[i].IdArticulo + "' ");
                a.Append("           ,'" + InfoAlta.Minutas[i].DescrArticulo + "' ");
                a.Append("           ,'" + InfoAlta.FechaEstimadaArriboRequerida.ToString("yyyyMMdd") + "' ");
                a.Append("           ," + InfoAlta.Minutas[i].CantidadContenedores.ToString() + " ");
                a.Append("           ,'" + InfoAlta.Minutas[i].ComentarioContenedores + "' ");
                a.Append("           ," + InfoAlta.Minutas[i].CantidadPresentacion.ToString() + " ");
                a.Append("           ," + InfoAlta.Minutas[i].Cantidad.ToString() + " ");
                a.Append("           ,'" + InfoAlta.Minutas[i].IdMoneda + "' ");
                a.Append("           ," + InfoAlta.Minutas[i].Precio.ToString() + " ");
                a.Append("           ," + InfoAlta.Minutas[i].Importe.ToString() + " ");
                a.Append("           ,'' ");
                a.Append("           ,'20000101' ");
                a.Append("           ,'' ");
                a.Append("           ,'20000101' ");
                a.Append("           ,'' ");
                a.Append("           ,'' ");
                a.Append("           ,'20000101' ");
                a.Append("           ,'20000101' ");
                a.Append("           ,'' ");
                a.Append("           ,'20000101' ");
                a.Append("           ,'20000101' ");
                a.Append("           ,'20000101' ");
                a.Append("           ," + InfoAlta.Minutas[i].ImporteGastosNacionalizacion.ToString() + " ");
                a.Append("           ,'" + InfoAlta.Comentario + "' ");
                a.Append("           ,@IdOp) ");
            }
            a.Append("select @IdOrdenCompra as IdOrdenCompra ");
            DataTable tb = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr);
            InfoAlta.Id = Convert.ToInt32(tb.Rows[0]["IdOrdenCompra"]);
        }
        public void IngresoInfoEmbarque(string ListaOrdenesCompra, CedForecastEntidades.OrdenCompraInfoEmbarque InfoEmbarque, List<string> HandlersWF)
        {
            StringBuilder a = new StringBuilder();
            for (int i = 0; i < HandlersWF.Count; i++)
            {
                a.Append(HandlersWF[i]);
                a.Append("end ");
            }
            a.Append("update OrdenCompra set ");
            a.Append("IdReferenciaSAP='" + InfoEmbarque.IdReferenciaSAP + "', ");
            a.Append("FechaEstimadaSalida='" + InfoEmbarque.FechaEstimadaSalida.ToString("yyyyMMdd") + "', ");
            a.Append("Vapor='" + InfoEmbarque.Vapor + "', ");
            a.Append("FechaEstimadaArribo='" + InfoEmbarque.FechaEstimadaArribo.ToString("yyyyMMdd") + "' ");
            a.Append("where convert(varchar, Id) + IdItem in (" + ListaOrdenesCompra + ") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void ActualizacionInfoEmbarque(CedForecastEntidades.OrdenCompra OrdenCompra, CedForecastEntidades.OrdenCompraInfoEmbarque InfoEmbarque, string HandlerWF)
        {
            StringBuilder a = new StringBuilder();
            a.Append(HandlerWF);
            a.Append("end ");
            a.Append("update OrdenCompra set ");
            a.Append("IdReferenciaSAP='" + InfoEmbarque.IdReferenciaSAP + "', ");
            a.Append("FechaEstimadaSalida='" + InfoEmbarque.FechaEstimadaSalida.ToString("yyyyMMdd") + "', ");
            a.Append("Vapor='" + InfoEmbarque.Vapor + "', ");
            a.Append("FechaEstimadaArribo='" + InfoEmbarque.FechaEstimadaArribo.ToString("yyyyMMdd") + "' ");
            a.Append("where convert(varchar, Id) + IdItem = " + OrdenCompra.Id.ToString()+OrdenCompra.IdItem + " ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void RecepcionDocumentos(string ListaOrdenesCompra, CedForecastEntidades.OrdenCompraInfoRecepcionDocumentos InfoRecepcionDocumentos, List<string> HandlersWF)
        {
            StringBuilder a = new StringBuilder();
            for (int i = 0; i < HandlersWF.Count; i++)
            {
                a.Append(HandlersWF[i]);
                a.Append("end ");
            }
            a.Append("update OrdenCompra set ");
            a.Append("NroConocimientoEmbarque='" + InfoRecepcionDocumentos.NroConocimientoEmbarque + "', ");
            a.Append("Factura='" + InfoRecepcionDocumentos.Factura + "', ");
            a.Append("FechaRecepcionDocumentos='" + InfoRecepcionDocumentos.FechaRecepcionDocumentos.ToString("yyyyMMdd") + "' ");
            a.Append("where convert(varchar, Id) + IdItem in (" + ListaOrdenesCompra + ") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void RegistroDespacho(string ListaOrdenesCompra, CedForecastEntidades.OrdenCompraInfoRegistroDespacho InfoRegistroDespacho, List<string> HandlersWF)
        {
            StringBuilder a = new StringBuilder();
            for (int i = 0; i < HandlersWF.Count; i++)
            {
                a.Append(HandlersWF[i]);
                a.Append("end ");
            }
            a.Append("update OrdenCompra set ");
            a.Append("FechaIngresoAPuerto='" + InfoRegistroDespacho.FechaIngresoAPuerto.ToString("yyyyMMdd") + "', ");
            a.Append("NroDespacho='" + InfoRegistroDespacho.NroDespacho + "', ");
            a.Append("FechaOficializacion='" + InfoRegistroDespacho.FechaOficializacion.ToString("yyyyMMdd") + "' ");
            a.Append("where convert(varchar, Id) + IdItem in (" + ListaOrdenesCompra + ") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void InspeccionRENAR(string ListaOrdenesCompra, CedForecastEntidades.OrdenCompraInfoInspeccionRENAR InfoInspeccionRENAR, List<string> HandlersWF)
        {
            StringBuilder a = new StringBuilder();
            for (int i = 0; i < HandlersWF.Count; i++)
            {
                a.Append(HandlersWF[i]);
                a.Append("end ");
            }
            a.Append("update OrdenCompra set ");
            a.Append("FechaInspeccionRENAR='" + InfoInspeccionRENAR.FechaInspeccionRENAR.ToString("yyyyMMdd") + "' ");
            a.Append("where convert(varchar, Id) + IdItem in (" + ListaOrdenesCompra + ") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void IngresoADeposito(string ListaOrdenesCompra, CedForecastEntidades.OrdenCompraInfoIngresoADeposito InfoIngresoADeposito, List<string> HandlersWF)
        {
            StringBuilder a = new StringBuilder();
            for (int i = 0; i < HandlersWF.Count; i++)
            {
                a.Append(HandlersWF[i]);
                a.Append("end ");
            }
            a.Append("update OrdenCompra set ");
            a.Append("FechaIngresoDeposito='" + InfoIngresoADeposito.FechaIngresoDeposito.ToString("yyyyMMdd") + "' ");
            a.Append("where convert(varchar, Id) + IdItem in (" + ListaOrdenesCompra + ") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void Anulacion(List<string> HandlersWF)
        {
            StringBuilder a = new StringBuilder();
            for (int i = 0; i < HandlersWF.Count; i++)
            {
                a.Append(HandlersWF[i]);
                a.Append("end ");
            }
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void Modificacion(CedForecastEntidades.OrdenCompra OrdenCompraOriginal, CedForecastEntidades.OrdenCompra OrdenCompraModificada, string HandlerWF)
        {
            StringBuilder a = new StringBuilder();
            a.Append(HandlerWF);
            a.Append("end ");
            a.Append("update OrdenCompra set ");
            a.Append("Prefijo='" + OrdenCompraModificada.Prefijo + "', ");
            a.Append("IdProveedor='" + OrdenCompraModificada.IdProveedor + "', ");
            a.Append("DescrProveedor='" + OrdenCompraModificada.DescrProveedor + "', ");
            a.Append("Fecha='" + OrdenCompraModificada.Fecha.ToString("yyyyMMdd") + "', ");
            a.Append("IdPaisOrigen='" + OrdenCompraModificada.IdPaisOrigen + "', ");
            a.Append("DescrPaisOrigen='" + OrdenCompraModificada.DescrPaisOrigen + "', ");
            a.Append("IdArticulo='" + OrdenCompraModificada.IdArticulo + "', ");
            a.Append("DescrArticulo='" + OrdenCompraModificada.DescrArticulo + "', ");
            a.Append("FechaEstimadaArriboRequerida='" + OrdenCompraModificada.FechaEstimadaArriboRequerida.ToString("yyyyMMdd") + "', ");
            a.Append("CantidadContenedores=" + OrdenCompraModificada.CantidadContenedores.ToString() + ", ");
            a.Append("ComentarioContenedores='" + OrdenCompraModificada.ComentarioContenedores + "', ");
            a.Append("CantidadPresentacion=" + OrdenCompraModificada.CantidadPresentacion.ToString() + ", ");
            a.Append("Cantidad=" + OrdenCompraModificada.Cantidad.ToString() + ", ");
            a.Append("IdMoneda='" + OrdenCompraModificada.IdMoneda + "', ");
            a.Append("Precio=" + OrdenCompraModificada.Precio.ToString() + ", ");
            a.Append("Importe=" + OrdenCompraModificada.Importe.ToString() + ", ");
            a.Append("ImporteGastosNacionalizacion=" + OrdenCompraModificada.ImporteGastosNacionalizacion.ToString() + ", ");
            a.Append("Comentario='" + OrdenCompraModificada.Comentario + "', "); 
            a.Append("IdReferenciaSAP='" + OrdenCompraModificada.IdReferenciaSAP + "', ");
            a.Append("FechaEstimadaSalida='" + OrdenCompraModificada.FechaEstimadaSalida.ToString("yyyyMMdd") + "', ");
            a.Append("Vapor='" + OrdenCompraModificada.Vapor + "', ");
            a.Append("FechaEstimadaArribo='" + OrdenCompraModificada.FechaEstimadaArribo.ToString("yyyyMMdd") + "', ");
            a.Append("NroConocimientoEmbarque='" + OrdenCompraModificada.NroConocimientoEmbarque + "', ");
            a.Append("Factura='" + OrdenCompraModificada.Factura + "', ");
            a.Append("FechaRecepcionDocumentos='" + OrdenCompraModificada.FechaRecepcionDocumentos.ToString("yyyyMMdd") + "', ");
            a.Append("FechaIngresoAPuerto='" + OrdenCompraModificada.FechaIngresoAPuerto.ToString("yyyyMMdd") + "', ");
            a.Append("NroDespacho='" + OrdenCompraModificada.NroDespacho + "', ");
            a.Append("FechaOficializacion='" + OrdenCompraModificada.FechaOficializacion.ToString("yyyyMMdd") + "', ");
            a.Append("FechaInspeccionRENAR='" + OrdenCompraModificada.FechaInspeccionRENAR.ToString("yyyyMMdd") + "', ");
            a.Append("FechaIngresoDeposito='" + OrdenCompraModificada.FechaIngresoDeposito.ToString("yyyyMMdd") + "' ");
            a.Append("where convert(varchar, Id) + IdItem = '" + OrdenCompraOriginal.Id.ToString() + OrdenCompraOriginal.IdItem + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void CambioEstado(CedForecastEntidades.OrdenCompra OrdenCompraOriginal, CedForecastEntidades.OrdenCompra OrdenCompraModificada, string HandlerWF)
        {
            StringBuilder a = new StringBuilder();
            a.Append(HandlerWF);
            a.Append("end ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
    }
}