<%@ Page Language="C#" MasterPageFile="~/CedForecastWeb.Master" AutoEventWireup="true" CodeBehind="CuentaConfiguracion.aspx.cs" Inherits="CedForecastWeb.CuentaConfiguracion"  %>

<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceHolderNoAutenticado">
    <table border="0" cellpadding="0" cellspacing="0" style="height: 500px; width: 890px; background-color: white;">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 100%; padding-top: 10px">
                     <tr>
                        <td style="width: 20px; vertical-align:top; padding-left: 10px; padding-right:10px;">
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
                        <td style="width:864px; text-align:left;">
                            <asp:Label ID="Label2" SkinID="TituloPagina" runat="server" Text="Configuración de la cuenta"></asp:Label>
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left" style="padding-left: 10px">
                            <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                            <table id="Table1" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right" style="padding-right: 5px; padding-top: 20px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="NombreTextBox"
                                            ErrorMessage="Nombre y Apellido" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label7" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NombreTextBox"
                                            ErrorMessage="Nombre y Apellido" SetFocusOnError="True">
                                            <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="NombreLabel" runat="server" Text="Nombre y Apellido"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 20px">
                                        <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" TabIndex="1" Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 3px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TelefonoTextBox"
                                            ErrorMessage="Teléfono" SetFocusOnError="True" ValidationExpression="[0-9\-]*">
                                            <asp:Label ID="Label9" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TelefonoTextBox"
                                            ErrorMessage="Teléfono" SetFocusOnError="True">
                                            <asp:Label ID="Label10" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="TelefonoLabel" runat="server" Text="Teléfono"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 3px">
                                        <asp:TextBox ID="TelefonoTextBox" runat="server" MaxLength="50" TabIndex="2" Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 3px; padding-right: 5px">
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
                                    <td align="left" colspan="2" style="padding-top: 3px">
                                        <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" ReadOnly="true" Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 3px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="EmailTextBox"
                                            ErrorMessage="Email para SMSs" SetFocusOnError="True" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                                            <asp:Label ID="Label1" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:Label ID="Label13" runat="server" Text="Email para SMSs"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 3px">
                                        <asp:TextBox ID="EmailSMSTextBox" runat="server" MaxLength="128" Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 3px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="PreguntaTextBox"
                                            ErrorMessage="Pregunta de seguridad" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label19" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="PreguntaTextBox"
                                            ErrorMessage="Pregunta de seguridad" SetFocusOnError="True">
                                            <asp:Label ID="Label20" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="PreguntaLabel" runat="server" Text="Pregunta de seguridad"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 3px">
                                        <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="¿"></asp:Label>
                                        <asp:TextBox ID="PreguntaTextBox" runat="server" MaxLength="256" TabIndex="7" Width="334px"></asp:TextBox>
                                        <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 3px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="RespuestaTextBox"
                                            ErrorMessage="Respuesta" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label21" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="RespuestaTextBox"
                                            ErrorMessage="Respuesta" SetFocusOnError="True">
                                            <asp:Label ID="Label22" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="RespuestaLabel" runat="server" Text="Respuesta"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 3px">
                                        <asp:TextBox ID="RespuestaTextBox" runat="server" MaxLength="256" TabIndex="8" Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 3px; padding-right: 5px; height: 25px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 3px; padding-right: 5px; height: 25px;">
                                        <asp:Label ID="DivisionLabel" runat="server" Text="División"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 3px; height: 25px;">
                                        <asp:DropDownList ID="DivisionDropDownList" runat="server" TabIndex="9" Width="360px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 3px; padding-right: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TipoCuentaDropDownList"
                                            ErrorMessage="Página de inicio" SetFocusOnError="True">
                                            <asp:Label ID="Label4" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label5" runat="server" Text="Tipo de cuenta"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 3px">
                                        <asp:DropDownList ID="TipoCuentaDropDownList" runat="server" TabIndex="4" Width="360px" OnSelectedIndexChanged="TipoCuentaDropDownList_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-top: 3px; padding-right: 5px">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="PaginaDefaultDropDownList"
                                            ErrorMessage="Página de inicio" SetFocusOnError="True">
                                            <asp:Label ID="Label26" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label25" runat="server" Text="Página de inicio"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top: 3px">
                                        <asp:DropDownList ID="PaginaDefaultDropDownList" runat="server" TabIndex="4" Width="360px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 10px">
                                        <asp:Button ID="GuardarButton" runat="server" OnClick="GuardarButton_Click" TabIndex="4"
                                            Text="Guardar" Width="100px" />
                                    </td>
                                    <td align="right" style="padding-top: 10px">
                                        <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/Configuracion.aspx"
                                            TabIndex="5" Text="Cancelar" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="center" colspan="2" style="padding-bottom: 30px">
                                        <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                        <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
