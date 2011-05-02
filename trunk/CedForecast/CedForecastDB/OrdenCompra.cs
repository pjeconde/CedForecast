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
            Hasta.IdOpWF = Convert.ToInt32(Desde["IdOpWF"]);
        }
    }
}