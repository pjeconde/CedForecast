<%@ Page AutoEventWireup="true" Codebehind="Explorador.aspx.cs" Inherits="CedForecastWeb.Admin.Cuenta.Explorador"
	Language="C#" MasterPageFile="~/Admin/Administracion.Master" StylesheetTheme="Cedeira" %>

<%@ Register Assembly="CedeiraUIWebForms" Namespace="CedeiraUIWebForms" TagPrefix="cc1" %>

<asp:content id="AdminCuentaContent" runat="Server" contentplaceholderid="AdministracionContentPlaceHolder">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="height: 500px;
        width: 890px; text-align: left; background-color:White;">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-top: 10px">
                    <!-- @@@ TITULO DE LA PAGINA @@@-->
                    <tr>
                        <td style="padding-left: 10px;" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 20px; vertical-align:top;">
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
                                    <td style="width: 800px; height: 20px;">
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Cuentas"></asp:Label>
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 10px;">
                                        <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Haga clic en la cuenta que desee seleccionar."></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                    <tr>
                        <td style="padding-left: 10px; padding-top: 10px" valign="top">
                            <asp:Panel ID="Panel1" runat="server" BackColor="peachpuff" BorderColor="brown" BorderStyle="Solid"
                                BorderWidth="1px" Height="373px" ScrollBars="Auto" Width="760px">
                                <cc1:PagingGridView ID="CuentaPagingGridView" runat="server" OnPageIndexChanging="CuentaPagingGridView_PageIndexChanging"
                                    OnRowDataBound="CuentaPagingGridView_RowDataBound" OnSelectedIndexChanged="CuentaPagingGridView_SelectedIndexChanged"
                                    OnSorting="CuentaPagingGridView_Sorting" AllowPaging="True" AllowSorting="True" VirtualItemCount="-1">
                                    <Columns>
                                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="IdCuenta">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" width="300px" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdTipoCuenta" HeaderText="Tipo" SortExpression="Cuenta.IdTipoCuenta">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdEstadoCuenta" HeaderText="Estado" SortExpression="Cuenta.IdEstadoCuenta">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaAlta" DataFormatString="{0:dd/MM/yyyy H:mm}" HeaderText="Fecha alta"
                                            HtmlEncode="False" SortExpression="FechaAlta">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CantidadEnviosMail" HeaderText="qEnv.mail" SortExpression="CantidadEnviosMail">
                                            <headerstyle horizontalalign="Center" wrap="False" />
                                            <itemstyle horizontalalign="Center" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaUltimoReenvioMail" DataFormatString="{0:dd/MM/yyyy H:mm}"
                                            HeaderText="Fecha ult.env.mail" HtmlEncode="False" SortExpression="FechaUltimoReenvioMail">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" wrap="False" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerSettings Mode="NumericFirstLast" />
                                </cc1:PagingGridView>
                            </asp:Panel>
                        </td>
                        <td align="left" style="padding-left: 10px; padding-top: 6px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center" class="TextoResaltado" style="padding-top: 5px">
                                        Acciones
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="ModificarButton" runat="server" OnClick="ModificarButton_Click"
                                            Text="Modificar" Width="100px" Enabled="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="BajaButton" runat="server" Enabled="false" OnClick="BajaButton_Click"
                                            Text="Dar de baja" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="AnularBajaButton" runat="server" Enabled="false" OnClick="AnularBajaButton_Click"
                                            Text="Anular la baja" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="ReenviarMailButton" runat="server" Enabled="false" OnClick="ReenviarMailButton_Click"
                                            Text="Reenviar mail" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" class="TextoResaltado" style="padding-top: 10px">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" class="TextoResaltado" style="padding-top: 10px">
                                        Proceso
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="DepurarButton" runat="server" OnClick="DepurarButton_Click" Text="Depurar"
                                            ToolTip="Depura las cuentas dadas de Baja." Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 20px">
                                        <asp:Button ID="SalirButton" runat="server" OnClick="SalirButton_Click" Text="Salir"
                                            Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 10px">
                                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- @@@ @@@-->
                </table>
            </td>
            <td style="width: 30px" valign="top">
            </td>
        </tr>
    </table>
</asp:content>
