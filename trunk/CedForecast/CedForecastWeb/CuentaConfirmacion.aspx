<%@ Page Language="C#" MasterPageFile="~/CedForecastWeb.Master" AutoEventWireup="true" CodeBehind="CuentaConfirmacion.aspx.cs" Inherits="CedForecastWeb.CuentaConfirmacion"  %>

<asp:Content ID="Content" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="height: 500px;
        width: 890px; text-align: left; background-color: white;">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-top: 10px">
                    <tr>
                        <td align="left" colspan="2" style="padding-left: 10px" valign="top">
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
                                            <asp:Image ID="Image3" runat="server" AlternateText="o" ImageUrl="~/Imagenes/button_link.gif" />
                                            </td>
                                        </tr>
                                        </table>   
                                    </td>
                                    <td style="width:864px;" colspan="3">
                                        <asp:Label ID="TituloLabel" SkinID="TituloPagina" runat="server" Text="Confirmación de creación de cuenta"></asp:Label>
                                        <hr />
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top: 10px; padding-left: 32px; padding-right: 32px">
                            <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 10px; padding-left: 32px">
                            <asp:Label ID="Label2" runat="server" Font-Bold="true" ForeColor="red" Text="»"></asp:Label>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Inicio.aspx" SkinID="LinkMedianoClaro">Ir a Inicio</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
