<%@ Page AutoEventWireup="true" Codebehind="ExploradorRollingForecast.aspx.cs" Inherits="CedForecastWeb.Forecast.ExploradorRollingForecast"
    Language="C#" MasterPageFile="~/Forecast/Forecast.Master" StylesheetTheme="Cedeira" %>

<%@ Register Assembly="CedeiraUIWebForms" Namespace="CedeiraUIWebForms" TagPrefix="cc1" %>
<asp:Content ID="ExploradorForecastContent" runat="Server" ContentPlaceHolderID="ForecastContentPlaceHolder">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="height: 500px;
        width: 890px; text-align: left; background-color: White;">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-top: 10px">
                    <!-- @@@ TITULO DE LA PAGINA @@@-->
                    <tr>
                        <td style="padding-left: 10px;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 20px; vertical-align: top;">
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
                                    <td colspan="2" style="width: 800px; height: 20px;">
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Rolling Forecast"></asp:Label>
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="text-align: right; padding-right: 3px; vertical-align: middle; height: 10px;">
                                        <asp:Label ID="FechaLabel" runat="server" SkinID="TituloMediano" Text="Período:"></asp:Label>
                                    </td>
                                    <td align="left" style="" valign="top">
                                        <asp:TextBox ID="PeriodoTextBox" runat="server" Width="75px"></asp:TextBox><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="text-align: right; padding-right: 3px; vertical-align: middle;">
                                        <asp:Label ID="ClienteLabel" runat="server" SkinID="TituloMediano" Text="Cliente:"></asp:Label>
                                    </td>
                                    <td align="left" style="" valign="top">
                                        <asp:DropDownList ID="ClienteDropDownList" runat="server" TabIndex="10" Width="388px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="left" style="padding-top: 10px;">
                                        <asp:Button ID="LeerButton" runat="server" OnClick="LeerButton_Click" Text="Leer"
                                            Width="860px" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                    <tr>
                        <td style="padding-left: 10px; padding-top: 10px" valign="top">
                            <asp:Panel ID="Panel1" runat="server" BackColor="peachpuff" BorderColor="brown" BorderStyle="Solid"
                                BorderWidth="1px" Height="373px" ScrollBars="Auto" Width="860px">
                                <cc1:PagingGridView ID="ForecastPagingGridView" runat="server" OnPageIndexChanging="ForecastPagingGridView_PageIndexChanging"
                                    OnRowDataBound="ForecastPagingGridView_RowDataBound" 
                                    OnSorting="ForecastPagingGridView_Sorting" AllowPaging="True" AllowSorting="True"
                                    VirtualItemCount="-1">
                                    <Columns>
                                        <asp:BoundField DataField="DescrArticulo" HeaderText="Artículo" SortExpression="DescrArticuloCombo">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" width="300px" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescrCliente" HeaderText="Cliente" SortExpression="DescrCliente">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" width="300px" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Proyectado" HeaderText="Proyectado" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ventas" HeaderText="Ventas" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Desvio" HeaderText="Desvio" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad1" HeaderText="Cantidad1" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad2" HeaderText="Cantidad2" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad3" HeaderText="Cantidad3" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad4" HeaderText="Cantidad4" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad5" HeaderText="Cantidad5" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad6" HeaderText="Cantidad6" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad7" HeaderText="Cantidad7" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad8" HeaderText="Cantidad8" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad9" HeaderText="Cantidad9" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad10" HeaderText="Cantidad10" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad11" HeaderText="Cantidad11" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad12" HeaderText="Cantidad12" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CantidadTotal" HeaderText="Total" SortExpression="">
                                            <headerstyle horizontalalign="Right" wrap="False" />
                                            <itemstyle horizontalalign="Right" wrap="False" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerSettings Mode="NumericFirstLast" />
                                </cc1:PagingGridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; padding-left:10px">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="vertical-align: top;">
                                        <asp:Button ID="ExportarButton" runat="server" Text="Exportar"
                                            Width="100px" OnClick="ExportarButton_Click" />
                                    </td>
                                    <td style="width: 660px;">
                                    </td>
                                    <td style="vertical-align: top;">
                                        <asp:Button ID="SalirButton" runat="server" OnClick="SalirButton_Click" Text="Salir"
                                            Width="100px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="">
                            <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label></td>
                    </tr>
                    <!-- @@@ @@@-->
                </table>
            </td>
            <td style="width: 30px" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>
