<%@ Page Language="C#" MasterPageFile="~/CedForecastWeb.Master" AutoEventWireup="true" CodeBehind="SoloDispPUsuariosAdministradores.aspx.cs" Inherits="CedForecastWeb.SoloDispPUsuariosAdministradores" StylesheetTheme="Cedeira"  %>

<asp:Content ID="ExContent" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="height: 500px;
        width: 890px; text-align: left; background-color: White;">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-top: 10px">
                    <tr>
                        <td style="padding-left: 10px" valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 21px; height: 20px;">
                                        <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/button_link.gif" />
                                    </td>
                                    <td style="height: 20px;">
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top: 10px; padding-left: 32px; padding-right: 32px">
                            <asp:Label ID="Label1" runat="server" SkinID="MensajePaginaSinWidth" Text="Esta opción esta disponible sólo para USUARIOS ADMINISTRADORES."></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
