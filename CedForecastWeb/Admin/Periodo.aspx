<%@ Page Language="C#" MasterPageFile="~/Admin/Administracion.Master" AutoEventWireup="true"
    Codebehind="Periodo.aspx.cs" Inherits="CedForecastWeb.Admin.Configuracion" Title="configuración" StylesheetTheme="Cedeira" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdministracionContentPlaceHolder" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 890px;
        height: 500px; text-align: left;">
        <tr>
            <td style="height: 10px; width: 890px;" valign="top">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; width: 890px;" valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="2" style="" valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width:870px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 20px; vertical-align:top;">
                                                    <table border="0" cellpadding="0" cellspacing="0" id="ImagenTable">
        						                        <tr>
                                                            <td style="height: 3px;">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align:left;">
                                                            <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/button_link.gif" />
                                                            </td>
                                                        </tr>
                                                    </table>   
                                                </td>
                                                <td style="vertical-align:top; width: 850px">
                                                    <asp:Label ID="TituloLabel" SkinID="TituloPagina" runat="server" Text="Período"></asp:Label>
                                                    <hr />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td> 
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="3" style="text-align: left" class="">
                                                            <asp:Label ID="RollingForecastTituloLabel" runat="server" Text="Rolling Forecast" SkinID="TituloMediano"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" style="height: 10px" valign="middle">
                                                        </td>
                                                        <td style="width: 10px;">
                                                        </td>
                                                        <td align="left" style="width: 300px" valign="top">
                                                            &nbsp;<asp:Label ID="Label2" runat="server" Text="Ingresar el período de carga."></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="right" style="height: 10px" valign="middle">
                                                            <asp:Label ID="lblPeriodo" runat="server" SkinID="TituloMediano" Text="Período:"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td align="left" style="width: 300px" valign="top">
                                                            <asp:TextBox ID="PeriodoTextBox" runat="server" Width="73px"></asp:TextBox>
                                                            <asp:Label ID="Label1" runat="server" SkinID="TituloMediano" Text="Formato (YYYYMM)"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" style="height: 10px" valign="middle">
                                                        </td>
                                                        <td style="width: 10px;">
                                                        </td>
                                                        <td align="left" style="width: 300px" valign="top">
                                                         </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" style="height: 10px" valign="middle">
                                                        </td>
                                                        <td style="width: 10px;">
                                                        </td>
                                                        <td align="left" style="width: 300px" valign="top">
                                                            &nbsp;<asp:Label ID="Label3" runat="server" Text="Ingresar la fecha de inhabilitación de la carga."></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="right" style="height: 10px" valign="middle">
                                                            <asp:Label ID="Label4" runat="server" SkinID="TituloMediano" Text="Fecha:"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td align="left" style="width: 300px" valign="top">
                                                            <asp:TextBox ID="FechaInhabilitacionCargaTextBox" runat="server" Width="73px"></asp:TextBox>
                                                            <asp:Label ID="Label5" runat="server" SkinID="TituloMediano" Text="formato (YYYYMMDD)"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" style="height: 10px" valign="middle">
                                                        </td>
                                                        <td style="width: 10px;">
                                                        </td>
                                                        <td align="left" style="width: 300px" valign="top">
                                                         </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 20px">
                                                        </td>
                                                        <td align="right" style="height: 20px" valign="middle">
                                                            &nbsp;</td>
                                                        <td style="height: 20px">
                                                        </td>
                                                        <td align="left" style="width: 300px height: 20px;" valign="top">
                                                            <asp:CheckBox ID="CargaHabilitadaCheckBox" runat="server" Width="300px" Text="Habilitar la carga de datos." ToolTip="Marcar para habilitar la carga de datos." />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" style="height: 10px" valign="middle">
                                                        </td>
                                                        <td style="width: 10px;">
                                                        </td>
                                                        <td align="left" style="width: 300px" valign="top">
                                                         </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width:100%;">
                                            </td>
                                            <td>
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="width: 1px">
                                                        </td>
                                                        <td colspan="3" style="text-align: left" class="">
                                                            <asp:Label ID="ProyectadoTituloLabel" runat="server" Text="Proyectado Anual" SkinID="TituloMediano"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1px">
                                                        </td>
                                                        <td align="left" style="height: 10px" valign="middle">
                                                        </td>
                                                        <td style="width: 10px;">
                                                        </td>
                                                        <td align="left" style="width: 300px" valign="top">
                                                            &nbsp;<asp:Label ID="Label7" runat="server" Text="Ingresar el período de carga."></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1px">
                                                        </td>
                                                        <td align="right" style="height: 10px" valign="middle">
                                                            <asp:Label ID="Label8" runat="server" SkinID="TituloMediano" Text="Período:"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td align="left" style="width: 300px" valign="top">
                                                            <asp:TextBox ID="PeriodoProyectadoTextBox" runat="server" Width="73px"></asp:TextBox>
                                                            <asp:Label ID="Label9" runat="server" SkinID="TituloMediano" Text="Formato (YYYY)"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1px">
                                                        </td>
                                                        <td align="left" style="height: 10px" valign="middle">
                                                        </td>
                                                        <td style="width: 10px;">
                                                        </td>
                                                        <td align="left" style="width: 300px" valign="top">
                                                         </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1px">
                                                        </td>
                                                        <td align="left" style="height: 10px" valign="middle">
                                                        </td>
                                                        <td style="width: 10px;">
                                                        </td>
                                                        <td align="left" style="width: 300px" valign="top">
                                                            &nbsp;<asp:Label ID="Label10" runat="server" Text="Ingresar la fecha de inhabilitación de la carga."></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1px">
                                                        </td>
                                                        <td align="right" style="height: 10px" valign="middle">
                                                            <asp:Label ID="Label11" runat="server" SkinID="TituloMediano" Text="Fecha:"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td align="left" style="width: 300px" valign="top">
                                                            <asp:TextBox ID="FechaInhabilitacionCargaProyectadoTextBox" runat="server" Width="73px"></asp:TextBox>
                                                            <asp:Label ID="Label12" runat="server" SkinID="TituloMediano" Text="formato (YYYYMMDD)"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1px">
                                                        </td>
                                                        <td align="left" style="height: 10px" valign="middle">
                                                        </td>
                                                        <td style="width: 10px;">
                                                        </td>
                                                        <td align="left" style="width: 300px" valign="top">
                                                         </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1px">
                                                        </td>
                                                        <td align="right" style="height: 10px" valign="middle">
                                                            &nbsp;</td>
                                                        <td>
                                                        </td>
                                                        <td align="left" style="width: 300px" valign="top">
                                                            <asp:CheckBox ID="CargaHabilitadaProyectadoCheckBox" runat="server" Width="300px" Text="Habilitar la carga de datos." ToolTip="Marcar para habilitar la carga de datos." />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1px">
                                                        </td>
                                                        <td align="left" style="height: 10px" valign="middle">
                                                        </td>
                                                        <td style="width: 10px;">
                                                        </td>
                                                        <td align="left" style="width: 300px" valign="top">
                                                         </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Button ID="AceptarButton" runat="server" OnClick="AceptarButton_Click" Text="Aceptar"
                                            Width="188px" />

                                    </td>
                                    <td style="width: 100%">
                                    </td>
                                    <td>
                                        <asp:Button ID="CancelarButton" runat="server" OnClick="CancelarButton_Click" Text="Cancelar"
                                            Width="188px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;">
                                    </td>
                                </tr>   
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
