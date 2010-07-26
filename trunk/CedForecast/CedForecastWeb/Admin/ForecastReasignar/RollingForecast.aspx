<%@ Page AutoEventWireup="true" Codebehind="RollingForecast.aspx.cs" Inherits="CedForecastWeb.Admin.ForecastReasignar.RollingForecast"
    Language="C#" MasterPageFile="~/Admin/Administracion.Master" StylesheetTheme="Cedeira" %>

<%@ Register Assembly="CedeiraUIWebForms" Namespace="CedeiraUIWebForms" TagPrefix="cc1" %>
<asp:Content ID="ForecastReasignarContent" runat="Server" ContentPlaceHolderID="AdministracionContentPlaceHolder">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="height: 500px;
        width: 890px; text-align: left; background-color: White;">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-top: 10px">
                     <tr>
                        <td style="padding-left: 10px;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <!-- @@@ TITULO DE LA PAGINA @@@-->
                                <tr>
                                    <td style="width: 20px; vertical-align: top; height: 25px;">
                                        <table border="0" cellpadding="0" cellspacing="0" id="TABLE3">
                                            <tr>
                                                <td style="height: 3px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/button_link.gif" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td colspan="2" style="width: 800px;">
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Reasignación de datos del Rolling Forecast"></asp:Label>
                                        <hr />
                                    </td>
                                </tr>
                                <!-- @@@ @@@-->
                                <tr>
                                    <td>
                                    </td>
                                    <td colspan="2" style="text-align: left; padding-right: 3px; vertical-align: middle;">
                                        <asp:Panel ID="PanelSeleccion" runat="server" Enabled="true" Height="50px">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="text-align: right; padding-right: 3px; vertical-align: top;" valign="top">
                                                        <asp:Label ID="CuentaLabel" runat="server" SkinID="TituloMediano" Text="Vendedor:"></asp:Label>
                                                    </td>
                                                    <td align="left" style="" valign="top">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="left" style="" valign="top">
                                                                    <asp:DropDownList ID="CuentaDropDownList" runat="server" TabIndex="10" Width="424px">
                                                                    </asp:DropDownList>&nbsp;
                                                                </td>
                                                                <td style="width: 40px">
                                                                </td>
                                                                <td style="text-align: right; padding-right: 3px; vertical-align: middle">
                                                                    <asp:Label ID="FechaLabel" runat="server" SkinID="TituloMediano" Text="Período:"></asp:Label>
                                                                </td>
                                                                <td align="left" style="" valign="top">
                                                                    <asp:TextBox ID="PeriodoTextBox" runat="server" Width="70px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 5px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right; padding-right: 3px; vertical-align: top;">
                                                        <asp:Label ID="ClienteLabel" runat="server" SkinID="TituloMediano" Text="Cliente:"></asp:Label>
                                                    </td>
                                                    <td align="left" style="" valign="top">
                                                        <asp:DropDownList ID="ClienteDropDownList" runat="server" TabIndex="10" Width="424px">
                                                        </asp:DropDownList>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="left" style="padding-top: 10px;">
                                        <asp:Button ID="LeerButton" runat="server" OnClick="LeerButton_Click" Text="Leer"
                                            Width="860px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                    <tr>
                        <td style="padding-left: 10px; padding-top: 10px" valign="top">
                            <asp:Panel ID="Panel1" runat="server" BackColor="peachpuff" BorderColor="brown" BorderStyle="Solid"
                                BorderWidth="1px" Height="373px" ScrollBars="Auto" Width="860px">
                                &nbsp;<cc1:PagingGridView ID="ForecastPagingGridView" runat="server" AllowPaging="True"
                                    AllowSorting="True" OnPageIndexChanging="ForecastPagingGridView_PageIndexChanging"
                                    OnRowDataBound="ForecastPagingGridView_RowDataBound" OnSorting="ForecastPagingGridView_Sorting"
                                    VirtualItemCount="-1">
                                    <PagerSettings Mode="NumericFirstLast" />
                                    <Columns>
                                        <asp:BoundField DataField="DescrArticulo" HeaderText="Art&#237;culo" SortExpression="DescrArticulo">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" width="300px" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdCliente" HeaderText="Id.Cliente" SortExpression="IdCliente" />
                                        <asp:BoundField DataField="DescrCliente" HeaderText="Cliente" SortExpression="DescrCliente">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" width="300px" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Proyectado" HeaderText="Proyectado">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ventas" HeaderText="Ventas">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Desvio" HeaderText="Desvio">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad1" HeaderText="Cantidad1">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad2" HeaderText="Cantidad2">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad3" HeaderText="Cantidad3">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad4" HeaderText="Cantidad4">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad5" HeaderText="Cantidad5">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad6" HeaderText="Cantidad6">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad7" HeaderText="Cantidad7">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad8" HeaderText="Cantidad8">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad9" HeaderText="Cantidad9">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad10" HeaderText="Cantidad10">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad11" HeaderText="Cantidad11">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad12" HeaderText="Cantidad12">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CantidadTotal" HeaderText="Total">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                    </Columns>
                                </cc1:PagingGridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="text-align: right; padding-right: 3px; padding-left:15px; vertical-align: middle;">
                                        <asp:Label ID="VendedorHastaLabel" runat="server" SkinID="TituloMediano" Text="Asignar al Vendedor:"></asp:Label>
                                    </td>
                                    <td align="left" style="" valign="top">
                                        <asp:DropDownList ID="CuentaAReasignarDropDownList" runat="server" TabIndex="10"
                                            Width="324px">
                                        </asp:DropDownList>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <table border="0" cellpadding="0" cellspacing="0" id="Table1">
                                <tr>
                                    <td style="width: 190px; text-align:left; padding-left:15px;">
                                        <asp:Button ID="AceptarButton" runat="server" OnClick="AceptarButton_Click" Text="Aceptar"
                                            Width="100px" />
                                    </td>
                                    <td style="width: 490px;">
                                    </td>
                                    <td style="width: 190px; text-align: right;">
                                        <asp:Button ID="CancelarButton" runat="server" OnClick="CancelarButton_Click" Text="Cancelar"
                                            Width="100px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left:15px;">
                            <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label></td>
                    </tr>
                </table>
            </td>
            <td style="width: 30px" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>
