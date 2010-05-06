<%@ Page AutoEventWireup="true" Codebehind="Explorador.aspx.cs" Inherits="CedForecastWeb.Admin.ConfirmacionCarga.Explorador"
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
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Confirmación de Carga"></asp:Label>
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 10px;">
                                        <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Haga clic en la Confirmacion de Carga que desee seleccionar."></asp:Label>
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
                                <cc1:PagingGridView ID="ConfirmacionCargaPagingGridView" runat="server" AllowPaging="True" AllowSorting="True"
                                    OnPageIndexChanging="ConfirmacionCargaPagingGridView_PageIndexChanging" OnRowDataBound="ConfirmacionCargaPagingGridView_RowDataBound" OnSelectedIndexChanged="ConfirmacionCargaPagingGridView_SelectedIndexChanged" 
                                    OnSorting="ConfirmacionCargaPagingGridView_Sorting"
                                    VirtualItemCount="-1">
                                    <Columns>
                                        <asp:BoundField DataField="IdTipoPlanilla" HeaderText="Planilla" HtmlEncode="False" SortExpression="IdTipoPlanilla">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" width="100px" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdPeriodo" HeaderText="IdPeriodo" DataFormatString="{0:MM/yyyy}" HtmlEncode="False" SortExpression="IdPeriodo">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" width="100px" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdCuenta" HeaderText="Id.Cuenta" SortExpression="IdCuenta">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" wrap="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaConfirmacionCarga" DataFormatString="{0:dd/MM/yyyy H:mm}" HeaderText="Fecha" HtmlEncode="False" SortExpression="FechaConfirmacionCarga">
                                            <headerstyle horizontalalign="Left" wrap="False" />
                                            <itemstyle horizontalalign="Left" width="100px" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdEstadoConfirmacionCarga" HeaderText="Estado" SortExpression="IdEstadoConfirmacionCarga">
                                            <headerstyle horizontalalign="Center" wrap="False" />
                                            <itemstyle horizontalalign="Center" wrap="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Comentario" HeaderText="Comentario" SortExpression="Comentario">
                                            <headerstyle horizontalalign="Center" wrap="true" />
                                            <itemstyle horizontalalign="Center" wrap="true" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerSettings Mode="NumericFirstLast" />
                                </cc1:PagingGridView>
                            </asp:Panel>
                            <asp:Label ID="Label1" runat="server" Text="Comentario: "></asp:Label>
                            <asp:TextBox ID="ComentarioTextBox" runat="server" Width="755px"></asp:TextBox><br />
                        
                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label></td>
                        <td align="left" style="padding-left: 10px; padding-top: 6px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center" class="TextoResaltado" style="padding-top: 5px">
                                        Acciones
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="AceptarButton" runat="server" Enabled="false" OnClick="AceptarButton_Click"
                                            Text="Aceptar" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px; height: 29px;">
                                        <asp:Button ID="RechazarButton" runat="server" Enabled="false" OnClick="RechazarButton_Click"
                                            Text="Rechazar" Width="100px" /></td>
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
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        &nbsp;<br />
                                        <br />
                                        <br />
                                        <br />
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
                                        &nbsp;</td>
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
