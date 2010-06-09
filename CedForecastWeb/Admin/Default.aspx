<%@ Page Language="C#"  MasterPageFile="~/Admin/Administracion.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CedForecastWeb.Admin.Default" StylesheetTheme="Cedeira" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="CedeiraUIWebForms" Namespace="CedeiraUIWebForms" TagPrefix="cc1" %>

<asp:content id="AdministracionContent" runat="Server" contentplaceholderid="AdministracionContentPlaceHolder">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 890px; height: 500px; text-align: left; background-color:White;">
        <tr>
            <td style="height: 10px;" valign="top">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; width: 100%" valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
								<tr>
                                    <td colspan="2" style="HEIGHT: 50px">
                                        <table border="0" cellpadding="0" cellspacing="0" id="TablaEnca">
                                            <tr>
                                                <td style="width: 20px; vertical-align:top;">
        						                    <table border="0" cellpadding="0" cellspacing="0" id="TableEnca1">
        						                        <tr>
                                                            <td style="height: 3px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Image ID="Image1" runat="server" AlternateText="o" ImageUrl="~/Imagenes/button_link.gif" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0" id="TablaEnca2">
                                                        <tr>
                                                            <td style="width: 800px; vertical-align:top;">
                                                                <asp:Label ID="TituloLabel" SkinID="TituloPagina" runat="server" Text="Administración"></asp:Label>
                                                                <hr />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>   
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 26px">
                                    </td>
                                    <td align="left" style="padding-top: 10px; height: 26px;" valign="middle">
                                        Explorador de:
                                        <asp:HyperLink ID="PeriodoHiperLink" runat="server" NavigateUrl="~/Admin/Periodo.aspx"
                                            SkinID="LinkMedianoClaro">Periodo</asp:HyperLink>
                                        <asp:Label ID="PeriodoLabel" runat="server" SkinID="TextoMediano" Text=", " Width="3px"></asp:Label>
                                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/Cuenta/Explorador.aspx"
                                            SkinID="LinkMedianoClaro">Cuentas</asp:HyperLink>
                                        <asp:Label ID="CuentasLabel" runat="server" SkinID="TextoMediano" Text="( ), "></asp:Label>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/ConfirmacionCarga/Explorador.aspx"
                                            SkinID="LinkMedianoClaro">Confirmación de Carga</asp:HyperLink>
                                        </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 5px; padding-right: 3px" valign="top">
                                        <asp:CheckBox ID="ModoDepuracionCheckBox" runat="server" AutoPostBack="true" Enabled="false"
                                            OnCheckedChanged="ModoDepuracionCheckBox_CheckedChanged" Visible="False" />&nbsp;</td>
                                    <td align="left" style="padding-top: 5px;" valign="middle">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 3px; height: 20px;" valign="top">
                                        <asp:CheckBox ID="RecibeAvisoConfirmacionCargaViaMailCheckBox" runat="server" AutoPostBack="true"
                                            OnCheckedChanged="RecibeAvisoConfirmacionCargaViaMailCheckBox_CheckedChanged" />&nbsp;</td>
                                    <td align="left" valign="middle" style="height: 20px">
                                        Recibe aviso de confirmación de carga por vendedor (vía Email)</td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 3px; height: 20px;" valign="top">
                                        <asp:CheckBox ID="RecibeAvisoConfirmacionCargaViaSMSCheckBox" runat="server" AutoPostBack="true"
                                            OnCheckedChanged="RecibeAvisoConfirmacionCargaViaSMSCheckBox_CheckedChanged" />&nbsp;</td>
                                    <td align="left" valign="middle" style="height: 20px">
                                        Recibe aviso de confirmacion de carga por vendedor (vía SMS)</td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 3px" valign="top">
                                        &nbsp;</td>
                                    <td align="left" valign="middle" style="">
                                        (en la Configuración de su Cuenta Forecast podrá ingresar el 'Email
                                        para SMSs')
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 24px" align="right">
                                        Visitantes &nbsp;
                                    </td>
                                    <td align="left" style="padding-top: 5px; height: 24px;">
                                        <asp:Label ID="VisitantesLabel" runat="server" Width="151px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right" style="height: 19px">
                                        Visitantes registrados &nbsp;
                                    </td>
                                    <td align="left" style="padding-top: 5px; height: 19px;">
                                        <asp:Label ID="RegistradosLabel" runat="server" Width="146px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="color: #A52A2A; font-weight: bold; padding-top: 10px; width: 700px" valign="top">
                                        Ultimas altas de Cuentas
                                        <br />
                                        <asp:Panel ID="Panel1" runat="server" BackColor="peachpuff" BorderColor="brown" BorderStyle="Solid"
                                            BorderWidth="1px" Font-Bold="false" ForeColor="black" Height="159px" ScrollBars="Auto"
                                            Width="700px">
                                            <cc1:PagingGridView ID="UltimasAltasPagingGridView" runat="server" OnPageIndexChanging="UltimasAltasPagingGridView_PageIndexChanging"
                                                OnSorting="UltimasAltasPagingGridView_Sorting">
                                                <Columns>
                                                    <asp:BoundField DataField="FechaAlta" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Fecha y hora"
                                                        HtmlEncode="false" SortExpression="FechaAlta">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="IdCuenta">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" width="300px" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IdTipoCuenta" HeaderText="Tipo" SortExpression="Cuenta.IdTipoCuenta">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IdEstadoCuenta" HeaderText="Estado" SortExpression="Cuenta.IdEstadoCuenta">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                                                        <headerstyle horizontalalign="left" wrap="False" />
                                                        <itemstyle horizontalalign="left" wrap="False" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </cc1:PagingGridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 10px">
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://www.cualesmiip.com/"
                                            SkinID="LinkMedianoClaro" Target="_blank">¿ Cuál es mi IP ?</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="center" colspan="3" style="padding-top: 10px">
                                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>         
            </td>
        </tr>
    </table>
</asp:content>
