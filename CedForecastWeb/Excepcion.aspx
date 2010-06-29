<%@ Page Language="C#" MasterPageFile="~/CedForecastWeb.Master" AutoEventWireup="true" CodeBehind="Excepcion.aspx.cs" Inherits="CedForecastWeb.Excepcion"  StylesheetTheme="Cedeira" %>

<asp:Content ID="ExContent" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="height: 500px;
        width: 890px; text-align: left; background-color: White">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-top: 10px">
                    <tr>
                        <td style="padding-left: 10px" valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left" style="padding-left: 10px" valign="top">
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
                                                        <asp:Image ID="Image3" runat="server" AlternateText="o" ImageUrl="~/Imagenes/button_link.gif" />
                                                        </td>
                                                    </tr>
                                                    </table>   
                                                </td>
                                                <td style="width:864px;" colspan="3">
                                                    <asp:Label ID="Label1" SkinID="TituloPagina" runat="server" Text="Notificación de excepción "></asp:Label>
                                                    <hr />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top: 10px; padding-left: 32px">
                            <asp:Label ID="ExLabel" runat="server" SkinID="MensajePagina"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
