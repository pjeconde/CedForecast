<%@ Page Language="C#" MasterPageFile="~/Forecast/Forecast.Master" AutoEventWireup="true" CodeBehind="ConfirmacionCarga.aspx.cs" Inherits="CedForecastWeb.Forecast.ConfirmacionCarga" StylesheetTheme="Cedeira"  UICulture="es-AR"%>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="CedeiraUIWebForms" Namespace="CedeiraUIWebForms" TagPrefix="cc1" %>

<asp:content id="ForecastContent" runat="Server" contentplaceholderid="ForecastContentPlaceHolder">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 890px; text-align: left; background-color: white">
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
                            <table border="0" cellpadding="0" cellspacing="0" id="TablaTit" onclick="">
        						<tr>
                                    <td style="width: 20px; vertical-align:top;">
                                        <table border="0" cellpadding="0" cellspacing="0" id="Table3">
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
                                    <td style="width: 846px">
                                        <asp:Label ID="TituloLabel" SkinID="TituloPagina" runat="server" Text="Rolling Forecast"></asp:Label>
                                        <asp:Label ID="MsgLabel" runat="server" Width="600px"></asp:Label>
                                        <hr />
                                    </td>
                               </tr>
                           </table>
                           <table border="0" cellpadding="0" cellspacing="0" id="TablaDet">    
                                <tr>
                                    <td colspan="4" style="">
                                        <asp:Panel ID="CabeceraFijaPanel" runat="server" Enabled="false">
                                            <table border="0" cellpadding="0" cellspacing="0" id="CabeceraFijaTable">
                                                <tr>
                                                    <td align="right" style="height: 10px; width: 150px;" valign="middle">
                                                        <asp:Label ID="FechaLabel" runat="server" SkinID="TituloMediano" Text="Período:"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 712px" valign="top">
                                                        <asp:TextBox ID="PeriodoTextBox" runat="server" Width="75px" Enabled="False"></asp:TextBox>&nbsp;&nbsp;
                                                        <asp:Label ID="FechaVtoConfimacionCargaLabel" runat="server" SkinID="TituloMediano" Font-Bold="False"  ></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height:10px; width: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="height: 10px; width: 150px;" valign="middle">
                                                        <asp:Label ID="Label2" runat="server" SkinID="TituloMediano" Text="Fecha:"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 712px" valign="top">
                                                        <asp:TextBox ID="FechaConfirmacionCargaTextBox" runat="server" Width="150px" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height:10px; width: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="height: 10px; width: 150px;" valign="middle">
                                                        <asp:Label ID="Label4" runat="server" SkinID="TituloMediano" Text="Estado:"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 712px" valign="top">
                                                        <asp:TextBox ID="IdEstadoConfirmacionCargaTextBox" runat="server" Width="150px" Enabled="False"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height:10px; width: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="height: 10px; width: 150px;" valign="middle">
                                                        <asp:Label ID="ComentarioLabel" runat="server" SkinID="TituloMediano" Text="Comentario:"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 722px" valign="top">
                                                        <asp:TextBox ID="ComentarioTextBox" runat="server" Width="706px" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height:10px; width: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="width: 10px;">
                                                        <asp:Label ID="Label1" runat="server" Text="La confirmación, le avisa al administrador la finalización de la carga de datos, correspondiente al período en vigencia. De ser necesario, se podrá anular la confirmación, siempre y cuando el administrador no haya cerrado la carga para ese período." Width="862px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                         </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 10px;">
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" id="TABLE2" onclick="">
                                <tr>
                                    <td>
                                        <asp:Button ID="ConfirmarButton" runat="server" OnClick="ConfirmarButton_Click" Text="Confirmar"
                                            Width="188px" />

                                    </td>
                                    <td style="width: 490px">
                                    </td>
                                    <td>
                                        <asp:Button ID="AnularConfirmacionButton" runat="server" OnClick="AnularConfirmacionButton_Click" Text="Anular Confirmación"
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
</asp:content>