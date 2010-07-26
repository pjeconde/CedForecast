<%@ Page Language="C#" MasterPageFile="~/Admin/Administracion.Master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="CedForecastWeb.Admin.Forecast.Consulta" StylesheetTheme="Cedeira" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    
<%@ Register Assembly="CedeiraUIWebForms" Namespace="CedeiraUIWebForms" TagPrefix="cc1" %>

<asp:content id="ForecastContent" runat="Server" contentplaceholderid="AdministracionContentPlaceHolder">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 890px;
        height: 500px; text-align: left; background-color: white;">
        <tr>
            <td style="height: 10px;" valign="top">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right:10px;" valign="top">
                <!-- @@@ TITULO DE LA PAGINA @@@-->
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left" style="" valign="top">
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
                                            <asp:Image ID="Image1" runat="server" AlternateText="o" ImageUrl="~/Imagenes/button_link.gif" />
                                            </td>
                                        </tr>
                                        </table>   
                                    </td>
                                    <td style="width:864px;" colspan="3">
                                        <asp:Label ID="TituloLabel" SkinID="TituloPagina" runat="server" Text="Consulta "></asp:Label>
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td style="padding-top: 10px">
                                        <asp:Label ID="Label13" runat="server" SkinID="TextoMediano" Text="Tiene disponible las siguientes opciones de consulta:"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top: 10px; padding-left: 20px" valign="middle">
                            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/Forecast/ExploradorForecastProyectado.aspx"
                                SkinID="LinkGrandeClaro">Proyectado Anual</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="padding-top: 10px; padding-left: 20px">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/Forecast/ExploradorForecast.aspx"
                                SkinID="LinkGrandeClaro">Rolling Forecast</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:content>
