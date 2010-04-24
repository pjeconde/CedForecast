<%@ Page Language="C#" MasterPageFile="~/CedForecastWeb.Master" AutoEventWireup="true" CodeBehind="CuentaConfirmacion.aspx.cs" Inherits="CedeiraAJAX.CuentaConfirmacion"  %>

<asp:Content ID="Content" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="height: 500px;
        width: 800px; text-align: left;">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-top: 10px">
                    <tr>
                        <td style="padding-left: 10px" valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="Label5" runat="server" SkinID="TituloPagina" Text="Confirmación de creación de cuenta"></asp:Label>
                                    </td>
                                    <td style="height: 20px; padding-left: 3px" valign="middle">
                                        <asp:Image ID="Image1" runat="server" AlternateText="Factura Electrónica" ImageUrl="~/Imagenes/eFact.jpg" />
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
