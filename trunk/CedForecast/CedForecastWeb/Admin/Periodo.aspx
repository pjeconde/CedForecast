<%@ Page Language="C#" MasterPageFile="~/Admin/Administracion.Master" AutoEventWireup="true"
    Codebehind="Periodo.aspx.cs" Inherits="CedForecastWeb.Admin.Configuracion" Title="configuración" StylesheetTheme="Cedeira" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdministracionContentPlaceHolder" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 977px;
        height: 500px; text-align: left;">
        <tr>
            <td style="height: 10px;" valign="top">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px;" valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="" valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
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
                                    <td style="" colspan="3">
                                        <asp:Label ID="TituloLabel" SkinID="TituloPagina" runat="server" Text="Configuración" Width="30px"></asp:Label>
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="height: 10px" valign="middle">
                                    </td>
                                    <td style="width: 10px;">
                                    </td>
                                    <td align="left" style="width: 392px;" valign="top">
                                        &nbsp;<asp:Label ID="Label2" runat="server" Text="Ingresar el período de carga actual."></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="right" style="height: 10px" valign="middle">
                                        <asp:Label ID="lblPeriodo" runat="server" SkinID="TituloMediano" Text="Período:"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td align="left" style="width: 392px;" valign="top">
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
                                    <td align="left" style="width: 392px;" valign="top">
                                     </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="height: 10px" valign="middle">
                                    </td>
                                    <td style="width: 10px;">
                                    </td>
                                    <td align="left" style="width: 392px;" valign="top">
                                        &nbsp;<asp:Label ID="Label3" runat="server" Text="Ingresar la fecha de vencimiento para el ingreso de datos del período actual."></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="right" style="height: 10px" valign="middle">
                                        <asp:Label ID="Label4" runat="server" SkinID="TituloMediano" Text="Fecha Vto.:"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td align="left" style="width: 392px;" valign="top">
                                        <asp:TextBox ID="FechaVtoConfirmacionCargaTextBox" runat="server" Width="73px"></asp:TextBox>
                                        <asp:Label ID="Label5" runat="server" SkinID="TituloMediano" Text="formato (YYYYMMDD)"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="height: 10px" valign="middle">
                                    </td>
                                    <td style="width: 10px;">
                                    </td>
                                    <td align="left" style="width: 392px;" valign="top">
                                     </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="right" style="height: 10px" valign="middle">
                                        &nbsp;</td>
                                    <td>
                                    </td>
                                    <td align="left" style="width: 392px;" valign="top">
                                        &nbsp;<asp:CheckBox ID="HabilitarCargaCheckBox" runat="server" Width="380px" Text="Habilitar la carga de datos." ToolTip="Marcar para habilitar la carga de datos." /></td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="height: 10px" valign="middle">
                                    </td>
                                    <td style="width: 10px;">
                                    </td>
                                    <td align="left" style="width: 392px;" valign="top">
                                     </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td colspan="3">
                                        <table>
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
            </td>
        </tr>
    </table>
</asp:Content>
