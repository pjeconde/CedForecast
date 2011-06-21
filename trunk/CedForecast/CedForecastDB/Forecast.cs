using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CedForecastDB
{
    public class Forecast: db
    {
        public Forecast(CedEntidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void EliminarProyectadoAnual(string Año)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete Forecast where Forecast.IdTipoPlanilla='Proyectado' and substring(rtrim(ltrim(Forecast.IdPeriodo)), 1, 4) ='" + Año + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void EliminarRollingForecast(string Periodo)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete Forecast where Forecast.IdTipoPlanilla='RollingForecast' and Forecast.IdPeriodo>='" + Periodo + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Crear(CedForecastEntidades.Forecast Elemento)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("insert Forecast values ( ");
            a.Append("'" + Elemento.IdTipoPlanilla + "', ");
            a.Append("'" + Elemento.IdCuenta + "', ");
            a.Append("'" + Elemento.IdCliente + "', ");
            a.Append("'" + Elemento.IdArticulo + "', ");
            a.Append("'" + Elemento.IdPeriodo + "', ");
            a.Append(Convert.ToString(Elemento.Cantidad, cedeiraCultura) + " ");
            a.Append(") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public DataSet LeerDatosParaFinanciero(string IdPeriodo, string TipoReporte, string ListaClientes)
        {
            System.Text.StringBuilder a = new StringBuilder();
            switch (TipoReporte)
            {
                case "Zona-Cliente":
                    a.Append("Select Zona, Cliente, TipoDato, Descr, FecVto, Saldo into #Financiero from (");
                    a.Append("Select Clientes.clizon_cod as Zona, CabVenta.cve_CodCli as Cliente, ");
                    a.Append("convert(varchar(50), 'CtaCte') as TipoDato, ");
                    a.Append("CabVenta.cvetco_Cod + '-' + CabVenta.cve_CodPvt + '-' + CabVenta.cve_Nro + '-Fec.Emi:' + convert(varchar(10), CabVenta.cve_FEmision, 103) + '-Imp.Orig:' + ltrim(rtrim(convert(varchar(30), CabVenta.cve_ImpMonLoc))) as Descr, ");
                    a.Append("CabVenta.cve_FVto as FecVto, ");
                    a.Append("CabVenta.cve_SaldoMonLoc as Saldo ");
                    a.Append("from SBDAFERT.dbo.CabVenta left outer join SBDAFERT.dbo.Clientes on CabVenta.cve_CodCli=Clientes.cli_Cod "); 
                    a.Append("where cvetco_Cod in ('FC', 'ND', 'NC', 'FCE', 'NDE', 'NCE', 'RC', 'FCT', 'LIA', 'ACF', 'ADF', 'AJC', 'AJD') and CabVenta.cve_CodCli <> '' ");
                    a.Append("and CabVenta.cve_SaldoMonLoc <> 0 and CabVenta.cve_CodCli in (" + ListaClientes + ") "); 
                    a.Append("UNION "); 
                    a.Append("Select Clientes.clizon_cod as Zona, ch3cli_Cod as Cliente, ");
                    a.Append("convert(varchar(50), 'Cheques') as TipoDato, ");
                    a.Append("'Cheque Nro.:' + rtrim(ltrim(ch3_nroCheq)) + '-Banco:' + ch3bco_cod as Descr, ");
                    a.Append("ch3_FVto as FecVto, ch3_Importe as Saldo ");
                    a.Append("from SBDAFERT.dbo.Cheques3 left outer join SBDAFERT.dbo.Clientes on Cheques3.ch3cli_Cod=Clientes.cli_Cod ");
                    a.Append("where ch3_FVto >= '" + IdPeriodo + "01" + "' and ch3tch_Cod = 'DIF' and Cheques3.ch3cli_Cod in (" + ListaClientes + ") ");
                    //a.Append("UNION ");
                    a.Append(" ) go ");
                    a.Append("select distinct Zona from #Financiero order by Zona ");
                    a.Append("select distinct Cliente from #Financiero order by Cliente ");
                    a.Append("select Zona, Cliente, TipoDato, Descr, FecVto, Saldo from #Financiero order by Zona, Cliente, TipoDato, Descr, FecVto asc ");
                    a.Append("drop table #Financiero ");
                    break;
                default:
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.OpcionInvalida();
            }
            return (DataSet)Ejecutar(a.ToString(), TipoRetorno.DS, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public DataSet LeerDatosParaFinancieroDs(string IdPeriodo, string TipoReporte, string ListaClientes)
        {
            System.Text.StringBuilder a = new StringBuilder();
            switch (TipoReporte)
            {
                case "Zona-Cliente":
                    a.Append("Select Zona, Cliente, Nombre, TipoDato, Descripcion, FecVto, Saldo into #Financiero from (");
                    a.Append("Select Clientes.clizon_cod as Zona, CabVenta.cve_CodCli as Cliente, Clientes.cli_RazSoc as Nombre, ");
                    a.Append("convert(varchar(50), 'CtaCte') as TipoDato, ");
                    a.Append("CabVenta.cvetco_Cod + '-' + CabVenta.cve_CodPvt + '-' + CabVenta.cve_Nro + '-Fec.Emi:' + convert(varchar(10), CabVenta.cve_FEmision, 103) + '-Imp.Orig:' + ltrim(rtrim(convert(varchar(30), CabVenta.cve_ImpMonLoc))) as Descripcion, ");
                    a.Append("CabVenta.cve_FVto as FecVto, ");
                    a.Append("CabVenta.cve_SaldoMonLoc as Saldo ");
                    a.Append("from SBDAFERT.dbo.CabVenta left outer join SBDAFERT.dbo.Clientes on CabVenta.cve_CodCli=Clientes.cli_Cod ");
                    a.Append("where cvetco_Cod in ('FC', 'ND', 'NC', 'FCE', 'NDE', 'NCE', 'RC', 'FCT', 'LIA', 'ACF', 'ADF', 'AJC', 'AJD') and CabVenta.cve_CodCli <> '' ");
                    a.Append("and CabVenta.cve_SaldoMonLoc <> 0 and CabVenta.cve_CodCli in (" + ListaClientes + ") ");
                    a.Append("UNION ");
                    a.Append("Select Clientes.clizon_cod as Zona, ch3cli_Cod as Cliente, Clientes.cli_RazSoc as Nombre, ");
                    a.Append("convert(varchar(50), 'Cheques') as TipoDato, ");
                    a.Append("'Cheque Nro.:' + rtrim(ltrim(ch3_nroCheq)) + '-Banco:' + ch3bco_cod as Descripcion, ");
                    a.Append("ch3_FVto as FecVto, ch3_Importe as Saldo ");
                    a.Append("from SBDAFERT.dbo.Cheques3 left outer join SBDAFERT.dbo.Clientes on Cheques3.ch3cli_Cod=Clientes.cli_Cod ");
                    a.Append("where ch3_FVto >= '" + IdPeriodo + "01" + "' and ch3tch_Cod = 'DIF' and Cheques3.ch3cli_Cod in (" + ListaClientes + ") ");
                    a.Append(" ) go ");
                    a.Append("select distinct Zona from #Financiero order by Zona ");
                    a.Append("select distinct Zona, Cliente, Nombre from #Financiero order by Zona, Cliente ");
                    a.Append("select Zona, Cliente, Nombre, TipoDato, Descripcion, FecVto, Saldo from #Financiero order by Zona, Cliente, TipoDato, Descripcion, FecVto asc ");

                    a.Append("Select Zona, Cliente, TipoDato, Descripcion, Saldo into #FinancieroT from (select Clientes.clizon_cod as Zona, Clientes.cli_Cod as Cliente, ");
                    a.Append("convert(varchar(50), 'Credito') as TipoDato, ");
                    a.Append("convert(varchar(50), 'Crédito Máximo Otorgado') as Descripcion, ");
                    a.Append("sum(sfc_CredMax) as Saldo ");
                    a.Append("from SBDAFERT.dbo.SitFcieraC left outer join SBDAFERT.dbo.Clientes on SitFcieraC.sfccli_Cod = Clientes.cli_Cod ");
                    a.Append("where Clientes.cli_Cod in (" + ListaClientes + ") and sfc_CredMax <> 0 ");
                    a.Append("Group by Clientes.clizon_cod, Clientes.cli_Cod ");
                    a.Append("UNION ");
                    a.Append("Select Clientes.clizon_cod as Zona, CabVenta.cve_CodCli as Cliente, ");
                    a.Append("convert(varchar(50), 'Exposicion') as TipoDato, ");
                    a.Append("convert(varchar(50), 'Exposición') as Descripcion, ");
                    a.Append("Sum(CabVenta.cve_SaldoMonLoc * -1) as Saldo ");
                    a.Append("from SBDAFERT.dbo.CabVenta left outer join SBDAFERT.dbo.Clientes on CabVenta.cve_CodCli=Clientes.cli_Cod ");
                    a.Append("where cvetco_Cod in ('FC', 'ND', 'NC', 'FCE', 'NDE', 'NCE', 'RC', 'FCT', 'LIA', 'ACF', 'ADF', 'AJC', 'AJD') and CabVenta.cve_CodCli <> '' ");
                    a.Append("and CabVenta.cve_SaldoMonLoc <> 0 and CabVenta.cve_CodCli in (" + ListaClientes + ") ");
                    a.Append("Group by Clientes.clizon_cod, CabVenta.cve_CodCli ");
                    a.Append("UNION ");
                    a.Append("Select Clientes.clizon_cod as Zona, ch3cli_Cod as Cliente, ");
                    a.Append("convert(varchar(50), 'Exposicion') as TipoDato, ");
                    a.Append("convert(varchar(50), 'Exposición') as Descripcion, ");
                    a.Append("sum(ch3_Importe * -1) as Saldo ");
                    a.Append("from SBDAFERT.dbo.Cheques3 left outer join SBDAFERT.dbo.Clientes on Cheques3.ch3cli_Cod=Clientes.cli_Cod ");
                    a.Append("where ch3_FVto >= '" + IdPeriodo + "01" + "' and ch3tch_Cod = 'DIF' and Cheques3.ch3cli_Cod in (" + ListaClientes + ") ");
                    a.Append("Group by Clientes.clizon_cod, ch3cli_Cod ) GO ");
                    a.Append("select Zona, Cliente, TipoDato, Descripcion, sum(Saldo) as Monto from #financieroT where Cliente in (select distinct #Financiero.Cliente from #Financiero) group by Zona, Cliente, TipoDato, Descripcion ");
                    a.Append("drop table #financieroT ");
                    a.Append("drop table #Financiero ");
                    break;
                default:
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.OpcionInvalida();
            }
            return (DataSet)Ejecutar(a.ToString(), TipoRetorno.DS, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public DataSet LeerDatosParaStockXArticulo(string PeriodoDesde, string TipoReporte, string ListaArticulos)
        {
            System.Text.StringBuilder a = new StringBuilder();
            switch (TipoReporte)
            {
                case "Familia-Articulo":
                    //Articulos y Familias
                    a.Append("select IdFamiliaArticulo as Familia, IdArticulo, Articulos.art_DescGen as DescrArticulo into #ArticuloInfoAdicionalAux ");
                    a.Append("from ArticuloInfoAdicional left outer join SBDAFERT.dbo.Articulos on ArticuloInfoAdicional.IdArticulo = LTRIM(RTRIM(Articulos.art_CodGen)) ");
                    a.Append("where ArticuloInfoAdicional.IdArticulo in (" + ListaArticulos + ") ");
                    a.Append("order by IdArticulo ");
                    a.Append("select Familia, IdArticulo, DescrArticulo from #ArticuloInfoAdicionalAux order by IdArticulo asc ");
                    a.Append("select distinct Familia from #ArticuloInfoAdicionalAux order by Familia asc ");    
                    
                    //Forecast
                    a.Append("Select '4' as Orden, 'Forecast' as TipoDato, 'Forecast' as Descr, IdFamiliaArticulo as Familia, Forecast.IdArticulo as IdArticulo, Articulos.art_DescGen as DescrArticulo, Forecast.IdPeriodo as Periodo, sum(Cantidad) as Cantidad ");
                    a.Append("from Forecast left outer join ArticuloInfoAdicional on Forecast.IdArticulo=ArticuloInfoAdicional.IdArticulo collate database_default ");
                    a.Append("left outer join SBDAFERT.dbo.Articulos on ArticuloInfoAdicional.IdArticulo = LTRIM(RTRIM(Articulos.art_CodGen)) ");
                    a.Append("where Forecast.IdTipoPlanilla='RollingForecast' and Forecast.IdArticulo in (" + ListaArticulos + ") ");
                    a.Append("and IdPeriodo>='" + PeriodoDesde + "' group by IdFamiliaArticulo, Forecast.IdArticulo, Articulos.art_DescGen, Forecast.IdPeriodo ");
                    a.Append("order by Forecast.IdArticulo asc, Forecast.IdPeriodo asc ");
                    
                    //Ordenes de Compra
                    a.Append("Select '2' as Orden, 'Ordenes de Compra' as TipoDato, 'Ordenes de Compra' as Descr, ArticuloInfoAdicional.IdFamiliaArticulo as Familia, OrdenCompra.IdArticulo as IdArticulo, OrdenCompra.DescrArticulo as Articulo, convert(varchar(6), FechaEstimadaArribo, 112) as Periodo, sum(Cantidad) as Cantidad ");
                    a.Append("from OrdenCompra left outer join ArticuloInfoAdicional on OrdenCompra.IdArticulo=ArticuloInfoAdicional.IdArticulo collate database_default ");
                    a.Append("left outer join WF_Op on OrdenCompra.IdOpWF=WF_Op.IdOp ");
                    a.Append("where convert(varchar(6), FechaEstimadaArribo, 112) >= '" + PeriodoDesde + "' and WF_Op.IdEstado not in ('Concluida', 'Anulada') ");
                    a.Append("and OrdenCompra.IdArticulo in (" + ListaArticulos + ") ");
                    a.Append("group by IdFamiliaArticulo, OrdenCompra.IdArticulo, OrdenCompra.DescrArticulo, convert(varchar(6), FechaEstimadaArribo, 112) ");
                    a.Append("Order by OrdenCompra.IdArticulo asc, convert(varchar(6), FechaEstimadaArribo, 112) asc ");
                    
                    //Stock (B)
                    a.Append("Select '1' as Orden, 'Stock' as TipoDato, Stock.stkdep_Cod+'-'+dep_Desc as Descr, LTRIM(RTRIM(stkart_CodGen)) as IdArticulo, stkdep_Cod as Deposito, stk_CantUM1 as Cantidad, stk_FecMod as FechaModif ");
                    a.Append("from SBDAFERT.dbo.Stock left outer join SBDAFERT.dbo.Deposito on Stock.stkdep_Cod = Deposito.dep_Cod where stkart_CodGen in (" + ListaArticulos + ") and stk_CantUM1 <> 0 order by stkart_CodGen ");

                    //Notas de Pedido Autorizadas Pendientes de Remitir del mes o meses anteriores (B)
                    a.Append("SELECT '3' as Orden, 'Notas de Pedido (Con Remito Pte.)' as TipoDato, SegTiposV.spvtco_Cod+'-'+SegTiposV.spv_Nro+'  Cliente:'+SegCabV.scvcli_Cod+'-'+SegCabV.scvcli_RazSoc+'  FechaEmi:'+Convert(varchar(10), SegCabV.scv_FEmision, 103) as Descr, SegTiposV.spvtco_Cod as TipoComprobante, SegTiposV.spv_Nro as NroComprobante, LTRIM(RTRIM(SegDetV.sdvart_CodGen)) AS IdArticulo, ");
                    a.Append("SegDetV.sdv_Desc AS DescrArticulo, SegCabV.scv_FEmision AS Fecha_Emision, SegCabV.scv_FEntrega AS Fecha_Entrega, ");
                    a.Append("SegDetV.sdv_CantUM1 AS Cantidad_Total, SegDetV.sdv_CPendRtUM1 AS Cantidad_Pend_RT, SegDetV.sdv_CPendFcUM1 AS Cantidad_Pend_FC, SegDetV.sdvemp_Codigo, ");
                    a.Append("SegDetV.sdvsuc_Cod, SegDetV.sdv_ID, SegDetV.sdvscv_ID ");
                    a.Append("FROM SBDAFERT.dbo.SegTiposV INNER JOIN ");
                    a.Append("SBDAFERT.dbo.SegCabV ON SegTiposV.spvscv_ID = SegCabV.scv_ID AND SegTiposV.spvsuc_Cod = SegCabV.scvsuc_Cod AND ");
                    a.Append("SegTiposV.spvemp_Codigo = SegCabV.scvemp_Codigo INNER JOIN SBDAFERT.dbo.SegDetV ON SegCabV.scv_ID = SegDetV.sdvscv_ID ");
                    a.Append("WHERE SegTiposV.spvtco_Cod = 'NPA' and SegDetV.sdvart_CodGen in (" + ListaArticulos + ") and SegDetV.sdv_CPendRtUM1 <> 0 ");
                    a.Append("order by SegDetV.sdvart_CodGen asc ");

                    //Notas de Pedido Autorizadas Remitidas del mes (B)
                    a.Append("SELECT  '5' as Orden, 'Notas de Pedido del Mes (Sin Remito Pte.)' as TipoDato, SegTiposV.spvtco_Cod+' Nro:'+SegTiposV.spv_Nro+' Cliente:'+SegCabV.scvcli_Cod+'-'+SegCabV.scvcli_RazSoc+'  FechaEmi:'+Convert(varchar(10), SegCabV.scv_FEmision, 103) as Descr, SegTiposV.spvtco_Cod as TipoComprobante, SegTiposV.spv_Nro as NroComprobante, LTRIM(RTRIM(SegDetV.sdvart_CodGen)) AS IdArticulo, ");
                    a.Append("SegDetV.sdv_Desc AS DescrArticulo, SegCabV.scv_FEmision AS Fecha_Emision, SegCabV.scv_FEntrega AS Fecha_Entrega, ");
                    a.Append("SegDetV.sdv_CantUM1 AS Cantidad_Total, SegDetV.sdv_CPendRtUM1 AS Cantidad_Pend_RT, SegDetV.sdv_CPendFcUM1 AS Cantidad_Pend_FC, SegDetV.sdvemp_Codigo, ");
                    a.Append("SegDetV.sdvsuc_Cod, SegDetV.sdv_ID, SegDetV.sdvscv_ID ");
                    a.Append("FROM SBDAFERT.dbo.SegTiposV INNER JOIN ");
                    a.Append("SBDAFERT.dbo.SegCabV ON SegTiposV.spvscv_ID = SegCabV.scv_ID AND SegTiposV.spvsuc_Cod = SegCabV.scvsuc_Cod AND ");
                    a.Append("SegTiposV.spvemp_Codigo = SegCabV.scvemp_Codigo INNER JOIN SBDAFERT.dbo.SegDetV ON SegCabV.scv_ID = SegDetV.sdvscv_ID ");
                    a.Append("WHERE SegTiposV.spvtco_Cod = 'NPA' and SegDetV.sdvart_CodGen in (" + ListaArticulos + ") and convert(varchar(6), SegCabV.scv_FEmision, 112) >= '" + PeriodoDesde + "' and SegDetV.sdv_CPendRtUM1 = 0 ");
                    a.Append("order by SegDetV.sdvart_CodGen asc ");

                    //Bajas de Remitos de NP (B)
                    a.Append("SELECT '6' as Orden, 'Baja de Remitos de NP' as TipoDato, SegTiposV.spvtco_Cod+'-'+SegTiposV.spv_Nro+'  Cliente:'+SegCabV.scvcli_Cod+'-'+SegCabV.scvcli_RazSoc+'  FechaEmi:'+Convert(varchar(10), SegCabV.scv_FEmision, 103) as Descr, SegTiposV.spvtco_Cod as TipoComprobante, SegTiposV.spv_Nro as NroComprobante, LTRIM(RTRIM(SegDetV.sdvart_CodGen)) AS IdArticulo, ");
                    a.Append("SegDetV.sdv_Desc AS DescrArticulo, SegCabV.scv_FEmision AS Fecha_Emision, SegCabV.scv_FEntrega AS Fecha_Entrega, SegDetV.sdv_CantUM1 AS Cantidad_Total, SegDetV.sdv_CPendRtUM1 AS Cantidad_Pend_RT, SegDetV.sdv_CPendFcUM1 AS Cantidad_Pend_FC, SegDetV.sdvemp_Codigo, SegDetV.sdvsuc_Cod, SegDetV.sdv_ID, SegDetV.sdvscv_ID ");
                    a.Append("FROM SBDAFERT.dbo.SegTiposV INNER JOIN SBDAFERT.dbo.SegCabV ON SegTiposV.spvscv_ID = SegCabV.scv_ID AND SegTiposV.spvsuc_Cod = SegCabV.scvsuc_Cod AND SegTiposV.spvemp_Codigo = SegCabV.scvemp_Codigo ");
                    a.Append("INNER JOIN SBDAFERT.dbo.SegDetV ON SegCabV.scv_ID = SegDetV.sdvscv_ID ");
                    a.Append("WHERE SegTiposV.spvtco_Cod = 'REM' and SegDetV.sdvart_CodGen in (" + ListaArticulos + ") ");
                    a.Append("order by SegDetV.sdvart_CodGen asc ");

                    a.Append("drop table #ArticuloInfoAdicionalAux ");                    
                    break;
                default:
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.OpcionInvalida();
            }
            return (DataSet)Ejecutar(a.ToString(), TipoRetorno.DS, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public DataSet LeerDatosParaResumenArgentinaXZonas(string PeriodoDesde, string PeriodoHasta, string TipoReporte, string ListaArticulos, string ListaClientes, string ListaVendedores)
        {
            System.Text.StringBuilder a = new StringBuilder();
            switch (TipoReporte)
            {
                case "Zona-Familia-Articulo":
                    a.Append("Select convert(varchar(8), 'Empresa') as Empresa, SBDAFERT.dbo.Clientes.clizon_Cod as Zona, IdFamiliaArticulo as Familia, Forecast.IdArticulo as IdArticulo, Forecast.IdArticulo as Articulo, Forecast.IdPeriodo as Periodo, sum(Cantidad) as Cantidad into #ForecastAux ");
                    a.Append("from Forecast left outer join SBDAFERT.dbo.Clientes on Forecast.IdCliente = SBDAFERT.dbo.Clientes.cli_Cod collate SQL_Latin1_General_CP1_CS_AS ");
                    a.Append("left outer join SBDAFERT.dbo.Vendedor on Forecast.IdCuenta = SBDAFERT.dbo.Vendedor.ven_Cod collate SQL_Latin1_General_CP1_CS_AS ");
                    a.Append("left outer join ArticuloInfoAdicional on Forecast.IdArticulo=ArticuloInfoAdicional.IdArticulo ");
                    a.Append("where Forecast.IdTipoPlanilla='RollingForecast' and Forecast.IdArticulo in (" + ListaArticulos + ") and SBDAFERT.dbo.Clientes.cli_Cod in (" + ListaClientes + ") ");
                    a.Append("and SBDAFERT.dbo.Vendedor.ven_Cod in (" + ListaVendedores + ") ");
                    a.Append("and IdPeriodo>='" + PeriodoDesde + "' and IdPeriodo<='" + PeriodoHasta + "' group by SBDAFERT.dbo.Clientes.clizon_Cod, IdFamiliaArticulo, Forecast.IdArticulo, Forecast.IdPeriodo ");
                    a.Append("select distinct Zona from #ForecastAux order by Zona ");
                    a.Append("select distinct Familia from #ForecastAux order by Familia ");
                    a.Append("select distinct Articulo from #ForecastAux order by Articulo ");
                    a.Append("select Empresa, Zona, Familia, IdArticulo, Articulo, Periodo, Cantidad from #ForecastAux order by Zona, Familia, Articulo, Periodo asc ");
                    a.Append("drop table #ForecastAux ");
                    break;
                case "Vendedor-Familia-Articulo":
                    a.Append("Select convert(varchar(8), 'Empresa') as Empresa, SBDAFERT.dbo.Vendedor.ven_Cod as Vendedor, IdFamiliaArticulo as Familia, Forecast.IdArticulo as IdArticulo, Forecast.IdArticulo as Articulo, Forecast.IdPeriodo as Periodo, sum(Cantidad) as Cantidad into #ForecastAux ");
                    a.Append("from Forecast left outer join SBDAFERT.dbo.Clientes on Forecast.IdCliente = SBDAFERT.dbo.Clientes.cli_Cod collate SQL_Latin1_General_CP1_CS_AS ");
                    a.Append("left outer join SBDAFERT.dbo.Vendedor on Forecast.IdCuenta = SBDAFERT.dbo.Vendedor.ven_Cod collate SQL_Latin1_General_CP1_CS_AS ");
                    a.Append("left outer join ArticuloInfoAdicional on Forecast.IdArticulo=ArticuloInfoAdicional.IdArticulo ");
                    a.Append("where Forecast.IdTipoPlanilla='RollingForecast' and Forecast.IdArticulo in (" + ListaArticulos + ") and SBDAFERT.dbo.Clientes.cli_Cod in (" + ListaClientes + ") ");
                    a.Append("and SBDAFERT.dbo.Vendedor.ven_Cod in (" + ListaVendedores + ") ");
                    a.Append("and IdPeriodo>='" + PeriodoDesde + "' and IdPeriodo<='" + PeriodoHasta + "' group by SBDAFERT.dbo.Vendedor.ven_Cod, IdFamiliaArticulo, Forecast.IdArticulo, Forecast.IdPeriodo ");
                    a.Append("select distinct Vendedor from #ForecastAux order by Vendedor ");
                    a.Append("select distinct Familia from #ForecastAux order by Familia ");
                    a.Append("select distinct Articulo from #ForecastAux order by Articulo ");
                    a.Append("select Empresa, Vendedor, Familia, IdArticulo, Articulo, Periodo, Cantidad from #ForecastAux order by Vendedor, Familia, Articulo, Periodo asc ");
                    a.Append("drop table #ForecastAux ");
                    break;
                default:
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.OpcionInvalida();
            }
            return (DataSet)Ejecutar(a.ToString(), TipoRetorno.DS, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public DataSet LeerDatosParaCrossTabArticulosClientes(string IdPeriodoDesde, string IdPeriodoHasta, string TipoReporte, string ListaArticulos, string ListaClientes, string ListaVendedores)
        {
            System.Text.StringBuilder a = new StringBuilder();
            switch (TipoReporte)
            {
                case "Artículos-Vendedores":
                case "Vendedores-Artículos":
                    a.Append("select IdArticulo as Articulo, IdCuenta as Vendedor, IdCliente as Cliente, sum(Cantidad) as Cantidad into #ForecastAux ");
                    a.Append("from Forecast ");
                    a.Append("where IdTipoPlanilla='RollingForecast' and IdArticulo in (" + ListaArticulos + ") and IdCliente in (" + ListaClientes + ") and IdCuenta in (" + ListaVendedores + ") ");
                    a.Append("and IdPeriodo>='" + IdPeriodoDesde + "'  and IdPeriodo<='" + IdPeriodoHasta + "' group by IdArticulo, IdCuenta, IdCliente ");
                    a.Append("select distinct Articulo from #ForecastAux order by Articulo ");
                    a.Append("select distinct Vendedor from #ForecastAux order by Vendedor ");
                    a.Append("select distinct Cliente from #ForecastAux order by Cliente ");
                    a.Append("select Articulo, Vendedor, Cliente, Cantidad from #ForecastAux order by Articulo, Vendedor ");
                    a.Append("drop table #ForecastAux ");
                    break;
                case "Sólo Artículos":
                    a.Append("select IdArticulo as Articulo, IdCliente as Cliente, sum(Cantidad) as Cantidad into #ForecastAux ");
                    a.Append("from Forecast ");
                    a.Append("where IdTipoPlanilla='RollingForecast' and IdArticulo in (" + ListaArticulos + ") and IdCliente in (" + ListaClientes + ") ");
                    a.Append("and IdPeriodo>='" + IdPeriodoDesde + "'  and IdPeriodo<='" + IdPeriodoHasta + "' group by IdArticulo, IdCliente ");
                    a.Append("select distinct Articulo from #ForecastAux order by Articulo ");
                    a.Append("select * from #ForecastAux where 1=2 ");
                    a.Append("select distinct Cliente from #ForecastAux order by Cliente ");
                    a.Append("select Articulo, Cliente, Cantidad from #ForecastAux order by Articulo ");
                    a.Append("drop table #ForecastAux ");
                    break;
                default:
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.Validaciones.OpcionInvalida();
            }
            return (DataSet)Ejecutar(a.ToString(), TipoRetorno.DS, Transaccion.NoAcepta, sesion.CnnStr);
        }

        public DataSet LeerDatosForecastParaFinancieroDS(string PeriodoDesde, string PeriodoHasta, string ListaClientes)
        {
            System.Text.StringBuilder a = new StringBuilder();
            //"Zona-Cliente+CondicionDeVenta"
            a.Append("Select SBDAFERT.dbo.Clientes.clizon_Cod as Zona, SBDAFERT.dbo.Clientes.cli_Cod as Cliente, SBDAFERT.dbo.Clientes.cli_RazSoc as Nombre, SBDAFERT.dbo.CondVta.cvt_CantDias as CondVta, Forecast.IdArticulo as Articulo, Forecast.IdPeriodo as Periodo, sum(Cantidad) as Cantidad into #ForecastAux ");
            a.Append("from Forecast left outer join SBDAFERT.dbo.Clientes on Forecast.IdCliente = SBDAFERT.dbo.Clientes.cli_Cod collate SQL_Latin1_General_CP1_CS_AS ");
            a.Append("left outer join SBDAFERT.dbo.CondVta on Clientes.clicvt_Cod = CondVta.cvt_Cod collate SQL_Latin1_General_CP1_CS_AS ");
            a.Append("where Forecast.IdTipoPlanilla='RollingForecast' and SBDAFERT.dbo.Clientes.cli_Cod in (" + ListaClientes + ") ");
            a.Append("and IdPeriodo>='" + PeriodoDesde + "' and IdPeriodo<='" + PeriodoHasta + "' group by SBDAFERT.dbo.Clientes.clizon_Cod, SBDAFERT.dbo.Clientes.cli_RazSoc, SBDAFERT.dbo.Clientes.cli_Cod, SBDAFERT.dbo.CondVta.cvt_CantDias, Forecast.IdArticulo, Forecast.IdPeriodo ");
            a.Append("select Zona, Cliente, Nombre, CondVta, Periodo, Articulo, Cantidad from #ForecastAux order by Zona, Cliente, CondVta, Articulo asc, Periodo asc ");
            a.Append("drop table #ForecastAux ");
            return (DataSet)Ejecutar(a.ToString(), TipoRetorno.DS, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}