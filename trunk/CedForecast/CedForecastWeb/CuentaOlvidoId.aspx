<%@ Page Language="C#" MasterPageFile="~/CedForecastWeb.Master" AutoEventWireup="true" CodeBehind="CuentaOlvidoId.aspx.cs" Inherits="CedForecastWeb.CuentaOlvidoId" StylesheetTheme="Cedeira" %>

<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="height: 500px;
        width: 890px; text-align: left; background-color: white;">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-top: 10px">
                    <!-- @@@ TITULO DE LA PAGINA @@@-->
                    <tr>
                        <td style="padding-left: 10px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left" style="padding-left: 10px" valign="top">
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
                                                    <asp:Label ID="Label1" SkinID="TituloPagina" runat="server" Text="¿Olvidó el Id.Usuario de su cuenta? "></asp:Label>
                                                    <hr />
                                                </td>
                                            </tr>
                                        </table>
                                        <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 21px">
                                    </td>
                                    <td align="left" style="padding-top: 10px;">
                                        <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Si no recuerda el Id.Usuario de su cuenta eFact, ingrese el eMail, que registró en el momento de creación de su cuenta."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 21px">
                                    </td>
                                    <td align="left" style="padding-top: 5px;">
                                        <asp:Label ID="Label9" runat="server" SkinID="TextoMediano" Text="<b>Le enviaremos su Id.Cuenta por correo electrónico</b>, a esa dirección."></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                    <tr>
                        <td align="center" style="padding-top: 20px">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right" style="padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="EmailTextBox"
                                            ErrorMessage="Email" SetFocusOnError="True" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                                            <asp:Label ID="Label11" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="EmailTextBox"
                                            ErrorMessage="Email" SetFocusOnError="True">
                                            <asp:Label ID="Label12" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" TabIndex="3" Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 10px">
                                        <asp:Button ID="AceptarButton" runat="server" OnClick="AceptarButton_Click" TabIndex="4"
                                            Text="Solicitar Id.Usuario" />
                                    </td>
                                    <td align="right" style="padding-top: 10px">
                                        <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/Inicio.aspx"
                                            TabIndex="5" Text="Cancelar" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-top: 10px">
                            <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                            <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
                        </td>
                    </tr>
                    <!-- @@@ @@@-->
                </table>
            </td>
            <td style="width: 30px" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>
